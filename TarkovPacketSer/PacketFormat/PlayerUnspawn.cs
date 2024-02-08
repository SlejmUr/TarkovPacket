namespace TarkovPacketSer.PacketFormat
{
    internal class PlayerUnspawn
    {
        public static PlayerUnspawn Deserialize(byte[] data)
        {
            PlayerUnspawn replyPacket = new PlayerUnspawn();
            BinaryReader binaryReader = new(new MemoryStream(data));
            replyPacket.num = binaryReader.ReadInt32();
            replyPacket.Key = binaryReader.ReadByte();
            binaryReader.Close();
            binaryReader.Dispose();
            return replyPacket;
        }

        public int num;
        public byte Key;
    }
}
