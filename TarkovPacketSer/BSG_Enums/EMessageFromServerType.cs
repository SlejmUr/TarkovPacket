using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TarkovPacketSer.BSG_Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EMessageFromServerType
    {
        World,
        Player,
        Data,
        Vehicle,
        MAX_VALUE = 3
    }
}
