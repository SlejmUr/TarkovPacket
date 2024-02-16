namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct AcceptHitDebugDataPacket : INested<AcceptHitDebugDataPacket>
    {
        public INested<AcceptHitDebugDataPacket> Nested { get; set; }
        public ClientShot[] ClientShots;
    }
}