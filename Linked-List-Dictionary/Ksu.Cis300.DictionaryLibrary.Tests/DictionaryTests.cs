/* DictionaryTests.cs
 * Author: Josh Weese
 */
using NUnit.Framework;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Ksu.Cis300.DictionaryLibrary.Tests
{
    /// <summary>
    /// Unit tests for the Dictionary class.
    /// </summary>
    [TestFixture]
    public class DictionaryTests
    {
        /// <summary>
        /// Gets a dictionary containing five keys and values.
        /// </summary>
        /// <returns>A dictionary containing five keys and values.</returns>
        private static DictionaryLibrary.Dictionary<int, string> LoadDictionary()
        {
            DictionaryLibrary.Dictionary<int, string> d = new();
            d.Add(10, "Ten");
            d.Add(5, "Five");
            d.Add(15, "Fifteen");
            d.Add(7, "Seven");
            d.Add(20, "Twenty");
            return d;
        }
        /// <summary>
        /// Tests that a correct exception is thrown when a null key is added.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAAddNullKey()
        {
            DictionaryLibrary.Dictionary<string, float> d = new();
            // We'll force the compiler to ignore the warning on the null, even though the
            // warning is deserved. We need to make sure the implementation handles this case
            // correctly.
            Assert.That(() => d.Add(null!, 0), Throws.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// Tests that a correct exception is thrown when a null key is looked up.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestALookUpNullKey()
        {
            DictionaryLibrary.Dictionary<string, double> d = new();
            // We'll force the compiler to ignore the warning on the null, even though the
            // warning is deserved. We need to make sure the implementation handles this case
            // correctly.
            Assert.That(() => d.TryGetValue(null!, out double x), Throws.TypeOf<ArgumentNullException>());
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
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDAddDuplicate()
        {
            DictionaryLibrary.Dictionary<string, int> d = new();
            d.Add("two", 2);
            d.Add("one", 1);
            Assert.That(() => d.Add("two", 2), Throws.TypeOf<ArgumentException>());
        }

        /// <summary>
        /// Adds five keys and values, then looks up the one that should be
        /// first in the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpFirst()
        {
            DictionaryLibrary.Dictionary<int, string> d = LoadDictionary();
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(5, out string? s), Is.True);
                Assert.That(s, Is.EqualTo("Five"));
            });
        }

        /// <summary>
        /// Adds five keys and values, then looks up the one that should be last
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
        /// Adds five keys and values, then looks up a key smaller than any in the dictionary.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpSmaller()
        {
            DictionaryLibrary.Dictionary<int, string> d = LoadDictionary();
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(3, out string? s), Is.False);
                Assert.That(s, Is.Null);
            });
        }

        /// <summary>
        /// Adds five keys and values, then looks up a nonexistent key belonging in the
        /// middle of the list.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDLookUpMiddle()
        {
            DictionaryLibrary.Dictionary<int, string> d = LoadDictionary();
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(13, out string? s), Is.False);
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

        /// <summary>
        /// Adds five keys and values, then looks up all of them.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestELookUpAll()
        {
            DictionaryLibrary.Dictionary<int, string> d = LoadDictionary();
            Assert.Multiple(() =>
            {
                Assert.That(d.TryGetValue(5, out string? s), Is.True);
                Assert.That(s, Is.EqualTo("Five"));
                Assert.That(d.TryGetValue(7, out s), Is.True);
                Assert.That(s, Is.EqualTo("Seven"));
                Assert.That(d.TryGetValue(10, out s), Is.True);
                Assert.That(s, Is.EqualTo("Ten"));
                Assert.That(d.TryGetValue(15, out s), Is.True);
                Assert.That(s, Is.EqualTo("Fifteen"));
                Assert.That(d.TryGetValue(20, out s), Is.True);
                Assert.That(s, Is.EqualTo("Twenty"));
            });
        }
    }
}
