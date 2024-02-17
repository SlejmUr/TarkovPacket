using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarkovPacketSer.BSG_Classes.Packets;

namespace TarkovPacketSer.BSG_Classes.ReadWriteDescriptor.DescriptorClasses
{
    [Serializable]
    public class ClassTransformSync
    {

        public PacketTransformSyncs ToUnity()
        {
            return new PacketTransformSyncs
            {
                Position = this.Position.ToUnityVector3(),
                Rotation = this.Rotation.ToUnityQuaternion()
            };
        }

        public static ClassTransformSync FromUnity(PacketTransformSyncs transformSync)
        {
            return new ClassTransformSync
            {
                Position = transformSync.Position,
                Rotation = transformSync.Rotation
            };
        }

        public static PacketTransformSyncs[] ToUnity(ClassTransformSync[] syncs)
        {
            PacketTransformSyncs[] array = new PacketTransformSyncs[syncs.Length];
            for (int i = 0; i < syncs.Length; i++)
            {
                ClassTransformSync classTransformSync = syncs[i];
                array[i] = classTransformSync.ToUnity();
            }
            return array;
        }

        public static ClassTransformSync[] FromUnity(PacketTransformSyncs[] syncs)
        {
            ClassTransformSync[] array = new ClassTransformSync[syncs.Length];
            for (int i = 0; i < syncs.Length; i++)
            {
                PacketTransformSyncs transformSync = syncs[i];
                array[i] = ClassTransformSync.FromUnity(transformSync);
            }
            return array;
        }

        public ClassVector3 Position;

        public ClassQuaternion Rotation;
    }
}
