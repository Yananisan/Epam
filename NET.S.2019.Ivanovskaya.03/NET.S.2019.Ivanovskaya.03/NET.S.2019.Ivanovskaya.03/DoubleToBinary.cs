using System.Runtime.InteropServices;
using System.Text;

namespace NET.S._2019.Ivanovskaya._03
{
    public static class DoubleToBinaryClass
    {
        public static string DoubleToBinary(this double number)
        {
            DoubleToLongStruct bits = new DoubleToLongStruct(number);
            return bits.ToLong().ConvertToIEEE();
        }

        /// <summary>
        /// Method that convert long value into the IEEE 754 Format Style string.
        /// </summary>
        /// <param name="bits">Value that need to be represent in IEEE 754 Format Style.</param>
        /// <returns>IEEE 754 string representation.</returns>
        private static string ConvertToIEEE(this long _long)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 64; i++)
            {
                if ((_long & 1) == 1)
                    result.Insert(0, "1");
                else
                    result.Insert(0, "0");

                _long >>= 1;
            }
            return result.ToString();
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)]
            private readonly long _long;

            [FieldOffset(0)]
            private readonly double _double;

            public DoubleToLongStruct(double number) : this()
            {
                _double = number;
            }

            public long ToLong() => _long;
        }
    }
}
