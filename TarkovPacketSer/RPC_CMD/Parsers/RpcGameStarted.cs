using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.RPC_CMD.Parsers
{
    internal class RpcGameStarted
    {
        public static RpcGameStarted Deserialize(BinaryReader reader)
        {
            RpcGameStarted rsp = new();
            rsp.netId = reader.ReadPackedUInt32();
            rsp.pastTime = reader.ReadSingle();
            rsp.sessionSeconds = reader.ReadPackedInt32();
            return rsp;
        }

        public uint netId;
        public float pastTime;
        public int sessionSeconds;
    }
}
