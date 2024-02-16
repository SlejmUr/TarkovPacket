using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarkovPacketSer.Enums;

namespace TarkovPacketSer.BSG_Classes
{
    public class BTR
    {
        public void Deserialize(BinaryReader reader)
        {
            HasBTR = reader.ReadBoolean();
            if (HasBTR) 
            {
                BTRData = reader.SafeReadSizeAndBytes();
            }
        }
        public bool HasBTR;
        public byte[] BTRData;
    }
}
