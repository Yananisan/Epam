using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day2
{
    class FilterDigitClass
    {
        /// <summary>
        /// Filters list of <paramref name="array"/>
        /// </summary>
        /// <param name="number">Filtering digit</param>
        /// <param name="array">Array of integers to filter</param>
        /// <returns>Array of filtered numbers</returns>
        public static int[] FilterDigit(int number, int[] array)
        {
            if (array == null) throw new ArgumentNullException();
            if (array.Length == 0) throw new ArgumentException();
            if (number < 0) number *= -1;

            List<int> list = new List<int>();
            foreach (int value in array)
            {
                Match match = Regex.Match(value.ToString(), number.ToString());
                if (match.Success)
                {
                    list.Add(value);
                }
            }
            return list.ToArray();
        }
    }
}
