using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.RPC_CMD.Parsers
{
    internal class RpcGameStopped
    {
        public static RpcGameStopped Deserialize(BinaryReader reader)
        {
            RpcGameStopped rsp = new();
            rsp.netId = reader.ReadPackedUInt32();
            rsp.ExitStatus = reader.ReadInt32();
            rsp.playTime = reader.ReadPackedInt32();
            return rsp;
        }

        public uint netId;
        public int ExitStatus;
        public int playTime;
    }
}
