/* SortTests.cs
 * Author: Josh Weese
 */
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Ksu.Cis300.SortLibrary.Tests
{
    /// <summary>
    /// Unit tests for the Sort class.
    /// </summary>
    [TestFixture]
    public class SortTests
    {
        /// <summary>
        /// Tests that when passed null, QuickSort throws an ArgumentNullException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestASortNull()
        {
            // We override the warning in order to test that this case is handled properly.
            Assert.That(() => Sort.QuickSort(null!), Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        /// Tests sorting a 1-element array.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestASortOne()
        {
            int[] data = new int[] { 1 };
            int[] result = new int[] { 1 };
            Sort.QuickSort(result);
            Assert.That(result, Is.EquivalentTo(data));
        }

        /// <summary>
        /// Tests sorting a 2-element unordered array.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBSortTwoUnordered()
        {
            int[] data = new int[] { 7, 2 };
            int[] result = new int[2];
            data.CopyTo(result, 0);
            Sort.QuickSort(result);
            Assert.That(result, Is.Ordered.And.EquivalentTo(data));
        }

        /// <summary>
        /// Tests sorting a 2-element ordered array.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBSortTwoOrdered()
        {
            int[] data = new int[] { 2, 7 };
            int[] result = (int[])data.Clone();
            Sort.QuickSort(result);
            Assert.That(result, Is.Ordered.And.EquivalentTo(data));
        }

        /// <summary>
        /// Tests sorting a 4-element array in which neither half contains elements less
        /// than all the elements in the other half.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCSortFourMixed()
        {
            int[] data = new int[] { 7, 2, 5, 3 };
            int[] result = (int[])data.Clone();
            Sort.QuickSort(result);
            Assert.That(result, Is.Ordered.And.EquivalentTo(data));
        }

        /// <summary>
        /// Tests sorting a 4-element array in reverse order.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCSortFourReversed()
        {
            int[] data = new int[] { 7, 5, 3, 2 };
            int[] result = (int[])data.Clone();
            Sort.QuickSort(result);
            Assert.That(result, Is.Ordered.And.EquivalentTo(data));
        }

        /// <summary>
        /// Tests sorting a 10-element array.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDSortTen()
        {
            int[] data = new int[] { 3, -7, 0, 11, -7, 8, 4, 8, -2, 6 };
            int[] result = new int[data.Length];
            data.CopyTo(result, 0);
            Sort.QuickSort(result);
            Assert.That(result, Is.Ordered.And.EquivalentTo(data));
        }

        /// <summary>
        /// Iniitializes two lists to the same sequence of random ints.
        /// </summary>
        /// <param name="data">The first list.</param>
        /// <param name="result">The second list.</param>
        /// <param name="n">The number of elements in each list, and the upper bound
        /// on their values (values will be nonnegative and less than n).</param>
        private static void Initialize(IList<int> data, IList<int> result, int n)
        {
            Random r = new();
            for (int i = 0; i < n; i++)
            {
                data.Add(r.Next(n));
                result.Add(data[i]);
            }
        }

        /// <summary>
        /// Tests sorting a random list of 100 elements.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestESort100()
        {
            List<int> data = new();
            List<int> result = new();
            Initialize(data, result, 100);
            Sort.QuickSort(result);
            Assert.That(result, Is.Ordered.And.EquivalentTo(data));
        }

        /// <summary>
        /// Tests sorting a random list of 30000 elements.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestFSort30000()
        {
            List<int> data = new();
            List<int> result = new();
            Initialize(data, result, 30000);
            Sort.QuickSort(result);
            Assert.That(result, Is.Ordered);
        }

        /// <summary>
        /// Tests sorting a random list of one million elements.
        /// </summary>
        [Test, Timeout(5000)]
        public void TestGSortMillion()
        {
            List<int> data = new();
            List<int> result = new();
            Initialize(data, result, 1000000);
            Sort.QuickSort(result);
            Assert.That(result, Is.Ordered);
        }

        /// <summary>
        /// Tests sorting a pre-sorted array of 7,000 elements.
        /// </summary>
        [Test, Timeout(5000)]
        public void TestHSort7000Sorted()
        {
            int[] data = new int[7000];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }
            Sort.QuickSort(data);
            Assert.That(data, Is.Ordered);
        }
    }
}
