namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct SetSearched : INested<SetSearched>
    {
        public string ItemId;
        public GridId GridId;
        public bool Silent;
        public INested<SetSearched> Nested { get; set; }
    }
}
