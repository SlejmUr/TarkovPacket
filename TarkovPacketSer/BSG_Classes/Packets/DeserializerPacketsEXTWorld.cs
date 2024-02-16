using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public static partial class DeserializerPacketsEXT
    {
        public static void DeserializeLootSyncPackets(this IReaderStream reader, List<PreviousPacket> packets, List<PreviousPacket> previousPackets)
        {
            if (!reader.ReadBool())
            {
                return;
            }
            int num = reader.ReadLimitedInt32(1, 64);
            for (int i = 0; i < num; i++)
            {
                PreviousPacket previousPacket = new PreviousPacket
                {
                    Id = reader.ReadInt32()
                };
                PreviousPacket previousPacket2;
                if (smethod_3(previousPackets, previousPacket.Id, out previousPacket2))
                {
                    previousPacket.Deserialize(reader, previousPacket2);
                }
                else
                {
                    previousPacket.Deserialize(reader);
                }
                packets.Add(previousPacket);
            }
        }

        private static bool smethod_3(List<PreviousPacket> packets, int id, out PreviousPacket found)
        {
            for (int i = 0; i < packets.Count; i++)
            {
                PreviousPacket previousPacket = packets[i];
                if (previousPacket.Id == id)
                {
                    found = previousPacket;
                    return true;
                }
            }
            found = new();
            return false;
        }

        public static void DeserializeCorpseSyncPackets(this IReaderStream reader, List<CorpseSyncPacket> packets, List<CorpseSyncPacket> previousPackets)
        {
            if (!reader.ReadBool())
            {
                return;
            }
            int num = reader.ReadLimitedInt32(1, 32);
            for (int i = 0; i < num; i++)
            {
                CorpseSyncPacket gstruct = new CorpseSyncPacket
                {
                    Id = reader.ReadInt32()
                };
                CorpseSyncPacket previousPacket;
                if (smethod_4(previousPackets, gstruct.Id, out previousPacket))
                {
                    gstruct.Deserialize(reader, previousPacket);
                }
                else
                {
                    gstruct.Deserialize(reader);
                }
                packets.Add(gstruct);
            }
        }

        private static bool smethod_4(List<CorpseSyncPacket> packets, int id, out CorpseSyncPacket found)
        {
            for (int i = 0; i < packets.Count; i++)
            {
                CorpseSyncPacket gstruct = packets[i];
                if (gstruct.Id == id)
                {
                    found = gstruct;
                    return true;
                }
            }
            found = new();
            return false;
        }

        public static void DeserializeGrenadeSyncPackets(this IReaderStream reader, List<GrenadeSyncPacket> packets, List<GrenadeSyncPacket> previousPackets)
        {
            if (!reader.ReadBool())
            {
                return;
            }
            int num = reader.ReadLimitedInt32(1, 32);
            for (int i = 0; i < num; i++)
            {
                GrenadeSyncPacket gstruct = new GrenadeSyncPacket
                {
                    Id = reader.ReadInt32()
                };
                GrenadeSyncPacket previousPacket;
                if (smethod_5(previousPackets, gstruct.Id, out previousPacket))
                {
                    gstruct.Deserialize(reader, previousPacket);
                }
                else
                {
                    gstruct.Deserialize(reader);
                }
                packets.Add(gstruct);
            }
        }
        private static bool smethod_5(List<GrenadeSyncPacket> packets, int id, out GrenadeSyncPacket found)
        {
            for (int i = 0; i < packets.Count; i++)
            {
                GrenadeSyncPacket gstruct = packets[i];
                if (gstruct.Id == id)
                {
                    found = gstruct;
                    return true;
                }
            }
            found = new();
            return false;
        }

        public static void DeserializePackets(this IReaderStream reader, List<BorderZonePacket> packets)
        {
            if (reader.ReadBool())
            {
                Console.WriteLine(reader.BitsRemain + " !!!!  BorderZonePacket");
                int num = reader.ReadLimitedInt32(0, 100);
                for (int i = 0; i < num; i++)
                {
                    packets.Add(new BorderZonePacket
                    {
                        Id = reader.ReadLimitedInt32(0, 100),
                        PlayerId = reader.ReadInt32(),
                        WillHit = reader.ReadBool()
                    });
                }
            }
        }

        public static void DeserializePackets(this IReaderStream reader, List<PlatformSyncPacket> packets)
        {
            if (reader.ReadBool())
            {
                Console.WriteLine(reader.BitsRemain + " !!!!  PlatformSyncPacket");
                int num = reader.ReadLimitedInt32(0, 1000);
                for (int i = 0; i < num; i++)
                {
                    packets.Add(new PlatformSyncPacket
                    {
                        Id = reader.ReadByte(),
                        Position = reader.ReadFloat()
                    });
                }
            }
        }
    }
}
