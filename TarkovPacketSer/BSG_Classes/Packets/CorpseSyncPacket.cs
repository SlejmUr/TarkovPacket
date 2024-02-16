using System.Numerics;
using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct CorpseSyncPacket
    {

        public void Deserialize(IReaderStream reader, CorpseSyncPacket previousPacket)
        {
            this.Deserialize(reader, true, previousPacket);
        }

        public void Deserialize(IReaderStream reader)
        {
            this.Deserialize(reader, false, default(CorpseSyncPacket));
        }

        public void Deserialize(IReaderStream reader, bool hasPreviousPacket, CorpseSyncPacket previousPacket)
        {
            UsualPositionQuantizer.Read(reader, out this.Position);
            this.Done = reader.ReadBool();
            if (this.Done)
            {
                this.TransformSyncs = new PacketTransformSyncs[12];
                for (int i = 0; i < 12; i++)
                {
                    PacketTransformSyncs packetTransformSyncs = new();
                    UsualPositionQuantizer.Read(reader, out packetTransformSyncs.Position);
                    CorpseSyncPacket.gclass1172_0.Read(reader, out packetTransformSyncs.Rotation);
                    this.TransformSyncs[i] = packetTransformSyncs;
                }
            }
        }

        private const float float_0 = 5f;

        private const float float_1 = 25f;

        private static readonly UsualPositionQuantizer gclass1177_0 = new UsualPositionQuantizer(-5f, 5f, 0.001953125f, -5f, 5f, 0.0009765625f, -5f, 5f, 0.001953125f, true);

        private static readonly CorpseSyncPacketRotationQ gclass1172_0 = new CorpseSyncPacketRotationQ(0.015625f, BitPackingTag.CorpseSyncPacketRotationQuantizer);

        private const int int_0 = 12;

        public int Id;

        public Vector3 Position;

        public bool Done;

        public PacketTransformSyncs[] TransformSyncs;

        public bool IsNotValidPosition;

        private static readonly UsualPositionQuantizer UsualPositionQuantizer = new UsualPositionQuantizer(-448.0f, 752.0f, 0.001953125f, -250.0f, 250.0f, 0.0009765625f, -280.0f, 260.0f, 0.001953125f, true);

    }
}