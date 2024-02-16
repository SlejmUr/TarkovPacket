using System.Numerics;
using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct PreviousPacket
    {
        public void Deserialize(IReaderStream reader, PreviousPacket previousPacket)
        {
            this.method_1(reader, true, previousPacket);
        }
        public void Deserialize(IReaderStream reader)
        {
            this.method_1(reader, false, new());
        }

        private void method_1(IReaderStream reader, bool hasPreviousPacket, PreviousPacket previousPacket)
        {
            UsualPositionQuantizer.Read(reader, out this.Position);
            gclass1172_0.Read(reader, out this.Rotation);
            this.Done = reader.ReadBool();
            if (!this.Done)
            {
                gclass1177_1.Read(reader, out this.Velocity);
                gclass1177_2.Read(reader, out this.AngularVelocity);
            }
        }

        // Token: 0x04006BD8 RID: 27608
        public int Id;

        // Token: 0x04006BD9 RID: 27609
        public Vector3 Position;

        // Token: 0x04006BDA RID: 27610
        public Quaternion Rotation;

        // Token: 0x04006BDB RID: 27611
        public Vector3 Velocity;

        // Token: 0x04006BDC RID: 27612
        public Vector3 AngularVelocity;

        // Token: 0x04006BDD RID: 27613
        public bool Done;

        // Token: 0x04006BDE RID: 27614
        private const float float_0 = 5f;

        // Token: 0x04006BDF RID: 27615
        private const float float_1 = 25f;
        private static readonly UsualPositionQuantizer UsualPositionQuantizer = new UsualPositionQuantizer(-448.0f, 752.0f, 0.001953125f, -250.0f, 250.0f, 0.0009765625f, -280.0f, 260.0f, 0.001953125f, true);
        private static readonly UsualPositionQuantizer gclass1177_0 = new UsualPositionQuantizer(-5f, 5f, 0.001953125f, -5f, 5f, 0.0009765625f, -5f, 5f, 0.001953125f, true);

        // Token: 0x04006BE1 RID: 27617
        private static readonly LootSyncPacketRotationQ gclass1172_0 = new LootSyncPacketRotationQ(0.015625f, BitPackingTag.LootSyncPacketRotationQuantizer);

        // Token: 0x04006BE2 RID: 27618
        private static readonly UsualPositionQuantizer gclass1177_1 = new UsualPositionQuantizer(-30f, 30f, 0.125f, -30f, 10f, 0.125f, -30f, 30f, 0.125f, true);

        // Token: 0x04006BE3 RID: 27619
        private static readonly UsualPositionQuantizer gclass1177_2 = new UsualPositionQuantizer(-160f, 160f, 0.125f, -160f, 160f, 0.125f, -160f, 160f, 0.125f, true);
    }
}