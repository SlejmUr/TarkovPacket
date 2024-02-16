using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.RetardedBitReader
{
    public interface ISerializer2
    {
        byte[] Buffer { get; }

        int BitsCount { get; }

        int BitsRemain { get; }

        bool IsOverflow { get; }

        EBitStreamMode StreamMode { get; }

        void SerializeLimitedInt32(ref int value, int min, int max, BitPackingTag tag);

        void SerializeUInt32UsingBitRange(ref uint value, int[] rangeBits, BitPackingTag tag);

        void SerializeLimitedFloat(ref float value, float min, float max, float res, BitPackingTag tag);

        void SerializeLimitedString(ref string value, char min, char max, BitPackingTag tag, uint? maxSize = 1200);

        void SerializeBits(ref uint value, int bits);

        void SerializeBytes(ref byte[] data, int startIndex, int length);

        void SerializeBytesAndSize(ref byte[] data, uint? maxSize = 1200);

        void Serialize(ref char value);

        void Serialize(ref byte value);

        void Serialize(ref short value);

        void Serialize(ref ushort value);

        void Serialize(ref int value);

        void Serialize(ref uint value);

        void Serialize(ref long value);

        void Serialize(ref ulong value);

        void Serialize(ref float value);

        void Serialize(ref double value);

        void Serialize(ref string value, uint? maxSize = 1200);

        void Serialize(ref Vector3 value);

        void Serialize(ref Vector2 value);

        void Serialize(ref Quaternion value);

        void Serialize(ref bool value);

        void Serialize<TEnum>(ref TEnum value) where TEnum : struct, Enum, IConvertible;

        bool SerializeCheck(uint checkNumber, string message = null);

        void SerializeAlign();

        void Reset();
    }
}
