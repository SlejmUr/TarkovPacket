using System.Numerics;
using System;
using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    internal class LootSyncPacketRotationQ
    {
        public LootSyncPacketRotationQ(float resolution, BitPackingTag tag)
        {
            this.Resolution = resolution;
            this.tag = tag;
        }
        public void Read(IReaderStream reader, out Quaternion quaternion)
        {
            quaternion = Quaternion.Identity;
            int num = reader.ReadLimitedInt32(0, 3);
            float num2 = 0f;
            for (int i = 0; i < 4; i++)
            {
                if (i != num)
                {
                    float num3 = reader.ReadLimitedFloat(-1f, 1f, this.Resolution);
                    quaternion[i] = num3;
                    num2 += num3 * num3;
                }
            }
            quaternion[num] = MathF.Sqrt(1f - num2);
        }

        // Token: 0x040060BC RID: 24764
        private float Resolution;

        // Token: 0x040060BD RID: 24765
        private readonly BitPackingTag tag;
    }
}