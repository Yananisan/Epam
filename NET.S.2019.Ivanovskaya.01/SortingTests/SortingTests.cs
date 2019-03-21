using System;
using NUnit.Framework;

namespace SortingMethods.Test
{
    public class Test
    {
        [Test]
        public void QuickSortTest()
        {
            int[] array = { 24, 16, 54, -4, 3, 47, 93, 101, 255, -34, -2019 };
            SortingMethods.Quicksort(array);
            Assert.AreEqual(new int[] { -2019, -34, -4, 3, 16, 24, 47, 54, 93, 101, 255 }, array);
        }

        [Test]
        public void MergeSortTest()
        {
            int[] array = { 24, 16, 54, -4, 3, 47, 93, 101, 255, -34, -2019 };
            SortingMethods.Mergesort(array);
            Assert.AreEqual(new int[] { -2019, -34, -4, 3, 16, 24, 47, 54, 93, 101, 255 }, array);
        }

        [Test]
        public void CheckQuickSortOnNull() => Assert.Throws<ArgumentNullException>(() => SortingMethods.Quicksort(null));

        [Test]
        public void CheckMergeSortOnNull() => Assert.Throws<ArgumentNullException>(() => SortingMethods.Mergesort(null));

        [Test]
        public void CheckQuickSortOnEmpty() => Assert.Throws<ArgumentException>(() => SortingMethods.Quicksort(new int[] { }));

        [Test]
        public void CheckMergeSortOnEmpty() => Assert.Throws<ArgumentException>(() => SortingMethods.Mergesort(new int[] { }));
    }
}
