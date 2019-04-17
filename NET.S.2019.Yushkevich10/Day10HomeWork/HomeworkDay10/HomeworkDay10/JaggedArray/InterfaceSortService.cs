namespace HomeworkDay10
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InterfaceSortService
    {
        public enum SortMode
        {
            Sum,
            Max,
            Min,
        }

        public static void Sort(SortMode mode, bool descanding, int[][] arrayToSort)
        {
            Func<int[], int> calcMethod;

            switch (mode)
            {
                case SortMode.Sum:
                    calcMethod = Enumerable.Sum;
                    break;
                case SortMode.Max:
                    calcMethod = Enumerable.Max;
                    break;
                case SortMode.Min:
                    calcMethod = Enumerable.Min;
                    break;
                default:
                    calcMethod = Enumerable.Sum;
                    break;
            }

            Comparer<int[]> arrayComparer = Comparer<int[]>.Create((x, y) => Comparer<int>.Default.Compare(calcMethod(x), calcMethod(y)));

            StartSort(arrayComparer, arrayToSort, descanding);
        }

        ///<summary>Interface IComparer over Comprassion delegate</summary>
        ///<param name="arrayToSort">given array</param>
        ///<param name="comparer">custom comparer</param>
        ///<param name="descanding">order by?</param>
        public static void StartSort(IComparer<int[]> comparer, int[][] arrayToSort, bool descanding) => BubbleSort(comparer.Compare, arrayToSort, descanding);

        /// <summary>Sorts array using temp as arguments</summary>
        /// <param name="argumentsArray">array with arguments</param>
        /// <param name="arrayToSort">array to sort</param>
        private static void BubbleSort(Comparison<int[]> comparison, int[][] arrayToSort, bool descanding)
        {
            Func<int[], int[], bool> swap;
            if (descanding)
            {
                swap = (x, y) => comparison(x, y) < 0;
            }
            else
            {
                swap = (x, y) => comparison(x, y) > 0;
            }

            for (int i = 0; i < arrayToSort.Length; i++)
            {
                for (int j = i + 1; j < arrayToSort.Length; j++)
                { 
                    if (swap(arrayToSort[i], arrayToSort[j]))
                    {
                        ///   SwapNumbers(ref argumentsArray[i], ref argumentsArray[j]);
                        SwapArrays(ref arrayToSort[i], ref arrayToSort[j]);
                    }
                }
            }
        }

        /// <summary>Swap two number arrays</summary>
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
