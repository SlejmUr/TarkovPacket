namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct ShowStatNotificationPacket : INested<ShowStatNotificationPacket>
    {
        public INested<ShowStatNotificationPacket> Nested { get; set; }
        public uint LocalizationKey1;
        public uint LocalizationKey2;
        public int Value;
    }
}