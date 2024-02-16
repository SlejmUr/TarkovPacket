namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct WeaponOverheatPacket : INested<WeaponOverheatPacket>
    {
        public INested<WeaponOverheatPacket> Nested { get; set; }

        public string WeaponId;

        public float LastShotTime;

        public float LastOverheat;

        public bool SlideOnOverheatReached;
    }
}