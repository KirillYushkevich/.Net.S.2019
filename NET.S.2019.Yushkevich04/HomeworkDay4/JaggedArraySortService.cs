using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDay4
{
    public class JaggedArraySortService
    {
        #region orderBy
        // <summary>Order array of arrays by Sum of integer in arrays(More information in readme.txt).</summary>
        /// <param name="array">array of arrays of numbers</param>
        /// <returns>
        ///     Sorted Array
        /// </returns>
        public static int[][] OrderBySum(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            int[] temp = new int[array.Length];
            for (int index = 0; index < array.Length; index++)
            {
                temp[index] = array[index].Sum();
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (temp[i] > temp[j])
                    {
                        SwapNumbers(ref temp[i], ref temp[j]);
                        SwapArrays(ref array[i], ref array[j]);
                    }
                }
            }

            return array;
        }

        /// <summary>Order array of arrays by Max integer in arrays(More information in readme.txt).</summary>
        /// <param name="array">array of arrays of numbers</param>
        /// <returns>
        ///     Sorted Array
        /// </returns>      
        public static int[][] OrderByMax(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            int[] temp = new int[array.Length];
            for (int index = 0; index < array.Length; index++)
            {
                temp[index] = array[index].Max();
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (temp[i] > temp[j])
                    {
                        SwapNumbers(ref temp[i], ref temp[j]);
                        SwapArrays(ref array[i], ref array[j]);
                    }
                }
            }

            return array;
        }

        /// <summary>Order array of arrays by Min integer in arrays(More information in readme.txt).</summary>
        /// <param name="array">array of arrays of numbers</param>
        /// <returns>
        ///     Sorted Array
        /// </returns>
        public static int[][] OrderByMin(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            int[] temp = new int[array.Length];
            for (int index = 0; index < array.Length; index++)
            {
                temp[index] = array[index].Min();
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (temp[i] > temp[j])
                    {
                        SwapNumbers(ref temp[i], ref temp[j]);
                        SwapArrays(ref array[i], ref array[j]);
                    }
                }
            }

            return array;
        }
        #endregion
        #region orderDescanding
        // <summary>Order array of arrays by Max integer in arrays descanding(More information in readme.txt).</summary>
        /// <param name="array">array of arrays of numbers</param>
        /// <returns>
        ///     Sorted Array
        /// </returns>
        public static int[][] OrderByMaxDescending(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            int[] temp = new int[array.Length];
            for (int index = 0; index < array.Length; index++)
            {
                temp[index] = array[index].Max();
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (temp[i] > temp[j])
                    {
                        SwapNumbers(ref temp[i], ref temp[j]);
                        SwapArrays(ref array[i], ref array[j]);
                    }
                }
            }

            array = array.Reverse().ToArray();
            return array;
        }

        /// <summary>Order array of arrays by Sum of integer in arrays descanding(More information in readme.txt).</summary>
        /// <param name="array">array of arrays of numbers</param>
        /// <returns>
        ///     Sorted Array
        /// </returns>
        public static int[][] OrderBySumDescending(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            int[] temp = new int[array.Length];
            for (int index = 0; index < array.Length; index++)
            {
                temp[index] = array[index].Sum();
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (temp[i] > temp[j])
                    {
                        SwapNumbers(ref temp[i], ref temp[j]);
                        SwapArrays(ref array[i], ref array[j]);
                    }
                }
            }

            array = array.Reverse().ToArray();
            return array;
        }

        /// <summary>Order array of arrays by Min integer in arrays descanding(More information in readme.txt).</summary>
        /// <param name="array">array of arrays of numbers</param>
        /// <returns>
        ///     Sorted Array
        /// </returns>
        public static int[][] OrderByMinDescending(int[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            int[] temp = new int[array.Length];
            for (int index = 0; index < array.Length; index++)
            {
                temp[index] = array[index].Min();
            }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (temp[i] > temp[j])
                    {
                        SwapNumbers(ref temp[i], ref temp[j]);
                        SwapArrays(ref array[i], ref array[j]);
                    }
                }
            }

            array = array.Reverse().ToArray();
            return array;
        }
        #endregion

        /// <summary>Swap two int</summary>
        /// <param name="firstArg">first integer</param>
        /// <param name="secondArg">second integer</param>
        private static void SwapNumbers(ref int firstArg, ref int secondArg)
        {
            int temp = firstArg;
            firstArg = secondArg;
            secondArg = temp;
        }

        /// <summary>Swap two int arrays</summary>
        /// <param name="firstArg">first array </param>
        /// <param name="secondArg">second array</param>
        private static void SwapArrays(ref int[] firstArg, ref int[] secondArg)
        {
            int[] temp = firstArg;
            firstArg = secondArg;
            secondArg = temp;
        }
    }
}
