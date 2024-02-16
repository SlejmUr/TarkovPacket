using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarkovPacketSer.BSG_Enums;
using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    internal static class MFS_Data
    {
        public static MFS_DataPacket DeserializeGameWorldPacket(this IReaderStream readerStream)
        {
            MFS_DataPacket dataPacket = new();
            dataPacket.int_0 = readerStream.ReadInt32();
            /*
            while (readerStream.ReadBool())
            {
                int num = readerStream.ReadInt32();              
                EDataLifeTime dataLifeTime = readerStream.ReadEnum<EDataLifeTime>();
            }*/
            return dataPacket;
        }

        public struct MFS_DataPacket
        {
            public int int_0;
        }

        public struct IDK
        {
            public int TypeId;
            public EDataLifeTime DataLifeTime;

        }
    }
}
