using System.Numerics;

namespace TarkovPacketSer.BSG_Classes
{
    public class AirDrop
    {
        public void Deserialize(BinaryReader reader)
        {
            Id = reader.ReadUInt16();
            Position = reader.ReadVector3();
            Rotation = ToQuaternion(reader.ReadVector3());
            UniqueId = (int)reader.ReadByte(); 
            AirDropType = reader.ReadByte();
            ObjectId = reader.ReadByte();
            IdString = reader.ProperReadString();
            IsStatic = reader.ReadBoolean();
            Item_Part1 = reader.SafeReadSizeAndBytes();
            Item_Part2 = reader.SafeReadSizeAndBytes();
        }
        public UInt16 Id;
        public Vector3 Position;
        public Quaternion Rotation;
        public int UniqueId;
        public byte AirDropType;
        public byte ObjectId;
        public string IdString;
        public bool IsStatic;
        public byte[] Item_Part1;
        public byte[] Item_Part2;

        public static Quaternion ToQuaternion(Vector3 v)
        {

            float cy = (float)Math.Cos(v.Z * 0.5);
            float sy = (float)Math.Sin(v.Z * 0.5);
            float cp = (float)Math.Cos(v.Y * 0.5);
            float sp = (float)Math.Sin(v.Y * 0.5);
            float cr = (float)Math.Cos(v.X * 0.5);
            float sr = (float)Math.Sin(v.X * 0.5);

            return new Quaternion
            {
                W = (cr * cp * cy + sr * sp * sy),
                X = (sr * cp * cy - cr * sp * sy),
                Y = (cr * sp * cy + sr * cp * sy),
                Z = (cr * cp * sy - sr * sp * cy)
            };

        }
    }
}
