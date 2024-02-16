using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TarkovPacketSer.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum ELampState
{
    TurningOn,
    TurningOff,
    On,
    Off,
    Destroyed,
    ConstantFlickering,
    SmoothOff
}