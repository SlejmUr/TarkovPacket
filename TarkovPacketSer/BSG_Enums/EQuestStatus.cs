using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.BSG_Enums
{
    public enum EQuestStatus
    {

        Locked,

        AvailableForStart,

        Started,

        AvailableForFinish,

        Success,

        Fail,

        FailRestartable,

        MarkedAsFailed,

        Expired,

        AvailableAfter
    }
}
