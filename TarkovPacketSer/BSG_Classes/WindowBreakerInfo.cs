using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TarkovPacketSer.Enums;

namespace TarkovPacketSer.BSG_Classes
{
    public class WindowBreakerInfo
    {
        public void Deserialize(BinaryReader reader)
        {
            this.Id = reader.ReadInt32();
            this.Position = reader.ReadVector3();

        }
        public Int32 Id;
        public Vector3 Position;
    }
}
