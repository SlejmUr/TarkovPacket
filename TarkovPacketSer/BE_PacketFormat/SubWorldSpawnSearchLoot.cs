using System.Formats.Asn1;
using System.Security.Claims;
using TarkovPacketSer.BSG_Classes;
using TarkovPacketSer.RetardedBitReader;

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
                replyPacket.searchableItems = new();
                MyReader myReader = new(replyPacket.searchableItemInfos_serialized);
                var num = myReader.ReadInt32();
                for (int i = 0; i < num; i++)
                {
                    SearchableItem item;
                    Serializer.Deserialize(myReader, out item);
                    replyPacket.searchableItems.Add(item);
                }
            }
            binaryReader.Close();
            binaryReader.Dispose();
            return replyPacket;
        }

        public bool flag;
        public byte[] searchableItemInfos_serialized;
        public List<SearchableItem> searchableItems;
    }
}
