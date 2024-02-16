using System.Numerics;

namespace TarkovPacketSer.RetardedBitReader
{
    public class MyReader : IReaderStream, ISerializer2
    {
        public MyReader(byte[] buffer)
        {
            this.bitreader = new MyBitReader(buffer);
        }

        public byte[] Buffer
        {
            get
            {
                return this.bitreader.Buffer;
            }
        }

        public int BitsRead
        {
            get
            {
                return this.bitreader.BitsRead;
            }
        }

        public int BitsCount
        {
            get
            {
                return this.bitreader.BitsCount;
            }
        }

        public int BitsRemain
        {
            get
            {
                return this.BitsCount - this.BitsRead;
            }
        }

        public int BytesRead
        {
            get
            {
                return this.bitreader.BytesRead;
            }
        }

        public bool IsOverflow
        {
            get
            {
                return this.bitreader.IsOverflow;
            }
        }

        public EBitStreamMode StreamMode
        {
            get
            {
                return EBitStreamMode.Reading;
            }
        }

        public int ReadLimitedInt32(int min, int max)
        {
            int bits = RBR.BitRequired((long)min, (long)max);
            return (int)(this.bitreader.ReadBits(bits) + (uint)min);
        }

        public uint ReadUInt32UsingBitRange(int[] rangeBits)
        {
            int num = 0;
            int num2 = rangeBits.Length;
            for (int i = 0; i < num2 - 1; i++)
            {
                int max = num + ((1 << rangeBits[i]) - 1);
                if (this.ReadBool())
                {
                    return (uint)this.ReadLimitedInt32(num, max);
                }
                num += 1 << rangeBits[i];
            }
            return (uint)this.ReadLimitedInt32(num, num + ((1 << rangeBits[num2 - 1]) - 1));
        }

        public float ReadLimitedFloat(float min, float max, float res)
        {
            float delta;
            int maxIntegerValue;
            int bits;
            RBR.CalculateDataForQuantizing(min, max, res, out delta, out maxIntegerValue, out bits);
            return RBR.DequantizeUIntToFloat(this.ReadBits(bits), min, maxIntegerValue, delta);
        }

        public string ReadLimitedString(char min, char max, uint? maxSize = 1200)
        {
            if (this.ReadBool())
            {
                return null;
            }
            this.ReadAlign();
            int num = this.ReadInt32();
            if (maxSize != null)
            {
                long num2 = (long)num;
                uint? num3 = maxSize;
                long? num4 = (num3 != null) ? new long?((long)((ulong)num3.GetValueOrDefault())) : null;
                if (num2 > num4.GetValueOrDefault() & num4 != null)
                {
                    throw RBR.InvalidMaxSize(num, maxSize.Value, this.bitreader);
                }
            }
            char[] array = new char[num];
            int bits = RBR.BitRequired((long)((ulong)min), (long)((ulong)max));
            for (int i = 0; i < num; i++)
            {
                uint num5 = this.bitreader.ReadBits(bits);
                array[i] = (char)(num5 + (uint)min);
            }
            return new string(array);
        }

        public uint ReadBits(int bits)
        {
            return this.bitreader.ReadBits(bits);
        }

        public void ReadBytes(byte[] destinationBytes, int destinationStartIndex, int length)
        {
            this.ReadAlign();
            this.bitreader.ReadBytes(destinationBytes, destinationStartIndex, length);
        }

        public byte[] ReadBytesAlloc(uint? maxSize)
        {
            ushort num = this.ReadUInt16();
            if (maxSize != null)
            {
                uint num2 = (uint)num;
                uint? num3 = maxSize;
                if (num2 > num3.GetValueOrDefault() & num3 != null)
                {
                    throw RBR.InvalidMaxSize((int)num, maxSize.Value, this.bitreader);
                }
            }
            byte[] array = new byte[(int)num];
            this.ReadBytes(array, 0, array.Length);
            return array;
        }

        public char ReadChar()
        {
            return (char)this.bitreader.ReadBits(16);
        }

        public byte ReadByte()
        {
            return (byte)this.bitreader.ReadBits(8);
        }

        public short ReadInt16()
        {
            return (short)this.bitreader.ReadBits(16);
        }

        public ushort ReadUInt16()
        {
            return (ushort)this.bitreader.ReadBits(16);
        }

        public int ReadInt32()
        {
            return (int)this.bitreader.ReadBits(32);
        }

        public uint ReadUInt32()
        {
            return this.bitreader.ReadBits(32);
        }

        public long ReadInt64()
        {
            uint num = this.ReadUInt32();
            return (long)((ulong)this.ReadUInt32() << 32 | (ulong)num);
        }

        public ulong ReadUInt64()
        {
            uint num = this.ReadUInt32();
            return (ulong)this.ReadUInt32() << 32 | (ulong)num;
        }

        public float ReadFloat()
        {
            return new FloatStruct
            {
                UInt = this.ReadUInt32()
            }.Float;
        }

        public double ReadDouble()
        {
            return new DoubleStruct
            {
                Ulong = this.ReadUInt64()
            }.Double;
        }

