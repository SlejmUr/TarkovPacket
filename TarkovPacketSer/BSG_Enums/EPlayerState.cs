using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TarkovPacketSer.BSG_Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EPlayerState : byte
    {

        None,

        Idle,

        ProneIdle,

        ProneMove,

        Run,

        Sprint,

        Jump,

        FallDown,

        Transition,

        BreachDoor,

        Loot,

        Pickup,

        Open,

        Close,

        Unlock,

        Sidestep,

        DoorInteraction,

        Approach,

        Prone2Stand,

        Transit2Prone,

        Plant,

        Stationary,

        Roll,

        JumpLanding,

        ClimbOver,

        ClimbUp,

        VaultingFallDown,

        VaultingLanding,

        BlindFire
    }
}
