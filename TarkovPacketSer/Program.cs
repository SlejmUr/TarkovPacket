using Newtonsoft.Json;
using TarkovPacketSer.PacketFormat;
using static TarkovPacketSer.PacketFormat.PartialCommand;

namespace TarkovPacketSer
{
    internal class Program
    {
        public static List<PartialCommandData> partialCommandDatas = new List<PartialCommandData>();
        static List<MsgTypeEnum> BEEncrpyted_Msgs = new()
        {
            MsgTypeEnum.WorldSpwan,
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
        static void Main(string[] args)
        {
            List<BaseJson> baseJsons = new List<BaseJson>();
            string[] files = new string[0];
            Console.WriteLine("Hello, World!");
            Console.WriteLine(args.Length);
            Console.WriteLine(args[args.Length - 1]);
            if (args.Length == 0)
            {
                files = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\UN");
            }
            else
            {
                files = Directory.GetFiles(args[0]);
            }

            
            foreach (var file in files)
            {
                Console.WriteLine();
                FileInfo fileInfo = new FileInfo(file);
                if (fileInfo.Name.Contains("NULL"))
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
                    if (shPid < 100)
                        continue;
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
                    case MsgTypeEnum.Unknown:
                        break;
                    case MsgTypeEnum.ClientReadyToBegin:
                        break;
                    case MsgTypeEnum.ClientAddPlayerFailedMessage:
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
                    case MsgTypeEnum.WorldSpwan:
                        break;
                    case MsgTypeEnum.WorldUnspawn:
                        break;
                    case MsgTypeEnum.SubWorldSpawnLoot:
                        break;
                    case MsgTypeEnum.SubWorldSpawnSearchLoot:
                        break;
                    case MsgTypeEnum.SubWorldUnspawn:
                        break;
                    case MsgTypeEnum.PlayerUnspawn:
                        break;
                    case MsgTypeEnum.ObserverUnspawn:
                        baseJsons.Add(new BaseJson()
                        {
                            Json = ObserverUnspawn.Deserialize(bytes),
                            Time = realname,
                            MsgType = msg
                        });
                        break;
                    case MsgTypeEnum.DeathInventorySync:
                        break;
                    case MsgTypeEnum.PlayerSpawn:
                        break;
                    case MsgTypeEnum.ObserverSpawn:
                        break;
                    case MsgTypeEnum.messageFromServer:
                        break;
                    case MsgTypeEnum.SpawnObservedPlayer:
                        break;
                    case MsgTypeEnum.SpawnObservedPlayers:
                        break;
                    case MsgTypeEnum.ChangeFramerate:
                        break;
                    case MsgTypeEnum.SnapshotObservedPlayers:
                        break;
                    case MsgTypeEnum.CommandsObservedPlayers:
                        break;
                    case MsgTypeEnum.SnapshotBTRVehicles:
                        break;
                    case MsgTypeEnum.HLAPI:
                        break;
                    case MsgTypeEnum.ProgressReport:
                        //Console.WriteLine("Dropped");
                        break;
                    default:
                        break;
                }
            }
            File.WriteAllText("parsed.json",JsonConvert.SerializeObject(baseJsons, formatting: Formatting.Indented));
            PartialCommand.DataWorker();
        }
    }
}
