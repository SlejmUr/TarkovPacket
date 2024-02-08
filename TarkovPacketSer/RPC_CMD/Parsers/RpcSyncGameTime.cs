﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.RPC_CMD.Parsers
{
    internal class RpcSyncGameTime
    {
        public static RpcSyncGameTime Deserialize(BinaryReader reader)
        {
            RpcSyncGameTime rsp = new();
            rsp.netId = reader.ReadPackedUInt32();
            rsp.Time = reader.ReadPackedInt64();
            return rsp;
        }

        public uint netId;
        public long Time;
    }
}
