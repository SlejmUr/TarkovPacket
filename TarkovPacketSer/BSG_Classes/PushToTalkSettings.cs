namespace TarkovPacketSer.BSG_Classes
{
    internal class PushToTalkSettings
    {
        public static PushToTalkSettings Default { get; } = new PushToTalkSettings
        {
            SpeakingSecondsLimit = 7f,
            SpeakingSecondsInterval = 10f,
            ActivationsLimit = 2,
            ActivationsInterval = 2f,
            BlockingTime = 10f,
            AlertDistanceMeters = 5,
            HearingDistance = 50,
            AbuseTraceSeconds = 2f
        }; 
        
        public void Deserialize(BinaryReader reader)
        {
            this.SpeakingSecondsLimit = reader.ReadSingle();
            this.SpeakingSecondsInterval = reader.ReadSingle();
            this.ActivationsLimit = reader.ReadByte();
            this.ActivationsInterval = reader.ReadSingle();
            this.BlockingTime = reader.ReadSingle();
            this.AlertDistanceMeters = reader.ReadByte();
            this.HearingDistance = reader.ReadByte();
            this.AbuseTraceSeconds = (float)reader.ReadByte();
        }
        public float SpeakingSecondsLimit;

        public float SpeakingSecondsInterval;

        public byte ActivationsLimit;

        public float ActivationsInterval;

        public float BlockingTime;

        public byte AlertDistanceMeters;

        public byte HearingDistance;

        public float AbuseTraceSeconds;
    }
}
