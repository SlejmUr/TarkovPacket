using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using TarkovPacketSer.BSG_Classes;
using TarkovPacketSer.BSG_Classes.Packets;
using TarkovPacketSer.BSG_Enums;
using TarkovPacketSer.RetardedBitReader;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static TarkovPacketSer.PacketFormat.ConnectionRequestPacker;

namespace TarkovPacketSer.BE_PacketFormat
{
    internal class MessageFromServer
    {
        public static string Token = "100703687"; // method_10
        public static MessageFromServer Deserialize(byte[] data)
        {
            Console.WriteLine();
            MessageFromServer replyPacket = new();
            MyReader reader = new(data); 
            Console.WriteLine(reader.BytesRead);
            replyPacket.ChannnelId = reader.ReadByte();
            Console.WriteLine(reader.BytesRead);
            replyPacket.MessageType = (EMessageFromServerType)reader.ReadLimitedInt32(0,3);
            Console.WriteLine(reader.BytesRead);
            Console.WriteLine("ChannelId: " + replyPacket.ChannnelId);
            Console.WriteLine("MessageType: " + replyPacket.MessageType.ToString());
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
            Console.WriteLine("Deserializer: ");
            MyReader reader = new(data);
            ChannnelId = reader.ReadByte();
            MessageType = (EMessageFromServerType)reader.ReadLimitedInt32(0, 3);
            Console.WriteLine("ChannelId: " + ChannnelId);
            Console.WriteLine("MessageType: " + MessageType.ToString());
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

        public void TryDoFunny()
        {
            File.WriteAllBytes("test", PlayerData.ToArray());
            MyReader reader = new(PlayerData.ToArray());
            var clientPlayer = ClientPlayer.Deserialize(reader);
            Data = clientPlayer;
        }

        public byte ChannnelId;
        public EMessageFromServerType MessageType;
        public object Data;
        public byte[] Bytes;
    }
}
