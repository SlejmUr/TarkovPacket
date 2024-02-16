using ComponentAce.Compression.Libs.zlib;
using Newtonsoft.Json;
using TarkovPacketSer.PacketFormat;
using static TarkovPacketSer.PacketFormat.PartialCommand;

namespace TarkovPacketSer
{
    internal class Program
    {
        public static List<PartialCommandData> partialCommandDatas = new List<PartialCommandData>();

        static void Main(string[] args)
        {
            
            string[] files = new string[0];
            Console.WriteLine("Hello, World!");
            Console.WriteLine(args.Length);
            Console.WriteLine(args[args.Length - 1]);
            if (args.Length == 0)
            {
                files = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\UN");
            }
            else if (args.Length == 1)
            {
                if (args[0].Contains("\\"))
                    files = Directory.GetFiles(args[0]);
                else
                {
                    ParsePacketUInt(args[0]);
                    ParsePacketInt(args[0]);
                    Environment.Exit(0);
                }
                if (files[0].Contains("UN"))
                {
                    UN_Parser.Parse(files);
                }
                if (files[0].Contains("BE"))
                {
                    BE_Parser.Parse(files);
                }
            }
            else if (args.Length == 2)
            {
                File.WriteAllBytes(args[0], SimpleZlib.DecompressToBytes(File.ReadAllBytes(args[1])));

            }


        }

        static void ParsePacketUInt(string thing)
        {
            var bytes = Convert.FromHexString(thing);
            BinaryReader binaryReader = new(new MemoryStream(bytes));
            var uintPacket = binaryReader.ReadPackedUInt32();
            binaryReader.Close();
            binaryReader.Dispose();
            Console.WriteLine(uintPacket);
        }

        static void ParsePacketInt(string thing)
        {
            var bytes = Convert.FromHexString(thing);
            BinaryReader binaryReader = new(new MemoryStream(bytes));
            var uintPacket = binaryReader.ReadPackedInt32();
            binaryReader.Close();
            binaryReader.Dispose();
            Console.WriteLine(uintPacket);
        }
    }
}
