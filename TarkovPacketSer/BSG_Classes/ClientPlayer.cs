using TarkovPacketSer.BSG_Classes.Packets;
using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes
{
    internal class ClientPlayer
    {
        public static ClientPlayer Deserialize(IReaderStream reader)
        {
            ClientPlayer replyPacket = new();
            SelfPlayerInfo selfPlayerInfo = new();
            SelfPlayerInfo.Deserialize(reader, ref selfPlayerInfo);
            replyPacket.playerInfo = selfPlayerInfo;
            return replyPacket;
        }

        public SelfPlayerInfo playerInfo;

    }
}
