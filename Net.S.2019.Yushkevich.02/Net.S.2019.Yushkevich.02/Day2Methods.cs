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
        // <summary>Insert bits if range indexI->indexJ from numberIn to numberSource(More information in readme.txt).</summary>
        /// <param name="numberSource">First number.</param>
        /// <param name="numberIn">Second number.</param>
        /// <param name="indexI">Start position</param>
        /// <param name="indexJ">End position</param>
        /// <returns>
        ///   Updated number
        /// </returns>
        public static int InsertNumber(int numberSource, int numberIn, int indexI, int indexJ)
        {
            if (numberSource >= int.MaxValue || numberSource <= int.MinValue || numberIn >= int.MaxValue || numberIn <= int.MinValue) throw new ArgumentException();
            if (indexI < 0 || indexJ < 0) throw new ArgumentException();

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

        // <summary>Next bigger number with the same digits(More information in readme.txt).</summary>
        /// <param name="number">Source number.</param>
        /// <returns>
        ///   Struct Result 
        ///   Result.result int wich contains next number
        ///   Result.elapsedTime time since search start
        /// </returns>
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

        // <summary>Remove from list all number that doesn't contains given digit(More information in readme.txt).</summary>
        /// <param name="list">Source list.</param>
        /// <param name="digit">Digit .</param>
        /// <returns>
        ///   Struct Result 
        ///   Result.result int wich contains next number
        ///   Result.elapsedTime time since search start
        /// </returns>
        public static void FilterDigit(ref List<int> list, int digit)
        {
            List<int> temp = new List<int>();

            foreach (int number in list)
            {
                if (number.ToString().IndexOf(digit.ToString()) != -1) if (temp.IndexOf(number) == -1) temp.Add(number);

            }
            list = temp;
        }

        // <summary>Find nthRoot of given number(More information in readme.txt).</summary>
        /// <param name="nthRoot">Root.</param>
        /// <param name="number">Source number.</param>
        /// <param name="eps">Accuracy of root.</param>
        /// <returns>
        ///   nthRoot
        /// </returns>
        public static double FindNthRoot(double nthRoot, double number, double eps)
        {
            if (nthRoot >= double.MaxValue ||  number >= double.MaxValue) throw new ArgumentException();
            if (nthRoot<0) throw new ArgumentException();

            double x0 = number / nthRoot;
            double x1 = (1 / nthRoot) * ((nthRoot - 1) * x0 + (number / Math.Pow(x0, (int)nthRoot - 1)));

            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = (1 / nthRoot) * ((nthRoot - 1) * x0 + (number / Math.Pow(x0, (int)nthRoot - 1)));
            }
            int i = 0;
            while (eps * Math.Pow(10, 1 + i) % 10 != 0) { i++; }

            return Math.Round(x1, i);
        }

    }
}
