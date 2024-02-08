using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.RPC_CMD.Parsers
{
    internal class CmdWorldSpawnConfirm
    {
        public static CmdWorldSpawnConfirm Deserialize(BinaryReader reader)
        {
            CmdWorldSpawnConfirm rsp = new();
            rsp.netId = reader.ReadPackedUInt32();
            return rsp;
        }

        public uint netId;
    }
}
