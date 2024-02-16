using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct StatusPacket
    {
        public ushort Id;

        public EOperationStatus Status;

        public string Error;
    }
}
