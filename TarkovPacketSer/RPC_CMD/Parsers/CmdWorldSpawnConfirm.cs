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
