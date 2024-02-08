namespace TarkovPacketSer.BSG_Classes
{
    internal class PlayerStateLimits
    {
        public static PlayerStateLimits Deserialize(BinaryReader reader)
        {
            return new PlayerStateLimits
            {
                MinSpeed = reader.ReadSingle(),
                MaxSpeed = reader.ReadSingle(),
            };
        }

        public float MinSpeed;
        public float MaxSpeed;
    }
}
