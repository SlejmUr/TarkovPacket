namespace TarkovPacketSer.BSG_Classes
{
    internal class VoipSettings
    {
        public void Deserialize(BinaryReader reader)
        {
            this.VoipEnabled = reader.ReadBoolean();
            this.VoipQualitySettings = VoipQualitySettings.Default;
            this.VoipQualitySettings.Deserialize(reader);
            this.PushToTalkSettings = PushToTalkSettings.Default;
            this.PushToTalkSettings.Deserialize(reader);
        }
        public bool VoipEnabled;
        public VoipQualitySettings VoipQualitySettings;
        public PushToTalkSettings PushToTalkSettings;
    }
}
