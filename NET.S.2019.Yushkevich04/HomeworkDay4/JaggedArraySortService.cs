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
        /// <summary>Order array of arrays by Sum of integer in arrays(More information in readme.txt).</summary>
        /// <param name="arrayToSort">array of arrays of numbers</param>
        /// <returns>
        ///     Sorted Array
        /// </returns>
        public static int[][] OrderBySum(int[][] arrayToSort)
        {
            if (arrayToSort == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayToSort.Length == 0)
            {
                throw new ArgumentException();
            }

            if(arrayToSort.Length==1)
            {
                return arrayToSort;
            }

            int[] arrayOfSums = new int[arrayToSort.Length];
            for (int index = 0; index < arrayToSort.Length; index++)
            {
                arrayOfSums[index] = arrayToSort[index].Sum();
            }

            BubbleSort(ref arrayOfSums, ref arrayToSort);
            return arrayToSort;
        }

        /// <summary>Order array of arrays by Max integer in arrays(More information in readme.txt).</summary>
        /// <param name="arrayToSort">array of arrays of numbers</param>
        /// <returns>
        ///     Sorted Array
        /// </returns>      
        public static int[][] OrderByMax(int[][] arrayToSort)
        {
            if (arrayToSort == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayToSort.Length == 0)
            {
                throw new ArgumentException();
            }

            int[] arrayOfMax = new int[arrayToSort.Length];
            for (int index = 0; index < arrayToSort.Length; index++)
            {
                arrayOfMax[index] = arrayToSort[index].Max();
            }

            BubbleSort(ref arrayOfMax, ref arrayToSort);
            return arrayToSort;
        }

        /// <summary>Order array of arrays by Min integer in arrays(More information in readme.txt).</summary>
        /// <param name="arrayToSort">array of arrays of numbers</param>
        /// <returns>
        ///     Sorted Array
        /// </returns>
        public static int[][] OrderByMin(int[][] arrayToSort)
        {
            if (arrayToSort == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayToSort.Length == 0)
            {
                throw new ArgumentException();
            }

            int[] arrayOfMin = new int[arrayToSort.Length];
            for (int index = 0; index < arrayToSort.Length; index++)
            {
                arrayOfMin[index] = arrayToSort[index].Min();
            }

            BubbleSort(ref arrayOfMin, ref arrayToSort);
            return arrayToSort;
        }
        #endregion
        #region orderDescanding
        /// <summary>Order array of arrays by Max integer in arrays descanding(More information in readme.txt).</summary>
        /// <param name="arrayToSort">array of arrays of numbers</param>
        /// <returns>
        ///     Sorted Array
        /// </returns>
        public static int[][] OrderByMaxDescending(int[][] arrayToSort)
        {
            if (arrayToSort == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayToSort.Length == 0)
            {
                throw new ArgumentException();
            }

            int[] arrayOfMax = new int[arrayToSort.Length];
            for (int index = 0; index < arrayToSort.Length; index++)
            {
                arrayOfMax[index] = arrayToSort[index].Max();
            }

            BubbleSort(ref arrayOfMax, ref arrayToSort);
            arrayToSort = arrayToSort.Reverse().ToArray();
            return arrayToSort;
        }

        /// <summary>Order array of arrays by Sum of integer in arrays descanding(More information in readme.txt).</summary>
        /// <param name="arrayToSort">array of arrays of numbers</param>
        /// <returns>
        ///     Sorted Array
        /// </returns>
        public static int[][] OrderBySumDescending(int[][] arrayToSort)
        {
            if (arrayToSort == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayToSort.Length == 0)
            {
                throw new ArgumentException();
            }

            int[] arrayOfSums = new int[arrayToSort.Length];
            for (int index = 0; index < arrayToSort.Length; index++)
            {
                arrayOfSums[index] = arrayToSort[index].Sum();
            }

            BubbleSort(ref arrayOfSums, ref arrayToSort);
            arrayToSort = arrayToSort.Reverse().ToArray();
            return arrayToSort;
        }

        /// <summary>Order array of arrays by Min integer in arrays descanding(More information in readme.txt).</summary>
        /// <param name="arrayToSort">array of arrays of numbers</param>
        /// <returns>
        ///     Sorted Array
        /// </returns>
        public static int[][] OrderByMinDescending(int[][] arrayToSort)
        {
            if (arrayToSort == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayToSort.Length == 0)
            {
                throw new ArgumentException();
            }

            int[] arrayOfMin = new int[arrayToSort.Length];
            for (int index = 0; index < arrayToSort.Length; index++)
            {
                arrayOfMin[index] = arrayToSort[index].Min();
            }

            BubbleSort(ref arrayOfMin, ref arrayToSort);
            arrayToSort = arrayToSort.Reverse().ToArray();
            return arrayToSort;
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

        /// <summary>Sorts array using temp as arguments</summary>
        /// <param name="argumentsArray">array with arguments</param>
        /// <param name="arrayToSort">array to sort</param>
        private static void BubbleSort(ref int[] argumentsArray, ref int[][] arrayToSort)
        {
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                for (int j = i + 1; j < arrayToSort.Length; j++)
                {
                    if (argumentsArray[i] > argumentsArray[j])
                    {
                        SwapNumbers(ref argumentsArray[i], ref argumentsArray[j]);
                        SwapArrays(ref arrayToSort[i], ref arrayToSort[j]);
                    }
                }
            }
        }
    }
}
