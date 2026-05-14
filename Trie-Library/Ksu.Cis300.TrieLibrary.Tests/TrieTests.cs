/* TrieTests.cs
 * Author: Josh Weese
 */
using NUnit.Framework;
using System;
using System.Text;

namespace Ksu.Cis300.TrieLibrary.Tests
{
    /// <summary>
    /// Unit tests for the Trie class.
    /// </summary>
    [TestFixture]
    public class TrieTests
    {
        /// <summary>
        /// Tests that passing null to a TrieWithNoChildren's Contains method throws an 
        /// ArugmentNullException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestANoChildrenContainsNullThrowsException()
        {
            ITrie t = new TrieWithNoChildren();
            // We override the compiler warning even though it is warranted.
            // We need to test that this case is handled.
            Assert.That(() => t.Contains(null!), Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        /// Tests that passing null to Add throws an ArgumentNullException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestANoChildrenAddNullThrowsException()
        {
            ITrie t = new TrieWithNoChildren();
            // We override the compiler warning even though it is warranted.
            // We need to test that this case is handled.
            Assert.That(() => t.Add(null!), Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        /// Tests looking up an empty string in an empty trie.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAEmptyContainsEmptyString()
        {
            ITrie t = new TrieWithNoChildren();
            Assert.That(t.Contains(""), Is.False);
        }

        /// <summary>
        /// Tests looking up a nonempty string in an empty trie.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAEmptyContainsNonemptyString()
        {
            ITrie t = new TrieWithNoChildren();
            Assert.That(t.Contains("word"), Is.False);
        }

        /// <summary>
        /// Tests looking up a string with an invalid character in an empty trie.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAEmptyContainsInvalidString()
        {
            ITrie t = new TrieWithNoChildren();
            Assert.That(t.Contains("`"), Is.False);
        }

        /// <summary>
        /// Tests that adding the empty string to an empty trie gives a TrieWithNoChildren.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBAddEmptyCheckType()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("");
            Assert.That(t, Is.TypeOf(typeof(TrieWithNoChildren)));
        }

        /// <summary>
        /// Adds the empty string to an empty trie and looks it up.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBAddEmptyLookItUp()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("");
            Assert.That(t.Contains(""), Is.True);
        }

        /// <summary>
        /// Tests adding a string with an invalid character to an empty trie.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBAddInvalid()
        {
            ITrie t = new TrieWithNoChildren();
            Assert.That(() => t.Add("`"), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        /// Tests adding another invalid string to an empty trie.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBAddInvalid2()
        {
            ITrie t = new TrieWithNoChildren();
            Assert.That(() => t.Add("{"), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        /// Tests that passing a null string to a TrieWithNoChildren's Contains
        /// mmethod throws an ArgumentNullException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBContainsNull()
        {
            ITrie t = new TrieWithNoChildren();
            // We override the compiler warning even though it is warranted.
            // We need to test that this case is handled.
            Assert.That(() => t.Contains(null!), Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        /// Tests that passing a null string to TrieWithNoChildren's Add method
        /// throws an ArgumentNullException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBAddNull()
        {
            ITrie t = new TrieWithNoChildren();
            // We override the compiler warning even though it is warranted.
            // We need to test that this case is handled.
            Assert.That(() => t.Add(null!), Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        /// Tests that passing a null string to the TrieWithOneChild constructor
        /// throws an ArgumentNullException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCOneChildConstructorNull()
        {
            // We override the compiler warning even though it is warranted.
            // We need to test that this case is handled.
            Assert.That(() => new TrieWithOneChild(null!, false), Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        /// Tests that adding a 1-letter word to an empty trie gives a TrieWithOneChild.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCAddShortWordCheckType()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("i");
            Assert.That(t, Is.TypeOf(typeof(TrieWithOneChild)));
        }

        /// <summary>
        /// Adds a 1-letter word and looks it up.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCAddShortWordLookItUp()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("i");
            Assert.That(t.Contains("i"), Is.True);
        }

        /// <summary>
        /// Adds a 1-letter word to an empty trie and looks up the empty string.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCAddShortWordLookUpEmpty()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("i");
            Assert.That(t.Contains(""), Is.False);
        }

        /// <summary>
        /// Adds the empty string and a 1-letter word to an empty trie and looks up the empty string.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCAddEmptyAndShortWordLookUpEmpty()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("");
            t = t.Add("i");
            Assert.That(t.Contains(""), Is.True);
        }

        /// <summary>
        /// Tests that passing null to TrieWithOneChild's Contains method throws
        /// an ArgumentNullException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCContainsNull()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("i");
            // We override the compiler warning even though it is warranted.
            // We need to test that this case is handled.
            Assert.That(() => t.Contains(null!), Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        /// Tests that passing null to TrieWithOneChild's Add method throws
        /// an ArgumentNullException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCAddNull()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("i");
            // We override the compiler warning even though it is warranted.
            // We need to test that this case is handled.
            Assert.That(() => t.Add(null!), Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        /// Adds a longer word and looks it up.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDAddLongWordLookItUp()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("word");
            Assert.That(t.Contains("word"), Is.True);
        }

        /// <summary>
        /// Adds a word and looks up a prefix that should not be in the trie.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDAddWordLookUpPrefix()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("word");
            Assert.That(t.Contains("wo"), Is.False);
        }

        /// <summary>
        /// Adds a word, then a prefix, and looks up all prefixes.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestELookupAllPrefixes()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("ice");
            t = t.Add("i");
            StringBuilder sb = new StringBuilder();
            sb.Append(t.Contains(""));
            sb.Append(t.Contains("i"));
            sb.Append(t.Contains("ic"));
            sb.Append(t.Contains("ice"));
            Assert.That(sb.ToString(), Is.EqualTo("FalseTrueFalseTrue"));
        }

        /// <summary>
        /// Adds a word, then a continuation of that word, and looks up all prefixes.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestELookupAllPrefixes2()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("i");
            t = t.Add("ice");
            StringBuilder sb = new StringBuilder();
            sb.Append(t.Contains(""));
            sb.Append(t.Contains("i"));
            sb.Append(t.Contains("ic"));
            sb.Append(t.Contains("ice"));
            Assert.That(sb.ToString(), Is.EqualTo("FalseTrueFalseTrue"));
        }

        /// <summary>
        /// Tests that passing a null string to the TrieWithManyChildren constructor throws
        /// an ArgumentNullException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestFConstructorNullString()
        {
            // We override the compiler warning even though it is warranted.
            // We need to test that this case is handled.
            Assert.That(() => new TrieWithManyChildren(null!, false, 'i', new TrieWithNoChildren()),
                Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        /// Tests that passing a null trie to the TrieWithManyChildren constructor throws
        /// an ArgumentNullException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestFConstructorNullTrie()
        {
            // We override the compiler warning even though it is warranted.
            // We need to test that this case is handled.
            Assert.That(() => new TrieWithManyChildren("c", false, 'i', null!),
                Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        /// Adds a word starting with a different letter to a TrieWithOneChild and
        /// checks its type.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestFAddDifferentLetterCheckType()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("i");
            t = t.Add("ice");
            t = t.Add("cream");
            Assert.That(t, Is.TypeOf(typeof(TrieWithManyChildren)));
        }

        /// <summary>
        /// Adds several words and looks them up, along with the empty string.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestFAddDifferentLetterLookUpAll()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("i");
            t = t.Add("ice");
            t = t.Add("cream");
            StringBuilder sb = new StringBuilder();
            sb.Append(t.Contains(""));
            sb.Append(t.Contains("i"));
            sb.Append(t.Contains("ice"));
            sb.Append(t.Contains("cream"));
            Assert.That(sb.ToString, Is.EqualTo("FalseTrueTrueTrue"));
        }

        /// <summary>
        /// Adds the empty string to an empty trie, then several words to form a
        /// TrieWithManyChildren, and looks up the empty string.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestFAddEmptyAndDifferentLetterLookUpEmpty()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("");
            t = t.Add("i");
            t = t.Add("ice");
            t = t.Add("cream");
            Assert.That(t.Contains(""), Is.EqualTo(true));
        }

        /// <summary>
        /// Tests that passing null to a TrieWithManyChildren's Contains method
        /// throws an ArgumentNullException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestFContainsNull()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("i");
            t = t.Add("ice");
            t = t.Add("cream");
            // We override the compiler warning even though it is warranted.
            // We need to test that this case is handled.
            Assert.That(() => t.Contains(null!), Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        /// Tests that passing null to a TrieWithManyChildren's Add method
        /// throws an ArgumentNullException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestFAddNull()
        {
            ITrie t = new TrieWithNoChildren();
            t = t.Add("i");
            t = t.Add("ice");
            t = t.Add("cream");
            // We override the compiler warning even though it is warranted.
            // We need to test that this case is handled.
            Assert.That(() => t.Add(null!), Throws.InstanceOf<ArgumentNullException>());
        }

    }
}
