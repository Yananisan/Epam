using System;

namespace Day2
{
    class FindNthRootClass
    {
        /// <summary>
        /// Calculate the nth root of a number by the Newton's method
        /// </summary>
        /// <param name="number">The number from which to extract the root</param>
        /// <param name="degree">Root</param>
        /// <param name="precision">Precision</param>
        /// <returns>Returns the nth root of a number by the Newton's method</returns>
        public static double FindNthRoot(double number, int degree, double precision = 0.0001)
        {
            if (precision <= 0) throw new ArgumentOutOfRangeException();

            double x0 = number / degree;
            double x1 = (1.0 / degree) * ((degree - 1) * x0 + number / Math.Pow(x0, degree - 1));

            while (Math.Abs(x1 - x0) > precision)
            {
                x0 = x1;
                x1 = (1.0 / degree) * ((degree - 1) * x0 + number / Math.Pow(x0, degree - 1));
            }

            return x1;
        }
    }
}
