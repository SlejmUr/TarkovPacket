using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarkovPacketSer.BSG_Enums;
using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public static partial class DeserializerPacketsEXT
    {
        public static void Serialize(this ISerializer2 stream, ref HitInfo hitInfo)
        {
            stream.Serialize<EBodyPart>(ref hitInfo.BodyPart);
            stream.Serialize<EDamageType>(ref hitInfo.DamageType);
            stream.Serialize(ref hitInfo.Damage);
            if (hitInfo.DamageType == EDamageType.Melee)
            {
                stream.Serialize(ref hitInfo.HitPoint);
                stream.Serialize(ref hitInfo.DamagerPlayerProfileID, new uint?(1200U));
                stream.Serialize(ref hitInfo.HitNormal);
            }
        }

        public static void Serialize(this ISerializer2 stream, ref ArmorUpdate armorUpdate)
        {
            stream.SerializeLimitedString(ref armorUpdate.Id, ' ', 'z', BitPackingTag.ArmorUpdateId, new uint?(1200U));
            stream.SerializeLimitedFloat(ref armorUpdate.Durability, 0f, 120f, 0.1f, BitPackingTag.ArmorUpdateDurability);
        }

        public static void Serialize(this ISerializer2 stream, ref Update sideEffectUpdate)
        {
            stream.SerializeLimitedString(ref sideEffectUpdate.Id, ' ', 'z', BitPackingTag.PoisonUpdateId, new uint?(1200U));
            stream.SerializeLimitedFloat(ref sideEffectUpdate.Resource, 0f, 100f, 1f, BitPackingTag.PoisonUpdateResource);
        }

        public static void Serialize(this ISerializer2 stream, ref DHitInfo dHitInfo)
        {
            stream.SerializeLimitedInt32(ref dHitInfo.Damage, 0, 500, BitPackingTag.DetailedHitInfo0);
            stream.SerializeLimitedInt32(ref dHitInfo.Absorbed, 0, 500, BitPackingTag.DetailedHitInfo1);
            stream.Serialize<EBodyPart>(ref dHitInfo.Part);
            stream.Serialize<EHitSpecial>(ref dHitInfo.Special);
            stream.SerializeLimitedInt32(ref dHitInfo.StaminaLoss, 0, 255, BitPackingTag.DetailedHitInfo4);
            stream.Serialize<EDamageType>(ref dHitInfo.DamageType);
        }

        public static void Serialize(this ISerializer2 stream, ref StatusPacket operationStatus)
        {
            stream.Serialize(ref operationStatus.Id);
            stream.Serialize<EOperationStatus>(ref operationStatus.Status);
            if (operationStatus.Status == EOperationStatus.Failed)
            {
                stream.SerializeLimitedString(ref operationStatus.Error, ' ', '\u007f', BitPackingTag.InventoryOperationStatusError, new uint?(1200U));
            }
            bool flag = false;
            stream.Serialize(ref flag);
            if (flag)
            {
                int num = 0;
                bool flag2 = false;
                stream.Serialize(ref num);
                stream.Serialize(ref flag2);
            }
        }

        public static void Serialize(this ISerializer2 stream, ref Condition condition)
        {
            stream.Serialize(ref condition.ConditionId);
            stream.Serialize<EQuestStatus>(ref condition.Status);
            bool flag = condition.Value <= 15f;
            stream.Serialize(ref flag);
            if (flag)
            {
                stream.SerializeLimitedFloat(ref condition.Value, -1f, 15f, 0.01f, BitPackingTag.ConditionValue1);
            }
            else
            {
                stream.SerializeLimitedFloat(ref condition.Value, 15f, 1209600f, 0.01f, BitPackingTag.ConditionValue2);
            }
            stream.Serialize(ref condition.Notify);
        }
    }
}
