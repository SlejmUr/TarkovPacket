﻿namespace TarkovPacketSer.RPC_CMD.Parsers
{
    internal class RpcGameStopping
    {
        public static RpcGameStopping Deserialize(BinaryReader reader)
        {
            RpcGameStopping rsp = new();
            rsp.netId = reader.ReadPackedUInt32();
            return rsp;
        }

        public uint netId;
    }
}
