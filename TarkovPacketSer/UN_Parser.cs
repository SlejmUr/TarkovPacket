using Newtonsoft.Json;
using TarkovPacketSer.PacketFormat;
using TarkovPacketSer.RPC_CMD;

namespace TarkovPacketSer
{
    internal class UN_Parser
    {
        static List<MsgTypeEnum> BEEncrpyted_Msgs = new()
        {
            MsgTypeEnum.WorldSpawn,
            MsgTypeEnum.SubWorldSpawnLoot,
            MsgTypeEnum.SubWorldSpawnSearchLoot,
            MsgTypeEnum.messageFromServer,
            MsgTypeEnum.SpawnObservedPlayer,
            MsgTypeEnum.SpawnObservedPlayers,
            MsgTypeEnum.ChangeFramerate,
            MsgTypeEnum.SnapshotBTRVehicles,
            MsgTypeEnum.SnapshotObservedPlayers,
            MsgTypeEnum.CommandsObservedPlayers,
        };
        public static void Parse(string[] files)
        {
            List<BaseJson> baseJsons = new List<BaseJson>();
            foreach (var file in files)
            {
                Console.WriteLine();
                FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Name.Contains("NULL"))
                    continue;
                // also we dont care about stacktrace's
                if (fileInfo.Name.Contains("stacktrace"))
                    continue;
                var name = fileInfo.Name.Split("_");
                var isReply = fileInfo.Name.Contains("SendWriter");
                string realname = string.Empty;
                if (isReply)
                {
                    realname = name[name.Count() - 1];
                }
                else
                    realname = name[name.Count() - 2];
                bool fromHandler = false;
                short readerId = 0;
                if (fileInfo.Name.Contains("HandleReader"))
                {
                    var packetId = fileInfo.Name.Split("HandleReader_0_")[1].Split("_")[0];
                    Console.WriteLine(packetId);
                    var shPid = short.Parse(packetId);
                    readerId = shPid;
                    fromHandler = true;
                }
                Console.WriteLine(fileInfo.Name);
                var bytes = File.ReadAllBytes(file);
                if (bytes.Length < 4)
                    continue;
                var msg = PacketIdentifier.GetMsgType(bytes, out short sh);
                if (readerId != 0)
                {
                    msg = (MsgTypeEnum)readerId;
                    sh = readerId;
                }
                if (msg != MsgTypeEnum.ProgressReport)
                {
                    Console.WriteLine(realname);
                    Console.WriteLine(msg.ToString() + $" ({sh})");
                }
                if (BEEncrpyted_Msgs.Contains(msg))
                {
                    Console.WriteLine(msg.ToString() + $" ({sh}) Is using BE encrypted Packet. Currently Skipping!");
                    continue;

                }



                switch (msg)
                {
                    case MsgTypeEnum.RPC:
                    case MsgTypeEnum.Command:
                        {
                            baseJsons.Add(new BaseJson()
                            {
                                Json = ParsedRCP_CMD.Parse(bytes, fromHandler),
                                Time = realname,
                                MsgType = msg
                            });
                        }
                        break;
                    case MsgTypeEnum.ConnectionRequest:
                        if (isReply)
                        {
                            baseJsons.Add(new BaseJson()
                            {
                                Json = ConnectionRequestPacker.ParseReplyPacket(bytes, fromHandler),
                                Time = realname,
                                MsgType = msg
                            });
                        }
                        else
                        {
                            baseJsons.Add(new BaseJson()
                            {
                                Json = ConnectionRequestPacker.ParseRequestPacket(bytes, fromHandler),
                                Time = realname,
                                MsgType = msg
                            });
                        }
                        break;
                    case MsgTypeEnum.RejectResponse:
                        break;
                    case MsgTypeEnum.BEPacket:
                        /*
                        baseJsons.Add(new BaseJson()
                        { 
                            Json = BEPacket.ParsePacket(bytes, fromHandler),
                            Time = realname,
                            MsgType = msg
                        });*/
                        break;
                    case MsgTypeEnum.PartialCommand:
                        baseJsons.Add(new BaseJson()
                        {
                            Json = PartialCommand.Deserialize(bytes, fromHandler),
                            Time = realname,
                            MsgType = msg
                        });
                        break;
                    case MsgTypeEnum.NightMare:
                        baseJsons.Add(new BaseJson()
                        {
                            Json = NightMare.Deserialize(bytes, fromHandler),
                            Time = realname,
                            MsgType = msg
                        });
                        break;
                    case MsgTypeEnum.SyncToPlayers:
                        baseJsons.Add(new BaseJson()
                        {
                            Json = SyncToPlayers.Deserialize(bytes, fromHandler),
                            Time = realname,
                            MsgType = msg
                        });
                        break;
                    case MsgTypeEnum.ObserverUnspawn:
                        baseJsons.Add(new BaseJson()
                        {
                            Json = ObserverUnspawn.Deserialize(bytes),
                            Time = realname,
                            MsgType = msg
                        });
                        break;
                    default:
                        break;
                }
            }
            File.WriteAllText("UN_parsed.json", JsonConvert.SerializeObject(baseJsons, formatting: Formatting.Indented));
            PartialCommand.DataWorker();
        }
    }
}
