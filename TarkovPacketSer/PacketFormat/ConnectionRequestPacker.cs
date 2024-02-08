using Newtonsoft.Json;
using System.Numerics;
using TarkovPacketSer.BSG_Classes;
using TarkovPacketSer.BSG_Enums;

namespace TarkovPacketSer.PacketFormat
{
    internal class ConnectionRequestPacker
    {
        public static ReplyPacket ParseReplyPacket(byte[] data, bool FromHandler)
        {
            if (!FromHandler)
                data = data.Skip(4).ToArray();
            ReplyPacket replyPacket = new ReplyPacket();
            BinaryReader binaryReader = new(new MemoryStream(data));
            replyPacket.ProfileId = binaryReader.ProperReadString();
            replyPacket.Token = binaryReader.ProperReadString();
            replyPacket.ObserveOnly = binaryReader.ReadBoolean();
            replyPacket.EncryptionKey = binaryReader.ReadBytesAndSize();
            replyPacket.EncryptionKeyLen = binaryReader.ReadInt32();
            replyPacket.LocationId = binaryReader.ProperReadString();
            binaryReader.Close();
            binaryReader.Dispose();
            return replyPacket;
        }

        public static RequestPacket ParseRequestPacket(byte[] data, bool FromHandler)
        {
            if (!FromHandler)
                data = data.Skip(4).ToArray();
            RequestPacket replyPacket = new RequestPacket();
            BinaryReader binaryReader = new(new MemoryStream(data));
            replyPacket.Deserialize(binaryReader);
            binaryReader.Close();
            binaryReader.Dispose();
            return replyPacket;
        }

        public class ReplyPacket
        {
            public string ProfileId;
            public string Token;
            public bool ObserveOnly;
            public byte[] EncryptionKey;
            public int EncryptionKeyLen;
            public string LocationId;
        }

        public class RequestPacket
        {
            public void Deserialize(BinaryReader reader)
            {
                this.encryptionEnabled = reader.ReadBoolean();
                this.decryptionEnabled = reader.ReadBoolean();
                this.gameDateTime = GameDateTime.Deserialize(reader);
                this.ResourceKeyArray_Zipped = reader.ReadBytesAndSize();
                this.CustomizationArray_Zipped = reader.ReadBytesAndSize();
                this.WeatherArray_Zipped = reader.ReadBytesAndSize();
                this.IsWinter = reader.ReadBoolean();
                this.canRestart = reader.ReadBoolean();
                this.ememberCategory = (EMemberCategory)reader.ReadInt32();
                this.fixedDeltaTime = reader.ReadSingle();
                this.interactables_zipped = reader.ReadBytesAndSize();
                this.sessionId = reader.ReadBytesAndSize();
                Vector3 min = reader.ReadVector3();
                Vector3 max = reader.ReadVector3();
                this.bounds = new Bounds
                {
                    min = min,
                    max = max
                };
                this.SCPort = reader.ReadUInt16();
                this.enetLogsLevel = (ENetLogsLevel)reader.ReadByte();
                this.gitVersion = GitVersion.Deserialize(reader);
                this.speedLimitEnabled = reader.ReadBoolean();
                if (this.speedLimitEnabled)
                {
                    this.config.Deserialize(reader);
                }
                if (reader.ReadBoolean())
                {
                    this.voipSettings = new VoipSettings();
                    this.voipSettings.Deserialize(reader);
                }
            }

            public bool encryptionEnabled;

            public bool decryptionEnabled;

            public GameDateTime gameDateTime;

            public byte[] ResourceKeyArray_Zipped;

            public byte[] CustomizationArray_Zipped;

            public byte[] WeatherArray_Zipped;

            public bool IsWinter;

            public bool canRestart;

            public EMemberCategory ememberCategory;

            public float fixedDeltaTime;

            public byte[] interactables_zipped;

            public byte[] sessionId;

            public Bounds bounds;

            public ushort SCPort;

            public ENetLogsLevel enetLogsLevel;

            public GitVersion gitVersion;

            public bool speedLimitEnabled;

            public ConnectionConfig config = new();

            public VoipSettings voipSettings;
        }
    }
}
