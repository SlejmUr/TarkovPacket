using Newtonsoft.Json;
using TarkovPacketSer.BSG_Classes;

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
            //SynchronizableObjectType
            //BTR
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

        public ExfiltrationController exfiltrationController;
        public BufferZoneControllerClass bufferZoneControllerClass;
        public List<SmokeGrenadeInfo> SmokeGrenades;
        public List<DoorInfo> DoorInfos;
        public List<LampControllerInfo> LampControllerInfos;
        public List<WindowBreakerInfo> WindowBreakerInfos;
    }
}
