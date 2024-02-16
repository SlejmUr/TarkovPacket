namespace TarkovPacketSer.RPC_CMD.Parsers
{
    internal class CmdStartGameAfterTeleport
    {
        public static CmdStartGameAfterTeleport Deserialize(BinaryReader reader)
        {
            CmdStartGameAfterTeleport rsp = new();
            rsp.netId = reader.ReadPackedUInt32();
            return rsp;
        }

        public uint netId;
    }
}
