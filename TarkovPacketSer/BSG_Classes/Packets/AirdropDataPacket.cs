using TarkovPacketSer.BSG_Enums;
using TarkovPacketSer.Enums;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct AirdropDataPacket
    {

        public bool SignalFire;

        public EAirdropFallingStage FallingStage;

        public EAirdropType AirdropType;

        public int UniqueId;
    }
}