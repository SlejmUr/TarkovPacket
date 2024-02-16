using System.Numerics;
using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct SyncPosition
    {
        public byte Iteration;
        public Vector3 Position;
        public SyncPositionReason Reason;
    }
}
