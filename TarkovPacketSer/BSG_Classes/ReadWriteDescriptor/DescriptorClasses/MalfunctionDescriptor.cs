namespace TarkovPacketSer.BSG_Classes.ReadWriteDescriptor.DescriptorClasses
{
    public sealed class MalfunctionDescriptor
    {
        public byte Malfunction;

        public float LastShotOverheat;

        public float LastShotTime;

        public bool SlideOnOverheatReached;

        public List<string> PlayersWhoKnowAboutMalfunction;

        public List<string> PlayersWhoKnowMalfType;

        public Dictionary<string, byte> PlayersReducedMalfChances;

        public string AmmoToFireTemplateId;

        public string AmmoWillBeLoadedToChamberTemplateId;

        public string AmmoMalfunctionedTemplateId;
    }
}