using System.Numerics;
using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct SyncHealthPacket : INested<SyncHealthPacket>
    {
        public INested<SyncHealthPacket> Nested { get; set; }
        public ESyncType SyncType;
        public DataStruct Data;

        public enum ESyncType
        {

            AddEffect,

            RemoveEffect,

            EffectNextState,

            EffectStateTime,

            EffectStrength,

            EffectMedResource,

            EffectStimulatorBuff,

            IsAlive,

            BodyHealth,

            Energy,

            Hydration,

            Temperature,

            DamageCoeff,

            ApplyDamage,

            DestroyedBodyPart,

            HealthRates,

            HealerDone,

            BurnEyes,

            Poison,

            StaminaCoeff
        }

        public struct AddEffect
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}, {2}: {3}, {4}: {5}", new object[]
                {
                "EffectId",
                this.EffectId,
                "Type",
                this.Type,
                "BodyPart",
                this.BodyPart
                });
            }

            public int EffectId;

            public byte Type;

            public EBodyPart BodyPart;

            public float DelayTime;
            public float BuildUpTime;

            public float WorkTime;
            public float ResidueTime;

            public float Strength;

            public AddEffect.EExtraDataType ExtraDataType;

            public object ExtraData;

            public enum EExtraDataType
            {

                None,

                MedEffect,

                Stimulator
            }
            /*
            [StructLayout(LayoutKind.Explicit)]
            public struct ExtraDataStruct
            {

    
                public MedEffect MedEffect;

    
                public StimulatorStruct Stimulator;
            }*/
        }

        public struct RemoveEffect
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}", "EffectId", this.EffectId);
            }

            public int EffectId;
        }

        public struct EffectNextState
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}, {2}: {3}", new object[]
                {
                "EffectId",
                this.EffectId,
                "StateTime",
                this.StateTime
                });
            }

            public int EffectId;

            public float StateTime;
        }

        public struct EffectStateTime
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}, {2}: {3}", new object[]
                {
                "EffectId",
                this.EffectId,
                "RemainingStateTime",
                this.RemainingStateTime
                });
            }

            public int EffectId;

            public float RemainingStateTime;
        }

        public struct EffectStrength
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}, {2}: {3}", new object[]
                {
                "EffectId",
                this.EffectId,
                "Strength",
                this.Strength
                });
            }

            public int EffectId;

            public float Strength;
        }

        public struct EffectMedResource
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}, {2}: {3}", new object[]
                {
                "EffectId",
                this.EffectId,
                "Resource",
                this.Resource
                });
            }

            public int EffectId;

            public float Resource;
        }

        public struct EffectStimulatorBuff
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}, {2}: {3}, {4}: {5}, {6}: {7}, {8}: {9}, {10}: {11}", new object[]
                {
                "EffectId",
                this.EffectId,
                "BuffIndex",
                this.BuffIndex,
                "BuffActivate",
                this.BuffActivate,
                "BuffValue",
                this.BuffValue,
                "BuffDuration",
                this.BuffDuration,
                "BuffDelay",
                this.BuffDelay
                });
            }

            public int EffectId;

            public int BuffIndex;

            public bool BuffActivate;

            public float BuffValue;

            public float BuffDuration;

            public float BuffDelay;
        }

        public struct IsAlive
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}, {2}: {3}", new object[]
                {
                "IsAlive",
                this.bIsAlive,
                "DamageType",
                this.DamageType
                });
            }

            public bool bIsAlive;

            public EDamageType DamageType;
        }

        public struct BodyHealth
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}, {2}: {3}", new object[]
                {
                "BodyPart",
                this.BodyPart,
                "Value",
                this.Value
                });
            }

            public EBodyPart BodyPart;

            public float Value;
        }

        public struct Energy
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}", "Value", this.Value);
            }

            public float Value;
        }

        public struct DamageCoeff
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}", "DamageCoeff", this.fDamageCoeff);
            }

            public float fDamageCoeff;
        }

        public struct StaminaCoeff
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}", "StaminaCoeff", this.fStaminaCoeff);
            }

            public float fStaminaCoeff;
        }

        public struct ApplyDamage
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}, {2}: {3}, {4}: {5}", new object[]
                {
                "BodyPart",
                this.BodyPart,
                "Damage",
                this.Damage,
                "DamageType",
                this.DamageType
                });
            }

            public EBodyPart BodyPart;

            public float Damage;

            public EDamageType DamageType;
        }

        public struct DestroyedBodyPart
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}, {2}: {3}, {4}: {5}, {6}: {7}", new object[]
                {
                "BodyPart",
                this.BodyPart,
                "IsDestroyed",
                this.IsDestroyed,
                "DamageType",
                this.DamageType,
                "HealthMaximum",
                this.HealthMaximum
                });
            }

            public EBodyPart BodyPart;

            public bool IsDestroyed;

            public EDamageType DamageType;

            public float HealthMaximum;
        }

        public struct HealthRates
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}, {2}: {3}, {4}: {5}, {6}: {7}, {8}: {9}, {10}: {11}", new object[]
                {
                "HealRate",
                this.HealRate,
                "DamageRate",
                this.DamageRate,
                "DamageMultiplier",
                this.DamageMultiplier,
                "Energy",
                this.Energy,
                "Hydration",
                this.Hydration,
                "Temperature",
                this.Temperature
                });
            }

            public float HealRate;

            public float DamageRate;

            public float DamageMultiplier;

            public float Energy;

            public float Hydration;

            public float Temperature;
        }

        public struct HealerDone
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}", "EffectId", this.EffectId);
            }

            public int EffectId;
        }

        public struct BurnEyes
        {

            public override string ToString()
            {
                return string.Format("{0}: {1}, {2}: {3}, {4}: {5}", new object[]
                {
                "Position",
                this.Position,
                "DistanceStrength",
                this.DistanceStrength,
                "NormalTime",
                this.NormalTime
                });
            }

            public Vector3 Position;

            public float DistanceStrength;

            public float NormalTime;
        }

        //[StructLayout(LayoutKind.Explicit)]
        public struct DataStruct
        {


            public AddEffect AddEffect;


            public RemoveEffect RemoveEffect;


            public EffectNextState EffectNextState;


            public EffectStateTime EffectStateTime;


            public EffectStrength EffectStrength;


            public EffectMedResource EffectMedResource;


            public EffectStimulatorBuff EffectStimulatorBuff;


            public IsAlive IsAlive;


            public BodyHealth BodyHealth;


            public Energy Energy;


            public Energy Hydration;


            public Energy Temperature;


            public Energy Poison;


            public DamageCoeff DamageCoeff;


            public StaminaCoeff StaminaCoeff;


            public ApplyDamage ApplyDamage;


            public DestroyedBodyPart DestroyedBodyPart;


            public HealthRates HealthRates;


            public HealerDone HealerDone;


            public BurnEyes BurnEyes;
        }
    }
}
