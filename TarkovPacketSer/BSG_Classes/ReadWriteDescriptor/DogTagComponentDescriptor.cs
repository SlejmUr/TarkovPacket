using TarkovPacketSer.BSG_Classes.ReadWriteDescriptor.DescriptorClasses;
using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes.ReadWriteDescriptor
{
    public class DogTagComponentDescriptor : AbstractComponent
    {
        public string AccountId = "";

        public string ProfileId = "";

        public string Nickname = "";

        public EPlayerSide Side;

        public int Level;

        public double Time;

        public string Status = "";

        public string KillerAccountId = "";

        public string KillerProfileId = "";

        public string KillerName = "";

        public string WeaponName = "";

        public bool CarriedByGroupMember;
    }
}