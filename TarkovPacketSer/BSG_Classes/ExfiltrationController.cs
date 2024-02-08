using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.BSG_Classes
{
    public class ExfiltrationController
    {
        public void Deserialize(BinaryReader reader)
        {
            exfilDatas = new();
            short num = reader.ReadInt16();
            for (int i = 0; i < num; i++) 
            {
                ExfilData exfilData = new ExfilData();
                exfilData.Deserialize(reader);
                exfilDatas.Add(exfilData);
            }
        }

        public List<ExfilData> exfilDatas;
    }
}
