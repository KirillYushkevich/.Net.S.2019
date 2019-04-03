namespace Day3HomeWork
{
    using System;

    public class GCDService
    {
        /// <summary>GCD for 2,3..etc params(More information in readme.txt).</summary>
        /// <param name="numbers">array of numbers</param>
        /// <returns>
        ///     Gcd
        /// </returns>
        public static Data<int> GCD(params int[] numbers)
        {
            Data<int> data = new Data<int>();
            if (numbers.Length == 1)
            {
                data.Result = numbers[0];
                return data;
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();
            data.Result = StandartGCD(Math.Abs(numbers[0]), Math.Abs(numbers[1]));
            if (numbers.Length > 2)
            {
                for (int i = 2; i <= numbers.Length - 1; i++)
                {
                    data.Result = StandartGCD(data.Result, Math.Abs(numbers[i]));
                }
            }

            watch.Stop();
            data.Time = watch.ElapsedMilliseconds;
            return data;
        }

        /// <summary>Binary GCD for 2,3..etc param(More information in readme.txt).</summary>
        /// <param name="numbers">array of numbers</param>
        /// <returns>
        ///     Gcd
        /// </returns>
        public static Data<int> StainGCD(params int[] numbers)
        {
            Data<int> data = new Data<int>();
            if (numbers.Length == 1)
            {
                data.Result = numbers[0];
                return data;
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();
            data.Result = Stain2GCD(Math.Abs(numbers[0]), Math.Abs(numbers[1]));
            if (numbers.Length > 2)
            {
                for (int i = 2; i <= numbers.Length - 1; i++)
                {
                    data.Result = Stain2GCD(data.Result, Math.Abs(numbers[i]));
                }
            }

            watch.Stop();
            data.Time = watch.ElapsedMilliseconds;
            return data;
        }

        /// <summary>GCD for 2 numbers(More information in readme.txt).</summary>
        /// <param name="firstNumber">array of numbers</param>
        ///  <param name="secondNumber">array of numbers</param>
        /// <returns>
        ///     GCD
        /// </returns>
        private static int StandartGCD(int firstNumber, int secondNumber)
        {
            if (secondNumber == 0)
            {
                return firstNumber;
            }

            return StandartGCD(secondNumber, firstNumber % secondNumber);
        }

        /// <summary>BinaryGCD for 2 numbers(More information in readme.txt).</summary>
        /// <param name="firstNumber">array of numbers</param>
        ///  <param name="secondNumber">array of numbers</param>
        /// <returns>
        ///     GCD
        /// </returns>
        private static int Stain2GCD(int firstNumber, int secondNumber)
        {
            if (firstNumber == secondNumber)
            {
                return firstNumber;
            }

            if (firstNumber == 0)
            {
                return secondNumber;
            }

            if (secondNumber == 0)
            {
                return firstNumber;
            }
            ////firstNumber even
            if ((~firstNumber & 1) != 0)
            {
                ////secondNumber odd
                if ((secondNumber & 1) != 0)
                {
                    return Stain2GCD(firstNumber >> 1, secondNumber);
                }
                else
                {
                    return Stain2GCD(firstNumber >> 1, secondNumber >> 1) << 1;
                }
            }
            ////secondNumber odd,firstNumber even
            if ((~secondNumber & 1) != 0)
            {
                return Stain2GCD(firstNumber, secondNumber >> 1);
            }
            ////reduce
            if (firstNumber > secondNumber)
            {
                return Stain2GCD((firstNumber - secondNumber) >> 1, secondNumber);
            }

            return Stain2GCD((secondNumber - firstNumber) >> 1, firstNumber);
        }
    }
}
