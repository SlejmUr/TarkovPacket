namespace TarkovPacketSer.RetardedBitReader
{
    internal class MyBitReader : IBitReader
    {
        public unsafe MyBitReader(byte[] bufferBytes)
        {
            buffer = bufferBytes;
            int num = buffer.Length;
            fixed (byte* ptr = &buffer[0])
            {
                byte* ptr2 = ptr;
                pUint_0 = (uint*)ptr2;
            }
            int_0 = num / 4;
            bitsCount = int_0 * 32;
            bitsRead = 0;
            int_3 = 0;
            int_4 = 0;
            bool_1 = true;
            isOverflow = false;
        }

        public byte[] Buffer
        {
            get
            {
                return buffer;
            }
        }

        public bool IsOverflow
        {
            get
            {
                return isOverflow;
            }
        }

        public int BitsRead
        {
            get
            {
                return bitsRead;
            }
        }

        public int BitsCount
        {
            get
            {
                return bitsCount;
            }
        }

        public int BytesRead
        {
            get
            {
                return (int_4 + (int_3 > 0 ? 1 : 0)) * 4;
            }
        }

        public int TotalBytes
        {
            get
            {
                return bitsCount * 8;
            }
        }

        public unsafe uint ReadBits(int bits)
        {
            if (bool_1)
            {
                ulong_0 = *pUint_0;
                bool_1 = false;
            }
            if (bitsRead + bits > bitsCount)
            {
                isOverflow = true;
                return 0U;
            }
            bitsRead += bits;
            if (int_3 + bits < 32)
            {
                ulong_0 <<= bits;
                int_3 += bits;
            }
            else
            {
                int_4++;
                int num = 32 - int_3;
                int num2 = bits - num;
                ulong_0 <<= num;
                ulong_0 |= pUint_0[int_4];
                ulong_0 <<= num2;
                int_3 = num2;
            }
            uint result = (uint)(ulong_0 >> 32);
            ulong_0 &= 4294967295UL;
            return result;
        }

        public unsafe void ReadBytes(byte[] destination, int destinationStartIndex, int bytesCount)
        {
            if (bool_1)
            {
                ulong_0 = *pUint_0;
                bool_1 = false;
            }
            if (bitsRead + bytesCount * 8 > bitsCount)
            {
                Array.Clear(destination, destinationStartIndex, bytesCount);
                isOverflow = true;
                return;
            }
            int num = (4 - int_3 / 8) % 4;
            if (num > bytesCount)
            {
                num = bytesCount;
            }
            for (int i = 0; i < num; i++)
            {
                destination[destinationStartIndex + i] = (byte)ReadBits(8);
            }
            if (num == bytesCount)
            {
                return;
            }
            int num2 = (bytesCount - num) / 4;
            if (num2 > 0)
            {
                int length = num2 * 4;
                int sourceIndex = int_4 * 4;
                Array.Copy(buffer, sourceIndex, destination, destinationStartIndex + num, length);
                bitsRead += num2 * 32;
                int_4 += num2;
                ulong_0 = pUint_0[int_4];
            }
            int num3 = num + num2 * 4;
            int num4 = bytesCount - num3;
            for (int j = 0; j < num4; j++)
            {
                destination[destinationStartIndex + num3 + j] = (byte)ReadBits(8);
            }
        }

        public int GetAlignBits()
        {
            return (8 - bitsRead % 8) % 8;
        }

        public void ReadAlign()
        {
            int num = bitsRead % 8;
            if (num != 0)
            {
                ReadBits(8 - num);
            }
        }

        public void Reset()
        {
            bitsRead = 0;
            int_3 = 0;
            int_4 = 0;
            bool_1 = true;
            isOverflow = false;
        }

        private unsafe readonly uint* pUint_0;

        private readonly byte[] buffer;

        private readonly int int_0;

        private readonly int bitsCount;

        private int bitsRead;

        private ulong ulong_0;

        private int int_3;

        private int int_4;

        private bool isOverflow;

        private bool bool_1;
    }
}
