using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.BSG_Classes.ReadWriteDescriptor.DescriptorClasses
{
    [Serializable]
    public sealed class ClassVector3
    {

        public Vector3 ToUnityVector3()
        {
            return new Vector3(this.x, this.y, this.z);
        }

        public ClassVector3 Clone()
        {
            return new ClassVector3
            {
                x = this.x,
                y = this.y,
                z = this.z
            };
        }

        public static ClassVector3 FromUnityVector3(Vector3 v)
        {
            return new ClassVector3
            {
                x = v.X,
                y = v.Y,
                z = v.Z
            };
        }

        public static implicit operator Vector3(ClassVector3 vec)
        {
            return vec.ToUnityVector3();
        }

        public static implicit operator ClassVector3(Vector3 vec)
        {
            return ClassVector3.FromUnityVector3(vec);
        }

        public static Vector3 operator -(ClassVector3 a, ClassVector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public float x;

        public float y;

        public float z;
    }
}
