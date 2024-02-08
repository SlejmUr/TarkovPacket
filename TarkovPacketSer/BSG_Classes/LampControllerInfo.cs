using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarkovPacketSer.Enums;

namespace TarkovPacketSer.BSG_Classes
{
    public class LampControllerInfo
    {
        public void Deserialize(BinaryReader reader)
        {
            this.Id = reader.ReadInt32();
            this.State = (ELampState)reader.ReadByte();
            
        }
        public Int32 Id;
        public ELampState State;
    }
}
