namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct TradersInfoPacket : INested<TradersInfoPacket>
    {
        public INested<TradersInfoPacket> Nested { get; set; }

        public string TraderId;
        public double Standing;
    }
}