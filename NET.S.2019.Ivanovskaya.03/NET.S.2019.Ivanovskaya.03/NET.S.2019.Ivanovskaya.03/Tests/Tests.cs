using System;
using NUnit.Framework;

namespace NET.S._2019.Ivanovskaya._03.Tests
{
    class Tests
    {
        #region Euclidian GCD

        [TestCase(7, 14, 49, ExpectedResult = 7)]
        [TestCase(16, 144, 32, 56, ExpectedResult = 8)]
        [TestCase(12, ExpectedResult = 12)]
        [TestCase(-33, 11, 110, ExpectedResult = 11)]
        [TestCase(10, 20, 30, 50, 100, ExpectedResult = 10)]
        [TestCase(0, 13, 26, ExpectedResult = 13)]
        public int GCDTests(params int[] array) =>
            GCDClass.GCD(out TimeSpan time, array);

        [Test]
        public void CheckOnNull() => Assert.Throws<ArgumentNullException>(() =>
        GCDClass.GCD(out TimeSpan time, null));

        [Test]
        public void CheckOnEmpty() => Assert.Throws<ArgumentException>(() =>
        GCDClass.GCD(out TimeSpan time, new int[] { }));

        #endregion

        #region Stein's GCD

        [TestCase(7, 14, 49, ExpectedResult = 7)]
        [TestCase(16, 144, 32, 56, ExpectedResult = 8)]
        [TestCase(12, ExpectedResult = 12)]
        [TestCase(-33, 11, 110, ExpectedResult = 11)]
        [TestCase(10, 20, 30, 50, 100, ExpectedResult = 10)]
        [TestCase(0, 13, 26, ExpectedResult = 13)]
        public int BinaryGCDTests(params int[] array) =>
        GCDClass.BinaryGCD(out TimeSpan time, array);

        [Test]
        public void CheckBinaryOnNull() => Assert.Throws<ArgumentNullException>(() =>
        GCDClass.BinaryGCD(out TimeSpan time, null));

        [Test]
        public void CheckBinaryOnEmpty() => Assert.Throws<ArgumentException>(() =>
        GCDClass.BinaryGCD(out TimeSpan time, new int[] { }));

        #endregion

        #region DoubleToBinary

        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000000")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.NaN, ExpectedResult = "1111111111111000000000000000000000000000000000000000000000000000")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "1111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "0111111111110000000000000000000000000000000000000000000000000000")]
        [TestCase(-0.0, ExpectedResult = "1000000000000000000000000000000000000000000000000000000000000000")]
        [TestCase(0.0, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000000")]
        public string DoubleToBinary_IsCorrect(double number)
            => number.DoubleToBinary();

        #endregion
    }
}
