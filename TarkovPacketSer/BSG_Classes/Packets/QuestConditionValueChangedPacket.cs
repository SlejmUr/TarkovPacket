namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct QuestConditionValueChangedPacket : INested<QuestConditionValueChangedPacket>
    {
        public INested<QuestConditionValueChangedPacket> Nested { get; set; }
        public ConditionalData ProgressData;
    }
}