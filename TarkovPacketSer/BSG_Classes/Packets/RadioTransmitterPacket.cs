using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct RadioTransmitterPacket : INested<RadioTransmitterPacket>
    {
        public INested<RadioTransmitterPacket> Nested { get; set; }
        public bool IsEncoded; 
        public RadioTransmitterStatus Status;
        public bool IsAgressor;
    }
}