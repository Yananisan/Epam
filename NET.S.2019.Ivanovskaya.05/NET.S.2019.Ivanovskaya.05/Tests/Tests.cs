using System;
using NUnit.Framework;


namespace NET.S._2019.Ivanovskaya._05.Tests
{
    class Tests
    {
        #region Overloaded operations

        [TestCase]
        public void Polynomial_Sum_IsCorrect()
        {
            Polynomial FisrtOp = new Polynomial(1, 2, 3);
            Polynomial SecondOp = new Polynomial(2, 3, 4);
            Polynomial expected = new Polynomial(3, 5, 7);

            Polynomial result = FisrtOp + SecondOp;
            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void Polynomial_SumPolyAndNumber_IsCorrect()
        {
            Polynomial FisrtOp = new Polynomial(1, 2, 3);
            double SecondOp = 2;
            Polynomial expected = new Polynomial(3, 2, 3);

            Polynomial result = FisrtOp + SecondOp;
            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void Polynomial_Subtr_IsCorrect()
        {
            Polynomial FisrtOp = new Polynomial(1, 3, 7);
            Polynomial SecondOp = new Polynomial(2, 2, 4);
            Polynomial expected = new Polynomial(-1, 1, 3);

            Polynomial result = FisrtOp - SecondOp;
            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void Polynomial_SubtrPolyAndNumber_IsCorrect()
        {
            Polynomial FisrtOp = new Polynomial(1, 2, 3);
            double SecondOp = 2;
            Polynomial expected = new Polynomial(-1, 2, 3);

            Polynomial result = FisrtOp - SecondOp;
            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void Polynomial_Mult_IsCorrect()
        {
            Polynomial FisrtOp = new Polynomial(1, 2, 3);
            Polynomial SecondOp = new Polynomial(2, 3, 4);
            Polynomial expected = new Polynomial(2, 7, 16, 17, 12);

            Polynomial result = FisrtOp * SecondOp;
            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void Polynomial_MultPolyAndDouble_IsCorrect()
        {
            Polynomial FisrtOp = new Polynomial(1, 2, 3);
            double SecondOp = 2;
            Polynomial expected = new Polynomial(2, 4, 6);

            Polynomial result = FisrtOp * SecondOp;
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region ToString

        [TestCase]
        public void Polynomial_ToString_IsCorrect()
        {
            Polynomial test = new Polynomial(1, 2, 3);
            string expected = "3x^2 + 2x + 1";

            string result = test.ToString();
            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void Polynomial_ToString_IsNotCorrect()
        {
            Polynomial test = new Polynomial(1, 2, 3);
            string expected = "9x^2 + 5x";

            string result = test.ToString();
            Assert.AreNotEqual(expected, result);
        }

        [TestCase]
        public void Polynomial_ToString_NullReferenceException()
        {
            Polynomial test = null;
            Assert.Throws<NullReferenceException>(() => test.ToString());
        }

        #endregion

        #region Equal

        [TestCase]
        public void Polynomial_EqualOperator_IsCorrect()
        {
            Polynomial poly1 = new Polynomial(1, 2);
            Polynomial poly2 = poly1;

            bool expected = true;
            bool actual = (poly1 == poly2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Polynomial_NotEqualOperator_IsCorrect()
        {
            Polynomial poly1 = new Polynomial(1, 2);
            Polynomial poly2 = poly1;

            bool expected = false;
            bool actual = (poly1 != poly2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Polynomial_Equals_IsEqual()
        {
            Polynomial obj = new Polynomial(1, 2, 3);
            bool expected = true;
            bool actual = obj.Equals(obj);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Polynomial_EqualsObject_IsCorrect()
        {
            Polynomial poly1 = new Polynomial(1, 2);
            object poly2 = new Polynomial(1, 2);

            bool expected = true;
            bool actual = poly1.Equals(poly2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void Polynomial_Equals_IsNotEqual()
        {
            Polynomial lhs = new Polynomial(1, 2, 3);
            Polynomial rhs = new Polynomial(2, 3, 4);
            bool expected = false;

            bool result = lhs.Equals(rhs);
            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void Polynomial_Object_Equals_IsNotEqual()
        {
            Polynomial lhs = new Polynomial(1, 2, 3);
            object rhs = new object[ 50, 234, 123 ];
            bool expected = false;

            bool result = lhs.Equals(rhs);
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region Constructor

        [TestCase]
        public void PolynomialConstructor_NullArg_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => new Polynomial(null));

        [TestCase]
        public void PolynomialConstructor_EmptyArg_ArgumentException()
            => Assert.Throws<ArgumentException>(() => new Polynomial(new double[] { }));

        #endregion

        #region Indexer

        [TestCase]
        public void PolynomialIndexer_IsCorrect()
        {
            Polynomial poly = new Polynomial(new double[] { 1, 2, 3 });
            double expected = 2;

            double actual = poly[1];
            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PolynomialIndexer_ArgumentOutOfRangeException()
        {
            Polynomial poly = new Polynomial(new double[] { 1, 2, 3 });
            double temp = 0;

            Assert.Throws<ArgumentOutOfRangeException>(() => temp = poly[10]);
        }

        #endregion
    }
}
