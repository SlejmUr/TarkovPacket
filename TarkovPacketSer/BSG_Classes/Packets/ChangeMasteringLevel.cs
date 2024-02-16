namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct ChangeMasteringLevel : INested<ChangeMasteringLevel>
    {
        public string GroupName;
        public float Value;
        public INested<ChangeMasteringLevel> Nested { get; set; }
    }
}
