using System.Numerics;
using System.Text;

namespace TarkovPacketSer
{
    public static class BinaryReaderExtensions
    {
        public static String ProperReadString(this BinaryReader reader)
        {
            Int16 length = reader.ReadInt16();
            Byte[] bytes = reader.ReadBytes(length);

            return Encoding.UTF8.GetString(bytes);
        }
        public static Vector2 ReadVector2(this BinaryReader reader)
        {
            return new Vector2(reader.ReadSingle(), reader.ReadSingle());
        }
        public static Vector3 ReadVector3(this BinaryReader reader)
        {
            return new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }

        public static Quaternion ReadQuaternion(this BinaryReader reader)
        {
            return new Quaternion(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }

        public static byte[] ReadBytesAndSize(this BinaryReader reader)
        {
            UInt16 length = reader.ReadUInt16();
            Byte[] bytes = reader.ReadBytes(length);

            return bytes;
        }

        public static byte[] SafeReadSizeAndBytes(this BinaryReader reader)
        {
            int size = reader.ReadInt32();
            return reader.SafeReadBytes(size);
        }

        public static byte[] SafeReadBytes(this BinaryReader reader, int size)
        {
            if (size <= 0)
            {
                return Array.Empty<byte>();
            }
            return reader.ReadBytes(size);
        }

        public static uint ReadPackedUInt32(this BinaryReader reader)
        {
            byte b = reader.ReadByte();
            if (b < 241)
            {
                return (uint)b;
            }
            byte b2 = reader.ReadByte();
            if (b >= 241 && b <= 248)
            {
                return 240U + 256U * (uint)(b - 241) + (uint)b2;
            }
            byte b3 = reader.ReadByte();
            if (b == 249)
            {
                return 2288U + 256U * (uint)b2 + (uint)b3;
            }
            byte b4 = reader.ReadByte();
            if (b == 250)
            {
                return (uint)((int)b2 + ((int)b3 << 8) + ((int)b4 << 16));
            }
            byte b5 = reader.ReadByte();
            if (b >= 251)
            {
                return (uint)((int)b2 + ((int)b3 << 8) + ((int)b4 << 16) + ((int)b5 << 24));
            }
            throw new IndexOutOfRangeException("ReadPackedUInt32() failure: " + b);
        }

        public static int ReadPackedInt32(this BinaryReader reader)
        {
            byte b = reader.ReadByte();
            if (b < 241)
            {
                return b;
            }
            byte b2 = reader.ReadByte();
            if (b >= 241 && b <= 248)
            {
                return 240 + 256 * (b - 241) + b2;
            }
            byte b3 = reader.ReadByte();
            if (b == 249)
            {
                return 2288 + 256 * b2 + b3;
            }
            byte b4 = reader.ReadByte();
            if (b == 250)
            {
                return (int)b2 + ((int)b3 << 8) + ((int)b4 << 16);
            }
            byte b5 = reader.ReadByte();
            if (b >= 251)
            {
                return (int)b2 + ((int)b3 << 8) + ((int)b4 << 16) + ((int)b5 << 24);
            }
            throw new IndexOutOfRangeException("ReadPackedInt32() failure: " + b);
        }

        public static ulong ReadPackedUInt64(this BinaryReader reader)
        {
            byte b = reader.ReadByte();
            if (b < 241)
            {
                return (ulong)b;
            }
            byte b2 = reader.ReadByte();
            if (b >= 241 && b <= 248)
            {
                return 240UL + 256UL * ((ulong)b - 241UL) + (ulong)b2;
            }
            byte b3 = reader.ReadByte();
            if (b == 249)
            {
                return 2288UL + 256UL * (ulong)b2 + (ulong)b3;
            }
            byte b4 = reader.ReadByte();
            if (b == 250)
            {
                return (ulong)b2 + ((ulong)b3 << 8) + ((ulong)b4 << 16);
            }
            byte b5 = reader.ReadByte();
            if (b == 251)
            {
                return (ulong)b2 + ((ulong)b3 << 8) + ((ulong)b4 << 16) + ((ulong)b5 << 24);
            }
            byte b6 = reader.ReadByte();
            if (b == 252)
            {
                return (ulong)b2 + ((ulong)b3 << 8) + ((ulong)b4 << 16) + ((ulong)b5 << 24) + ((ulong)b6 << 32);
            }
            byte b7 = reader.ReadByte();
            if (b == 253)
            {
                return (ulong)b2 + ((ulong)b3 << 8) + ((ulong)b4 << 16) + ((ulong)b5 << 24) + ((ulong)b6 << 32) + ((ulong)b7 << 40);
            }
            byte b8 = reader.ReadByte();
            if (b == 254)
            {
                return (ulong)b2 + ((ulong)b3 << 8) + ((ulong)b4 << 16) + ((ulong)b5 << 24) + ((ulong)b6 << 32) + ((ulong)b7 << 40) + ((ulong)b8 << 48);
            }
            byte b9 = reader.ReadByte();
            if (b == 255)
            {
                return (ulong)b2 + ((ulong)b3 << 8) + ((ulong)b4 << 16) + ((ulong)b5 << 24) + ((ulong)b6 << 32) + ((ulong)b7 << 40) + ((ulong)b8 << 48) + ((ulong)b9 << 56);
            }
            throw new IndexOutOfRangeException("ReadPackedUInt64() failure: " + b);
        }

        public static long ReadPackedInt64(this BinaryReader reader)
        {
            byte b = reader.ReadByte();
            if (b < 241)
            {
                return (long)b;
            }
            byte b2 = reader.ReadByte();
            if (b >= 241 && b <= 248)
            {
                return 240L + 256L * ((long)b - 241L) + (long)b2;
            }
            byte b3 = reader.ReadByte();
            if (b == 249)
            {
                return 2288L + 256L * (long)b2 + (long)b3;
            }
            byte b4 = reader.ReadByte();
            if (b == 250)
            {
                return (long)b2 + ((long)b3 << 8) + ((long)b4 << 16);
            }
            byte b5 = reader.ReadByte();
            if (b == 251)
            {
                return (long)b2 + ((long)b3 << 8) + ((long)b4 << 16) + ((long)b5 << 24);
            }
            byte b6 = reader.ReadByte();
            if (b == 252)
            {
                return (long)b2 + ((long)b3 << 8) + ((long)b4 << 16) + ((long)b5 << 24) + ((long)b6 << 32);
            }
            byte b7 = reader.ReadByte();
            if (b == 253)
            {
                return (long)b2 + ((long)b3 << 8) + ((long)b4 << 16) + ((long)b5 << 24) + ((long)b6 << 32) + ((long)b7 << 40);
            }
            byte b8 = reader.ReadByte();
            if (b == 254)
            {
                return (long)b2 + ((long)b3 << 8) + ((long)b4 << 16) + ((long)b5 << 24) + ((long)b6 << 32) + ((long)b7 << 40) + ((long)b8 << 48);
            }
            byte b9 = reader.ReadByte();
            if (b == 255)
            {
                return (long)b2 + ((long)b3 << 8) + ((long)b4 << 16) + ((long)b5 << 24) + ((long)b6 << 32) + ((long)b7 << 40) + ((long)b8 << 48) + ((long)b9 << 56);
            }
            throw new IndexOutOfRangeException("ReadPackedUInt64() failure: " + b);
        }
    }
}
