using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.RPC_CMD
{
    internal class ParsedRCP_CMD
    {
        public static ParsedRCP_CMD Parse(byte[] data, bool fromHandler)
        {
            if (!fromHandler)
                data = data.Skip(4).ToArray();
            ParsedRCP_CMD ret = new();
            BinaryReader binaryReader = new(new MemoryStream(data));
            var packetId = binaryReader.ReadPackedInt32();
            ret.PacketId = packetId;
            if (RPCList.RPCCMDKV.TryGetValue(packetId, out var packetName))
            {
                ret.PacketName = packetName;

                var packet_type = typeof(ParsedRCP_CMD).Assembly.GetTypes().Where(x => x.Name.Contains(ret.PacketName)).ToList();
                if (packet_type.Count != 0)
                {
                    var method = packet_type[0].GetMethod("Deserialize");
                    ret.Data = method.Invoke(packet_type[0], [binaryReader]);

                }

            }
                
            binaryReader.Close();
            binaryReader.Dispose();
            return ret;
        }

        public int PacketId;
        public string PacketName;
        public object Data;
    }
}
