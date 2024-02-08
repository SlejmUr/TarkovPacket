using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.RPC_CMD.Parsers
{
    internal class RpcGameStartingWithTeleport
    {
        public static RpcGameStartingWithTeleport Deserialize(BinaryReader reader)
        {
            RpcGameStartingWithTeleport rsp = new();
            rsp.netId = reader.ReadPackedUInt32();
            rsp.Position = reader.ReadVector3();
            rsp.exfilId = reader.ReadPackedInt32();
            rsp.EntryPoint = reader.ProperReadString();
            return rsp;
        }

        public uint netId;
        public Vector3 Position;
        public int exfilId;
        public string EntryPoint;
    }
}
