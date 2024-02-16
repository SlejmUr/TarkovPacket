namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct StringNotificationPacket : INested<StringNotificationPacket>
    {
        public INested<StringNotificationPacket> Nested { get; set; }
        public string Message;
    }
}