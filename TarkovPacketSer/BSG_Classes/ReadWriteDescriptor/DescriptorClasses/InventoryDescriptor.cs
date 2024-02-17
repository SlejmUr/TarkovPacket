using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.BSG_Classes.ReadWriteDescriptor.DescriptorClasses
{
    public sealed class InventoryDescriptor
    {

        public ItemDescriptor Equipment;
        public ItemDescriptor Stash;
        public ItemDescriptor QuestRaidItems;
        public ItemDescriptor QuestStashItems;
        public ItemDescriptor SortingTable;
        public FastAccessDescriptor FastAccess;
        public DiscardLimit DiscardLimits;
    }
}
