using TarkovPacketSer.RetardedBitReader;
using static TarkovPacketSer.BSG_Classes.Packets.DeserializerPacketsEXT;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    internal class SelfPlayerInfo
    {
        public static void Deserialize(IReaderStream reader, ref SelfPlayerInfo selfPlayerInfo)
        {
            if (reader.ReadBool())
            {
                selfPlayerInfo.RTT = new ushort?(reader.ReadUInt16());
                selfPlayerInfo.ServerFixedUpdate = reader.ReadLimitedInt32(0, 512);
                selfPlayerInfo.ServerTime = reader.ReadLimitedInt32(0, 512);
            }
            selfPlayerInfo.ServerWorldTime = reader.ReadFloat();
            bool flag = reader.ReadBool();
            bool flag2 = reader.ReadBool();
            bool flag3 = reader.ReadBool();
            bool flag4 = reader.ReadBool();
            bool flag5 = reader.ReadBool();
            bool flag6 = reader.ReadBool();
            if (flag)
            {
                selfPlayerInfo.HitInfos = new();
                int num = reader.ReadLimitedInt32(1, 16);
                for (int i = 0; i < num; i++)
                {
                    HitInfo hitInfo = new();
                    reader.Serialize(ref hitInfo);
                    selfPlayerInfo.HitInfos.Add(hitInfo);
                }
            }
            if (flag2)
            {
                selfPlayerInfo.ArmorUpdates = new();
                int num2 = reader.ReadLimitedInt32(1, 32);
                for (int j = 0; j < num2; j++)
                {
                    ArmorUpdate a = new();
                    reader.Serialize(ref a);
                    selfPlayerInfo.ArmorUpdates.Add(a);
                }
            }
            if (flag3)
            {
                selfPlayerInfo.PoisonUpdates = new();
                int num3 = reader.ReadLimitedInt32(1, 16);
                for (int k = 0; k < num3; k++)
                {
                    Update update = new();
                    reader.Serialize(ref update);
                    selfPlayerInfo.PoisonUpdates.Add(update);
                }
            }
            if (flag4)
            {
                selfPlayerInfo.DetailedHitInfo = new();
                int num4 = reader.ReadLimitedInt32(1, 16);
                for (int l = 0; l < num4; l++)
                {
                    DHitInfo d = new();
                    reader.Serialize(ref d);
                    selfPlayerInfo.DetailedHitInfo.Add(d);
                }
            }
            if (flag5)
            {
                selfPlayerInfo.OperationStatuses = new();
                int num5 = reader.ReadLimitedInt32(1, 32);
                for (int m = 0; m < num5; m++)
                {
                    StatusPacket operationStatus = new();
                    reader.Serialize(ref operationStatus);
                    selfPlayerInfo.OperationStatuses.Add(operationStatus);
                }
            }
            if (flag6)
            {
                selfPlayerInfo.GlobalOperations = new();
                int num6 = reader.ReadLimitedInt32(1, 32);
                for (int n = 0; n < num6; n++)
                {
                    int playerId = reader.ReadLimitedInt32(1, 255);
                    byte[] serializedDescriptor = new byte[reader.ReadLimitedInt32(1, 255)];
                    reader.SerializeBytesAndSize(ref serializedDescriptor, new uint?(1200U));
                    selfPlayerInfo.GlobalOperations.Add((playerId, serializedDescriptor));
                }
            }
            selfPlayerInfo.CommonPacket = reader.DeserializeCommonPacket();
            selfPlayerInfo.SyncHealthPacket = reader.DeserializeSyncHealthPacket();
            selfPlayerInfo.AcceptHitDebugDataPacket = reader.DeserializeAcceptHitDebugDataPacket();
            selfPlayerInfo.QuestConditionValueChangedPacket = reader.DeserializeQuestConditionValueChangedPacket();
            selfPlayerInfo.AchievementConditionValueChangedPacket = reader.DeserializeAchievementConditionValueChangedPacket();
            selfPlayerInfo.ShowStatNotificationPacket = reader.DeserializeShowStatNotificationPacket();
            selfPlayerInfo.PlayerDiedPacket = reader.DeserializePlayerDiedPacket();
            selfPlayerInfo.ClientConfirmCallbackPacket = reader.DeserializeClientConfirmCallbackPacket();
            selfPlayerInfo.WeaponOverheatPacket = reader.DeserializeWeaponOverheatPacket();
            selfPlayerInfo.ChangeSkillExperiencePacket = reader.DeserializeChangeSkillExperiencePacket();
            selfPlayerInfo.ChangeMasteringExperiencePacket = reader.DeserializeChangeMasteringLevelPacket();
            selfPlayerInfo.TradersInfoPacket = reader.DeserializeTradersInfoPacket();
            selfPlayerInfo.StringNotificationPacket = reader.DeserializeStringNotificationPacket();
            selfPlayerInfo.RadioTransmitterPacket = reader.DeserializeRadioTransmitterPacket();
            selfPlayerInfo.LighthouseTraderZoneDataPacket = reader.DeserializeLighthouseTraderZonePacket();
            selfPlayerInfo.LighthouseTraderZoneDebugToolPacket = reader.DeserializeighthouseTraderZoneDebugToolPacket();
            selfPlayerInfo.InteractWithBtrPacket = reader.DeserializeInteractWithBtrPacket();
            reader.Serialize(ref selfPlayerInfo.TalkDetected);
            if (reader.ReadBool())
            {
                selfPlayerInfo.CriticalPacketsProcessed = reader.ReadLimitedInt32(0, 7);
                return;
            }
            selfPlayerInfo.CriticalPacketsProcessed = reader.ReadLimitedInt32(0, 2047);
        }

        public ushort? RTT;

        public int ServerFixedUpdate;

        public int ServerTime;

        public float ServerWorldTime;

        public List<HitInfo> HitInfos;
        
        public List<DHitInfo> DetailedHitInfo;

        public List<ArmorUpdate> ArmorUpdates;

        public List<Update> PoisonUpdates;

        public List<StatusPacket> OperationStatuses;

        public List<ValueTuple<int, byte[]>> GlobalOperations;

        public CommonPacket CommonPacket;
        public SyncHealthPacket? SyncHealthPacket;

        public AcceptHitDebugDataPacket? AcceptHitDebugDataPacket;

        public QuestConditionValueChangedPacket? QuestConditionValueChangedPacket;

        public AchievementConditionValueChangedPacket? AchievementConditionValueChangedPacket;

        public ShowStatNotificationPacket? ShowStatNotificationPacket;

        public PlayerDiedPacket? PlayerDiedPacket;

        public ClientConfirmCallbackPacket? ClientConfirmCallbackPacket;

        public WeaponOverheatPacket? WeaponOverheatPacket;

        public SkillPacket? ChangeSkillExperiencePacket;

        public ChangeMasteringLevel? ChangeMasteringExperiencePacket;

        public TradersInfoPacket? TradersInfoPacket;

        public StringNotificationPacket? StringNotificationPacket;

        public RadioTransmitterPacket? RadioTransmitterPacket;

        public LighthouseTraderZoneDataPacket? LighthouseTraderZoneDataPacket;

        public LighthouseTraderZoneDebugToolPacket? LighthouseTraderZoneDebugToolPacket;

        public InteractWithBtrPacket? InteractWithBtrPacket;

        public bool TalkDetected;

        public int CriticalPacketsProcessed;


    }
}
