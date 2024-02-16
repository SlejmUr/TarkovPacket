using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct GameWorldPacket : IDisposable
    {
        public PacketPriority Priority { get; set; }

        public int PriorityCounter { get; set; }

        public bool HasData
        {
            get
            {
                return this.InteractiveObjectsStatusPacket != null || this.SpawnQuestLootPacket != null || this.UpdateExfiltrationPointPacket != null || this.LampChangeStatePacket != null || this.WindowHitPacket != null || this.LootSyncPackets.Count > 0 || this.CorpseSyncPackets.Count > 0 || this.GrenadeSyncPackets.Count > 0 || this.PlatformSyncPackets.Count > 0 || this.BorderZonePackets.Count > 0 || this.SynchronizableObjectPackets.Count > 0;
            }
        }

        public static GameWorldPacket Create()
        {
            return new GameWorldPacket
            {
                LootSyncPackets = new(),
                CorpseSyncPackets = new(),
                GrenadeSyncPackets = new(),
                PlatformSyncPackets = new(),
                BorderZonePackets = new(),
                SynchronizableObjectPackets = new()
            };
        }

        public void Dispose()
        {
            if (this.LootSyncPackets != null)
            {
                this.LootSyncPackets = null;
            }
            if (this.SynchronizableObjectPackets != null)
            {
                this.SynchronizableObjectPackets = null;
            }
            if (this.CorpseSyncPackets != null)
            {
                this.CorpseSyncPackets = null;
            }
            if (this.GrenadeSyncPackets != null)
            {
                this.GrenadeSyncPackets = null;
            }
            if (this.PlatformSyncPackets != null)
            {
                this.PlatformSyncPackets = null;
            }
            if (this.BorderZonePackets != null)
            {
                this.BorderZonePackets = null;
            }
        }

        public GameWorldPacket Clone()
        {
            GameWorldPacket gameWorldPacket = this;
            gameWorldPacket.LootSyncPackets = new();
            gameWorldPacket.LootSyncPackets.AddRange(this.LootSyncPackets);
            gameWorldPacket.CorpseSyncPackets = new();
            gameWorldPacket.CorpseSyncPackets.AddRange(this.CorpseSyncPackets);
            gameWorldPacket.GrenadeSyncPackets = new();
            gameWorldPacket.GrenadeSyncPackets.AddRange(this.GrenadeSyncPackets);
            gameWorldPacket.PlatformSyncPackets = new();
            gameWorldPacket.PlatformSyncPackets.AddRange(this.PlatformSyncPackets);
            gameWorldPacket.BorderZonePackets = new();
            gameWorldPacket.BorderZonePackets.AddRange(this.BorderZonePackets);
            gameWorldPacket.SynchronizableObjectPackets = new();
            gameWorldPacket.SynchronizableObjectPackets.AddRange(this.SynchronizableObjectPackets);
            return gameWorldPacket;
        }

        public float RemoteTime;

        public InteractiveObjectsStatusPacket? InteractiveObjectsStatusPacket;

        public SpawnQuestLootPacket? SpawnQuestLootPacket;

        public UpdateExfiltrationPointPacket? UpdateExfiltrationPointPacket;

        public LampChangeStatePacket? LampChangeStatePacket;

        public WindowHitPacket? WindowHitPacket;

        public List<PreviousPacket> LootSyncPackets;

        public List<CorpseSyncPacket> CorpseSyncPackets;

        public List<GrenadeSyncPacket> GrenadeSyncPackets;

        public List<PlatformSyncPacket> PlatformSyncPackets;

        public List<BorderZonePacket> BorderZonePackets;

        public List<SynchronizableObjectPacket> SynchronizableObjectPackets;
    }
}
