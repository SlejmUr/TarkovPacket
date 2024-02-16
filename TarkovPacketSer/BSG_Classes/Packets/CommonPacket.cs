using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public class CommonPacket
    {
        public static CommonPacket Deserialize(IReaderStream reader)
        {
            return new CommonPacket
            {
                StartSearchingActionPacket = reader.DeserializeStartSearchingActionPacket(),
                StopSearchingActionPacket = reader.DeserializeStopSearchingActionPacket(),
                UpdateAccessStatusPacket = reader.DeserializeUpdateAccessStatusPacket(),
                SetSearchedPacket = reader.DeserializeSetSearchedPacket(),
                StopSearchingPacket = reader.DeserializeStopSearchingPacket(),
                SyncPositionPacket = reader.DeserializeSyncPositionPacket(),
                SwitchRenderersPacket = reader.DeserializeSwitchRenderersPacket(),
                ChangeSkillLevelPacket = reader.DeserializeChangeSkillExperiencePacket(),
                ChangeMasteringLevelPacket = reader.DeserializeChangeMasteringLevelPacket()
            };
        }

        public SearchingAction? StartSearchingActionPacket;
        public SearchingAction? StopSearchingActionPacket;
        public UpdateAccessStatus? UpdateAccessStatusPacket;
        public SetSearched? SetSearchedPacket;
        public StopSearching? StopSearchingPacket;
        public SyncPosition? SyncPositionPacket;
        public SwitchRenderers? SwitchRenderersPacket;
        public SkillPacket? ChangeSkillLevelPacket;
        public ChangeMasteringLevel? ChangeMasteringLevelPacket;
    }
}
