/* DictionaryTests.cs
 * Author: Josh Weese
 */
using NUnit.Framework;
using System;

namespace Ksu.Cis300.NameLookup.Tests
{
    /// <summary>
    /// Unit tests for the Dictionary class.
    /// </summary>
    [TestFixture]
    public class DictionaryTests
    {
        /// <summary>
        /// Gets a dictionary containing seven keys and values.
        /// </summary>
        /// <returns>A dictionary containing seven keys and values.</returns>
        private static DictionaryLibrary.Dictionary<int, string> LoadDictionary()
        {
            DictionaryLibrary.Dictionary<int, string> d = new();
            d.Add(10, "Ten");
            d.Add(5, "Five");
            d.Add(15, "Fifteen");
            d.Add(3, "Three");
            d.Add(7, "Seven");
            d.Add(13, "Thirteen");
            d.Add(20, "Twenty");
            return d;
        }
        /// <summary>
        /// Tests that a correct exception is thrown when a null key is added.
        /// A null indicates that no exception was thrown.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAAddNullKey()
        {
            DictionaryLibrary.Dictionary<string, float> d = new();
            // Override the compiler warning even though it is warranted. We need to
            // test that a null is handled properly.
            Assert.That(() => d.Add(null!, 0), Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        /// Tests that a correct exception is thrown when a null key is looked up.
        /// A null indicates that no exception was thrown.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestALookUpNullKey()
        {
            DictionaryLibrary.Dictionary<string, double> d = new();
            // Override the compiler warning even though it is warranted. We need to
            // test that a null is handled properly.
            Assert.That(() => d.TryGetValue(null!, out double _), Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        /// Tests a lookup on an empty dictionary. TryGetValue should return false
        /// and set its out parameter to null.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBLookUpEmpty()
        {
            DictionaryLibrary.Dictionary<int, string> d = new();
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(7, out string? s), Is.False);
                Assert.That(s, Is.Null);
            });
        }

        /// <summary>
        /// Adds one key and value, then looks it up.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCAddOneLookItUp()
        {
            DictionaryLibrary.Dictionary<string, int> d = new();
            d.Add("one", 1);
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue("one", out int i), Is.True);
                Assert.That(i, Is.EqualTo(1));
            });
        }

        /// <summary>
        /// Tests that the proper exception is thrown if a duplicate key is added.
        /// A null indicates that no exception was thrown.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDAddDuplicate()
        {
            DictionaryLibrary.Dictionary<string, int> d = new();
            d.Add("two", 2);
            d.Add("one", 1);
            Assert.That(() => d.Add("two", 2), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        /// Adds seven keys and values, then looks up the one that should be
        /// first in the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpFirst()
        {
            DictionaryLibrary.Dictionary<int, string> d = LoadDictionary();
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(3, out string? s), Is.True);
                Assert.That(s, Is.EqualTo("Three"));
            });
        }

        /// <summary>
        /// Adds seven keys and values, then looks up the one that should be
        /// second in the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpSecond()
        {
            DictionaryLibrary.Dictionary<int, string> d = LoadDictionary();
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(5, out string? s), Is.True);
                Assert.That(s, Is.EqualTo("Five"));
            });
        }

        /// <summary>
        /// Adds seven keys and values, then looks up the one that should be
        /// third in the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpThird()
        {
            DictionaryLibrary.Dictionary<int, string> d = LoadDictionary();
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(7, out string? s), Is.True);
                Assert.That(s, Is.EqualTo("Seven"));
            });
        }

        /// <summary>
        /// Adds seven keys and values, then looks up the one that should be
        /// fourth in the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpFourth()
        {
            DictionaryLibrary.Dictionary<int, string> d = LoadDictionary();
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(10, out string? s), Is.True);
                Assert.That(s, Is.EqualTo("Ten"));
            });
        }

        /// <summary>
        /// Adds seven keys and values, then looks up the one that should be
        /// fifth in the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpFifth()
        {
            DictionaryLibrary.Dictionary<int, string> d = LoadDictionary();
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(13, out string? s), Is.True);
                Assert.That(s, Is.EqualTo("Thirteen"));
            });
        }

        /// <summary>
        /// Adds seven keys and values, then looks up the one that should be
        /// sixth in the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpSixth()
        {
            DictionaryLibrary.Dictionary<int, string> d = LoadDictionary();
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(15, out string? s), Is.True);
                Assert.That(s, Is.EqualTo("Fifteen"));
            });
        }

        /// <summary>
        /// Adds seven keys and values, then looks up the one that should be last
        /// in the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpLast()
        {
            DictionaryLibrary.Dictionary<int, string> d = LoadDictionary();
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(20, out string? s), Is.True);
                Assert.That(s, Is.EqualTo("Twenty"));
            });
        }

        /// <summary>
        /// Adds seven keys and values, then looks up a key smaller than any in the dictionary.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpSmaller()
        {
            DictionaryLibrary.Dictionary<int, string> d = LoadDictionary();
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(2, out string? s), Is.False);
                Assert.That(s, Is.Null);
            });
        }

        /// <summary>
        /// Adds seven keys and values, then looks up a nonexistent key belonging in the
        /// middle of the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpMiddle()
        {
            DictionaryLibrary.Dictionary<int, string> d = LoadDictionary();
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(12, out string? s), Is.False);
                Assert.That(s, Is.Null);
            });
        }

        /// <summary>
        /// Adds five keys and values, then looks up a key larger than any in the dictionary.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpGreater()
        {
            DictionaryLibrary.Dictionary<int, string> d = LoadDictionary();
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(25, out string? s), Is.False);
                Assert.That(s, Is.Null);
            });
        }
    }
}
