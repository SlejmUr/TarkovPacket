using TarkovPacketSer.BSG_Classes;
using TarkovPacketSer.BSG_Classes.Packets;
using TarkovPacketSer.BSG_Enums;
using TarkovPacketSer.RetardedBitReader;

namespace TarkovPacketSer.BE_PacketFormat
{
    internal class MessageFromServer
    {
        public static string Token = "100703687"; // method_10
        public static MessageFromServer Deserialize(byte[] data)
        {
            MessageFromServer replyPacket = new();
            MyReader reader = new(data);
            replyPacket.ChannnelId = reader.ReadByte();
            replyPacket.MessageType = (EMessageFromServerType)reader.ReadLimitedInt32(0, 3);
            replyPacket.Bytes = reader.Buffer;
            if (replyPacket.MessageType == EMessageFromServerType.Player)
            {

                try
                {
                    var clientPlayer = ClientPlayer.Deserialize(reader);
                    replyPacket.Data = clientPlayer;
                }
                catch (Exception)
                {

                }
            }
            if (replyPacket.MessageType == EMessageFromServerType.World)
            {
                try
                {
                    var worldPacket = GameWorld.DeserializeGameWorldPacket(reader, OlderPacket);
                    OlderPacket = worldPacket;
                    replyPacket.Data = worldPacket;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
            return replyPacket;
        }

        public static GameWorldPacket OlderPacket = GameWorldPacket.Create();
        private GameWorldPacket OlderPacket_nonstatic = GameWorldPacket.Create();
        private List<byte> PlayerData;
        private List<byte> WorldData;
        public MessageFromServer()
        {
            PlayerData = new();
            WorldData = new();
        }
        public void Deserializer(byte[] data)
        {
            MyReader reader = new(data);
            ChannnelId = reader.ReadByte();
            MessageType = (EMessageFromServerType)reader.ReadLimitedInt32(0, 3);
            if (MessageType == EMessageFromServerType.Player)
            {
                PlayerData.AddRange(reader.Buffer);
                try
                {
                    var clientPlayer = ClientPlayer.Deserialize(reader);
                    Data = clientPlayer;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
            if (MessageType == EMessageFromServerType.World)
            {
                WorldData.AddRange(reader.Buffer);
                try
                {
                    var worldPacket = GameWorld.DeserializeGameWorldPacket(reader, OlderPacket_nonstatic);
                    OlderPacket_nonstatic = worldPacket;
                    Data = worldPacket;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
        }

        public byte ChannnelId;
        public EMessageFromServerType MessageType;
        public object Data;
        public byte[] Bytes;
    }
}
