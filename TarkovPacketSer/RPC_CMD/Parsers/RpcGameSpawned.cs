namespace TarkovPacketSer.RPC_CMD.Parsers
{
    internal class RpcGameSpawned
    {
        public static RpcGameSpawned Deserialize(BinaryReader reader)
        {
            RpcGameSpawned rsp = new();
            rsp.netId = reader.ReadPackedUInt32();
            return rsp;
        }

        public uint netId;
    }
}
