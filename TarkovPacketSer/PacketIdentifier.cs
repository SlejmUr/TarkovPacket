namespace TarkovPacketSer
{
    internal class PacketIdentifier
    {
        public static MsgTypeEnum GetMsgType(byte[] data, out short sh)
        {
            var msg = data.Skip(2).Take(2).ToArray();
            sh = BitConverter.ToInt16(msg);

            if (!Enum.IsDefined(typeof(MsgTypeEnum), sh))
                return MsgTypeEnum.Unknown;

            return (MsgTypeEnum)sh;
        }
    }
}
