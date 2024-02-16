namespace TarkovPacketSer.RPC_CMD.Parsers
{
    internal class CmdStartGame
    {
        public static CmdStartGame Deserialize(BinaryReader reader)
        {
            CmdStartGame rsp = new();
            rsp.netId = reader.ReadPackedUInt32();
            return rsp;
        }

        public uint netId;
    }
}
