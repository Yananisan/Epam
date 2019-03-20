using System;
using NUnit.Framework;

namespace QuickSort.Test
{
    public class Test
    {
        [Test]
        public void Test1()
        {
            int[] array = { 24, 16, 54 };
            QuickSort.quicksort(array);
            Assert.AreEqual(new int[] { 16, 24, 54 }, array);
        }
    }
}
