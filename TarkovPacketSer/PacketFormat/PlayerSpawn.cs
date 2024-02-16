using ComponentAce.Compression.Libs.zlib;
using System.Numerics;
using TarkovPacketSer.BSG_Classes;

namespace TarkovPacketSer.PacketFormat
{
    public class PlayerSpawn
    {
        public static PlayerSpawnPacket Deserialize(byte[] data)
        {
            PlayerSpawnPacket packet = new PlayerSpawnPacket();
            BinaryReader binaryReader = new(new MemoryStream(data));
            packet.Id = binaryReader.ReadInt32();
            packet.ChannelId = binaryReader.ReadByte();
            packet.Position = binaryReader.ReadVector3();
            packet.ChannelId_2 = binaryReader.ReadByte();
            packet.IsAlive = binaryReader.ReadBoolean();
            packet.Pos2 = binaryReader.ReadVector3();
            packet.rotation = binaryReader.ReadQuaternion();
            packet.IsInPronePose = binaryReader.ReadBoolean();
            packet.PoseLevel = binaryReader.ReadSingle();
            packet.VoipState = binaryReader.ReadByte();
            packet.IsInBufferZone = binaryReader.ReadBoolean();
            packet.bufferZoneTimeLeft = binaryReader.ReadInt32();
            packet.MalfRandoms = new();
            packet.MalfRandoms.Deserialize(binaryReader);
            packet.leftStance = binaryReader.ReadBoolean();
            packet.InventoryZip = binaryReader.SafeReadSizeAndBytes();
            packet.profileZip = binaryReader.SafeReadSizeAndBytes();
            packet.searchInfoSerilationBytes = binaryReader.SafeReadSizeAndBytes();
            var now = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            try
            {
                File.WriteAllBytes($"PlayerSpawn_InventoryZip_{now}.txt", SimpleZlib.DecompressToBytes(packet.InventoryZip));
                File.WriteAllBytes($"PlayerSpawn_profileZip_{now}.txt", SimpleZlib.DecompressToBytes(packet.profileZip));
                File.WriteAllBytes($"PlayerSpawn_searchInfoSerilationBytes_{now}.txt", SimpleZlib.DecompressToBytes(packet.searchInfoSerilationBytes));
            }
            catch
            {

            }

            packet.mongoId = new(binaryReader);
            if (packet.IsAlive)
            {
                packet.aliveSpawn = new()
                {
                    unk = binaryReader.ReadBoolean(),
                    ScavExfilMask = binaryReader.ReadInt32(),
                    HealthState = binaryReader.SafeReadSizeAndBytes(),
                    AnimationVariant = binaryReader.ReadInt32(),
                    HandsControllerType = binaryReader.ReadByte(),
                    HasItemId = binaryReader.ReadBoolean(),
                };

                if (packet.aliveSpawn.HasItemId)
                {
                    packet.aliveSpawn.ItemId = binaryReader.ProperReadString();
                }

                if (packet.aliveSpawn.HandsControllerType == 2)
                {
                    packet.aliveSpawn.fireArm = new()
                    {
                        isInSpawnOperation = binaryReader.ReadBoolean(),
                        Flag = binaryReader.ReadBoolean()
                    };
                    if (packet.aliveSpawn.fireArm.Flag)
                    {
                        packet.aliveSpawn.fireArm.stationary = new()
                        {
                            StationaryRotation = binaryReader.ReadVector2(),
                            QuatY = binaryReader.ReadSingle(),
                            QuatW = binaryReader.ReadSingle(),
                        };
                    }
                    packet.aliveSpawn.StringArrayCount = binaryReader.ReadByte();
                    string[] array = new string[(int)packet.aliveSpawn.StringArrayCount];
                    for (int i = 0; i < (int)packet.aliveSpawn.StringArrayCount; i++)
                    {
                        array[i] = binaryReader.ProperReadString();
                    }
                    packet.aliveSpawn.Strings = array;
                }
            }
            binaryReader.Close();
            binaryReader.Dispose();
            return packet;
        }



    }


    public class PlayerSpawnPacket
    {
        public int Id;
        public byte ChannelId;
        public Vector3 Position;

        // initial state
        public byte ChannelId_2;
        public bool IsAlive;
        public Vector3 Pos2;
        public Quaternion rotation;
        public bool IsInPronePose;
        public float PoseLevel;
        public byte VoipState;
        public bool IsInBufferZone;
        public int bufferZoneTimeLeft;
        public MalfRandom MalfRandoms;
        public bool leftStance;
        public byte[] InventoryZip;
        public byte[] profileZip;
        public byte[] searchInfoSerilationBytes;
        public MongoID mongoId;
        public AliveSpawn aliveSpawn;
        public class MalfRandom
        {
            public void Deserialize(BinaryReader reader)
            {
                this._seed = reader.ReadInt32();
                this._nextSeed = reader.ReadInt32();
            }
            public int _seed;
            public int _nextSeed;
        }
        public class AliveSpawn
        {
            public bool unk;
            public int ScavExfilMask;
            public byte[] HealthState;
            public int AnimationVariant;
            public byte HandsControllerType;
            public bool HasItemId;
            public string ItemId;

            public FireArm fireArm;
            //fireArm
            public class FireArm
            {
                public bool isInSpawnOperation;
                public bool Flag;
                public Stationary? stationary;
                public class Stationary
                {
                    public Vector2 StationaryRotation;
                    public float QuatY;
                    public float QuatW;
                }
            }
            //firearm end

            public byte StringArrayCount;
            public string[] Strings;
        }
    }
}
