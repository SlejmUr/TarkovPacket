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
            Int16 length = reader.ReadInt16();
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
    }
}
