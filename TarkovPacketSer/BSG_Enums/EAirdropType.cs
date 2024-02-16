using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TarkovPacketSer.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum EAirdropType
{
    Common,
    Supply,
    Medical,
    Weapon
}