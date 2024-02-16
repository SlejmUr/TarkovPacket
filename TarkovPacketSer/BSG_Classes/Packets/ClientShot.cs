namespace TarkovPacketSer.BSG_Classes.Packets
{
    [Serializable]
    public struct ClientShot
    {
        public bool Approved;
        public int BodyPart;
        public float Damage;
        public float LeftBodyPartHealth;
        public string TargetName;
    }
}