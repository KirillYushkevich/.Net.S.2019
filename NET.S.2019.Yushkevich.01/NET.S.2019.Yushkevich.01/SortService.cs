using System;

namespace NET.S._2019.Yushkevich._01
{
    public static class SortService
    {
        /// <summary> Sort array using Qsort(https://en.wikipedia.org/wiki/Quicksort).</summary>
        /// <param name="array">Last ellement of array.</param>
        /// <returns>
        ///   Sorted array.
        /// </returns>
        public static void QSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            algo(0, array.Length - 1);
            void algo(int firstEllement, int lastEllement)
            {
                int lowerBound = firstEllement, higherBound = lastEllement, pivot = array[(lastEllement + firstEllement) / 2];
                while (lowerBound <= higherBound)
                {
                    while (array[lowerBound] < pivot)
                    {
                        lowerBound++;
                    }

                    while (array[higherBound] > pivot)
                    {
                        higherBound--;
                    }

                    if (lowerBound <= higherBound)
                    {
                        var temp = array[lowerBound];
                        array[lowerBound] = array[higherBound];
                        array[higherBound] = temp;
                        lowerBound++;
                        higherBound--;
                    }
                }

                if (firstEllement < higherBound)
                {
                    algo(firstEllement, higherBound);
                }

                if (lastEllement > lowerBound)
                {
                    algo(lowerBound, lastEllement);
                }
            }
        }

        /// <summary> Sort array using Merge Sort(https://en.wikipedia.org/wiki/Merge_sort).</summary>
        /// <param name="array">Source int array.</param>
        /// <returns>
        ///   Sorted array.
        /// </returns>
        public static void MergeSort(this int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            algo(0, array.Length - 1);
            void algo(int firstEllement, int lastEllement)
            {
                if (firstEllement < lastEllement)
                {
                    int mid = (firstEllement + lastEllement) / 2;
                    algo(firstEllement, mid);
                    algo(mid + 1, lastEllement);
                    Merge(array, firstEllement, mid, lastEllement);
                }
            }
        }

        private static void Merge(int[] array, int low, int mid, int high)
        {
            int leftSubSize = mid - low + 1, rightSubSize = high - mid;
            int[] leftSub = new int[leftSubSize];
            int[] rightSub = new int[rightSubSize];

            for (int i = 0; i < leftSubSize; i++)
            {
                leftSub[i] = array[low + i];
            }

            for (int j = 0; j < rightSubSize; j++)
            {
                rightSub[j] = array[mid + 1 + j];
            }

            int leftIndex = 0, rightIndex = 0;
            int mergeIndex = low;
            while (leftIndex < leftSubSize && rightIndex < rightSubSize)
            {
                if (leftSub[leftIndex] <= rightSub[rightIndex])
                {
                    array[mergeIndex] = leftSub[leftIndex];
                    leftIndex++;
                }
                else
                {
                    array[mergeIndex] = rightSub[rightIndex];
                    rightIndex++;
                }

                mergeIndex++;
            }
            while (leftIndex < leftSubSize)
            {
                array[mergeIndex] = leftSub[leftIndex];
                leftIndex++;
                mergeIndex++;
            }

            while (rightIndex < rightSubSize)
            {
                array[mergeIndex] = rightSub[rightIndex];
                rightIndex++;
                mergeIndex++;
            }
        }
    }
}
