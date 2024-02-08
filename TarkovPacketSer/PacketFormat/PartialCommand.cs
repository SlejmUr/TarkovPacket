using System.IO;
using TarkovPacketSer.BSG_Enums;
using static TarkovPacketSer.PacketFormat.PartialCommand;

namespace TarkovPacketSer.PacketFormat
{
    internal class PartialCommand
    {
        public static PartialCommandReturn Deserialize(byte[] data, bool FromHandler)
        {
            if (!FromHandler)
                data = data.Skip(4).ToArray();
            PartialCommandReturn replyPacket = new PartialCommandReturn();
            BinaryReader binaryReader = new(new MemoryStream(data));
            replyPacket.eIncomeMessageType = (EIncomeMessageType)binaryReader.ReadByte();
            Console.WriteLine("PartialCommand: " + replyPacket.eIncomeMessageType);
            if (replyPacket.eIncomeMessageType == EIncomeMessageType.Data)
            {
                PartialCommandData partialCommandData = new();
                partialCommandData.CommandKey = binaryReader.ReadInt16();
                partialCommandData.Id = binaryReader.ReadInt32();
                partialCommandData.PartNum = binaryReader.ReadByte();
                partialCommandData.Offset = binaryReader.ReadInt32();
                partialCommandData.PartsCount = binaryReader.ReadByte();
                partialCommandData.PartSize = binaryReader.ReadUInt16();
                partialCommandData.Size = binaryReader.ReadInt32();
                partialCommandData.BufferLink = binaryReader.ReadBytes(partialCommandData.PartSize);
                /*
                if (partialCommandData.CommandKey == 155 && partialCommandData.Offset == 0)
                {
                    partialCommandData.FromCommandParsed = PlayerSpawn.Deserialize(partialCommandData.BufferLink);
                }*/
                Program.partialCommandDatas.Add(partialCommandData);
                replyPacket.Data = partialCommandData;
            }
            else
            {
                replyPacket.Data = binaryReader.ReadInt32();
            }
            binaryReader.Close();
            binaryReader.Dispose();
            return replyPacket;
        }

        

        public static void DataWorker()
        {
            var datas = Program.partialCommandDatas;

            Dictionary<int, (MemoryStream, int)> CommandBytes = new();
            Dictionary<int, int> PartCounts = new();
            foreach (var data in datas)
            {
                Console.WriteLine("Dataworker: " + data.Id + " " + data.CommandKey);

                if (CommandBytes.ContainsKey(data.Id) && PartCounts.ContainsKey(data.Id))
                {
                    Console.WriteLine(" CommandBytes  Dataworker: " + data.Id + " " + data.CommandKey);
                    var bytes = CommandBytes[data.Id];
                    var remainingparts = PartCounts[data.Id];
                    bytes.Item1.Position = data.Offset;
                    bytes.Item1.Write(data.BufferLink);
                    Console.WriteLine(bytes.Item1.Capacity + " " + bytes.Item1.Length);
                    remainingparts--;
                    PartCounts[data.Id] = remainingparts;
                    CommandBytes[data.Id] = bytes;
                }
                else
                {
                    Console.WriteLine("else Dataworker: " + data.Id + " " + data.CommandKey);
                    MemoryStream memoryStream = new(data.Size);
                    Console.WriteLine(memoryStream.Capacity + " " + memoryStream.Length);
                    memoryStream.Position = data.Offset;
                    memoryStream.Write(data.BufferLink);
                    CommandBytes.Add(data.Id, (memoryStream, data.CommandKey));
                    PartCounts.Add(data.Id, data.PartsCount);
                }
            }
            foreach (var item in CommandBytes)
            {
                var byts = item.Value.Item1.ToArray();
                File.WriteAllBytes("PartialCommand_" + item.Key  + "_" + item.Value.Item2+ ".bytes", byts);

                if (item.Value.Item2 == 155)
                {
                    PlayerSpawn.Deserialize(byts);
                }
            }   
        }


        public class PartialCommandReturn
        {
            public EIncomeMessageType eIncomeMessageType;
            public object Data;
        }
        public class PartialCommandData
        {
            public short CommandKey;
            public int Id;
            public byte PartNum;
            public int Offset;
            public byte PartsCount;
            public int Size;
            public ushort PartSize;
            public byte[] BufferLink;
            public object FromCommandParsed;
        }
    }
}
