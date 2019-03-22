using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class InsertNumberClass
    {
        /// <summary>
        /// Insert bits from the j-th to the i-th bit of one number into another so that the bits 
        /// of the second number take positions from bit j to bit i (bits are numbered from right to left).
        /// </summary>
        /// <param name="first">First number</param>
        /// <param name="second">Second number</param>
        /// <param name="startPos">Start position to insert bits</param>
        /// <param name="endPos">End position to insert bits</param>
        /// <returns>Bits represented by one number</returns>
        public static int InsertNumber(int first, int second, int startPos, int endPos)
        {            
            if ((startPos < 0) || (startPos > 31) || (endPos < 0) || (endPos > 31)) throw new ArgumentOutOfRangeException();
            if (startPos > endPos) throw new ArgumentException();

            int mask = ((2 << (endPos - startPos)) - 1) << startPos;
            return (first & ~mask) | ((second << startPos) & mask);
        }
    }
}
