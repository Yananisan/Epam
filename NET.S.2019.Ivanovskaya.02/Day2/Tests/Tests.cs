using System;
using NUnit.Framework;

namespace Day2.Tests
{
    [TestFixture]
    public class Tests
    {
        #region FindNextBiggerThan

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int? FindNextBiggerThanTests(int number) => 
            FindNextBiggerThanClass.FindNextBiggerThan(number, out TimeSpan time);

        #endregion

        #region FilterDigit

        [TestCase(7, new int[] { 17, 8, 7 }, ExpectedResult = new int[] { 17, 7 })]
        [TestCase(int.MaxValue, new int[] { int.MinValue + 1, int.MaxValue, 0 }, ExpectedResult = new int[] { int.MinValue + 1, int.MaxValue })]
        [TestCase(-1, new int[] { -1, -11, 101, 201 }, ExpectedResult = new int[] { -1, -11, 101, 201 })]   
        public int[] FilterDigitTests(int number, int[] array) => 
            FilterDigitClass.FilterDigit(number, array);

        [Test]
        public void CheckOnNull() => Assert.Throws<ArgumentNullException>(() => 
        FilterDigitClass.FilterDigit(-1, null));

        [Test]
        public void CheckOnEmpty() => Assert.Throws<ArgumentException>(() => 
        FilterDigitClass.FilterDigit(-1, new int[] { }));

        #endregion

        #region FindNthRoot

        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRootTests(double number, int degree, double precision, double expected)
        {
            double actual = FindNthRootClass.FindNthRoot(number, degree, precision);
            Assert.AreEqual(expected, actual, precision);
        }

        #endregion

    }
}
