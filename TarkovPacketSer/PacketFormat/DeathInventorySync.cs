namespace TarkovPacketSer.PacketFormat
{
    internal class DeathInventorySync
    {
        public static DeathInventorySync Deserialize(byte[] data)
        {
            DeathInventorySync replyPacket = new DeathInventorySync();
            BinaryReader binaryReader = new(new MemoryStream(data));
            replyPacket.Id = binaryReader.ReadInt32();
            replyPacket.Size = binaryReader.ReadInt32();
            replyPacket.data = binaryReader.SafeReadBytes(replyPacket.Size);
            binaryReader.Close();
            binaryReader.Dispose();
            return replyPacket;
        }

        public int Id;
        public int Size;
        public byte[] data;
    }
}
