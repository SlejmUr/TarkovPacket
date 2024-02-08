namespace TarkovPacketSer.PacketFormat
{
    internal class ObserverUnspawn
    {
        public static ObserverUnspawn Deserialize(byte[] data)
        {
            ObserverUnspawn replyPacket = new ObserverUnspawn();
            BinaryReader binaryReader = new(new MemoryStream(data));
            replyPacket.num = binaryReader.ReadInt32();
            replyPacket.Key = binaryReader.ReadByte();
            replyPacket.remoteTime = binaryReader.ReadSingle();
            binaryReader.Close();
            binaryReader.Dispose();
            return replyPacket;
        }

        public int num;
        public byte Key;
        public float remoteTime;
    }
}
