namespace TarkovPacketSer.BSG_Classes.ReadWriteDescriptor.DescriptorClasses
{
    public sealed class ItemDescriptor
    {
        public string Id;

        public string TemplateId;

        public int StackCount;

        public bool SpawnedInSession;

        public byte ActiveCamora;

        public bool IsUnderBarrelDeviceActive;

        public List<AbstractComponent> Components;

        public List<SlotDescriptor> Slots;

        public List<ShellTemplateDescriptor> ShellsInWeapon;

        public List<ShellTemplateDescriptor> ShellsInUnderbarrelWeapon;

        public List<GridDescriptor> Grids;

        public List<StackSlotDescriptor> StackSlots;

        public List<MalfunctionDescriptor> Malfunction;
    }
}