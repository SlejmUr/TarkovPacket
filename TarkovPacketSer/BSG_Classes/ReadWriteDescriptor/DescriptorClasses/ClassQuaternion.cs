using System.Numerics;

namespace TarkovPacketSer.BSG_Classes.ReadWriteDescriptor.DescriptorClasses
{
    [Serializable]
    public sealed class ClassQuaternion
    {
        public Quaternion ToUnityQuaternion()
        {
            return new Quaternion(this.x, this.y, this.z, this.w);
        }

        public static ClassQuaternion FromUnityQuaternion(Quaternion q)
        {
            return new ClassQuaternion
            {
                x = q.X,
                y = q.Y,
                z = q.Z,
                w = q.W
            };
        }

        public static implicit operator Quaternion(ClassQuaternion q)
        {
            return q.ToUnityQuaternion();
        }

        public static implicit operator ClassQuaternion(Quaternion q)
        {
            return new ClassQuaternion
            {
                x = q.X,
                y = q.Y,
                z = q.Z,
                w = q.W
            };
        }

        public float x;

        public float y;

        public float z;

        public float w;
    }
}
