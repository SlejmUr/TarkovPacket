namespace TarkovPacketSer.RPC_CMD.Parsers
{
    internal class CmdGameStarted
    {
        public static CmdGameStarted Deserialize(BinaryReader reader)
        {
            CmdGameStarted rsp = new();
            rsp.netId = reader.ReadPackedUInt32();
            return rsp;
        }

        public uint netId;
    }
}
