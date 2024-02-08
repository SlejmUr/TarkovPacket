using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.BSG_Classes
{
    internal class BufferZoneControllerClass
    {
        public void Deserialize(BinaryReader reader)
        {
            IsAvailable = reader.ReadBoolean();
        }

        public bool IsAvailable;
    }
}
