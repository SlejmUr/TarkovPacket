using TarkovPacketSer.Enums;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct UpdateExfiltrationPointPacket : INested<UpdateExfiltrationPointPacket>
    {
        public INested<UpdateExfiltrationPointPacket> Nested { get; set; }
        public string PointName;
        public EExfiltrationStatus Command;
        public List<string> QueuedPlayers;
    }
}