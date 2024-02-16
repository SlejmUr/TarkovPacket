namespace TarkovPacketSer.PacketFormat
{
    internal class BEPacket
    {
        public static BE_PacketJson ParsePacket(byte[] data, bool FromHandler)
        {
            if (!FromHandler)
                data = data.Skip(4).ToArray();
            var len = BitConverter.ToUInt16(data);
            var bepacket = data.Skip(2).Take(len);
            BE_PacketJson bE_PacketJson = new()
            {
                BEPacket = Convert.ToBase64String(bepacket.ToArray())
            };
            return bE_PacketJson;
        }

        public class BE_PacketJson
        {
            public string BEPacket;
        }
    }
}
