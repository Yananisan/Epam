using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Ivanovskaya._05
{
    public class JaggedArraySorting
    {
        private delegate bool SortType(int[] arr1, int[] arr2);

        public JaggedArraySorting(int[][] array)
        {
            Array = array ?? throw new ArgumentNullException(nameof(array));
        }

        public int[][] Array { get; }

        private static bool SumLeftMoreThanRight(int[] arr1, int[] arr2)
        {
            if (arr1.Sum() > arr2.Sum())
                return true;
            else
                return false;
        }

        private static bool SumRightMoreThanLeft(int[] arr1, int[] arr2)
        {
            if (arr1.Sum() < arr2.Sum())
                return true;
            else
                return false;
        }

        private static bool MaxLeftMoreThanRight(int[] arr1, int[] arr2)
        {
            if (arr1.Max() > arr2.Max())
                return true;
            else
                return false;
        }

        private static bool MaxRightMoreThanLeft(int[] arr1, int[] arr2)
        {
            if (arr1.Max() < arr2.Max())
                return true;
            else
                return false;
        }

        private static bool MinLeftMoreThanRight(int[] arr1, int[] arr2)
        {
            if (arr1.Min() > arr2.Min())
                return true;
            else
                return false;
        }

        private static bool MinRightMoreThanLeft(int[] arr1, int[] arr2)
        {
            if (arr1.Min() < arr2.Min())
                return true;
            else
                return false;
        }

        public void SortByMaxElementInRowAscending()
        {
            SortType sorttype = MaxLeftMoreThanRight;
            Sort(Array, sorttype);
        }

        public void SortByMaxElementInRowDescending()
        {
            SortType sorttype = MaxRightMoreThanLeft;
            Sort(Array, sorttype);
        }

        public void SortByMaxSumElOfRow()
        {
            SortType sorttype = SumLeftMoreThanRight;
            Sort(Array, sorttype);
        }

        public  void SortByMinSumElOfRow()
        {
            SortType sorttype = SumRightMoreThanLeft;
            Sort(Array, sorttype);
        }

        public void SortByMinElementInRowAscending()
        {
            SortType sorttype = MinLeftMoreThanRight;
            Sort(Array, sorttype);
        }

        public void SortByMinElementInRowDescending()
        {
            SortType sorttype = MinRightMoreThanLeft;
            Sort(Array, sorttype);
        }

        private static void Sort(int[][] jaggedArr, SortType sortType)
        {
            for (int i = 0; i < jaggedArr.GetLength(0); i++)
            {
                for (int j = 0; j < jaggedArr.GetLength(0) - 1 - i; j++)
                {
                    if (sortType(jaggedArr[j], jaggedArr[j + 1]))
                    {
                        Swap(ref jaggedArr[j], ref jaggedArr[j + 1]);
                    }
                }
            }
        }

        private static void Swap(ref int[] arr1, ref int[] arr2)
        {
            int[] buff = arr1;
            arr1 = arr2;
            arr2 = buff;
        }
    }
}
