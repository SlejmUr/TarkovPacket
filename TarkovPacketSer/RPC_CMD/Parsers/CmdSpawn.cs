namespace TarkovPacketSer.RPC_CMD.Parsers
{
    internal class CmdSpawn
    {
        public static CmdSpawn Deserialize(BinaryReader reader)
        {
            CmdSpawn rsp = new();
            rsp.netId = reader.ReadPackedUInt32();
            return rsp;
        }

        public uint netId;
    }
}
