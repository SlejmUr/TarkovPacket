using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes
{
    internal static class FloatQuantizerEXT
    {
        public static float DequantizeUIntValue(this FloatQuantizer floatQuantizer, uint value)
        {
            return value / (float)floatQuantizer.MaxIntegerValue * floatQuantizer.Delta + floatQuantizer.Min;
        }

        public static void Read(this FloatQuantizer floatQuantizer, IReaderStream bitReaderStream, out float value)
        {
            value = floatQuantizer.DequantizeUIntValue(bitReaderStream.ReadBits(floatQuantizer.BitsRequired));
        }
    }
}
