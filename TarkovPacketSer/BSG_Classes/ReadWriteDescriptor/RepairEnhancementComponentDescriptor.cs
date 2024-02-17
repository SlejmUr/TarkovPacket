using TarkovPacketSer.BSG_Classes.ReadWriteDescriptor.DescriptorClasses;
using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes.ReadWriteDescriptor
{
    public class RepairEnhancementComponentDescriptor : AbstractComponent
    {
        public ERepairBuffType BuffType;

        public EBuffRarity BuffRarity;

        public float Value;

        public float ThresholdDurability;
    }
}