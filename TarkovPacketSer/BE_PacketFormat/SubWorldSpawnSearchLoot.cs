using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.BE_PacketFormat
{
    internal class SubWorldSpawnSearchLoot
    {
        public static SubWorldSpawnSearchLoot Deserialize(byte[] data)
        {
            data = data.Skip(4).ToArray();
            SubWorldSpawnSearchLoot replyPacket = new();
            BinaryReader binaryReader = new(new MemoryStream(data));
            replyPacket.flag = binaryReader.ReadBoolean();
            replyPacket.searchableItemInfos_serialized = binaryReader.ReadBytesAndSize();
            if (replyPacket.flag)
            {
            }
            binaryReader.Close();
            binaryReader.Dispose();
            return replyPacket;
        }

        public bool flag;
        public byte[] searchableItemInfos_serialized;
    }
}
