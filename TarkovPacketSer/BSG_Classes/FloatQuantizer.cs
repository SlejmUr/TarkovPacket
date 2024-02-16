using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes
{
    public struct FloatQuantizer
    {
        public FloatQuantizer(float min, float max, float resolution, bool checkBounds = false)
        {
            this.Min = min;
            this.Max = max;
            this.Resolution = resolution;
            this.CheckBounds = checkBounds;
            RBR.CalculateDataForQuantizing(this.Min, this.Max, this.Resolution, out this.Delta, out this.MaxIntegerValue, out this.BitsRequired);
        }

        public readonly float Min;

        public readonly float Max;

        public readonly float Resolution;

        public readonly int BitsRequired;

        public readonly float Delta;

        public readonly int MaxIntegerValue;

        public readonly bool CheckBounds;
    }
}
