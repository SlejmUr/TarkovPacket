using System.Numerics;

namespace TarkovPacketSer.BSG_Classes
{
    public class WindowBreakerInfo
    {
        public void Deserialize(BinaryReader reader)
        {
            this.Id = reader.ReadInt32();
            this.Position = reader.ReadVector3();

        }
        public Int32 Id;
        public Vector3 Position;
    }
}
