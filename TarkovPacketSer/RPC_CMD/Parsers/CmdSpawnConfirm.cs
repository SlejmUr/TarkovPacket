using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.RPC_CMD.Parsers
{
    internal class CmdSpawnConfirm
    {
        public static CmdSpawnConfirm Deserialize(BinaryReader reader)
        {
            CmdSpawnConfirm rsp = new();
            rsp.netId = reader.ReadPackedUInt32();
            rsp.playerId = reader.ReadPackedInt32();
            return rsp;
        }

        public uint netId;
        public int playerId;
    }
}
