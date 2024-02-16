using ComponentAce.Compression.Libs.zlib;

namespace TarkovPacketSer.BE_PacketFormat
{
    internal class SubWorldSpawnLoot
    {
        public static SubWorldSpawnLoot Deserialize(byte[] data)
        {
            data = data.Skip(4).ToArray();
            SubWorldSpawnLoot replyPacket = new();
            BinaryReader binaryReader = new(new MemoryStream(data));
            replyPacket.flag = binaryReader.ReadBoolean();

            if (replyPacket.flag)
            {
                replyPacket.loots = binaryReader.ReadBytesAndSize();
                replyPacket.DecompressedLoot = SimpleZlib.DecompressToBytes(replyPacket.loots);
            }
            binaryReader.Close();
            binaryReader.Dispose();
            return replyPacket;
        }

        public bool flag;
        public byte[] loots;
        public byte[] DecompressedLoot;
    }
}
