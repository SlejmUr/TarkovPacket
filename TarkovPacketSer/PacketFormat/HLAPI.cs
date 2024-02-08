using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.PacketFormat
{
    internal class HLAPI
    {
        public static HLAPI Deserialize(byte[] data)
        {
            HLAPI replyPacket = new HLAPI();
            BinaryReader binaryReader = new(new MemoryStream(data));

            //WHAT HTE FUCK


            binaryReader.Close();
            binaryReader.Dispose();
            return replyPacket;
        }

    }
}
