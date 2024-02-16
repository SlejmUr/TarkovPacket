namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct SearchingAction : INested<SearchingAction>
    {
        public string ItemId;
        public INested<SearchingAction> Nested { get; set; }
    }
}
