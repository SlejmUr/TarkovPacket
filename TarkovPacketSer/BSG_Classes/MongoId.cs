using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovPacketSer.BSG_Classes
{
    public class MongoID
    {
        public static MongoID Read(BinaryReader reader)
        {
            return new MongoID(reader);
        }
        public MongoID(BinaryReader reader)
        {
            this._timeStamp = reader.ReadUInt32();
            this._counter = reader.ReadUInt64();
            this._stringID = null;
            this._stringID = this.method_1();
        }
      
        public string method_1()
        {
            return MongoID.smethod_0(this._timeStamp, this._counter);
        }

        public static string smethod_0(uint timeStamp, ulong counter)
        {
            return timeStamp.ToString("X8").ToLower() + counter.ToString("X16").ToLower();
        }

        public readonly uint _timeStamp;
        public readonly ulong _counter;
        public readonly string _stringID;
    }
}
