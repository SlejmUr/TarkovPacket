using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.BSG_Enums
{
    [Flags]
    public enum EFireMode : byte
    {

        fullauto = 0,

        single = 1,

        doublet = 2,

        burst = 3,

        doubleaction = 4,

        semiauto = 5
    }
}
