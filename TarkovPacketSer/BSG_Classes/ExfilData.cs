using TarkovPacketSer.Enums;

namespace TarkovPacketSer.BSG_Classes
{
    public class ExfilData
    {
        public void Deserialize(BinaryReader reader)
        {
            Name = reader.ProperReadString();
            exfiltrationStatus = (EExfiltrationStatus)reader.ReadByte();
            startTime = reader.ReadInt32();
            if (exfiltrationStatus == EExfiltrationStatus.Countdown)
            {
                startTime = reader.ReadInt16();
            }
            PlayerIds = new();
            var playerIdCounts = reader.ReadInt16();
            for (int i = 0; i < playerIdCounts; i++)
            {
                PlayerIds.Add(reader.ProperReadString());
            }
        }
        public string Name;
        public EExfiltrationStatus exfiltrationStatus;
        public int startTime;
        public List<string> PlayerIds;
    }
}
