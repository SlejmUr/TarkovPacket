using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.BSG_Classes.ReadWriteDescriptor.DescriptorClasses
{
    [Serializable]
    public sealed class WeightedLootPointSpawnPosition
    {

        public WeightedLootPointSpawnPosition()
        {
        }

        public WeightedLootPointSpawnPosition(Vector3 position, Vector3 rotationEuler, float weight, string name)
        {
            this.Position = position;
            this.Rotation = rotationEuler;
            this.Weight = weight;
            this.Name = name;
        }

        public string Name;

        public float Weight;

        public ClassVector3 Position;

        public ClassVector3 Rotation;
    }
}
