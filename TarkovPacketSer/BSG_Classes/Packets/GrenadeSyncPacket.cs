using System.Numerics;
using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct GrenadeSyncPacket
    {
        public void Deserialize(IReaderStream reader, GrenadeSyncPacket previousPacket)
        {
            this.method_1(reader, true, previousPacket);
        }

        // Token: 0x0600735C RID: 29532 RVA: 0x00221D30 File Offset: 0x0021FF30
        public void Deserialize(IReaderStream reader)
        {
            this.method_1(reader, false, new());
        }

        // Token: 0x0600735D RID: 29533 RVA: 0x00221D50 File Offset: 0x0021FF50
        private void method_1(IReaderStream reader, bool hasPreviousPacket, GrenadeSyncPacket previousPacket)
        {
            UsualPositionQuantizer.Read(reader, out this.Position);
            gclass1172_0.Read(reader, out this.Rotation);
            this.Done = reader.ReadBool();
            if (!this.Done)
            {
                gclass1177_1.Read(reader, out this.Velocity);
                gclass1177_2.Read(reader, out this.AngularVelocity);
                this.CollisionNumber = reader.ReadByte();
            }
        }
        public int Id;

        // Token: 0x04006BEF RID: 27631
        public Vector3 Position;

        // Token: 0x04006BF0 RID: 27632
        public Quaternion Rotation;

        // Token: 0x04006BF1 RID: 27633
        public Vector3 Velocity;

        // Token: 0x04006BF2 RID: 27634
        public Vector3 AngularVelocity;

        // Token: 0x04006BF3 RID: 27635
        public byte CollisionNumber;

        // Token: 0x04006BF4 RID: 27636
        public bool Done;

        // Token: 0x04006BF5 RID: 27637
        private const float float_0 = 10f;

        // Token: 0x04006BF6 RID: 27638
        private const float float_1 = 100f;

        // Token: 0x04006BF7 RID: 27639
        private static readonly UsualPositionQuantizer gclass1177_0 = new UsualPositionQuantizer(-10f, 10f, 0.001953125f, -10f, 10f, 0.0009765625f, -10f, 10f, 0.001953125f, true);

        // Token: 0x04006BF8 RID: 27640
        private static readonly GrenadeSyncPacketRotationQ gclass1172_0 = new GrenadeSyncPacketRotationQ(0.015625f, BitPackingTag.GrenadeSyncPacketRotationQuantizer);

        // Token: 0x04006BF9 RID: 27641
        private static readonly UsualPositionQuantizer gclass1177_1 = new UsualPositionQuantizer(-80f, 80f, 0.125f, -80f, 80f, 0.125f, -80f, 80f, 0.125f, true);

        // Token: 0x04006BFA RID: 27642
        private static readonly UsualPositionQuantizer gclass1177_2 = new UsualPositionQuantizer(-500f, 500f, 0.125f, -500f, 500f, 0.125f, -500f, 500f, 0.125f, true);

        private static readonly UsualPositionQuantizer UsualPositionQuantizer = new UsualPositionQuantizer(-448.0f, 752.0f, 0.001953125f, -250.0f, 250.0f, 0.0009765625f, -280.0f, 260.0f, 0.001953125f, true);

    }
}