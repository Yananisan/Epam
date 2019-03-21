using System;
using NUnit.Framework;

namespace SortingMethods.Test
{
    public class Test
    {
        [Test]
        public void QuickSortTest()
        {
            int[] array = { 24, 16, 54 };
            SortingMethods.Quicksort(array);
            Assert.AreEqual(new int[] { 16, 24, 54 }, array);
        }

        [Test]
        public void MergeSortTest()
        {
            int[] array = { 24, 16, 54 };
            SortingMethods.Mergesort(array);
            Assert.AreEqual(new int[] { 16, 24, 54 }, array);
        }
    }
}
