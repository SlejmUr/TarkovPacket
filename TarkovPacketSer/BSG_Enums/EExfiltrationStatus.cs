using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TarkovPacketSer.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum EExfiltrationStatus : byte
{
	NotPresent = 1,
	UncompleteRequirements,
	Countdown,
	RegularMode,
	Pending,
	AwaitsManualActivation
}