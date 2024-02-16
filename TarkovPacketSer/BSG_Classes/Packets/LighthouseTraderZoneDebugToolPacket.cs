namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct LighthouseTraderZoneDebugToolPacket : INested<LighthouseTraderZoneDebugToolPacket>
    {
        public INested<LighthouseTraderZoneDebugToolPacket> Nested { get; set; }
        public bool Active;
    }
}