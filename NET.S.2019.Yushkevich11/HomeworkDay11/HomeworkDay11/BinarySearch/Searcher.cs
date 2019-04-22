using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDay11.BinarySearch
{
    public static class Searcher
    {
        public static int TBinarySearch<T>(List<T> data, T item, Comparer<T> comparer = null)
        {
            if (data is null)
            {
                throw new ArgumentNullException();
            }

            comparer = comparer ?? Comparer<T>.Default;
            return BinarySearch<T>(data, item, 0, data.Capacity - 1, comparer);
        }

        private static int BinarySearch<T>(List<T> range, T item, int indexMin, int indexMax, Comparer<T> comparer)
        {
            if (indexMax < indexMin)
            {
                return -1;
            }

            int midle = (indexMin + indexMax) / 2;
            if (comparer.Compare(item, range[midle]) > 0)
            {
                return BinarySearch<T>(range, item, indexMin, midle - 1, comparer);
            }
            else if (comparer.Compare(item, range[midle]) < 0)
            {
                return BinarySearch<T>(range, item, midle + 1, indexMax, comparer);
            }
            else
            {
                return midle;
            }
        }
    }
}
