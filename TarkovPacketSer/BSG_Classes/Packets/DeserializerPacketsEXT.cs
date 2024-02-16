using TarkovPacketSer.BSG_Enums;
using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public static partial class DeserializerPacketsEXT
    {
        public static CommonPacket DeserializeCommonPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return CommonPacket.Deserialize(reader);
        }

        public static SearchingAction? DeserializeStartSearchingActionPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new SearchingAction?(new SearchingAction
            {
                ItemId = reader.ReadString(),
                Nested = reader.Deserialize(new DelegateRead<SearchingAction>(DeserializeStartSearchingActionPacket))
            });
        }

        public static SearchingAction? DeserializeStopSearchingActionPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new SearchingAction?(new SearchingAction
            {
                ItemId = reader.ReadString(),
                Nested = reader.Deserialize(new DelegateRead<SearchingAction>(DeserializeStopSearchingActionPacket))
            });
        }

        public static UpdateAccessStatus? DeserializeUpdateAccessStatusPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new UpdateAccessStatus?(new UpdateAccessStatus
            {
                ItemId = reader.ReadString(),
                State = (SearchedState)reader.ReadByte(),
                Nested = reader.Deserialize(new DelegateRead<UpdateAccessStatus>(DeserializeUpdateAccessStatusPacket))
            });
        }

        public static SetSearched? DeserializeSetSearchedPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new SetSearched?(new SetSearched
            {
                ItemId = reader.ReadString(),
                GridId = new GridId
                {
                    Id = reader.ReadString(),
                    ParentId = reader.ReadString(),
                },
                Silent = reader.ReadBool(),
                Nested = reader.Deserialize(new DelegateRead<SetSearched>(DeserializeSetSearchedPacket))
            });
        }

        public static StopSearching? DeserializeStopSearchingPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new StopSearching?(default(StopSearching));
        }

        public static SyncPosition? DeserializeSyncPositionPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new SyncPosition?(new SyncPosition
            {
                Iteration = reader.ReadByte(),
                Position = reader.ReadVector3(),
                Reason = (SyncPositionReason)reader.ReadInt32(),
            });
        }

        public static SwitchRenderers? DeserializeSwitchRenderersPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new SwitchRenderers?(new SwitchRenderers
            {
                Value = reader.ReadBool()
            });
        }

        public static SkillPacket? DeserializeChangeSkillExperiencePacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new SkillPacket?(new SkillPacket
            {
                SkillId = reader.ReadByte(),
                Value = reader.ReadFloat(),
                Effectiveness = reader.ReadFloat(),
                Nested = reader.Deserialize(new DelegateRead<SkillPacket>(DeserializeChangeSkillExperiencePacket))
            });
        }
        public static ChangeMasteringLevel? DeserializeChangeMasteringLevelPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new ChangeMasteringLevel?(new ChangeMasteringLevel
            {
                GroupName = reader.ReadString(),
                Value = reader.ReadFloat(),
                Nested = reader.Deserialize(new DelegateRead<ChangeMasteringLevel>(DeserializeChangeMasteringLevelPacket))
            });
        }

        public static SyncHealthPacket? DeserializeSyncHealthPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            SyncHealthPacket value = default(SyncHealthPacket);
            SerializeCommon(reader, ref value);
            value.Nested = reader.Deserialize(new DelegateRead<SyncHealthPacket>(DeserializeSyncHealthPacket));
            return new SyncHealthPacket?(value);
        }

        public static AcceptHitDebugDataPacket? DeserializeAcceptHitDebugDataPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            int num = reader.ReadInt32();
            ClientShot[] array = new ClientShot[num];
            for (int i = 0; i < num; i++)
            {
                array[i] = new ClientShot
                {
                    Approved = reader.ReadBool(),
                    BodyPart = reader.ReadInt32(),
                    Damage = reader.ReadFloat(),
                    LeftBodyPartHealth = reader.ReadFloat(),
                    TargetName = reader.ReadString(new uint?(1200U))
                };
            }
            return new AcceptHitDebugDataPacket?(new AcceptHitDebugDataPacket
            {
                ClientShots = array,
                Nested = reader.Deserialize(new DelegateRead<AcceptHitDebugDataPacket>(DeserializeAcceptHitDebugDataPacket))
            });
        }

        public static QuestConditionValueChangedPacket? DeserializeQuestConditionValueChangedPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            int conditionalIdHash = reader.ReadInt32();
            int num = reader.ReadLimitedInt32(0, 64);
            List<Condition> conditions = new();
            for (int i = 0; i < num; i++)
            {
                Condition item = default(Condition);
                reader.Serialize(ref item);
                conditions.Add(item);
            }
            return new QuestConditionValueChangedPacket?(new QuestConditionValueChangedPacket
            {
                ProgressData = new ConditionalData
                {
                    ConditionalIdHash = conditionalIdHash,
                    Conditions = conditions
                },
                Nested = reader.Deserialize(new DelegateRead<QuestConditionValueChangedPacket>(DeserializeQuestConditionValueChangedPacket))
            });
        }

        public static AchievementConditionValueChangedPacket? DeserializeAchievementConditionValueChangedPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            int conditionalIdHash = reader.ReadInt32();
            int num = reader.ReadLimitedInt32(0, 64);
            List<Condition> conditions = new();
            for (int i = 0; i < num; i++)
            {
                Condition item = default(Condition);
                reader.Serialize(ref item);
                conditions.Add(item);
            }
            return new AchievementConditionValueChangedPacket?(new AchievementConditionValueChangedPacket
            {
                ProgressData = new ConditionalData
                {
                    ConditionalIdHash = conditionalIdHash,
                    Conditions = conditions
                },
                Nested = reader.Deserialize(new DelegateRead<AchievementConditionValueChangedPacket>(DeserializeAchievementConditionValueChangedPacket))
            });
        }

        public static ShowStatNotificationPacket? DeserializeShowStatNotificationPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new ShowStatNotificationPacket?(new ShowStatNotificationPacket
            {
                LocalizationKey1 = reader.ReadUInt32(),
                LocalizationKey2 = reader.ReadUInt32(),
                Value = reader.ReadInt32(),
                Nested = reader.Deserialize(new DelegateRead<ShowStatNotificationPacket>(DeserializeShowStatNotificationPacket))
            });
        }

        public static PlayerDiedPacket? DeserializePlayerDiedPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new PlayerDiedPacket?(new PlayerDiedPacket
            {
                Aggressor = reader.ReadString(new uint?(1200U)),
                AggressorMainProfileName = reader.ReadString(new uint?(1200U)),
                AggressorSide = (EPlayerSide)reader.ReadByte(),
                ColliderType = (EBodyPartColliderType)reader.ReadByte(),
                WeaponName = reader.ReadString(new uint?(1200U)),
                MemberCategory = (EMemberCategory)reader.ReadByte()
            });
        }

        public static ClientConfirmCallbackPacket? DeserializeClientConfirmCallbackPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new ClientConfirmCallbackPacket?(new ClientConfirmCallbackPacket
            {
                CallbackId = reader.ReadUInt32(),
                Error = reader.ReadString(new uint?(1200U)),
                InventoryHashSum = reader.ReadInt32(),
                BadBeforeExecuting = reader.ReadByte(),
                Nested = reader.Deserialize(new DelegateRead<ClientConfirmCallbackPacket>(DeserializeClientConfirmCallbackPacket))
            });
        }

        public static WeaponOverheatPacket? DeserializeWeaponOverheatPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new WeaponOverheatPacket?(new WeaponOverheatPacket
            {
                WeaponId = reader.ReadString(new uint?(1200U)),
                LastShotTime = reader.ReadFloat(),
                LastOverheat = reader.ReadFloat(),
                SlideOnOverheatReached = reader.ReadBool()
            });
        }

        public static TradersInfoPacket? DeserializeTradersInfoPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new TradersInfoPacket?(new TradersInfoPacket
            {
                TraderId = reader.ReadString(new uint?(1200U)),
                Standing = reader.ReadDouble(),
                Nested = reader.Deserialize(new DelegateRead<TradersInfoPacket>(DeserializeTradersInfoPacket))
            });
        }

        public static StringNotificationPacket? DeserializeStringNotificationPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new StringNotificationPacket?(new StringNotificationPacket
            {
                Message = reader.ReadString(new uint?(1200U)),
                Nested = reader.Deserialize(new DelegateRead<StringNotificationPacket>(DeserializeStringNotificationPacket))
            });
        }


        public static RadioTransmitterPacket? DeserializeRadioTransmitterPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new RadioTransmitterPacket?(new RadioTransmitterPacket
            {
                IsEncoded = reader.ReadBool(),
                Status = reader.ReadEnum<RadioTransmitterStatus>(),
                IsAgressor = reader.ReadBool()
            });
        }

        public static LighthouseTraderZoneDataPacket? DeserializeLighthouseTraderZonePacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            int num = reader.ReadInt32();
            AllowedPlayers[] array = new AllowedPlayers[num];
            for (int i = 0; i < num; i++)
            {
                array[i] = new AllowedPlayers
                {
                    Nickname = reader.ReadString(new uint?(1200U)),
                    Status = reader.ReadEnum<RadioTransmitterStatus>()
                };
            }
            int num2 = reader.ReadInt32();
            AllowedPlayers[] array2 = new AllowedPlayers[num2];
            for (int j = 0; j < num2; j++)
            {
                array2[j] = new AllowedPlayers
                {
                    Nickname = reader.ReadString(new uint?(1200U)),
                    Status = reader.ReadEnum<RadioTransmitterStatus>()
                };
            }
            return new LighthouseTraderZoneDataPacket?(new LighthouseTraderZoneDataPacket
            {
                AllowedPlayers = array,
                UnallowedPlayers = array2
            });
        }

        public static LighthouseTraderZoneDebugToolPacket? DeserializeighthouseTraderZoneDebugToolPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new LighthouseTraderZoneDebugToolPacket?(new LighthouseTraderZoneDebugToolPacket
            {
                Active = reader.ReadBool()
            });
        }

        public static InteractWithBtrPacket? DeserializeInteractWithBtrPacket(this IReaderStream reader)
        {
            if (!reader.ReadBool())
            {
                return null;
            }
            return new InteractWithBtrPacket?(new InteractWithBtrPacket
            {
                HasInteraction = reader.ReadBool(),
                InteractionType = (EInteractionType)reader.ReadByte(),
                SideId = reader.ReadByte(),
                SlotId = reader.ReadByte(),
                Fast = reader.ReadBool()
            });
        }




        public static void SerializeCommon(ISerializer2 serializer, ref SyncHealthPacket packet)
        {
            serializer.Serialize<SyncHealthPacket.ESyncType>(ref packet.SyncType);
            switch (packet.SyncType)
            {
                case SyncHealthPacket.ESyncType.AddEffect:
                    serializer.SerializeLimitedInt32(ref packet.Data.AddEffect.EffectId, 0, 10000, BitPackingTag.AddEffectEffectId);
                    serializer.Serialize(ref packet.Data.AddEffect.Type);
                    serializer.Serialize<EBodyPart>(ref packet.Data.AddEffect.BodyPart);
                    serializer.Serialize(ref packet.Data.AddEffect.DelayTime);
                    serializer.Serialize(ref packet.Data.AddEffect.BuildUpTime);
                    serializer.Serialize(ref packet.Data.AddEffect.WorkTime);
                    serializer.Serialize(ref packet.Data.AddEffect.ResidueTime);
                    serializer.SerializeLimitedFloat(ref packet.Data.AddEffect.Strength, -100f, 100f, 0.01f, BitPackingTag.AddEffectStrength);
                    serializer.Serialize<SyncHealthPacket.AddEffect.EExtraDataType>(ref packet.Data.AddEffect.ExtraDataType);
                    switch (packet.Data.AddEffect.ExtraDataType)
                    {
                        case SyncHealthPacket.AddEffect.EExtraDataType.None:
                            break;
                        case SyncHealthPacket.AddEffect.EExtraDataType.MedEffect:
                            MedEffect medEffect = new();
                            serializer.SerializeLimitedString(ref medEffect.ItemId, ' ', 'z', BitPackingTag.MedEffectItemId, new uint?(1200U));
                            serializer.Serialize(ref medEffect.Amount);
                            packet.Data.AddEffect.ExtraData = medEffect;
                            return;
                        case SyncHealthPacket.AddEffect.EExtraDataType.Stimulator:
                            StimulatorStruct stimulator = new();
                            serializer.SerializeLimitedString(ref stimulator.BuffsName, ' ', 'z', BitPackingTag.StimulatorBuffsName, new uint?(1200U));
                            packet.Data.AddEffect.ExtraData = stimulator;
                            return;
                        default:
                            throw new InvalidOperationException();
                    }
                    break;
                case SyncHealthPacket.ESyncType.RemoveEffect:
                    serializer.SerializeLimitedInt32(ref packet.Data.RemoveEffect.EffectId, 0, 10000, BitPackingTag.RemoveEffect);
                    return;
                case SyncHealthPacket.ESyncType.EffectNextState:
                    serializer.SerializeLimitedInt32(ref packet.Data.EffectNextState.EffectId, 0, 10000, BitPackingTag.EffectNextState);
                    serializer.Serialize(ref packet.Data.EffectNextState.StateTime);
                    return;
                case SyncHealthPacket.ESyncType.EffectStateTime:
                    serializer.SerializeLimitedInt32(ref packet.Data.EffectStateTime.EffectId, 0, 10000, BitPackingTag.EffectStateTime);
                    serializer.Serialize(ref packet.Data.EffectStateTime.RemainingStateTime);
                    return;
                case SyncHealthPacket.ESyncType.EffectStrength:
                    serializer.SerializeLimitedInt32(ref packet.Data.EffectStrength.EffectId, 0, 10000, BitPackingTag.EffectStrengthEffectId);
                    serializer.SerializeLimitedFloat(ref packet.Data.EffectStrength.Strength, 0f, 27f, 0.1f, BitPackingTag.EffectStrengthStrength);
                    return;
                case SyncHealthPacket.ESyncType.EffectMedResource:
                    serializer.SerializeLimitedInt32(ref packet.Data.EffectMedResource.EffectId, 0, 10000, BitPackingTag.EffectMedResourceEffectId);
                    serializer.SerializeLimitedFloat(ref packet.Data.EffectMedResource.Resource, -1f, 3000f, 0.01f, BitPackingTag.EffectMedResourceResource);
                    return;
                case SyncHealthPacket.ESyncType.EffectStimulatorBuff:
                    serializer.SerializeLimitedInt32(ref packet.Data.EffectStimulatorBuff.EffectId, 0, 10000, BitPackingTag.EffectStimulatorBuff0);
                    serializer.SerializeLimitedInt32(ref packet.Data.EffectStimulatorBuff.BuffIndex, 0, 63, BitPackingTag.EffectStimulatorBuff1);
                    serializer.Serialize(ref packet.Data.EffectStimulatorBuff.BuffActivate);
                    if (packet.Data.EffectStimulatorBuff.BuffActivate)
                    {
                        serializer.Serialize(ref packet.Data.EffectStimulatorBuff.BuffValue);
                        serializer.Serialize(ref packet.Data.EffectStimulatorBuff.BuffDuration);
                        serializer.Serialize(ref packet.Data.EffectStimulatorBuff.BuffDelay);
                        return;
                    }
                    break;
                case SyncHealthPacket.ESyncType.IsAlive:
                    serializer.Serialize(ref packet.Data.IsAlive.bIsAlive);
                    if (!packet.Data.IsAlive.bIsAlive)
                    {
                        serializer.Serialize<EDamageType>(ref packet.Data.IsAlive.DamageType);
                        return;
                    }
                    break;
                case SyncHealthPacket.ESyncType.BodyHealth:
                    serializer.Serialize<EBodyPart>(ref packet.Data.BodyHealth.BodyPart);
                    serializer.SerializeLimitedFloat(ref packet.Data.BodyHealth.Value, 0f, 400f, 0.1f, BitPackingTag.BodyHealth);
                    return;
                case SyncHealthPacket.ESyncType.Energy:
                    serializer.SerializeLimitedFloat(ref packet.Data.Energy.Value, 0f, 200f, 0.1f, BitPackingTag.Energy);
                    return;
                case SyncHealthPacket.ESyncType.Hydration:
                    serializer.SerializeLimitedFloat(ref packet.Data.Hydration.Value, 0f, 200f, 0.1f, BitPackingTag.Hydration);
                    return;
                case SyncHealthPacket.ESyncType.Temperature:
                    serializer.SerializeLimitedFloat(ref packet.Data.Temperature.Value, 0f, 100f, 0.1f, BitPackingTag.Temperature);
                    return;
                case SyncHealthPacket.ESyncType.DamageCoeff:
                    serializer.Serialize(ref packet.Data.DamageCoeff.fDamageCoeff);
                    return;
                case SyncHealthPacket.ESyncType.ApplyDamage:
                    serializer.Serialize<EBodyPart>(ref packet.Data.ApplyDamage.BodyPart);
                    serializer.Serialize(ref packet.Data.ApplyDamage.Damage);
                    serializer.Serialize<EDamageType>(ref packet.Data.ApplyDamage.DamageType);
                    return;
                case SyncHealthPacket.ESyncType.DestroyedBodyPart:
                    serializer.Serialize<EBodyPart>(ref packet.Data.DestroyedBodyPart.BodyPart);
                    serializer.Serialize(ref packet.Data.DestroyedBodyPart.IsDestroyed);
                    if (packet.Data.DestroyedBodyPart.IsDestroyed)
                    {
                        serializer.Serialize<EDamageType>(ref packet.Data.DestroyedBodyPart.DamageType);
                        return;
                    }
                    serializer.Serialize(ref packet.Data.DestroyedBodyPart.HealthMaximum);
                    return;
                case SyncHealthPacket.ESyncType.HealthRates:
                    serializer.SerializeLimitedFloat(ref packet.Data.HealthRates.HealRate, 0f, 3000f, 0.01f, BitPackingTag.HealthRatesHealRate);
                    serializer.SerializeLimitedFloat(ref packet.Data.HealthRates.DamageRate, -1000f, 0f, 0.01f, BitPackingTag.HealthRatesDamageRate);
                    serializer.SerializeLimitedFloat(ref packet.Data.HealthRates.DamageMultiplier, 0f, 2f, 0.001f, BitPackingTag.HealthRatesDamageMultiplier);
                    serializer.SerializeLimitedFloat(ref packet.Data.HealthRates.Energy, -2000f, 3000f, 0.01f, BitPackingTag.HealthRatesEnergy);
                    serializer.SerializeLimitedFloat(ref packet.Data.HealthRates.Hydration, -2000f, 3000f, 0.01f, BitPackingTag.HealthRatesHydration);
                    serializer.SerializeLimitedFloat(ref packet.Data.HealthRates.Temperature, -100f, 100f, 0.01f, BitPackingTag.HealthRatesTemperature);
                    return;
                case SyncHealthPacket.ESyncType.HealerDone:
                    serializer.SerializeLimitedInt32(ref packet.Data.HealerDone.EffectId, -1, 100000, BitPackingTag.HealerDone);
                    return;
                case SyncHealthPacket.ESyncType.BurnEyes:
                    serializer.Serialize(ref packet.Data.BurnEyes.Position);
                    serializer.Serialize(ref packet.Data.BurnEyes.DistanceStrength);
                    serializer.Serialize(ref packet.Data.BurnEyes.NormalTime);
                    return;
                case SyncHealthPacket.ESyncType.Poison:
                    serializer.SerializeLimitedFloat(ref packet.Data.Poison.Value, 0f, 100f, 0.1f, BitPackingTag.Poison);
                    return;
                case SyncHealthPacket.ESyncType.StaminaCoeff:
                    serializer.Serialize(ref packet.Data.StaminaCoeff.fStaminaCoeff);
                    return;
                default:
                    throw new InvalidOperationException();
            }
        }

        public delegate void DelegateWrite<T>(BinaryWriter writer, ref T? t) where T : struct;
        public delegate T? DelegateRead<T>(IReaderStream reader) where T : struct;

        public static INested<T> Deserialize<T>(this IReaderStream reader, DelegateRead<T> deserializeDelegate) where T : struct, INested<T>
        {
            T? t = deserializeDelegate(reader);
            if (t != null)
            {
                return t.GetValueOrDefault();
            }
            return null;
        }
    }
}
