using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarkovPacketSer.Enums;

namespace TarkovPacketSer.BSG_Classes
{
    public class DoorInfo
    {
        public void Deserialize(BinaryReader reader)
        {
            NetId = reader.ReadInt16();
            byte stateInfo = reader.ReadByte();
            State = (EDoorState)(stateInfo & 239);
            IsBroken = (stateInfo & 16) > 0;
        }
        public short NetId;
        public EDoorState State;
        public bool IsBroken;
    }
}
