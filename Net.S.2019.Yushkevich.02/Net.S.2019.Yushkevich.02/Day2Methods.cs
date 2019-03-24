using System;
using System.Collections.Generic;

namespace Net.S._2019.Yushkevich._02
{
    public struct Result
    {
        public int? result;
        public long elapsedTime;
    }
    public static class Day2Methods
    {
        public static int InsertNumber(int numberSource, int numberIn, int indexI, int indexJ)
        {
            char[] sourceBinary = Convert.ToString(numberSource, 2).ToCharArray(), inBinary = Convert.ToString(numberIn, 2).ToCharArray();
            Array.Reverse(sourceBinary);
            Array.Reverse(inBinary);
            char[] result = new char[32];
            for (int i = 0; i <= result.Length - 1; i++)
            {
                if (i >= indexI && i <= indexJ && i <= inBinary.Length - 1)
                {
                    for (int j = 0; j <= inBinary.Length - 1; j++)
                    {
                        result[i] = inBinary[j];
                        i++;
                        if (i > indexJ) break;
                    }
                    i--;
                }
                else if (i <= sourceBinary.Length - 1) result[i] = sourceBinary[i];
                else result[i] = Convert.ToChar("0");

            }

            Array.Reverse(result);
            return Convert.ToInt32(new string(result), 2);
        }

        public static Result? NextBiggerThan(int number)
        {
            Result result = new Result();
            if (number == 0) throw new ArgumentException();
            if (number < 0) throw new ArgumentException();
            if (number >= int.MaxValue) return null;
            if (number <= int.MinValue) throw new ArgumentException();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            char[] numberArray = number.ToString().ToCharArray();
            for (int i = 0; i < numberArray.Length; i++)
            {
                if (numberArray.Length - i - 2 >= 0)
                {
                    if (numberArray[numberArray.Length - i - 1] > numberArray[numberArray.Length - i - 2])
                    {
                        char chtemp = numberArray[numberArray.Length - i - 1];
                        numberArray[numberArray.Length - i - 1] = numberArray[numberArray.Length - i - 2];
                        numberArray[numberArray.Length - i - 2] = chtemp;
                        Array.Sort(numberArray, numberArray.Length - i - 1, i + 1);
                        watch.Stop();
                        result.elapsedTime = watch.ElapsedMilliseconds;
                        if (numberArray.ToInt() > number)
                        {
                            result.result = numberArray.ToInt();
                            return result;
                        }

                    }

                }

            }
            watch.Stop();
            result.elapsedTime = watch.ElapsedMilliseconds;
            return result;
        }

        private static int ToInt(this char[] array)
        {
            string temp = new string(array);
            return Convert.ToInt32(temp);
        }
        private static double Pow(double number, int pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++) result *= number;
            return result;
        }
        public static List<int> FilterDigit(List<int> list, int digit)
        {
            List<int> temp = new List<int>();

            foreach (int number in list)
            {
                if (number.ToString().IndexOf(digit.ToString()) != -1) if (temp.IndexOf(number) == -1) temp.Add(number);

            }
            return temp;
        }

        public static double SqrtN(double n, double A, double eps)
        {
            double x0 = A / n;
            double x1 = (1 / n) * ((n - 1) * x0 + (A / Pow(x0, (int)n - 1)));
            while (Math.Abs(x1-x0) > eps)
            {
                x0 = x1;
                x1 = (1 / n) * ((n - 1) * x0 + (A / Pow(x0, (int)n - 1)));
            }
            int i = 0;
            while (eps * Math.Pow(10, 1 + i) % 10 != 0) { i++; }
            return Math.Round(x1,i);
        }

    }
}
