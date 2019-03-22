using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public static class FindNextBiggerNumber
    {
        public static int? FindNextBiggerThan(int number)
        {
            if (number == int.MaxValue) return null;
            if (number < 0) throw new ArgumentException();

            int[] array = new int[number.ToString().Length];
            int length = array.Length;

            for (int k = 0; k < number.ToString().Length; k++)
            {
                array[k] = int.Parse(number.ToString()[k].ToString());
            }      

            int i;
            bool swap = false;

            for (i = length - 1; i > 0; i--)
            {
                if (array[i] > array[i - 1])
                {
                    Swap(array, i, i - 1);
                    swap = true;
                }
                if (swap)
                {
                    for (; i < length - 1; i++)
                    {
                        for (int j = i + 1; j < length; j++)
                        {
                            if (array[i] > array[j])
                            {
                                Swap(array, i, j);
                            }
                        }
                    }
                    break;
                }
            }

            int result = int.Parse(string.Join("", array));

            if (result == number)
                return -1;
            else return result;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int buf = array[i];
            array[i] = array[j];
            array[j] = buf;
        }
    }
}
