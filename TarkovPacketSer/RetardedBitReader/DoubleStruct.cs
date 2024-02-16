using System.Runtime.InteropServices;

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
