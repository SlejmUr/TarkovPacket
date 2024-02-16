namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct ConditionalData
    {
        [NonSerialized]
        public string RealConditionalId;
        public int ConditionalIdHash;
        public List<Condition> Conditions;
    }
}