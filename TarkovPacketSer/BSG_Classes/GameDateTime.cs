namespace TarkovPacketSer.BSG_Classes
{
    internal class GameDateTime
    {
        public static GameDateTime Deserialize(BinaryReader reader)
        {
            GameDateTime dateTime = new();
            dateTime.realDateTime = reader.ReadBoolean() ? DateTime.UtcNow : DateTime.FromBinary(reader.ReadInt64());
            dateTime.gameDateTime = DateTime.FromBinary(reader.ReadInt64());
            dateTime.timeFactor = reader.ReadSingle();
            return dateTime;
        }

        public DateTime realDateTime;
        public DateTime gameDateTime;
        public float timeFactor;
    }
}
