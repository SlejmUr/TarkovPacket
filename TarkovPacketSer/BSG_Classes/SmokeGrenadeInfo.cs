using System.Numerics;

namespace TarkovPacketSer.BSG_Classes
{
    public class SmokeGrenadeInfo
    {
        public void Deserialize(BinaryReader reader)
        {
            Id = reader.ProperReadString();
            Position = reader.ReadVector3();
            Template = reader.ProperReadString();
            Time = reader.ReadInt32();
            Orientation = reader.ReadQuaternion();
            PlatformId = reader.ReadInt16();
        }
        public string Id;
        public Quaternion Orientation;
        public Int16 PlatformId;
        public Vector3 Position;
        public String Template;
        public Int32 Time;
    }
}
