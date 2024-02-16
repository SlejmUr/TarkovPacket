using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TarkovPacketSer.BE_PacketFormat;
using TarkovPacketSer.PacketFormat;

namespace TarkovPacketSer
{
    internal class BE_Parser
    {
        public static void Parse(string[] files)
        {
            List<BaseJson> baseJsons = new List<BaseJson>();

            foreach (var file in files)
            {
                
                FileInfo fileInfo = new FileInfo(file);

                //  currently we dont care about encrypting packets
                if (fileInfo.Name.Contains("EN"))
                    continue;

                // also we dont care about stacktrace's
                if (fileInfo.Name.Contains("stacktrace"))
                    continue;

                var splittedname = fileInfo.Name.Split("_");
                var realname = splittedname[splittedname.Count() - 2];

                var bytes = File.ReadAllBytes(file);
                if (bytes.Length < 4)
                    continue;
                var msg = PacketIdentifier.GetMsgType(bytes, out short sh);
                if (msg != MsgTypeEnum.Unknown)
                {
                    Console.WriteLine();
                    Console.WriteLine(realname);
                    Console.WriteLine(msg.ToString() + $" ({sh})");
                }


                switch (msg)
                {
                    case MsgTypeEnum.SubWorldSpawnSearchLoot:/*
                        baseJsons.Add(new BaseJson()
                        {
                            Json = SubWorldSpawnSearchLoot.Deserialize(bytes),
                            Time = realname,
                            MsgType = msg
                        });*/
                        break;
                    case MsgTypeEnum.SubWorldSpawnLoot:
                        /*
                        baseJsons.Add(new BaseJson()
                        {
                            Json = SubWorldSpawnLoot.Deserialize(bytes),
                            Time = realname,
                            MsgType = msg
                        });*/
                        break;
                    case MsgTypeEnum.WorldSpawn:
                        baseJsons.Add(new BaseJson()
                        {
                            Json = WorldSpawn.Deserialize(bytes),
                            Time = realname,
                            MsgType = msg
                        });
                        break;
                    default:
                        break;
                }

            }
            File.WriteAllText("BE_parsed.json", JsonConvert.SerializeObject(baseJsons, formatting: Formatting.Indented));
            //PartialCommand.DataWorker();
        }
    }
}
