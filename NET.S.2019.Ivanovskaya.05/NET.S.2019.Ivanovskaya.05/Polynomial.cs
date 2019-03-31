using System;
using System.Text;

namespace NET.S._2019.Ivanovskaya._05
{
    public class Polynomial: IDisposable, ICloneable
    {

        private readonly double[] _coefficients;

        #region Clone

        object ICloneable.Clone() => Clone();

        public Polynomial Clone()
        {
            return new Polynomial(_coefficients);
        }

        #endregion

        public Polynomial(params double[] coefficients)
        {
            if (coefficients == null)
            {
                throw new ArgumentNullException($"{nameof(coefficients)} can't be equal to null.");
            }

            if (coefficients.Length == 0)
            {
                throw new ArgumentException($"{nameof(coefficients)} can't be empty!");
            }

            _coefficients = coefficients;
        }

        public int Length
        {
            get
            {
                return _coefficients.Length;
            }
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index > Length)
                    throw new ArgumentOutOfRangeException($"{nameof(index)} is out of range!");

                return _coefficients[index];
            }

            private set
            {
                if (index < 0 || index > Length)
                    throw new ArgumentOutOfRangeException($"{nameof(index)} is out of range!");

                _coefficients[index] = value;
            }
        }

        public int Power
        {
            get
            {
                return _coefficients.Length;
            }
        }

        #region Overriding Object methods: ToString, GetHashCode, Equals, Finalize

        #region ToString

        public override string ToString()
        {
            if (this == null)
            {
                throw new ArgumentNullException($"Object can't be equal to null!");
            }

            StringBuilder result = new StringBuilder();

            for (int i = this.Power - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    result.Append(_coefficients[i]);
                }
                else
                {
                    if (i != 1)
                    {
                        result.Append(_coefficients[i] + "x^" + i + " + ");
                    }
                    else
                    {
                        if (this[i] > 0)
                        {
                            result.Append(_coefficients[i] + "x" + " + ");
                        }
                        else
                        {
                            result.Append(_coefficients[i] + "x");
                        }
                    }
                }
            }

            return result.ToString();
        }

        #endregion

        #region GetHashCode

        public override int GetHashCode()
        {
            int result = 0;
            foreach (double value in _coefficients)
            {
                result += ShiftAndWrap(value.GetHashCode(), 2);
            }
            return result;
        }

        public int ShiftAndWrap(int value, int positions)
        {
            positions = positions & 0x1F;

            // Save the existing bit pattern, but interpret it as an unsigned integer.
            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            // Preserve the bits to be discarded.
            uint wrapped = number >> (32 - positions);
            // Shift and wrap the discarded bits.
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }

        #endregion

        #region Equals

        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this is null || other is null)
            {
                return false;
            }

            for (int i = 0; i < other.Length; i++)
            {
                if (other[i] != _coefficients[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this is null || obj is null)
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((Polynomial)obj);
        }

        #endregion

        #region Finalize(Dispose)

        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool flag)
        {
            if (_isDisposed) return;
            if (flag) GC.SuppressFinalize(this);
        }

        ~Polynomial()
        {
            this.Dispose(false);
        }

        #endregion

        #endregion
    }
}
