namespace TarkovPacketSer.Enums;

[Flags]
public enum EDoorState : byte 
{
	None = 0,
	Locked = 1,
	Shut = 2,
	Open = 4,
	Interacting = 8,
	Breaching = 16
}