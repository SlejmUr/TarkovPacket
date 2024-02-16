namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct ClientConfirmCallbackPacket : INested<ClientConfirmCallbackPacket>
    {
        public INested<ClientConfirmCallbackPacket> Nested { get ; set; }

        public uint CallbackId;

        public string Error;

        public int InventoryHashSum;

        public byte BadBeforeExecuting;
    }
}