using System.Numerics;
using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public class GrenadeSyncPacketRotationQ
    {
        public GrenadeSyncPacketRotationQ(float resolution, BitPackingTag tag)
        {
            this.float_0 = resolution;
            this.bitPackingTag_0 = tag;
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
                    float num3 = reader.ReadLimitedFloat(-1f, 1f, this.float_0);
                    quaternion[i] = num3;
                    num2 += num3 * num3;
                }
            }
            quaternion[num] = MathF.Sqrt(1f - num2);
        }

        // Token: 0x040060BC RID: 24764
        private float float_0;

        // Token: 0x040060BD RID: 24765
        private readonly BitPackingTag bitPackingTag_0;
    }
}