using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.RetardedBitReader
{
    [StructLayout(LayoutKind.Explicit)]
    public struct DoubleStruct
    {
        [FieldOffset(0)]
        public double Double;

        [FieldOffset(0)]
        public ulong Ulong;
    }
}
