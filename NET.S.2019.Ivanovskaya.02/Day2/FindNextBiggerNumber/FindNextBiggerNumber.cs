using System;
using System.Diagnostics;

namespace Day2
{
    public static class FindNextBiggerNumber
    {
        /// <summary>
        /// Returns the nearest largest integer consisting of the digits of the original number, 
        /// and null if no such number exists.
        /// </summary>
        /// <param name="number">Input number.</param>
        /// <param name="time">Returns TimeSpan of finding number.</param>
        /// <returns></returns>
        public static int? FindNextBiggerThan(int number, out TimeSpan time)
        {
            time = new TimeSpan();

            if (number == int.MaxValue) return null;
            if (number < 0) throw new ArgumentException();
            
            Stopwatch stopwatch = new Stopwatch();

            int[] array = new int[number.ToString().Length];
            int length = array.Length;

            for (int k = 0; k < number.ToString().Length; k++)
            {
                array[k] = int.Parse(number.ToString()[k].ToString());
            }      

            int i;
            bool swap = false;

            stopwatch.Start();

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

            stopwatch.Stop();
            time = stopwatch.Elapsed;

            Console.WriteLine("TimeSpan of given number: {0:00}:{1:00}:{2:00}.{3:00}",
            time.Hours, time.Minutes, time.Seconds, time.Milliseconds / 10);

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
