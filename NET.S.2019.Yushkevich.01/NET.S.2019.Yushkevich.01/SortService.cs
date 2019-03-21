namespace NET.S._2019.Yushkevich._01
{
    public static class SortService
    {
        public static void QSort(this int[] array, int low, int high)
        {

            int lowerBound = low, higherBound = high, pivot = array[(high + low) / 2];
            while (lowerBound <= higherBound)
            {
                while (array[lowerBound] < pivot) lowerBound++;
                while (array[higherBound] > pivot) higherBound--;
                if (lowerBound <= higherBound)
                {
                    var temp = array[lowerBound];
                    array[lowerBound] = array[higherBound];
                    array[higherBound] = temp;
                    lowerBound++;
                    higherBound--;
                }
            }
            if (low < higherBound) QSort(array, low, higherBound);
            if (high > lowerBound) QSort(array, lowerBound, high);

        }
        public static void MergeSort(this int[] array, int low, int high)
        {
            if(low<high)
            {
                int mid = (low + high) / 2;
                MergeSort(array, low, mid);
                MergeSort(array, mid + 1, high);
                Merge(array, low, mid, high);
            }
        }
        public static void Merge (int[] array,int low,int mid,int high)
        {
            int leftSubSize = mid - low + 1, rightSubSize = high - mid;

            int[] leftSub = new int[leftSubSize];
            int[] rightSub = new int[rightSubSize];

            for (int i = 0; i < leftSubSize; i++) leftSub[i] = array[low + i];
            for (int j = 0; j < rightSubSize; j++) rightSub[j] = array[mid + 1 + j];

            int leftIndex = 0, rightIndex = 0;
            int mergeIndex = low;
            while (leftIndex < leftSubSize && rightIndex< rightSubSize)
            {
                if (leftSub[leftIndex]<=rightSub[rightIndex])
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
