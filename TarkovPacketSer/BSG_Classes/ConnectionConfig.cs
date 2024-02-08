using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes
{
    internal class ConnectionConfig
    {
        public void Deserialize(BinaryReader reader)
        {
            this.DefaultPlayerStateLimits = PlayerStateLimits.Deserialize(reader);
            this.DictPlayerStateLimits = DeserializeToDict(reader);
        }
        public PlayerStateLimits DefaultPlayerStateLimits;
        public Dictionary<EPlayerState, PlayerStateLimits> DictPlayerStateLimits;

        static Dictionary<EPlayerState, PlayerStateLimits> DeserializeToDict(BinaryReader reader)
        {
            Dictionary<EPlayerState, PlayerStateLimits> playerStateLimits = new();
            playerStateLimits.Clear();
            int num = reader.ReadInt32();
            for (int i = 0; i < num; i++)
            {
                EPlayerState key = (EPlayerState)reader.ReadByte();
                PlayerStateLimits value = default(PlayerStateLimits);
                value = PlayerStateLimits.Deserialize(reader);
                playerStateLimits[key] = value;
            }
            return playerStateLimits;
        }
    }
}
