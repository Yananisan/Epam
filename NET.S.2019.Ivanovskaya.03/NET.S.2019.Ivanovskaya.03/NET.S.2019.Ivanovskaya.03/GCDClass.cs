using System;
using System.Diagnostics;

namespace NET.S._2019.Ivanovskaya._03
{
    public class GCDClass
    {
        public static int GCD(out TimeSpan time, params int[] array)
        {
            time = new TimeSpan();
            Stopwatch stopwatch = new Stopwatch();

            if (array == null) throw new ArgumentNullException();
            if (array.Length < 1) throw new ArgumentException();
            if (array.Length == 1) return array[0];
            
            stopwatch.Start();

            int result = array[0];
            for (int i = 1; i < array.Length; i++)
                result = BaseGCD(array[i], result);

            stopwatch.Stop();
            time = stopwatch.Elapsed;

            Console.WriteLine("TimeSpan of given number: {0:00}:{1:00}:{2:00}.{3:00}",
            time.Hours, time.Minutes, time.Seconds, time.Milliseconds / 10);

            return result;
        }

        private static int BaseGCD(int a, int b)
        {
            if (a < 0) a *= -1;
            if (b < 0) b *= -1;

            if (a == 0)
                return b;
            return BaseGCD(b % a, a);
        }

        public static int BinaryGCD(out TimeSpan time, params int[] array)
        {
            time = new TimeSpan();
            Stopwatch stopwatch = new Stopwatch();

            if (array == null) throw new ArgumentNullException();
            if (array.Length < 1) throw new ArgumentException();
            if (array.Length == 1) return array[0];

            stopwatch.Start();

            int result = array[0];
            for (int i = 1; i < array.Length; i++)
                result = BinaryBaseGCD(array[i], result);

            stopwatch.Stop();
            time = stopwatch.Elapsed;

            Console.WriteLine("TimeSpan of given number: {0:00}:{1:00}:{2:00}.{3:00}",
            time.Hours, time.Minutes, time.Seconds, time.Milliseconds / 10);

            return result;
        }

        private static int BinaryBaseGCD(int a, int b)
        {
            if (a < 0) a *= -1;
            if (b < 0) b *= -1;

            if (a == 0)
                return b;
            if (b == 0)
                return a;

            int k = 1;
            while ((a != 0) && (b != 0))
            {
                while ((a % 2 == 0) && (b % 2 == 0))
                {
                    a >>= 1;
                    b >>= 1;
                    k <<= 1;
                }

                if (a >= b)
                    a -= b;
                else
                    b -= a;
            }

            return b * k;
        }

        private static int GcdFind(out TimeSpan time, Func<int, int, int> func, params int[] array)
        {
            time = new TimeSpan();
            Stopwatch stopwatch = new Stopwatch();

            if (array == null) throw new ArgumentNullException();
            if (array.Length < 1) throw new ArgumentException();
            if (array.Length == 1) return array[0];

            stopwatch.Start();

            int result = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                result = func(result, array[i]);
            }

            stopwatch.Stop();
            time = stopwatch.Elapsed;

            return result;
        }
    }
}
