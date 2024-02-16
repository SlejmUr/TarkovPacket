using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.BSG_Classes.Packets
{
    public struct HitInfo
    {
        public EBodyPart BodyPart;

        public EDamageType DamageType;

        public float Damage;

        public Vector3 HitPoint;

        public string DamagerPlayerProfileID;

        public Vector3 HitNormal;
    }
}