using System;
using System.Text;

namespace Day3HomeWork
{
    public static class NumberConverter
    {
        public static string FloatToBinary(this double number)
        {
            StringBuilder builder = new StringBuilder();
            byte[] byteArray = DoubleToBytes(number);
            foreach (byte b in byteArray)
            {
                for (int i = 0; i < 8; i++)
                {
                    builder.Insert(0, ((b >> i) & 1) == 1 ? "1" : "0");
                }
            }

            return builder.ToString();
        }

        private static unsafe byte[] DoubleToBytes(double value)
        {
            byte[] bytes = new byte[8];
            fixed (byte* b = bytes)
                *((double*)b) = value;
            return bytes;
        }
    }
}
