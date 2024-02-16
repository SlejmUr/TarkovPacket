namespace TarkovPacketSer.BSG_Classes
{
    internal class BufferZoneControllerClass
    {
        public void Deserialize(BinaryReader reader)
        {
            IsAvailable = reader.ReadBoolean();
        }

        public bool IsAvailable;
    }
}
