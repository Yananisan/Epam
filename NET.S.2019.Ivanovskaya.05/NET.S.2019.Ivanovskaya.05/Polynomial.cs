using System;
using System.Text;

namespace NET.S._2019.Ivanovskaya._05
{
    public class Polynomial: IDisposable, ICloneable
    {

        private readonly double[] _coefficients;


        #region Clone
        
        object ICloneable.Clone() => Clone();

        /// <summary>
        /// Realization of IClonable
        /// </summary>
        /// <returns></returns>
        public Polynomial Clone()
        {
            return new Polynomial(_coefficients);
        }

        #endregion

        /// <summary>
        /// Constructor for Polynomial class
        /// </summary>
        /// <param name="coefficients">Coefficients of polynomial</param>
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

        /// <summary>
        /// Returns the length of the Polynomial.
        /// </summary>
        public int Length
        {
            get
            {
                return _coefficients.Length;
            }
        }

        /// <summary>
        /// Indexer of Polynomial class
        /// </summary>
        /// <param name="index">Current index</param>
        /// <returns>Current polynomial value</returns>
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


        #region Overriding Object methods: ToString, GetHashCode, Equals, Finalize

        #region ToString

        /// <summary>
        /// Override ToString Method
        /// </summary>
        /// <returns>Object in string format</returns>
        public override string ToString()
        {
            if (this == null)
            {
                throw new ArgumentNullException($"Object can't be equal to null!");
            }

            StringBuilder result = new StringBuilder();

            for (int i = this.Length - 1; i >= 0; i--)
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

        /// <summary>
        /// Override GetHashCodeMethod
        /// </summary>
        /// <returns>Object's HashCode</returns>
        public override int GetHashCode()
        {
            int result = 0;
            foreach (double value in _coefficients)
            {
                result += ShiftAndWrap(value.GetHashCode(), 2);
            }
            return result;
        }

        private int ShiftAndWrap(int value, int positions)
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

        /// <summary>
        /// Override Equals method
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>Is object equal or not (true or false)</returns>
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

            for (int i = 0; i < ((Polynomial)obj).Length; i++)
            {
                if (((Polynomial)obj)[i] != _coefficients[i])
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Finalize(Dispose)

        private bool _isDisposed = false;

        /// <summary>
        /// IDisposable realization
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool flag)
        {
            if (_isDisposed) return;
            if (flag) GC.SuppressFinalize(this);
            _isDisposed = true;
        }

        ~Polynomial()
        {
            this.Dispose(false);
        }

        #endregion

        #endregion

        #region Overloaded operations

        public static Polynomial operator +(Polynomial FirstOp, Polynomial SecondOp) => Add(FirstOp, SecondOp);
        public static Polynomial operator +(Polynomial FirstOp, double SecondOp) => Add(FirstOp, SecondOp);
        public static Polynomial operator +(double FirstOp, Polynomial SecondOp) => Add(FirstOp, SecondOp);
        public static Polynomial operator -(Polynomial FirstOp, Polynomial SecondOp) => Subtract(FirstOp, SecondOp);
        public static Polynomial operator -(Polynomial FirstOp, double SecondOp) => Subtract(FirstOp, SecondOp);
        public static Polynomial operator -(double FirstOp, Polynomial SecondOp) => Subtract(FirstOp, SecondOp);
        public static Polynomial operator *(Polynomial FirstOp, Polynomial SecondOp) => Multiply(FirstOp, SecondOp);
        public static Polynomial operator *(Polynomial FirstOp, double SecondOp) => Multiply(FirstOp, SecondOp);
        public static Polynomial operator *(double FirstOp, Polynomial SecondOp) => Multiply(FirstOp, SecondOp);
        public static bool operator ==(Polynomial FirstOp, Polynomial SecondOp) => Equals(FirstOp, SecondOp);
        public static bool operator !=(Polynomial FirstOp, Polynomial SecondOp) => !Equals(FirstOp, SecondOp);

        #region Preparation

        private const int SummingSign = 1;
        private const int SubtractionSign = -1;

        private static double[] ToPolyArray(double[] FirstOp, double[] SecondOp)
            => new double[(FirstOp.Length > SecondOp.Length) ? FirstOp.Length : SecondOp.Length];

        private static void CheckInput(Polynomial poly)
        {
            if (poly == null)
            {
                throw new ArgumentNullException($"{nameof(poly)} is null!");
            }

            if (poly.Length == 0)
            {
                throw new ArgumentException($"{nameof(poly)} is empty!");
            }
        }

        private static void CheckInput(Polynomial poly1, Polynomial poly2)
        {
            CheckInput(poly1);
            CheckInput(poly2);
        }

        private static double[] GetSumSubtrResult(double[] result, double[] FirstOp, double[] SecondOp, int sign)
        {
            FirstOp.CopyTo(result, 0);

            for (int i = 0; i < result.Length; i++)
            {
                result[i] += SecondOp[i] * sign;
            }

            return result;
        }

        private static double[] GetSumSubtrResult(double[] result, double FirstOp, double[] SecondOp, int sign)
        {
            SecondOp.CopyTo(result, 0);

            result[0] += FirstOp * sign;

            return result;
        }

        private static double[] GetSumSubtrResult(double[] result, double[] FirstOp, double SecondOp, int sign)
        {
            FirstOp.CopyTo(result, 0);

            result[0] += SecondOp * sign;

            return result;
        }

        private static double[] GetMultuplyResult(double[] result, double[] FirstOp, double[] SecondOp)
        {
            for (int i = 0; i < FirstOp.Length; ++i)
            {
                for (int j = 0; j < SecondOp.Length; ++j)
                {
                    result[i + j] += FirstOp[i] * SecondOp[j];
                }
            }

            return result;
        }

        private static double[] GetMultuplyResult(double[] result, double FirstOp, double[] SecondOp)
        {
            for (int i = 0; i < SecondOp.Length; i++)
            {
                result[i] += SecondOp[i] * FirstOp;
            }

            return result;
        }

        private static double[] GetMultuplyResult(double[] result, double[] FirstOp, double SecondOp)
        {
            for (int i = 0; i < FirstOp.Length; i++)
            {
                result[i] += FirstOp[i] * SecondOp;
            }

            return result;
        }

        #endregion

        #region Add

        private static Polynomial Add(Polynomial FirstOp, Polynomial SecondOp)
        {
            CheckInput(FirstOp, SecondOp);

            double[] result = ToPolyArray(FirstOp._coefficients, SecondOp._coefficients);

            return new Polynomial(GetSumSubtrResult(result, FirstOp._coefficients, SecondOp._coefficients, SummingSign));
        }

        private static Polynomial Add(Polynomial FirstOp, double SecondOp)
        {
            CheckInput(FirstOp);

            double[] result = new double[FirstOp.Length];

            return new Polynomial(GetSumSubtrResult(result, FirstOp._coefficients, SecondOp, SummingSign));
        }

        private static Polynomial Add(double FirstOp, Polynomial SecondOp)
        {
            CheckInput(SecondOp);

            double[] result = new double[SecondOp.Length];

            return new Polynomial(GetSumSubtrResult(result, FirstOp, SecondOp._coefficients, SummingSign));
        }

        #endregion

        #region Subtract

        private static Polynomial Subtract(Polynomial FirstOp, Polynomial SecondOp)
        {
            CheckInput(FirstOp, SecondOp);

            double[] result = ToPolyArray(FirstOp._coefficients, SecondOp._coefficients);

            return new Polynomial(GetSumSubtrResult(result, FirstOp._coefficients, SecondOp._coefficients, SubtractionSign));
        }

        private static Polynomial Subtract(Polynomial FirstOp, double SecondOp)
        {
            CheckInput(FirstOp);

            double[] result = new double[FirstOp.Length];

            return new Polynomial(GetSumSubtrResult(result, FirstOp._coefficients, SecondOp, SubtractionSign));
        }

        private static Polynomial Subtract(double FirstOp, Polynomial SecondOp)
        {
            CheckInput(SecondOp);

            double[] result = new double[SecondOp.Length];

            return new Polynomial(GetSumSubtrResult(result, FirstOp, SecondOp._coefficients, SubtractionSign));
        }

        #endregion

        #region Multiply

        private static Polynomial Multiply(Polynomial FirstOP, Polynomial SecondOp)
        {
            CheckInput(FirstOP, SecondOp);

            double[] result = new double[FirstOP.Length + SecondOp.Length - 1];

            return new Polynomial(GetMultuplyResult(result, FirstOP._coefficients, SecondOp._coefficients));
        }

        private static Polynomial Multiply(Polynomial FirstOP, double SecondOp)
        {
            CheckInput(FirstOP);

            double[] result = new double[FirstOP.Length];

            return new Polynomial(GetMultuplyResult(result, FirstOP._coefficients, SecondOp));
        }

        private static Polynomial Multiply(double FirstOP, Polynomial SecondOp)
        {
            CheckInput(SecondOp);

            double[] result = new double[SecondOp.Length];

            return new Polynomial(GetMultuplyResult(result, FirstOP, SecondOp._coefficients));
        }

        #endregion

        #endregion
    }
}
