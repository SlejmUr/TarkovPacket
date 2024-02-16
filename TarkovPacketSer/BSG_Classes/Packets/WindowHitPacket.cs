using System.Numerics;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct WindowHitPacket : INested<WindowHitPacket>
    {
        public INested<WindowHitPacket> Nested { get; set; }
        public int NetId;
        public Vector3 HitPosition;
    }
}