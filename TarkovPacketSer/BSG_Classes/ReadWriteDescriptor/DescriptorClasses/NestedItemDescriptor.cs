using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.BSG_Classes.ReadWriteDescriptor.DescriptorClasses
{
    public sealed class NestedItemDescriptor
    {
        public AbstractDescriptor Address;
        public ItemDescriptor Item;
    }
}
