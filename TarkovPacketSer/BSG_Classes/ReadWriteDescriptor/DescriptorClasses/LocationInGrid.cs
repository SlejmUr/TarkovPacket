using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes.ReadWriteDescriptor.DescriptorClasses
{
    [Serializable]
    public sealed class LocationInGrid
    {
        public LocationInGrid()
        {
            this.isSearched = true;
        }

        public LocationInGrid(int x, int y, ItemRotation r) : this(x, y, r, true)
        {
        }

        public LocationInGrid(int x, int y, ItemRotation r, bool searched)
        {
            this.x = x;
            this.y = y;
            this.r = r;
            this.isSearched = searched;
        }

        public override string ToString()
        {
            return string.Concat(new object[]
            {
            "(x: ",
            this.x,
            ", y: ",
            this.y,
            ", r: ",
            this.r,
            ")"
            });
        }

        public LocationInGrid Clone()
        {
            return new LocationInGrid(this.x, this.y, this.r);
        }

        public int x;

        public int y;

        public ItemRotation r;

        public bool isSearched = true;
    }
}
