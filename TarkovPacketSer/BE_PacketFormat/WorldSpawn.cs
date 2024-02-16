using Newtonsoft.Json;
using TarkovPacketSer.BSG_Classes;
using TarkovPacketSer.Enums;

namespace TarkovPacketSer.BE_PacketFormat
{
    internal class WorldSpawn
    {
        public static WorldSpawn Deserialize(byte[] data)
        {
            data = data.Skip(4).ToArray();
            WorldSpawn replyPacket = new();
            BinaryReader binaryReader = new(new MemoryStream(data));
            replyPacket.exfiltrationController = new();
            replyPacket.exfiltrationController.Deserialize(binaryReader);
            replyPacket.bufferZoneControllerClass = new();
            replyPacket.bufferZoneControllerClass.Deserialize(binaryReader);
            replyPacket.InitializeSmokeGrenades(binaryReader);
            replyPacket.InitializeDoors(binaryReader);
            replyPacket.InitializeLampControllers(binaryReader);
            replyPacket.InitializeWindowBreakers(binaryReader);
            replyPacket.SynchronizableObjectType(binaryReader);
            replyPacket.ReadBTR(binaryReader);
            binaryReader.Close();
            binaryReader.Dispose();
            return replyPacket;
        }

        void InitializeSmokeGrenades(BinaryReader reader)
        {
            Int32 smokeGrenadesCount = reader.ReadInt32();
            Console.WriteLine(smokeGrenadesCount);
            this.SmokeGrenades = new();
            for (Int32 i = 0; i < smokeGrenadesCount; i++)
            {
                SmokeGrenadeInfo smokeGrenadeInfo =new SmokeGrenadeInfo();
                smokeGrenadeInfo.Deserialize(reader);
                SmokeGrenades.Add(smokeGrenadeInfo);
            }
        }

        void InitializeDoors(BinaryReader reader)
        {
            Int32 doorsCount = reader.ReadInt32();
            Console.WriteLine(doorsCount);
            this.DoorInfos = new();
            for (Int32 i = 0; i < doorsCount; i++)
            {
                DoorInfo doorInfo = new DoorInfo();
                doorInfo.Deserialize(reader);
                Console.WriteLine("Door Readed: " + JsonConvert.SerializeObject(doorInfo));
                DoorInfos.Add(doorInfo);
            }
        }
        void InitializeLampControllers(BinaryReader reader)
        {
            Int32 lampControllersCount = reader.ReadInt32();
            Console.WriteLine(lampControllersCount);
            this.LampControllerInfos = new();
            for (Int32 i = 0; i < lampControllersCount; i++)
            {
                LampControllerInfo lampControllerInfo = new LampControllerInfo();
                lampControllerInfo.Deserialize(reader);
                LampControllerInfos.Add(lampControllerInfo);
            }
        }

        void InitializeWindowBreakers(BinaryReader reader)
        {
            Int32 windowBreakersCount = reader.ReadInt32();
            Console.WriteLine(windowBreakersCount);
            this.WindowBreakerInfos = new();
            for (Int32 i = 0; i < windowBreakersCount; i++)
            {
                WindowBreakerInfo windowBreakerInfo = new WindowBreakerInfo();
                windowBreakerInfo.Deserialize(reader);
                WindowBreakerInfos.Add(windowBreakerInfo);
            }
        }

        void SynchronizableObjectType(BinaryReader reader)
        {
            Int32 SynchronizableObjectTypesCount = reader.ReadUInt16();
            Console.WriteLine(SynchronizableObjectTypesCount);
            SynchronizableObjectTypes = new();
            for (Int32 i = 0; i < SynchronizableObjectTypesCount; i++)
            {
                var type = (ESynchronizableObjectType)reader.ReadByte();
                if (type == ESynchronizableObjectType.AirDrop)
                {
                    AirDrop airDrop = new();
                    airDrop.Deserialize(reader);
                    SynchronizableObjectTypes.Add((type,airDrop));
                }
                else if (type == ESynchronizableObjectType.AirPlane)
                {
                    AirPlane airPlane = new();
                    airPlane.Deserialize(reader);
                    SynchronizableObjectTypes.Add((type, airPlane));
                }
            }
        }

        void ReadBTR(BinaryReader reader)
        {
            BTR = new();
            BTR.Deserialize(reader);
        }

        public ExfiltrationController exfiltrationController;
        public BufferZoneControllerClass bufferZoneControllerClass;
        public List<SmokeGrenadeInfo> SmokeGrenades;
        public List<DoorInfo> DoorInfos;
        public List<LampControllerInfo> LampControllerInfos;
        public List<WindowBreakerInfo> WindowBreakerInfos;
        public List<(ESynchronizableObjectType, object)> SynchronizableObjectTypes;
        public BTR BTR;
    }
}
