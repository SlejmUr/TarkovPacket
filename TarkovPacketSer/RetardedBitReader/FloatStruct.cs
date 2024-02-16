using System.Runtime.InteropServices;

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
