using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public static class QuickSort
    {
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

        public static void quicksort(int[] array)
        {
            quicksort(array, 0, array.Length - 1);
        }
    }
}
