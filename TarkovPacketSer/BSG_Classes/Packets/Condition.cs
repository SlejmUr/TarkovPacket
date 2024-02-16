using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct Condition
    {
        public int ConditionId;

        public EQuestStatus Status;

        public float Value;

        public bool Notify;
    }
}