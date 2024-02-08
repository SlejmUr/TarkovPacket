using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.PacketFormat
{
    internal class SyncToPlayers
    {
        public static SyncToPlayers Deserialize(byte[] data, bool FromHandler)
        {
            if (!FromHandler)
                data = data.Skip(4).ToArray();
            SyncToPlayers replyPacket = new SyncToPlayers();
            BinaryReader reader = new(new MemoryStream(data));

            replyPacket.float_0 = reader.ReadSingle();

            reader.Close();
            reader.Dispose();
            return replyPacket;
        }

        public float float_0;
    }
}
