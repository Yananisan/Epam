using NUnit.Framework;

namespace BinarySearch.Tests
{
    [TestFixture]
    public class BinaryTests
    {
        [Test]
        public void OnSortedIntArray_FindsKey()
        {
            int[] array = { 1, 3, 5, 9, 11, 13, 54 };
            int index = array.BinarySearch(3, (a, b) => a.CompareTo(b));

            Assert.AreEqual(1, index);
        }

        [Test]
        public void OnSortedIntArray_DoesntFindKey()
        {
            int[] array = { 1, 3, 5, 9, 11, 13, 54 };
            int index = array.BinarySearch(15, (a, b) => a.CompareTo(b));

            Assert.IsTrue(index < 0);
        }

        [Test]
        public void OnNonSortedIntArray_DoesntFindKey()
        {
            int[] array = { 1, 13, 5, 19, 11, 3, 54 };
            int index = array.BinarySearch(3, (a, b) => a.CompareTo(b));

            Assert.IsTrue(index < 0);
        }

        [Test]
        public void OnSortedIntArray_WithoutComparison()
        {
            int[] array = { 1, 13, 5, 19, 11, 3, 54 };
            int index = array.BinarySearch(3);

            Assert.IsTrue(index < 0);
        }

        [Test]
        public void OnSortedStringArray_FindsKey()
        {
            string[] array = { "a", "b", "cdfg", "ddfgh", "E", "F", "ghj" };
            int index = array.BinarySearch("ddfgh", (a, b) => string.Compare(a, b, true));

            Assert.AreEqual(3, index);
        }
    }
}
