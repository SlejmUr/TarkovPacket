using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct DHitInfo
    {

        public EDamageType DamageType;

        public int Damage;

        public int Absorbed;

        public EBodyPart Part;

        public EHitSpecial Special;

        public int StaminaLoss;
    }
}
