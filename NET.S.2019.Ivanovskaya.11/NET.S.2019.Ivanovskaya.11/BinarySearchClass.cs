using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public static class BinarySearchClass
    {
        public static int BinarySearch<T>(this T[] array, T key, Comparison<T> comparison)
        {
            int left = 0;
            int right = array.Length - 1;
            int mid = right / 2;

            while (left <= right)
            {
                int result = comparison(array[mid], key);
                if (result == 0)
                    return mid;
                else if (result < 0)
                {
                    left = mid + 1;
                    mid = (left + right) / 2;
                }
                else if (true)
                {
                    right = mid - 1;
                    mid = (left + right) / 2;
                }
            }
            return -1;
        }

        public static int BinarySearch<T>(this T[] array, T key)
        {
            if (key is IComparable)
            {
                IComparer<T> comparer = Comparer<T>.Default;
                return BinarySearch<T>(array, key, comparer.Compare);
            }
            else
                throw new InvalidOperationException();
        }
    }
}
