using TarkovPacketSer.Enums;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct LampChangeStatePacket : INested<LampChangeStatePacket>
    {
        public INested<LampChangeStatePacket> Nested { get; set; }
        public int NetId;
        public ELampState State;
    }
}