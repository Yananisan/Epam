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
    }
}