        public string ReadString(uint? maxSize)
        {
            if (this.ReadBool())
            {
                return null;
            }
            this.ReadAlign();
            int num = this.ReadInt32();
            if (num >= 0)
            {
                if (maxSize != null)
                {
                    long num2 = (long)num;
                    uint? num3 = maxSize;
                    long? num4 = (num3 != null) ? new long?((long)((ulong)num3.GetValueOrDefault())) : null;
                    if (num2 > num4.GetValueOrDefault() & num4 != null)
                    {
                        throw RBR.InvalidMaxSize(num, maxSize ?? 0U, this.bitreader);
                    }
                }
                if (num > 1000000)
                {
                    throw RBR.InvalidMaxSize(num, 1000000U, this.bitreader);
                }
                char[] array = new char[num];
                for (int i = 0; i < num; i++)
                {
                    array[i] = this.ReadChar();
                }
                return new string(array);
            }
            throw RBR.InvalidMaxSize(num, maxSize ?? 0U, this.bitreader);
        }

        public Vector3 ReadVector3()
        {
            float x = this.ReadFloat();
            float y = this.ReadFloat();
            float z = this.ReadFloat();
            return new Vector3(x, y, z);
        }

        public Vector2 ReadVector2()
        {
            float x = this.ReadFloat();
            float y = this.ReadFloat();
            return new Vector2(x, y);
        }

        public Quaternion ReadQuaternion()
        {
            float x = this.ReadFloat();
            float y = this.ReadFloat();
            float z = this.ReadFloat();
            float w = this.ReadFloat();
            return new Quaternion(x, y, z, w);
        }

        public bool ReadBool()
        {
            return this.ReadBits(1) > 0U;
        }

        public TEnum ReadEnum<TEnum>() where TEnum : struct, Enum, IConvertible
        {
            long min = RBR.EnumStructConverter<TEnum>.Min;
            long max = RBR.EnumStructConverter<TEnum>.Max;
            int bits = RBR.BitRequired(min, max);
            return RBR.EnumStructConverter<TEnum>.ToEnum((long)this.bitreader.ReadBits(bits) + min);
        }

        public bool ReadCheck(uint magic, string message = null)
        {
            this.ReadAlign();
            uint num = this.ReadBits(32);
            return magic == num;
        }

        public void ReadAlign()
        {
            this.bitreader.ReadAlign();
        }

        public void Reset()
        {
            this.bitreader.Reset();
        }

        public void SerializeLimitedInt32(ref int value, int min, int max, BitPackingTag tag)
        {
            value = this.ReadLimitedInt32(min, max);
        }

        public void SerializeUInt32UsingBitRange(ref uint value, int[] rangeBits, BitPackingTag tag)
        {
            value = this.ReadUInt32UsingBitRange(rangeBits);
        }

        public void SerializeLimitedFloat(ref float value, float min, float max, float res, BitPackingTag tag)
        {
            value = this.ReadLimitedFloat(min, max, res);
        }

        public void SerializeLimitedString(ref string value, char min, char max, BitPackingTag tag, uint? maxSize = 1200)
        {
            value = this.ReadLimitedString(min, max, maxSize);
        }

        public void SerializeBits(ref uint value, int bits)
        {
            value = this.ReadBits(bits);
        }

        public void SerializeBytes(ref byte[] data, int startIndex, int length)
        {
            this.ReadBytes(data, startIndex, length);
        }

        public void SerializeBytesAndSize(ref byte[] data, uint? maxSize)
        {
            data = this.ReadBytesAlloc(maxSize);
        }

        public void Serialize(ref char value)
        {
            value = this.ReadChar();
        }

        public void Serialize(ref byte value)
        {
            value = this.ReadByte();
        }

        public void Serialize(ref short value)
        {
            value = this.ReadInt16();
        }

        public void Serialize(ref ushort value)
        {
            value = this.ReadUInt16();
        }

        public void Serialize(ref int value)
        {
            value = this.ReadInt32();
        }

        public void Serialize(ref uint value)
        {
            value = this.ReadUInt32();
        }

        public void Serialize(ref long value)
        {
            value = this.ReadInt64();
        }

        public void Serialize(ref ulong value)
        {
            value = this.ReadUInt64();
        }

        public void Serialize(ref float value)
        {
            value = this.ReadFloat();
        }

        public void Serialize(ref double value)
        {
            value = this.ReadDouble();
        }

        public void Serialize(ref string value, uint? maxSize)
        {
            value = this.ReadString(maxSize);
        }

        public void Serialize(ref Vector3 value)
        {
            value = this.ReadVector3();
        }

        public void Serialize(ref Vector2 value)
        {
            value = this.ReadVector2();
        }

        public void Serialize(ref Quaternion value)
        {
            value = this.ReadQuaternion();
        }

        public void Serialize(ref bool value)
        {
            value = this.ReadBool();
        }

        public void Serialize<TEnum>(ref TEnum value) where TEnum : struct, Enum, IConvertible
        {
            value = this.ReadEnum<TEnum>();
        }

        public bool SerializeCheck(uint checkNumber, string message = null)
        {
            return this.ReadCheck(checkNumber, message);
        }

        public void SerializeAlign()
        {
            this.ReadAlign();
        }

        private readonly IBitReader bitreader;
    }
}
