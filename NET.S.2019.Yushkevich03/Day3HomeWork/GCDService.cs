namespace Day3HomeWork
{
    using System;

    public class GCDService
    {
        public static Data<int> GCD(params int[] numbers)
        {
            Data<int> data = new Data<int>();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            data.Result = StandartGCD(numbers[0], numbers[1]);
            if (numbers.Length > 2)
            {
                for (int i = 2; i <= numbers.Length - 1; i++)
                {
                    data.Result = StandartGCD(data.Result, numbers[i]);
                }
            }

            watch.Stop();
            data.Time = watch.ElapsedMilliseconds;
            return data;
        }

        public static Data<int> StainGCD(params int[] numbers)
        {
            Data<int> data = new Data<int>();
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

        private static int StandartGCD(int firstNumber, int secondNumber)
        {
            if (secondNumber == 0)
            {
                return Math.Abs(firstNumber);
            }

            return StandartGCD(secondNumber, firstNumber % secondNumber);
        }

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
