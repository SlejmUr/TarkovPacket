using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes.ReadWriteDescriptor.DescriptorClasses
{
    [Serializable]
    public class MapMarker
    {
        public MapMarker()
        {
        }
        public MapMarker(MapMarkerType type, int x, int y, string note)
        {
            Type = type;
            X = x;
            Y = y;
            Note = note;
        }
        public MapMarkerType Type;
        public int X;
        public int Y;
        public string Note;
    }
}