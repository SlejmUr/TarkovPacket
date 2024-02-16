using System.Numerics;
using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes
{
    public class UsualPositionQuantizer
    {
        public UsualPositionQuantizer(float xMin, float xMax, float xResolution, float yMin, float yMax, float yResolution, float zMin, float zMax, float zResolution, bool checkBounds = false)
        {
            this.gstruct100_0 = new FloatQuantizer(xMin, xMax, xResolution, checkBounds);
            this.gstruct100_1 = new FloatQuantizer(yMin, yMax, yResolution, checkBounds);
            this.gstruct100_2 = new FloatQuantizer(zMin, zMax, zResolution, checkBounds);
        }

        public void Read(IReaderStream bitReaderStream, out Vector3 value)
        {
            this.gstruct100_0.Read(bitReaderStream, out value.X);
            this.gstruct100_1.Read(bitReaderStream, out value.Y);
            this.gstruct100_2.Read(bitReaderStream, out value.Z);
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}, {2}: {3}, {4}: {5}", new object[]
            {
            "_xFloatQuantizer",
            this.gstruct100_0,
            "_yFloatQuantizer",
            this.gstruct100_1,
            "_zFloatQuantizer",
            this.gstruct100_2
            });
        }

        public Bounds GetBounds()
        {
            return new Bounds
            {
                min = new Vector3(this.gstruct100_0.Min, this.gstruct100_1.Min, this.gstruct100_2.Min),
                max = new Vector3(this.gstruct100_0.Max, this.gstruct100_1.Max, this.gstruct100_2.Max)
            };
        }

        private readonly FloatQuantizer gstruct100_0;

        private readonly FloatQuantizer gstruct100_1;

        private readonly FloatQuantizer gstruct100_2;
    }
}
