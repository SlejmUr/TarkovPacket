using TarkovPacketSer.BSG_Classes.ReadWriteDescriptor.DescriptorClasses;
using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes.ReadWriteDescriptor
{
    public static class RWD
    {
        public static T ReadPolymorph<T>(this BinaryReader reader) where T : class
        {
            switch (reader.ReadByte())
            {
                case 0:
                    return reader.ReadClassQuaternion() as T;
                case 1:
                    return reader.ReadClassTransformSync() as T;
                case 2:
                    return reader.ReadClassVector3() as T;
                case 3:
                    return reader.ReadLocationInGrid() as T;
                case 4:
                    return reader.ReadWeightedLootPointSpawnPosition() as T;
                case 5:
                    return reader.ReadEFTInventoryDescriptor() as T;
                case 6:
                    return reader.ReadEFTFastAccessDescriptor() as T;
                case 7:
                    return reader.ReadEFTDiscardLimitsDescriptor() as T;
                case 8:
                    return reader.ReadEFTSlotDescriptor() as T;
                case 9:
                    return reader.ReadEFTShellTemplateDescriptor() as T;
                case 10:
                    return reader.ReadEFTMalfunctionDescriptor() as T;
                case 11:
                    return reader.ReadEFTItemInGridDescriptor() as T;
                case 12:
                    return reader.ReadEFTGridDescriptor() as T;
                case 13:
                    return reader.ReadEFTStackSlotDescriptor() as T;
                case 14:
                    return reader.ReadEFTNestedItemDescriptor() as T;
                case 15:
                    return reader.ReadEFTItemDescriptor() as T;
                case 17:
                    return reader.ReadEFTFoodDrinkComponentDescriptor() as T;
                case 18:
                    return reader.ReadEFTPoisonComponentDescriptor() as T;
                case 19:
                    return reader.ReadEFTResourceItemComponentDescriptor() as T;
                case 20:
                    return reader.ReadEFTLightComponentDescriptor() as T;
                case 21:
                    return reader.ReadEFTLockableComponentDescriptor() as T;
                case 22:
                    return reader.ReadEFTMapComponentDescriptor() as T;
                case 23:
                    return reader.ReadEFTMedKitComponentDescriptor() as T;
                case 24:
                    return reader.ReadEFTRepairableComponentDescriptor() as T;
                case 25:
                    return reader.ReadEFTSightComponentDescriptor() as T;
                case 26:
                    return reader.ReadEFTTogglableComponentDescriptor() as T;
                case 27:
                    return reader.ReadEFTFaceShieldComponentDescriptor() as T;
                case 28:
                    return reader.ReadEFTFoldableComponentDescriptor() as T;
                case 29:
                    return reader.ReadEFTFireModeComponentDescriptor() as T;
                case 30:
                    return reader.ReadEFTDogTagComponentDescriptor() as T;
                case 31:
                    return reader.ReadEFTTagComponentDescriptor() as T;
                case 32:
                    return reader.ReadEFTKeyComponentDescriptor() as T;
                case 33:
                    return reader.ReadEFTRepairKitComponentDescriptor() as T;
                case 34:
                    return reader.ReadEFTRepairEnhancementComponentDescriptor() as T;
                case 35:
                    return reader.ReadEFTRecodableComponentDescriptor() as T;
                case 36:
                    return reader.ReadEFTCultistAmuletComponentDescriptor() as T;
                case 37:
                    return reader.ReadEFTJsonLootItemDescriptor() as T;
                case 38:
                    return reader.ReadEFTJsonCorpseDescriptor() as T;
                case 39:
                    return reader.ReadEFTLootDataDescriptor() as T;
                case 41:
                    return reader.ReadEFTSlotItemAddressDescriptor() as T;
                case 42:
                    return reader.ReadEFTStackSlotItemAddressDescriptor() as T;
                case 43:
                    return reader.ReadEFTContainerDescriptor() as T;
                case 44:
                    return reader.ReadEFTGridItemAddressDescriptor() as T;
                case 45:
                    return reader.ReadEFTOwnerItselfDescriptor() as T;
                case 46:
                    return reader.ReadEFTDestroyedItem() as T;
                case 48:
                    return reader.ReadEFTAddOperationDescriptor() as T;
                case 49:
                    return reader.ReadEFTMagOperationDescriptor() as T;
                case 50:
                    return reader.ReadEFTLoadMagOperationDescriptor() as T;
                case 51:
                    return reader.ReadEFTUnloadMagOperationDescriptor() as T;
                case 52:
                    return reader.ReadEFTRemoveOperationDescriptor() as T;
                case 53:
                    return reader.ReadEFTExamineOperationDescriptor() as T;
                case 54:
                    return reader.ReadEFTExamineMalfunctionOperationDescriptor() as T;
                case 55:
                    return reader.ReadEFTExamineMalfTypeOperationDescriptor() as T;
                case 56:
                    return reader.ReadEFTCheckMagazineOperationDescriptor() as T;
                case 57:
                    return reader.ReadEFTBindItemOperationDescriptor() as T;
                case 58:
                    return reader.ReadEFTUnbindItemOperationDescriptor() as T;
                case 59:
                    return reader.ReadEFTInsureItemsOperationDescriptor() as T;
                case 60:
                    return reader.ReadEFTMoveOperationDescriptor() as T;
                case 61:
                    return reader.ReadEFTMoveAllOperationDescriptor() as T;
                case 62:
                    return reader.ReadEFTSplitOperationDescriptor() as T;
                case 63:
                    return reader.ReadEFTMergeOperationDescriptor() as T;
                case 64:
                    return reader.ReadEFTTransferOperationDescriptor() as T;
                case 65:
                    return reader.ReadEFTSwapOperationDescriptor() as T;
                case 66:
                    return reader.ReadEFTThrowOperationDescriptor() as T;
                case 67:
                    return reader.ReadEFTToggleOperationDescriptor() as T;
                case 68:
                    return reader.ReadEFTFoldOperationDescriptor() as T;
                case 69:
                    return reader.ReadEFTShotOperationDescriptor() as T;
                case 70:
                    return reader.ReadEFTSetupItemOperationDescriptor() as T;
                case 71:
                    return reader.ReadEFTApplyOperationDescriptor() as T;
                case 72:
                    return reader.ReadEFTApplyHealthOperationDescriptor() as T;
                case 73:
                    return reader.ReadEFTCreateMapMarkerOperationDescriptor() as T;
                case 74:
                    return reader.ReadEFTEditMapMarkerOperationDescriptor() as T;
                case 75:
                    return reader.ReadEFTDeleteMapMarkerOperationDescriptor() as T;
                case 76:
                    return reader.ReadEFTAddNoteOperationDescriptor() as T;
                case 77:
                    return reader.ReadEFTEditNoteOperationDescriptor() as T;
                case 78:
                    return reader.ReadEFTDeleteNoteOperationDescriptor() as T;
                case 79:
                    return reader.ReadEFTTagOperationDescriptor() as T;
                case 80:
                    return reader.ReadEFTOperateStationaryWeaponOperationDescriptor() as T;
                case 81:
                    return reader.ReadEFTWeaponRechamberOperationDescriptor() as T;
                case 82:
                    return reader.ReadEFTObservedSyncItemsOperationDescriptor() as T;
                case 83:
                    return reader.ReadEFTTraderServiceAvailabilityData() as T;
                case 84:
                    return reader.ReadEFTQuestActionDescriptor() as T;
                case 85:
                    return reader.ReadEFTQuestAcceptDescriptor() as T;
                case 86:
                    return reader.ReadEFTQuestFinishDescriptor() as T;
                case 87:
                    return reader.ReadEFTQuestHandoverDescriptor() as T;
                case 88:
                    return reader.ReadEFTSceneResourceKey() as T;
                case 89:
                    return reader.ReadEFTResourceKey() as T;
                case 90:
                    return reader.ReadEFTNotesNote() as T;
                case 91:
                    return reader.ReadEFTInventoryLogicMapMarker() as T;
                case 92:
                    return reader.ReadEFTInventoryLogicOperationsCreateItemsDescriptor() as T;
                case 93:
                    return reader.ReadEFTInventoryLogicOperationsPurchaseTraderServiceOperationDescriptor() as T;
            }
            return default(T);
        }

        public static ClassQuaternion ReadClassQuaternion(this BinaryReader reader)
        {
            return new ClassQuaternion
            {
                x = reader.ReadSingle(),
                y = reader.ReadSingle(),
                z = reader.ReadSingle(),
                w = reader.ReadSingle()
            };
        }

        public static ClassTransformSync ReadClassTransformSync(this BinaryReader reader)
        {
            return new ClassTransformSync
            {
                Position = reader.ReadClassVector3(),
                Rotation = reader.ReadClassQuaternion()
            };
        }

        public static ClassVector3 ReadClassVector3(this BinaryReader reader)
        {
            return new ClassVector3
            {
                x = reader.ReadSingle(),
                y = reader.ReadSingle(),
                z = reader.ReadSingle()
            };
        }

        public static LocationInGrid ReadLocationInGrid(this BinaryReader reader)
        {
            return new LocationInGrid
            {
                x = reader.ReadInt32(),
                y = reader.ReadInt32(),
                r = (ItemRotation)reader.ReadInt32(),
                isSearched = reader.ReadBoolean()
            };
        }

        public static WeightedLootPointSpawnPosition ReadWeightedLootPointSpawnPosition(this BinaryReader reader)
        {
            return new WeightedLootPointSpawnPosition
            {
                Name = reader.ReadString(),
                Weight = reader.ReadSingle(),
                Position = reader.ReadClassVector3(),
                Rotation = reader.ReadClassVector3()
            };
        }

        public static InventoryDescriptor ReadEFTInventoryDescriptor(this BinaryReader reader)
        {
            InventoryDescriptor inventoryDescriptor = new InventoryDescriptor();
            inventoryDescriptor.Equipment = reader.ReadEFTItemDescriptor();
            if (reader.ReadBoolean())
            {
                inventoryDescriptor.Stash = reader.ReadEFTItemDescriptor();
            }
            if (reader.ReadBoolean())
            {
                inventoryDescriptor.QuestRaidItems = reader.ReadEFTItemDescriptor();
            }
            if (reader.ReadBoolean())
            {
                inventoryDescriptor.QuestStashItems = reader.ReadEFTItemDescriptor();
            }
            if (reader.ReadBoolean())
            {
                inventoryDescriptor.SortingTable = reader.ReadEFTItemDescriptor();
            }
            if (reader.ReadBoolean())
            {
                inventoryDescriptor.FastAccess = reader.ReadEFTFastAccessDescriptor();
            }
            if (reader.ReadBoolean())
            {
                inventoryDescriptor.DiscardLimits = reader.ReadEFTDiscardLimitsDescriptor();
            }
            return inventoryDescriptor;
        }

        public static ItemDescriptor ReadEFTItemDescriptor(this BinaryReader reader)
        {
            ItemDescriptor itemDescriptor = new ItemDescriptor();
            itemDescriptor.Id = reader.ReadString();
            itemDescriptor.TemplateId = reader.ReadString();
            itemDescriptor.StackCount = reader.ReadInt32();
            itemDescriptor.SpawnedInSession = reader.ReadBoolean();
            itemDescriptor.ActiveCamora = reader.ReadByte();
            itemDescriptor.IsUnderBarrelDeviceActive = reader.ReadBoolean();
            int num = reader.ReadInt32();
            itemDescriptor.Components = new List<AbstractComponent>(num);
            for (int i = 0; i < num; i++)
            {
                itemDescriptor.Components.Add(reader.ReadPolymorph<AbstractComponent>());
            }
            int num2 = reader.ReadInt32();
            itemDescriptor.Slots = new List<SlotDescriptor>(num2);
            for (int j = 0; j < num2; j++)
            {
                itemDescriptor.Slots.Add(reader.ReadEFTSlotDescriptor());
            }
            int num3 = reader.ReadInt32();
            itemDescriptor.ShellsInWeapon = new List<ShellTemplateDescriptor>(num3);
            for (int k = 0; k < num3; k++)
            {
                itemDescriptor.ShellsInWeapon.Add(reader.ReadEFTShellTemplateDescriptor());
            }
            int num4 = reader.ReadInt32();
            itemDescriptor.ShellsInUnderbarrelWeapon = new List<ShellTemplateDescriptor>(num4);
            for (int l = 0; l < num4; l++)
            {
                itemDescriptor.ShellsInUnderbarrelWeapon.Add(reader.ReadEFTShellTemplateDescriptor());
            }
            int num5 = reader.ReadInt32();
            itemDescriptor.Grids = new List<GridDescriptor>(num5);
            for (int m = 0; m < num5; m++)
            {
                itemDescriptor.Grids.Add(reader.ReadEFTGridDescriptor());
            }
            int num6 = reader.ReadInt32();
            itemDescriptor.StackSlots = new List<StackSlotDescriptor>(num6);
            for (int n = 0; n < num6; n++)
            {
                itemDescriptor.StackSlots.Add(reader.ReadEFTStackSlotDescriptor());
            }
            int num7 = reader.ReadInt32();
            itemDescriptor.Malfunction = new List<MalfunctionDescriptor>(num7);
            for (int num8 = 0; num8 < num7; num8++)
            {
                itemDescriptor.Malfunction.Add(reader.ReadEFTMalfunctionDescriptor());
            }
            return itemDescriptor;
        }

        public static SlotDescriptor ReadEFTSlotDescriptor(this BinaryReader reader)
        {
            return new SlotDescriptor
            {
                Id = reader.ReadString(),
                ContainedItem = reader.ReadEFTItemDescriptor()
            };
        }

        public static ShellTemplateDescriptor ReadEFTShellTemplateDescriptor(this BinaryReader reader)
        {
            return new ShellTemplateDescriptor
            {
                AmmoTemplateId = reader.ReadString()
            };
        }

        public static GridDescriptor ReadEFTGridDescriptor(this BinaryReader reader)
        {
            GridDescriptor gridDescriptor = new GridDescriptor();
            gridDescriptor.Id = reader.ReadString();
            int num = reader.ReadInt32();
            gridDescriptor.ContainedItems = new List<ItemInGridDescriptor>(num);
            for (int i = 0; i < num; i++)
            {
                gridDescriptor.ContainedItems.Add(reader.ReadEFTItemInGridDescriptor());
            }
            return gridDescriptor;
        }

        public static ItemInGridDescriptor ReadEFTItemInGridDescriptor(this BinaryReader reader)
        {
            return new ItemInGridDescriptor
            {
                Location = reader.ReadLocationInGrid(),
                Item = reader.ReadEFTItemDescriptor()
            };
        }

        public static StackSlotDescriptor ReadEFTStackSlotDescriptor(this BinaryReader reader)
        {
            StackSlotDescriptor stackSlotDescriptor = new StackSlotDescriptor();
            stackSlotDescriptor.Id = reader.ReadString();
            int num = reader.ReadInt32();
            stackSlotDescriptor.ContainedItems = new List<ItemDescriptor>(num);
            for (int i = 0; i < num; i++)
            {
                stackSlotDescriptor.ContainedItems.Add(reader.ReadEFTItemDescriptor());
            }
            return stackSlotDescriptor;
        }

        public static MalfunctionDescriptor ReadEFTMalfunctionDescriptor(this BinaryReader reader)
        {
            MalfunctionDescriptor malfunctionDescriptor = new MalfunctionDescriptor();
            malfunctionDescriptor.Malfunction = reader.ReadByte();
            malfunctionDescriptor.LastShotOverheat = reader.ReadSingle();
            malfunctionDescriptor.LastShotTime = reader.ReadSingle();
            malfunctionDescriptor.SlideOnOverheatReached = reader.ReadBoolean();
            int num = reader.ReadInt32();
            malfunctionDescriptor.PlayersWhoKnowAboutMalfunction = new List<string>(num);
            for (int i = 0; i < num; i++)
            {
                malfunctionDescriptor.PlayersWhoKnowAboutMalfunction.Add(reader.ReadString());
            }
            int num2 = reader.ReadInt32();
            malfunctionDescriptor.PlayersWhoKnowMalfType = new List<string>(num2);
            for (int j = 0; j < num2; j++)
            {
                malfunctionDescriptor.PlayersWhoKnowMalfType.Add(reader.ReadString());
            }
            int num3 = reader.ReadInt32();
            malfunctionDescriptor.PlayersReducedMalfChances = new Dictionary<string, byte>();
            for (int k = 0; k < num3; k++)
            {
                malfunctionDescriptor.PlayersReducedMalfChances[reader.ReadString()] = reader.ReadByte();
            }
            if (reader.ReadBoolean())
            {
                malfunctionDescriptor.AmmoToFireTemplateId = reader.ReadString();
            }
            if (reader.ReadBoolean())
            {
                malfunctionDescriptor.AmmoWillBeLoadedToChamberTemplateId = reader.ReadString();
            }
            if (reader.ReadBoolean())
            {
                malfunctionDescriptor.AmmoMalfunctionedTemplateId = reader.ReadString();
            }
            return malfunctionDescriptor;
        }

        public static FastAccessDescriptor ReadEFTFastAccessDescriptor(this BinaryReader reader)
        {
            FastAccessDescriptor fastAccessDescriptor = new FastAccessDescriptor();
            int num = reader.ReadInt32();
            fastAccessDescriptor.Items = new Dictionary<int, string>();
            for (int i = 0; i < num; i++)
            {
                fastAccessDescriptor.Items[reader.ReadInt32()] = reader.ReadString();
            }
            return fastAccessDescriptor;
        }

        public static DiscardLimit ReadEFTDiscardLimitsDescriptor(this BinaryReader reader)
        {
            DiscardLimit discardLimits = new DiscardLimit();
            int num = reader.ReadInt32();
            discardLimits.DiscardLimits = new Dictionary<string, int>();
            for (int i = 0; i < num; i++)
            {
                discardLimits.DiscardLimits[reader.ReadString()] = reader.ReadInt32();
            }
            return discardLimits;
        }

        public static NestedItemDescriptor ReadEFTNestedItemDescriptor(this BinaryReader reader)
        {
            return new NestedItemDescriptor
            {
                Address = reader.ReadPolymorph<AbstractDescriptor>(),
                Item = reader.ReadEFTItemDescriptor()
            };
        }

        public static FoodDrink ReadEFTFoodDrinkComponentDescriptor(this BinaryReader reader)
        {
            return new FoodDrink
            {
                HpPercent = reader.ReadSingle()
            };
        }

        public static PoisonComponentDescriptor ReadEFTPoisonComponentDescriptor(this BinaryReader reader)
        {
            return new PoisonComponentDescriptor
            {
                Resource = reader.ReadSingle()
            };
        }

        public static ResourceItemComponentDescriptor ReadEFTResourceItemComponentDescriptor(this BinaryReader reader)
        {
            return new ResourceItemComponentDescriptor
            {
                Resource = reader.ReadSingle()
            };
        }

        public static LightComponentDescriptor ReadEFTLightComponentDescriptor(this BinaryReader reader)
        {
            return new LightComponentDescriptor
            {
                IsActive = reader.ReadBoolean(),
                SelectedMode = reader.ReadInt32()
            };
        }

        public static LockableComponentDescriptor ReadEFTLockableComponentDescriptor(this BinaryReader reader)
        {
            return new LockableComponentDescriptor
            {
                Locked = reader.ReadBoolean()
            };
        }

        public static MapComponentDescriptor ReadEFTMapComponentDescriptor(this BinaryReader reader)
        {
            MapComponentDescriptor mapComponentDescriptor = new MapComponentDescriptor();
            int num = reader.ReadInt32();
            mapComponentDescriptor.Markers = new List<MapMarker>(num);
            for (int i = 0; i < num; i++)
            {
                mapComponentDescriptor.Markers.Add(reader.ReadEFTInventoryLogicMapMarker());
            }
            return mapComponentDescriptor;
        }

        public static MapMarker ReadEFTInventoryLogicMapMarker(this BinaryReader reader)
        {
            return new MapMarker
            {
                Type = (MapMarkerType)reader.ReadInt32(),
                X = reader.ReadInt32(),
                Y = reader.ReadInt32(),
                Note = reader.ReadString()
            };
        }

        public static MedKitComponentDescriptor ReadEFTMedKitComponentDescriptor(this BinaryReader reader)
        {
            return new MedKitComponentDescriptor
            {
                HpResource = reader.ReadSingle()
            };
        }

        public static RepairableComponentDescriptor ReadEFTRepairableComponentDescriptor(this BinaryReader reader)
        {
            return new RepairableComponentDescriptor
            {
                Durability = reader.ReadSingle(),
                MaxDurability = reader.ReadSingle()
            };
        }

        public static SightComponentDescriptor ReadEFTSightComponentDescriptor(this BinaryReader reader)
        {
            SightComponentDescriptor sightComponentDescriptor = new SightComponentDescriptor();
            sightComponentDescriptor.SelectedSightScope = reader.ReadInt32();
            int num = reader.ReadInt32();
            sightComponentDescriptor.ScopesSelectedModes = new int[num];
            for (int i = 0; i < num; i++)
            {
                sightComponentDescriptor.ScopesSelectedModes[i] = reader.ReadInt32();
            }
            int num2 = reader.ReadInt32();
            sightComponentDescriptor.ScopesSelectedCalibPoints = new int[num2];
            for (int j = 0; j < num2; j++)
            {
                sightComponentDescriptor.ScopesSelectedCalibPoints[j] = reader.ReadInt32();
            }
            return sightComponentDescriptor;
        }

        public static TogglableComponentDescriptor ReadEFTTogglableComponentDescriptor(this BinaryReader reader)
        {
            return new TogglableComponentDescriptor
            {
                IsOn = reader.ReadBoolean()
            };
        }

        public static FaceShieldComponentDescriptor ReadEFTFaceShieldComponentDescriptor(this BinaryReader reader)
        {
            return new FaceShieldComponentDescriptor
            {
                Hits = reader.ReadByte(),
                HitSeed = reader.ReadByte()
            };
        }

        public static FoldableComponentDescriptor ReadEFTFoldableComponentDescriptor(this BinaryReader reader)
        {
            return new FoldableComponentDescriptor
            {
                Folded = reader.ReadBoolean()
            };
        }

        public static FireModeComponentDescriptor ReadEFTFireModeComponentDescriptor(this BinaryReader reader)
        {
            return new FireModeComponentDescriptor
            {
                FireMode = (EFireMode)reader.ReadInt32()
            };
        }

        public static DogTagComponentDescriptor ReadEFTDogTagComponentDescriptor(this BinaryReader reader)
        {
            return new DogTagComponentDescriptor
            {
                AccountId = reader.ReadString(),
                ProfileId = reader.ReadString(),
                Nickname = reader.ReadString(),
                Side = (EPlayerSide)reader.ReadInt32(),
                Level = reader.ReadInt32(),
                Time = reader.ReadDouble(),
                Status = reader.ReadString(),
                KillerAccountId = reader.ReadString(),
                KillerProfileId = reader.ReadString(),
                KillerName = reader.ReadString(),
                WeaponName = reader.ReadString(),
                CarriedByGroupMember = reader.ReadBoolean()
            };
        }

        public static TagComponentDescriptor ReadEFTTagComponentDescriptor(this BinaryReader reader)
        {
            return new TagComponentDescriptor
            {
                Name = reader.ReadString(),
                Color = reader.ReadInt32()
            };
        }

        public static KeyComponentDescriptor ReadEFTKeyComponentDescriptor(this BinaryReader reader)
        {
            return new KeyComponentDescriptor
            {
                NumberOfUsages = reader.ReadInt32()
            };
        }

        public static RepairKits ReadEFTRepairKitComponentDescriptor(this BinaryReader reader)
        {
            return new RepairKits
            {
                Resource = reader.ReadSingle()
            };
        }

        public static RepairEnhancementComponentDescriptor ReadEFTRepairEnhancementComponentDescriptor(this BinaryReader reader)
        {
            return new RepairEnhancementComponentDescriptor
            {
                BuffType = (ERepairBuffType)reader.ReadInt32(),
                BuffRarity = (EBuffRarity)reader.ReadInt32(),
                Value = reader.ReadSingle(),
                ThresholdDurability = reader.ReadSingle()
            };
        }

        public static RecodableComponentDescriptor ReadEFTRecodableComponentDescriptor(this BinaryReader reader)
        {
            return new RecodableComponentDescriptor
            {
                IsEncoded = reader.ReadBoolean()
            };
        }

        public static CultistAmuletComponentDescriptor ReadEFTCultistAmuletComponentDescriptor(this BinaryReader reader)
        {
            return new CultistAmuletComponentDescriptor
            {
                NumberOfUsages = reader.ReadInt32()
            };
        }

        public static JsonLootItemDescriptor ReadEFTJsonLootItemDescriptor(this BinaryReader reader)
        {
            JsonLootItemDescriptor jsonLootItemDescriptor = new JsonLootItemDescriptor();
            if (reader.ReadBoolean())
            {
                jsonLootItemDescriptor.Id = reader.ReadString();
            }
            jsonLootItemDescriptor.Position = reader.ReadClassVector3();
            jsonLootItemDescriptor.Rotation = reader.ReadClassVector3();
            jsonLootItemDescriptor.Item = reader.ReadEFTItemDescriptor();
            if (reader.ReadBoolean())
            {
                int num = reader.ReadInt32();
                jsonLootItemDescriptor.ValidProfiles = new string[num];
                for (int i = 0; i < num; i++)
                {
                    jsonLootItemDescriptor.ValidProfiles[i] = reader.ReadString();
                }
            }
            jsonLootItemDescriptor.IsContainer = reader.ReadBoolean();
            jsonLootItemDescriptor.UseGravity = reader.ReadBoolean();
            jsonLootItemDescriptor.RandomRotation = reader.ReadBoolean();
            jsonLootItemDescriptor.Shift = reader.ReadClassVector3();
            jsonLootItemDescriptor.PlatformId = reader.ReadInt16();
            return jsonLootItemDescriptor;
        }

        public static JsonCorpseDescriptor ReadEFTJsonCorpseDescriptor(this BinaryReader reader)
        {
            JsonCorpseDescriptor jsonCorpseDescriptor = new JsonCorpseDescriptor();
            int num = reader.ReadInt32();
            jsonCorpseDescriptor.Customization = new Dictionary<int, string>();
            for (int i = 0; i < num; i++)
            {
                jsonCorpseDescriptor.Customization[reader.ReadInt32()] = reader.ReadString();
            }
            jsonCorpseDescriptor.Side = (EPlayerSide)reader.ReadInt32();
            int num2 = reader.ReadInt32();
            jsonCorpseDescriptor.Bones = new ClassTransformSync[num2];
            for (int j = 0; j < num2; j++)
            {
                jsonCorpseDescriptor.Bones[j] = reader.ReadClassTransformSync();
            }
            jsonCorpseDescriptor.PlayerProfileID = reader.ReadString();
            if (reader.ReadBoolean())
            {
                jsonCorpseDescriptor.Id = reader.ReadString();
            }
            jsonCorpseDescriptor.Position = reader.ReadClassVector3();
            jsonCorpseDescriptor.Rotation = reader.ReadClassVector3();
            jsonCorpseDescriptor.Item = reader.ReadEFTItemDescriptor();
            if (reader.ReadBoolean())
            {
                int num3 = reader.ReadInt32();
                jsonCorpseDescriptor.ValidProfiles = new string[num3];
                for (int k = 0; k < num3; k++)
                {
                    jsonCorpseDescriptor.ValidProfiles[k] = reader.ReadString();
                }
            }
            jsonCorpseDescriptor.IsContainer = reader.ReadBoolean();
            jsonCorpseDescriptor.UseGravity = reader.ReadBoolean();
            jsonCorpseDescriptor.RandomRotation = reader.ReadBoolean();
            jsonCorpseDescriptor.Shift = reader.ReadClassVector3();
            jsonCorpseDescriptor.PlatformId = reader.ReadInt16();
            return jsonCorpseDescriptor;
        }

        public static LootDataDescriptor ReadEFTLootDataDescriptor(this BinaryReader reader)
        {
            LootDataDescriptor lootDataDescriptor = new LootDataDescriptor();
            int num = reader.ReadInt32();
            lootDataDescriptor.Items = new List<JsonLootItemDescriptor>(num);
            for (int i = 0; i < num; i++)
            {
                lootDataDescriptor.Items.Add(reader.ReadPolymorph<JsonLootItemDescriptor>());
            }
            return lootDataDescriptor;
        }

        public static SlotItemAddressDescriptor ReadEFTSlotItemAddressDescriptor(this BinaryReader reader)
        {
            return new SlotItemAddressDescriptor
            {
                Container = reader.ReadEFTContainerDescriptor()
            };
        }

        public static StackSlotItemAddressDescriptor ReadEFTStackSlotItemAddressDescriptor(this BinaryReader reader)
        {
            return new StackSlotItemAddressDescriptor
            {
                Container = reader.ReadEFTContainerDescriptor()
            };
        }

        public static ContainerDescriptor ReadEFTContainerDescriptor(this BinaryReader reader)
        {
            return new ContainerDescriptor
            {
                ParentId = reader.ReadString(),
                ContainerId = reader.ReadString()
            };
        }

        public static GridItemAddressDescriptor ReadEFTGridItemAddressDescriptor(this BinaryReader reader)
        {
            return new GridItemAddressDescriptor
            {
                LocationInGrid = reader.ReadLocationInGrid(),
                Container = reader.ReadEFTContainerDescriptor()
            };
        }

        public static OwnerItselfDescriptor ReadEFTOwnerItselfDescriptor(this BinaryReader reader)
        {
            return new OwnerItselfDescriptor
            {
                Container = reader.ReadEFTContainerDescriptor()
            };
        }

        public static DestroyedItem ReadEFTDestroyedItem(this BinaryReader reader)
        {
            return new DestroyedItem
            {
                ItemId = reader.ReadMongoId(),
                NumberToDestroy = reader.ReadInt32(),
                NumberToPreserve = reader.ReadInt32()
            };
        }

        public static AddOperationDescriptor ReadEFTAddOperationDescriptor(this BinaryReader reader)
        {
            return new AddOperationDescriptor
            {
                ItemId = reader.ReadString(),
                To = reader.ReadPolymorph<AbstractDescriptor>(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static MagOperationDescriptor ReadEFTMagOperationDescriptor(this BinaryReader reader)
        {
            return new MagOperationDescriptor
            {
                InternalOperationDescriptor = reader.ReadPolymorph<AbstractInternalOperationDescriptor>(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static LoadMagOperationDescriptor ReadEFTLoadMagOperationDescriptor(this BinaryReader reader)
        {
            return new LoadMagOperationDescriptor
            {
                InternalOperationDescriptor = reader.ReadPolymorph<AbstractInternalOperationDescriptor>(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static UnloadMagOperationDescriptor ReadEFTUnloadMagOperationDescriptor(this BinaryReader reader)
        {
            return new UnloadMagOperationDescriptor
            {
                InternalOperationDescriptor = reader.ReadPolymorph<AbstractInternalOperationDescriptor>(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static RemoveOperationDescriptor ReadEFTRemoveOperationDescriptor(this BinaryReader reader)
        {
            return new RemoveOperationDescriptor
            {
                ItemId = reader.ReadString(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static ExamineOperationDescriptor ReadEFTExamineOperationDescriptor(this BinaryReader reader)
        {
            return new ExamineOperationDescriptor
            {
                ItemId = reader.ReadString(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static ExamineMalfunctionOperationDescriptor ReadEFTExamineMalfunctionOperationDescriptor(this BinaryReader reader)
        {
            return new ExamineMalfunctionOperationDescriptor
            {
                ItemId = reader.ReadString(),
                OperationId = reader.ReadUInt16()
            };
        }
        public static ExamineMalfTypeOperationDescriptor ReadEFTExamineMalfTypeOperationDescriptor(this BinaryReader reader)
        {
            return new ExamineMalfTypeOperationDescriptor
            {
                ItemId = reader.ReadString(),
                OperationId = reader.ReadUInt16()
            };
        }
        public static CheckMagazineOperationDescriptor ReadEFTCheckMagazineOperationDescriptor(this BinaryReader reader)
        {
            return new CheckMagazineOperationDescriptor
            {
                ItemId = reader.ReadString(),
                CheckStatus = reader.ReadBoolean(),
                SkillLevel = reader.ReadInt32(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static BindItemOperationDescriptor ReadEFTBindItemOperationDescriptor(this BinaryReader reader)
        {
            return new BindItemOperationDescriptor
            {
                ItemId = reader.ReadString(),
                Index = (EBoundItem)reader.ReadInt32(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static UnbindItemOperationDescriptor ReadEFTUnbindItemOperationDescriptor(this BinaryReader reader)
        {
            return new UnbindItemOperationDescriptor
            {
                ItemId = reader.ReadString(),
                Index = (EBoundItem)reader.ReadInt32(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static InsureItemsOperationDescriptor ReadEFTInsureItemsOperationDescriptor(this BinaryReader reader)
        {
            InsureItemsOperationDescriptor insureItemsOperationDescriptor = new InsureItemsOperationDescriptor();
            int num = reader.ReadInt32();
            insureItemsOperationDescriptor.Items = new string[num];
            for (int i = 0; i < num; i++)
            {
                insureItemsOperationDescriptor.Items[i] = reader.ReadString();
            }
            insureItemsOperationDescriptor.TraderId = reader.ReadString();
            insureItemsOperationDescriptor.OperationId = reader.ReadUInt16();
            return insureItemsOperationDescriptor;
        }

        public static MoveOperationDescriptor ReadEFTMoveOperationDescriptor(this BinaryReader reader)
        {
            MoveOperationDescriptor moveOperationDescriptor = new MoveOperationDescriptor();
            moveOperationDescriptor.ItemId = reader.ReadString();
            moveOperationDescriptor.From = reader.ReadPolymorph<AbstractDescriptor>();
            moveOperationDescriptor.To = reader.ReadPolymorph<AbstractDescriptor>();
            if (reader.ReadBoolean())
            {
                int num = reader.ReadInt32();
                moveOperationDescriptor.DestroyedItems = new List<DestroyedItem>(num);
                for (int i = 0; i < num; i++)
                {
                    moveOperationDescriptor.DestroyedItems.Add(reader.ReadEFTDestroyedItem());
                }
            }
            moveOperationDescriptor.OperationId = reader.ReadUInt16();
            return moveOperationDescriptor;
        }

        public static MoveAllOperationDescriptor ReadEFTMoveAllOperationDescriptor(this BinaryReader reader)
        {
            return new MoveAllOperationDescriptor
            {
                ItemId = reader.ReadString(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static SplitOperationDescriptor ReadEFTSplitOperationDescriptor(this BinaryReader reader)
        {
            return new SplitOperationDescriptor
            {
                ItemId = reader.ReadString(),
                CloneId = reader.ReadString(),
                From = reader.ReadPolymorph<AbstractDescriptor>(),
                To = reader.ReadPolymorph<AbstractDescriptor>(),
                Count = reader.ReadInt32(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static MergeOperationDescriptor ReadEFTMergeOperationDescriptor(this BinaryReader reader)
        {
            return new MergeOperationDescriptor
            {
                ItemId = reader.ReadString(),
                Item1Id = reader.ReadString(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static TransferOperationDescriptor ReadEFTTransferOperationDescriptor(this BinaryReader reader)
        {
            return new TransferOperationDescriptor
            {
                ItemId = reader.ReadString(),
                Item1Id = reader.ReadString(),
                Count = reader.ReadInt32(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static SwapOperationDescriptor ReadEFTSwapOperationDescriptor(this BinaryReader reader)
        {
            SwapOperationDescriptor swapOperationDescriptor = new SwapOperationDescriptor();
            swapOperationDescriptor.ItemId = reader.ReadString();
            swapOperationDescriptor.To = reader.ReadPolymorph<AbstractDescriptor>();
            swapOperationDescriptor.Item1Id = reader.ReadString();
            swapOperationDescriptor.To1 = reader.ReadPolymorph<AbstractDescriptor>();
            if (reader.ReadBoolean())
            {
                int num = reader.ReadInt32();
                swapOperationDescriptor.DestroyedItems = new List<DestroyedItem>(num);
                for (int i = 0; i < num; i++)
                {
                    swapOperationDescriptor.DestroyedItems.Add(reader.ReadEFTDestroyedItem());
                }
            }
            swapOperationDescriptor.OperationId = reader.ReadUInt16();
            return swapOperationDescriptor;
        }

        public static ThrowOperationDescriptor ReadEFTThrowOperationDescriptor(this BinaryReader reader)
        {
            ThrowOperationDescriptor throwOperationDescriptor = new ThrowOperationDescriptor();
            throwOperationDescriptor.ItemId = reader.ReadString();
            throwOperationDescriptor.DownDirection = reader.ReadBoolean();
            if (reader.ReadBoolean())
            {
                int num = reader.ReadInt32();
                throwOperationDescriptor.DestroyedItems = new List<DestroyedItem>(num);
                for (int i = 0; i < num; i++)
                {
                    throwOperationDescriptor.DestroyedItems.Add(reader.ReadEFTDestroyedItem());
                }
            }
            throwOperationDescriptor.OperationId = reader.ReadUInt16();
            return throwOperationDescriptor;
        }

        public static ToggleOperationDescriptor ReadEFTToggleOperationDescriptor(this BinaryReader reader)
        {
            return new ToggleOperationDescriptor
            {
                ItemId = reader.ReadString(),
                Value = reader.ReadBoolean(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static FoldOperationDescriptor ReadEFTFoldOperationDescriptor(this BinaryReader reader)
        {
            return new FoldOperationDescriptor
            {
                ItemId = reader.ReadString(),
                Value = reader.ReadBoolean(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static ShotOperationDescriptor ReadEFTShotOperationDescriptor(this BinaryReader reader)
        {
            return new ShotOperationDescriptor
            {
                ItemId = reader.ReadString(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static SetupItemOperationDescriptor ReadEFTSetupItemOperationDescriptor(this BinaryReader reader)
        {
            return new SetupItemOperationDescriptor
            {
                ItemId = reader.ReadString(),
                ZoneId = reader.ReadString(),
                Position = reader.ReadClassVector3(),
                Rotation = reader.ReadClassQuaternion(),
                SetupTime = reader.ReadSingle(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static ApplyOperationDescriptor ReadEFTApplyOperationDescriptor(this BinaryReader reader)
        {
            return new ApplyOperationDescriptor
            {
                ItemId = reader.ReadString(),
                TargetItemId = reader.ReadString(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static ApplyHealthOperationDescriptor ReadEFTApplyHealthOperationDescriptor(this BinaryReader reader)
        {
            return new ApplyHealthOperationDescriptor
            {
                ItemId = reader.ReadString(),
                BodyPart = (EBodyPart)reader.ReadInt32(),
                Count = reader.ReadInt32(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static CreateMapMarkerOperationDescriptor ReadEFTCreateMapMarkerOperationDescriptor(this BinaryReader reader)
        {
            return new CreateMapMarkerOperationDescriptor
            {
                MapItemId = reader.ReadString(),
                MapMarker = reader.ReadEFTInventoryLogicMapMarker(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static EditMapMarkerOperationDescriptor ReadEFTEditMapMarkerOperationDescriptor(this BinaryReader reader)
        {
            return new EditMapMarkerOperationDescriptor
            {
                MapItemId = reader.ReadString(),
                X = reader.ReadInt32(),
                Y = reader.ReadInt32(),
                MapMarker = reader.ReadEFTInventoryLogicMapMarker(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static DeleteMapMarkerOperationDescriptor ReadEFTDeleteMapMarkerOperationDescriptor(this BinaryReader reader)
        {
            return new DeleteMapMarkerOperationDescriptor
            {
                MapItemId = reader.ReadString(),
                X = reader.ReadInt32(),
                Y = reader.ReadInt32(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static AddNoteOperationDescriptor ReadEFTAddNoteOperationDescriptor(this BinaryReader reader)
        {
            return new AddNoteOperationDescriptor
            {
                Note = reader.ReadEFTNotesNote(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static EditNoteOperationDescriptor ReadEFTEditNoteOperationDescriptor(this BinaryReader reader)
        {
            return new EditNoteOperationDescriptor
            {
                Index = reader.ReadInt32(),
                Note = reader.ReadEFTNotesNote(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static DeleteNoteOperationDescriptor ReadEFTDeleteNoteOperationDescriptor(this BinaryReader reader)
        {
            return new DeleteNoteOperationDescriptor
            {
                Index = reader.ReadInt32(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static TagOperationDescriptor ReadEFTTagOperationDescriptor(this BinaryReader reader)
        {
            return new TagOperationDescriptor
            {
                ItemId = reader.ReadString(),
                TagName = reader.ReadString(),
                TagColor = reader.ReadInt32(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static OperateStationaryWeaponOperationDescriptor ReadEFTOperateStationaryWeaponOperationDescriptor(this BinaryReader reader)
        {
            return new OperateStationaryWeaponOperationDescriptor
            {
                WeaponId = reader.ReadString(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static WeaponRechamberOperationDescriptor ReadEFTWeaponRechamberOperationDescriptor(this BinaryReader reader)
        {
            return new WeaponRechamberOperationDescriptor
            {
                WeaponId = reader.ReadString(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static ObservedSyncItemsOperationDescriptor ReadEFTObservedSyncItemsOperationDescriptor(this BinaryReader reader)
        {
            ObservedSyncItemsOperationDescriptor observedSyncItemsOperationDescriptor = new ObservedSyncItemsOperationDescriptor();
            int num = reader.ReadInt32();
            observedSyncItemsOperationDescriptor.Items = new List<NestedItemDescriptor>(num);
            for (int i = 0; i < num; i++)
            {
                observedSyncItemsOperationDescriptor.Items.Add(reader.ReadEFTNestedItemDescriptor());
            }
            observedSyncItemsOperationDescriptor.InternalOperationDescriptor = reader.ReadPolymorph<AbstractInternalOperationDescriptor>();
            observedSyncItemsOperationDescriptor.OperationId = reader.ReadUInt16();
            return observedSyncItemsOperationDescriptor;
        }

        public static DialogContextServiceAvailabilityData ReadEFTTraderServiceAvailabilityData(this BinaryReader reader)
        {
            DialogContextServiceAvailabilityData dialogContextServiceAvailabilityData = new DialogContextServiceAvailabilityData();
            dialogContextServiceAvailabilityData.TraderId = reader.ReadMongoId();
            dialogContextServiceAvailabilityData.ServiceType = (ETraderServiceType)reader.ReadInt32();
            dialogContextServiceAvailabilityData.CanAfford = reader.ReadBoolean();
            dialogContextServiceAvailabilityData.WasPurchasedInThisRaid = reader.ReadBoolean();
            int num = reader.ReadInt32();
            dialogContextServiceAvailabilityData.ItemsToPay = new Dictionary<MongoID, int>();
            for (int i = 0; i < num; i++)
            {
                dialogContextServiceAvailabilityData.ItemsToPay[reader.ReadMongoId()] = reader.ReadInt32();
            }
            int num2 = reader.ReadInt32();
            dialogContextServiceAvailabilityData.UniqueItems = new MongoID[num2];
            for (int j = 0; j < num2; j++)
            {
                dialogContextServiceAvailabilityData.UniqueItems[j] = reader.ReadMongoId();
            }
            int num3 = reader.ReadInt32();
            dialogContextServiceAvailabilityData.SubServices = new Dictionary<string, int>();
            for (int k = 0; k < num3; k++)
            {
                dialogContextServiceAvailabilityData.SubServices[reader.ReadString()] = reader.ReadInt32();
            }
            return dialogContextServiceAvailabilityData;
        }

        public static QuestActionDescriptor ReadEFTQuestActionDescriptor(this BinaryReader reader)
        {
            return new QuestActionDescriptor
            {
                QuestId = reader.ReadString(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static Descriptor ReadEFTQuestAcceptDescriptor(this BinaryReader reader)
        {
            return new Descriptor
            {
                QuestId = reader.ReadString(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static QuestFinishDescriptor ReadEFTQuestFinishDescriptor(this BinaryReader reader)
        {
            return new QuestFinishDescriptor
            {
                QuestId = reader.ReadString(),
                OperationId = reader.ReadUInt16()
            };
        }

        public static QuestHandoverDescriptor ReadEFTQuestHandoverDescriptor(this BinaryReader reader)
        {
            QuestHandoverDescriptor questHandoverDescriptor = new QuestHandoverDescriptor();
            int num = reader.ReadInt32();
            questHandoverDescriptor.ItemIds = new MongoID[num];
            for (int i = 0; i < num; i++)
            {
                questHandoverDescriptor.ItemIds[i] = reader.ReadMongoId();
            }
            questHandoverDescriptor.ConditionId = reader.ReadMongoId();
            questHandoverDescriptor.QuestId = reader.ReadString();
            questHandoverDescriptor.OperationId = reader.ReadUInt16();
            return questHandoverDescriptor;
        }

        public static SceneResourceKey ReadEFTSceneResourceKey(this BinaryReader reader)
        {
            SceneResourceKey sceneResourceKey = new SceneResourceKey();
            sceneResourceKey.onlyOffline = reader.ReadBoolean();
            if (reader.ReadBoolean())
            {
                sceneResourceKey.path = reader.ReadString();
            }
            if (reader.ReadBoolean())
            {
                sceneResourceKey.rcid = reader.ReadString();
            }
            return sceneResourceKey;
        }

        public static ResourceKey ReadEFTResourceKey(this BinaryReader reader)
        {
            ResourceKey resourceKey = new ResourceKey();
            if (reader.ReadBoolean())
            {
                resourceKey.path = reader.ReadString();
            }
            if (reader.ReadBoolean())
            {
                resourceKey.rcid = reader.ReadString();
            }
            return resourceKey;
        }

        public static Note ReadEFTNotesNote(this BinaryReader reader)
        {
            return new Note
            {
                Time = reader.ReadSingle(),
                Text = reader.ReadString()
            };
        }

        public static InventoryLogicOperationsCreateItemsDescriptor ReadEFTInventoryLogicOperationsCreateItemsDescriptor(this BinaryReader reader)
        {
            InventoryLogicOperationsCreateItemsDescriptor inventoryLogicOperationsCreateItemsDescriptor = new InventoryLogicOperationsCreateItemsDescriptor();
            int num = reader.ReadInt32();
            inventoryLogicOperationsCreateItemsDescriptor.Items = new List<NestedItemDescriptor>(num);
            for (int i = 0; i < num; i++)
            {
                inventoryLogicOperationsCreateItemsDescriptor.Items.Add(reader.ReadEFTNestedItemDescriptor());
            }
            inventoryLogicOperationsCreateItemsDescriptor.OperationId = reader.ReadUInt16();
            return inventoryLogicOperationsCreateItemsDescriptor;
        }

        public static InventoryLogicOperationsPurchaseTraderServiceOperationDescriptor ReadEFTInventoryLogicOperationsPurchaseTraderServiceOperationDescriptor(this BinaryReader reader)
        {
            InventoryLogicOperationsPurchaseTraderServiceOperationDescriptor inventoryLogicOperationsPurchaseTraderServiceOperationDescriptor = new InventoryLogicOperationsPurchaseTraderServiceOperationDescriptor();
            inventoryLogicOperationsPurchaseTraderServiceOperationDescriptor.ServiceType = (ETraderServiceType)reader.ReadInt32();
            if (reader.ReadBoolean())
            {
                inventoryLogicOperationsPurchaseTraderServiceOperationDescriptor.SubServiceId = reader.ReadString();
            }
            inventoryLogicOperationsPurchaseTraderServiceOperationDescriptor.OperationId = reader.ReadUInt16();
            return inventoryLogicOperationsPurchaseTraderServiceOperationDescriptor;
        }

    }
}
