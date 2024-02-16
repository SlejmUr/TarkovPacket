using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes.Packets
{    
    public struct PlayerDiedPacket
    {
        public string Aggressor;

        public string AggressorMainProfileName;

        public EPlayerSide AggressorSide;

        public EBodyPartColliderType ColliderType;

        public string WeaponName;

        public EMemberCategory MemberCategory;
    }
}