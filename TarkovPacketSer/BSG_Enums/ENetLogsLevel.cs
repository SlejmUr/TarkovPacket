using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TarkovPacketSer.BSG_Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ENetLogsLevel
    {
        None,
        Minimum,
        Normal,
        Maximun
    }
}
