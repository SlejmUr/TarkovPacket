using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct UpdateAccessStatus : INested<UpdateAccessStatus>
    {
        public string ItemId;
        public SearchedState State;
        public INested<UpdateAccessStatus> Nested { get; set; }
    }
}
