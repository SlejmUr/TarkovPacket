using TarkovPacketSer.BSG_Enums;
using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct InteractWithBtrPacket
    {
        public void Deserialize(IReaderStream reader)
        {
            if (reader.ReadBool())
            {
                this.HasInteraction = true;
                this.InteractionType = (EInteractionType)reader.ReadLimitedInt32(5, 6);
                this.SideId = reader.ReadByte();
                this.SlotId = reader.ReadByte();
                this.Fast = reader.ReadBool();
            }
        }

        public bool HasInteraction;

        public EInteractionType InteractionType;

        public byte SideId;

        public byte SlotId;

        public bool Fast;
    }
}