namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct AchievementConditionValueChangedPacket : INested<AchievementConditionValueChangedPacket>
    {
        public INested<AchievementConditionValueChangedPacket> Nested { get; set; }
        public ConditionalData ProgressData;
    }
}