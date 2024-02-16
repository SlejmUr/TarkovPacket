using ComponentAce.Compression.Libs.zlib;

namespace TarkovPacketSer.PacketFormat
{
    internal class NightMare
    {
        public static NightMare Deserialize(byte[] data, bool FromHandler)
        {
            if (!FromHandler)
                data = data.Skip(4).ToArray();
            NightMare replyPacket = new NightMare();
            BinaryReader reader = new(new MemoryStream(data));

            replyPacket.Id = reader.ReadInt32();
            replyPacket.prefabsData = reader.ReadBytesAndSize();
            replyPacket.customiationData = reader.ReadBytesAndSize();
            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            File.WriteAllBytes($"nightmare_prefabs_{now}.txt", SimpleZlib.DecompressToBytes(replyPacket.prefabsData));
            File.WriteAllBytes($"nightmare_customiationData_{now}.txt", SimpleZlib.DecompressToBytes(replyPacket.customiationData));
            reader.Close();
            reader.Dispose();
            return replyPacket;
        }

        public int Id;
        public byte[] prefabsData;
        public byte[] customiationData;
    }
}
