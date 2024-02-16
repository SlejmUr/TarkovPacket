using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.RetardedBitReader
{
    [StructLayout(LayoutKind.Explicit)]
    public struct FloatStruct
    {
        [FieldOffset(0)]
        public float Float;

        [FieldOffset(0)]
        public uint UInt;
    }
}
