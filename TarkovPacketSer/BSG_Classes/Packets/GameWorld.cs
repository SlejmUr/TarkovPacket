using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarkovPacketSer.BSG_Enums;
using TarkovPacketSer.Enums;
using TarkovPacketSer.RetardedBitReader;
using static TarkovPacketSer.BSG_Classes.Packets.DeserializerPacketsEXT;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    internal static class GameWorld
    {
        public static GameWorldPacket DeserializeGameWorldPacket(this IReaderStream reader, GameWorldPacket previousPacket)
        {
            GameWorldPacket gameWorldPacket = GameWorldPacket.Create();
            gameWorldPacket.RemoteTime = reader.ReadFloat();
            gameWorldPacket.InteractiveObjectsStatusPacket = reader.DeserializeInteractiveObjectsStatusPacket();
            gameWorldPacket.SpawnQuestLootPacket = reader.DeserializeSpawnQuestLootPacket();
            gameWorldPacket.UpdateExfiltrationPointPacket = reader.DeserializeUpdateExfiltrationPointPacket();
            gameWorldPacket.LampChangeStatePacket = reader.DeserializeLampChangeStatePacket();
            gameWorldPacket.WindowHitPacket = reader.DeserializeWindowHitPacket();
            reader.DeserializeLootSyncPackets(gameWorldPacket.LootSyncPackets, previousPacket.LootSyncPackets);
            reader.DeserializeCorpseSyncPackets(gameWorldPacket.CorpseSyncPackets, previousPacket.CorpseSyncPackets);
            reader.DeserializeGrenadeSyncPackets(gameWorldPacket.GrenadeSyncPackets, previousPacket.GrenadeSyncPackets);
            reader.DeserializePackets(gameWorldPacket.PlatformSyncPackets);
            reader.DeserializePackets(gameWorldPacket.BorderZonePackets);
            reader.Serialize(gameWorldPacket.SynchronizableObjectPackets);
            return gameWorldPacket;
        }
        public static InteractiveObjectsStatusPacket? DeserializeInteractiveObjectsStatusPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            short num = reader.ReadInt16();
            byte[] array = new byte[(int)num];
            reader.ReadBytes(array, 0, (int)num);
            return new InteractiveObjectsStatusPacket?(new InteractiveObjectsStatusPacket
            {
                Segment = new ArraySegment<byte>(array)
            });
        }

        public static SpawnQuestLootPacket? DeserializeSpawnQuestLootPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new SpawnQuestLootPacket?(new SpawnQuestLootPacket
            {
                Item = reader.ReadBytesAlloc(new uint?(1200U))
            });
        }

        public static UpdateExfiltrationPointPacket? DeserializeUpdateExfiltrationPointPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            string pointName = reader.ReadString(new uint?(1200U));
            EExfiltrationStatus command = (EExfiltrationStatus)reader.ReadByte();
            byte b = reader.ReadByte();
            List<string> list = new List<string>();
            for (int i = 0; i < (int)b; i++)
            {
                list.Add(reader.ReadString(new uint?(1200U)));
            }
            var nested = reader.Deserialize(new DelegateRead<UpdateExfiltrationPointPacket>(DeserializeUpdateExfiltrationPointPacket));
            return new UpdateExfiltrationPointPacket?(new UpdateExfiltrationPointPacket
            {
                PointName = pointName,
                Command = command,
                QueuedPlayers = list,
                Nested = nested
            });
        }

        public static LampChangeStatePacket? DeserializeLampChangeStatePacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new LampChangeStatePacket?(new LampChangeStatePacket
            {
                NetId = reader.ReadInt32(),
                State = (ELampState)reader.ReadByte(),
                Nested = reader.Deserialize(new DelegateRead<LampChangeStatePacket>(DeserializeLampChangeStatePacket))
            });
        }

        public static WindowHitPacket? DeserializeWindowHitPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new WindowHitPacket?(new WindowHitPacket
            {
                NetId = reader.ReadInt32(),
                HitPosition = reader.ReadVector3(),
                Nested = reader.Deserialize(new DelegateRead<WindowHitPacket>(DeserializeWindowHitPacket))
            });
        }


        public static void Serialize(this ISerializer2 stream, List<SynchronizableObjectPacket> packets)
        {
            int num = (packets != null) ? packets.Count : 0;
            bool flag = num > 0;
            stream.Serialize(ref flag);
            if (flag)
            {
                stream.SerializeLimitedInt32(ref num, 1, 64, BitPackingTag.GameWorldPacketSyncObjectsPacketsCount);
                EBitStreamMode streamMode = stream.StreamMode;
                if (stream.StreamMode == EBitStreamMode.Writing)
                {
                    for (int i = 0; i < num; i++)
                    {
                        SynchronizableObjectPacket packet = packets[i];
                        stream.Serialize(ref packet);
                    }
                    return;
                }
                for (int j = 0; j < num; j++)
                {
                    SynchronizableObjectPacket item = new();
                    stream.Serialize(ref item);
                    packets.Add(item);
                }
            }
        }


        public static void Serialize(this ISerializer2 stream, ref SynchronizableObjectPacket packet)
        {
            stream.Serialize(ref packet.Develop);
            if (packet.Develop)
            {
                stream.Serialize(ref packet.PacketData.DevelopDataPacket);
                return;
            }
            stream.Serialize<ESynchronizableObjectType>(ref packet.ObjectType);
            if (packet.ObjectType == ESynchronizableObjectType.AirDrop)
            {
                stream.Serialize(ref packet.PacketData.AirdropDataPacket);
            }
            else
            {
                stream.Serialize(ref packet.PacketData.AirplaneDataPacket);
            }
            stream.SerializeLimitedInt32(ref packet.ObjectId, 0, 127, BitPackingTag.SyncPacketObjectId);
            stream.Serialize(ref packet.Position);
            stream.Serialize(ref packet.Rotation);
            stream.Serialize<ESynchronizableObjectType>(ref packet.ObjectType);
            stream.Serialize(ref packet.Outdated);
            stream.Serialize(ref packet.IsStatic);
        }

        public static void Serialize(this ISerializer2 stream, ref AirdropDataPacket packet)
        {
            stream.Serialize(ref packet.SignalFire);
            stream.Serialize<EAirdropFallingStage>(ref packet.FallingStage);
            stream.Serialize<EAirdropType>(ref packet.AirdropType);
            stream.SerializeLimitedInt32(ref packet.UniqueId, 0, 15, BitPackingTag.Airdrop);
        }

        public static void Serialize(this ISerializer2 stream, ref AirplaneDataPacket packet)
        {
            stream.SerializeLimitedInt32(ref packet.AirplanePercent, 0, 100, BitPackingTag.Airplane);
        }

        public static void Serialize(this ISerializer2 stream, ref DevelopDataPacket packet)
        {
            stream.SerializeLimitedInt32(ref packet.NextAirdropTimeRemaining, 0, 8191, BitPackingTag.DevelopSynchronizableData);
            stream.Serialize(ref packet.NextAirdropTimeByFlare);
        }
    }
}
