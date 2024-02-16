using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarkovPacketSer.BE_PacketFormat;
using TarkovPacketSer.BSG_Classes.Packets;
using TarkovPacketSer.BSG_Enums;
using TarkovPacketSer.RetardedBitReader;
using static TarkovPacketSer.BSG_Classes.Packets.DeserializerPacketsEXT;

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
