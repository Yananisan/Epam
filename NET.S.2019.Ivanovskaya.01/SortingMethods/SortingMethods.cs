using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethods
{
    public static class SortingMethods
    {
        /// <summary>
        /// Quicksort method with one parameter. Used for calling in tests
        /// </summary>
        /// <param name="array">Transmitted array for sorting</param>
        public static void Quicksort(int[] array)
        {
            quicksort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Quicksort method with 3 parameters
        /// </summary>
        /// <param name="array">Transmitted array for sorting</param>
        /// <param name="left">Left array's edge</param>
        /// <param name="right">Right array's edge</param>
        private static void quicksort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);
                if (pivot > 1)
                    quicksort(array, left, pivot - 1);
                if (pivot + 1 < right)
                    quicksort(array, pivot + 1, right);
            }
        }

        /// <summary>
        /// First step of Quicksort method, where each element is compared with pivot value.
        /// </summary>
        /// <param name="array">Transmitted array for sorting</param>
        /// <param name="left">Left array's edge</param>
        /// <param name="right">Right array's edge</param>
        /// <returns>Returns new pivot value</returns>
        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[left];
            while (true)
            {
                while (array[left] < pivot)
                    left++;

                while (array[right] > pivot)
                    right--;

                if (left < right)
                {
                    if (array[left] == array[right]) return right;
                    Swap(array, left, right);
                }
                else
                    return right;
            }
        }

        private static void Swap(int[] array, int i, int j)
        {
            int buf = array[i];
            array[i] = array[j];
            array[j] = buf;
        }

        /// <summary>
        /// Mergesort method with one parameter. Used for calling in tests
        /// </summary>
        /// <param name="array">Transmitted array for sorting</param>
        public static void Mergesort(int[] array)
        {
            Mergesort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Mergesort method with 3 parameters
        /// </summary>
        /// <param name="array">Transmitted array for sorting</param>
        /// <param name="left">Left array's edge</param>
        /// <param name="right">Right array's edge</param>
        private static void Mergesort(int[] array, int left, int right)
        {
            if (right > left)
            {
                int mid = (right + left) / 2;
                Mergesort(array, left, mid);
                Mergesort(array, mid + 1, right);

                Merge(array, left, mid + 1, right);
            }
        }

        /// <summary>
        /// Multiple time using method in sorting method, where is merging each part of the array
        /// </summary>
        /// <param name="array">Transmitted array for sorting</param>
        /// <param name="left">Left array's edge</param>
        /// <param name="mid">Middle array's element</param>
        /// <param name="right">Right array's edge</param>
        private static void Merge(int[] array, int left, int mid, int right)
        {
            int[] temp = new int[array.Length];

            int eol = mid - 1;
            int pos = left;
            int num = right - left + 1;

            while ((left <= eol) && (mid <= right))
            {
                if (array[left] <= array[mid])
                    temp[pos++] = array[left++];
                else
                    temp[pos++] = array[mid++];
            }

            while (left <= eol)
                temp[pos++] = array[left++];

            while (mid <= right)
                temp[pos++] = array[mid++];

            for (int i = 0; i < num; i++)
            {
                array[right] = temp[right];
                right--;
            }
        }
    }
}
