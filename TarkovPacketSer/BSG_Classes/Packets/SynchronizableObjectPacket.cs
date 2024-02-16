using System.Numerics;
using System.Runtime.InteropServices;
using TarkovPacketSer.Enums;
using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct SynchronizableObjectPacket
    {
        public bool Develop;

        public int ObjectId;

        public Vector3 Position;

        public Vector3 Rotation;

        public ESynchronizableObjectType ObjectType;

        public bool Outdated;

        public bool IsStatic;

        public PacketDataStruct PacketData;

        private static readonly LootSyncQ LootSync = new LootSyncQ(0.015625f, BitPackingTag.LootSyncPacketRotationQuantizer);

        public struct PacketDataStruct
        {
            public AirplaneDataPacket AirplaneDataPacket;
            public AirdropDataPacket AirdropDataPacket;
            public DevelopDataPacket DevelopDataPacket;
        }
    }
}