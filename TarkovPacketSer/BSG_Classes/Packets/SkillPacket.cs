namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct SkillPacket : INested<SkillPacket>
    {
        public byte SkillId;
        public float Value;
        public float Effectiveness;
        public INested<SkillPacket> Nested { get; set; }
    }
}
