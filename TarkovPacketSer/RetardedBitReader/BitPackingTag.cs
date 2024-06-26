﻿namespace TarkovPacketSer.RetardedBitReader
{
    public enum BitPackingTag
    {

        Unknown,

        DebugBotStruct1,

        DebugBotStruct2,

        DebugBotStruct3,

        DebugBotStruct4,

        DebugBotStruct5,

        DebugBotStruct6,

        DebugBotStruct7,

        DebugBotStruct8,

        DebugBotStruct9,

        DebugBotStruct10,

        DebugBotStruct11,

        DebugBotStruct12,

        DebugBotStruct13,

        DebugBotStruct14,

        DebugBotStruct15,

        DebugBotStruct16,

        DebugBotStruct17,

        DebugBotStruct18,

        DebugBotSpawnStructDataAlive,

        DebugBotSpawnStructDataProfileWait,

        DebugBotSpawnStructDataDelayed,

        DebugBotSpawnStructDataSpawnProcess,

        DebugBotSpawnStructDataSpawnHour,

        DebugBotSpawnStructDataGroupsCount,

        DebugBotSpawnStructDataGroupsCountArray,

        DebugBotSpawnStructDataSpawnBundlesWait,

        DebugGroupStructA,

        DebugGroupStructB,

        DebugGroupStructC,

        DebugGroupStructD,

        DebugGroupStructF,

        DebugGroupStructG,

        DebugGroupStructGE,

        DebugGroupStructGN,

        DebugGroupStructGA,

        GameWorldPacketExtension1,

        GameWorldPacketExtension2,

        GameWorldPacketExtension3,

        GameWorldPacketExtension4,

        QuaternionQuantizer,

        WriteUInt32UsingBitRange1,

        WriteUInt32UsingBitRange2,

        PhraseCommandPacket0,

        PhraseCommandPacket1,

        LimitedIntSettings,

        Client2ServerPacket0,

        Client2ServerPacket1,

        Client2ServerPacket2,

        Client2ServerPacket3,

        InteractWithDoorPacket0,

        InteractWithDoorPacket1,

        MovementInfoPacket0,

        MovementInfoPacket1,

        MovementInfoPacket2,

        MovementInfoPacket3,

        HandsChangePacket0,

        HandsChangePacket1,

        HandsChangePacket2,

        HandsChangePacket3,

        HandsChangePacket4,

        HandsChangePacket5,

        HandsChangePacket6,

        HandsChangePacket7,

        HandsChangePacket8,

        HandsChangePacket9,

        HandsChangePacket10,

        HandsChangePacket11,

        HandsChangePacket12,

        HandsChangePacket13,

        HandsChangePacket14,

        HandsChangePacket15,

        HandsChangePacket16,

        HandsChangePacket17,

        HandsChangePacket18,

        HandsChangePacket19,

        HandsChangePacket20,

        HandsChangePacket21,

        HandsChangePacket22,

        HandsChangePacket23,

        SelfPlayerInfo0,

        SelfPlayerInfo1,

        SelfPlayerInfo2,

        SelfPlayerInfo3,

        SelfPlayerInfo4,

        SelfPlayerInfo5,

        DetailedHitInfo0,

        DetailedHitInfo1,

        DetailedHitInfo2,

        DetailedHitInfo3,

        DetailedHitInfo4,

        InventoryOperationStatus,

        ServerWorld0,

        ServerWorld1,

        DebugBotDataSender0,

        DebugBotDataSender1,

        DebugBotDataSender2,

        DataSender0,

        DataSender1,

        DataSender2,

        DataSender3,

        ServerFixedUpdate,

        ServerTime,

        TrajectoryLengthSettings,

        DamageSerializationSettings,

        StaminaBurnRateSerializationSettings,

        PenetrationPowerSerializationSettings,

        ArmorDamageSerializationSettings,

        HitCosSerializationSettings,

        BulletMassGram,

        BulletDiameterMilimeters,

        BallisticCoefficient,

        DurationSettings,

        PoseLevelSettings,

        SpeedSettings,

        TiltSettings,

        DeltaTimeSettings,

        AddEffectEffectId,

        RemoveEffect,

        EffectNextState,

        EffectStateTime,

        EffectStrengthEffectId,

        EffectMedResourceEffectId,

        EffectStimulatorBuff0,

        EffectStimulatorBuff1,

        HealerDone,

        ToggleTacticalComboPacket0,

        SelectedMode,

        ScopeCalibrationIndex,

        SelectedMode0,

        ScopeIndexInsideSight0,

        ScopeCalibrationIndex0,

        SightsModePacketLength,

        AmmoIdsLength,

        AmmoLoadedToMag,

        BorderZonePacketPacketId,

        IClientPlayerDataSenderPacketsCount,

        LootSyncPacketRotationQuantizer,

        CorpseSyncPacketRotationQuantizer,

        GrenadeSyncPacketRotationQuantizer,

        AddEffectStrength,

        EffectStrengthStrength,

        EffectMedResourceResource,

        BodyHealth,

        Energy,

        Hydration,

        Temperature,

        Poison,

        HealthRatesHealRate,

        HealthRatesDamageRate,

        HealthRatesDamageMultiplier,

        HealthRatesEnergy,

        HealthRatesHydration,

        HealthRatesTemperature,

        ArmorUpdateDurability,

        HeadRotationX,

        HeadRotationY,

        ShotInfoFragmentId,

        ShotInfoShotsCount,

        InteractiveObjectsCount,

        LauncherReloadInfoAmmoIds,

        ArmorUpdateId,

        PoisonUpdateId,

        PoisonUpdateResource,

        InventoryOperationStatusError,

        DebugGroupStructName,

        DebugGroupStructEnemiesCountId,

        DebugBotStructName,

        DebugBotStructTarget,

        DebugBotStructProfileId,

        DebugBotStructNodeInfo,

        DebugBotStructNodeReasonInfo,

        DebugBotStructFightType,

        MedEffectItemId,

        StimulatorBuffsName,

        EInteractionTypeItemId,

        HandsChangePacketItemId,

        QuickReloadMagMagId,

        TacticalComboStatusId,

        SightModeStatusId,

        ReloadMagPacketMagId,

        ReloadBarrelsAmmoId,

        ReloadWithAmmoAmmoIds,

        SearchedStateKey,

        SearchableItemInfoId,

        KnownItemsArrayString,

        KnownItemsDictKey,

        SearchableGridInfoId,

        KnownItemsDictValue,

        DebugZoneInfoStructZonesCount,

        DebugZoneInfoStructWildTypesCount,

        DebugZoneInfoStructZoneName,

        DebugZoneInfoStructBlockElement,

        DebugBotStructHandsAnim,

        DebugBotStructShotNameWeapon,

        const_195,

        const_196,

        ChamberFireIndex,

        Overheat,

        Halloween,

        CamoraIndex,

        Airplane,

        DevelopSynchronizableData,

        Airdrop,

        SyncPacketObjectId,

        GameWorldPacketSyncObjectsPacketsCount,

        ConditionValue1,

        ConditionValue2,

        WeaponOverlap,

        DataProvider,

        InteractWithBtr
    }
}
