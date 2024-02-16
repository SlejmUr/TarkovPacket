using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static TarkovPacketSer.RetardedBitReader.RBR;

namespace TarkovPacketSer.RetardedBitReader
{
    public static class RBR
    {
        public static int BitRequired(long min, long max)
        {
            if (min != max)
            {
                return (int)(Log2((uint)(max - min)) + 1U);
            }
            return 0;
        }

        public static uint Log2(uint value)
        {
            uint num = value | value >> 1;
            uint num2 = num | num >> 2;
            uint num3 = num2 | num2 >> 4;
            uint num4 = num3 | num3 >> 8;
            return smethod_0((num4 | num4 >> 16) >> 1);
        }
        private static uint smethod_0(uint x)
        {
            uint num = x - (x >> 1 & 1431655765U);
            uint num2 = (num >> 2 & 858993459U) + (num & 858993459U);
            uint num3 = (num2 >> 4) + num2 & 252645135U;
            uint num4 = num3 + (num3 >> 8);
            return num4 + (num4 >> 16) & 63U;
        }

        public static void CalculateDataForQuantizing(float min, float max, float res, out float delta, out int maxIntegerValue, out int bits)
        {
            delta = max - min;
            float f = delta / res;
            maxIntegerValue = (int)MathF.Ceiling(f);
            bits = BitRequired(0L, (long)maxIntegerValue);
        }

        public static float DequantizeUIntToFloat(uint integerValue, float min, int maxIntegerValue, float delta)
        {
            return integerValue / (float)maxIntegerValue * delta + min;
        }

        public static uint QuantizeFloatValue(float value, float min, float delta, int maxIntegerValue)
        {
            return (uint)MathF.Floor(Clamp((value - min) / delta, 0f, 1f) * (float)maxIntegerValue + 0.5f);
        }

        public static float Clamp(float value, float min, float max)
        {
            bool flag = value < min;
            if (flag)
            {
                value = min;
            }
            else
            {
                bool flag2 = value > max;
                if (flag2)
                {
                    value = max;
                }
            }
            return value;
        }

        public static Exception InvalidMaxSize(int size, uint maxSize, IBitReader bitReader)
        {
            return new Exception("InvalidMaxSize!");
        }


        public static class EnumStructConverter<T> where T : struct, Enum
        {

            static EnumStructConverter()
            {
                Type underlyingType = Enum.GetUnderlyingType(typeof(T));
                if (underlyingType == typeof(int))
                {
                    EnumStructConverter<T>.func_0 = new Func<T, long>(IntConvert<T>.ToIntCaster);
                    EnumStructConverter<T>.Min = (long)IntConvert<T>.Min;
                    EnumStructConverter<T>.Max = (long)IntConvert<T>.Max;
                    EnumStructConverter<T>.dictionary_0 = IntConvert<T>.IntToEnumTable.ToDictionary(x=> (long)x.Key,x=> x.Value);
                    return;
                }
                if (underlyingType == typeof(short))
                {
                    EnumStructConverter<T>.func_0 = new Func<T, long>(ShortConvert<T>.ToIntCaster);
                    EnumStructConverter<T>.Min = (long)ShortConvert<T>.Min;
                    EnumStructConverter<T>.Max = (long)ShortConvert<T>.Max;
                    EnumStructConverter<T>.dictionary_0 = ShortConvert<T>.IntToEnumTable.ToDictionary(x => (long)x.Key, x => x.Value);
                    return;
                }
                if (underlyingType == typeof(byte))
                {
                    EnumStructConverter<T>.func_0 = new Func<T, long>(ByteConvert<T>.ToIntCaster);
                    EnumStructConverter<T>.Min = (long)((ulong)ByteConvert<T>.Min);
                    EnumStructConverter<T>.Max = (long)((ulong)ByteConvert<T>.Max);
                    EnumStructConverter<T>.dictionary_0 = ByteConvert<T>.IntToEnumTable.ToDictionary(x => (long)((ulong)x.Key), x => x.Value);
                    return;
                }
                if (!(underlyingType == typeof(long)))
                {
                    throw new Exception(string.Format("type mismatch {0}", underlyingType));
                }
                EnumStructConverter<T>.func_0 = new Func<T, long>(LongConvert<T>.ToIntCaster);
                EnumStructConverter<T>.Min = LongConvert<T>.Min;
                EnumStructConverter<T>.Max = LongConvert<T>.Max;
                EnumStructConverter<T>.dictionary_0 = LongConvert<T>.IntToEnumTable.ToDictionary(x => x.Key, x => x.Value);
            }
            public static T ToEnum(long i)
            {
                return EnumStructConverter<T>.dictionary_0[i];
            }
            public static long ToInt(T e)
            {
                return EnumStructConverter<T>.func_0(e);
            }
            public static readonly long Min;
            public static readonly long Max;
            private static readonly Func<T, long> func_0;
            private static readonly Dictionary<long, T> dictionary_0;
        }

        private static class IntConvert<T> where T : struct, Enum
        {

            public unsafe static long ToIntCaster(T arg)
            {
                int* ptr = (int*)(&arg);
                return (long)(*ptr);
            }

            public static int Min
            {
                get
                {
                    return Enum.GetValues(typeof(T)).Cast<int>().Min();
                }
            }

            public static int Max
            {
                get
                {
                    return Enum.GetValues(typeof(T)).Cast<int>().Max();
                }
            }

            public static Dictionary<int, T> IntToEnumTable
            {
                get
                {
                    return ((T[])Enum.GetValues(typeof(T))).ToDictionary(x => (int)((object)x), x => x);
                }
            }
        }

        private static class LongConvert<T> where T : struct, Enum
        {

            public unsafe static long ToIntCaster(T arg)
            {
                long* ptr = (long*)(&arg);
                return *ptr;
            }

            public static long Min
            {
                get
                {
                    return Enum.GetValues(typeof(T)).Cast<long>().Min();
                }
            }

            public static long Max
            {
                get
                {
                    return Enum.GetValues(typeof(T)).Cast<long>().Max();
                }
            }

            public static Dictionary<long, T> IntToEnumTable
            {
                get
                {
                    return ((T[])Enum.GetValues(typeof(T))).ToDictionary(x => (long)((object)x), x => x);
                }
            }
        }

        private static class ShortConvert<T> where T : struct, Enum
        {

            public unsafe static long ToIntCaster(T arg)
            {
                short* ptr = (short*)(&arg);
                return (long)(*ptr);
            }

            public static short Min
            {
                get
                {
                    return Enum.GetValues(typeof(T)).Cast<short>().Min<short>();
                }
            }

            public static short Max
            {
                get
                {
                    return Enum.GetValues(typeof(T)).Cast<short>().Max<short>();
                }
            }

            public static Dictionary<short, T> IntToEnumTable
            {
                get
                {
                    return ((T[])Enum.GetValues(typeof(T))).ToDictionary(x=> (short)((object)x), x=>x);
                }
            }
        }

        private static class ByteConvert<T> where T : struct, Enum
        {

            public unsafe static long ToIntCaster(T arg)
            {
                byte* ptr = (byte*)(&arg);
                return (long)((ulong)(*ptr));
            }

            public static byte Min
            {
                get
                {
                    return Enum.GetValues(typeof(T)).Cast<byte>().Min<byte>();
                }
            }

            public static byte Max
            {
                get
                {
                    return Enum.GetValues(typeof(T)).Cast<byte>().Max<byte>();
                }
            }

            public static Dictionary<byte, T> IntToEnumTable
            {
                get
                {
                    return ((T[])Enum.GetValues(typeof(T))).ToDictionary(x=> (byte)((object)x), x=>x);
                }
            }
        }
    }
}
