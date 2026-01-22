/* StackTest.cs
 * Author: Josh Weese
 */
using System.Text;

namespace Ksu.Cis300.LinkedListLibrary.Tests
{
    /// <summary>
    /// A unit tests class for the class library Ksu.Cis300.LinkedListLibrary.
    /// </summary>
    [TestFixture]
    public class StackTest
    {
        /// <summary>
        /// Tests that Count is defined as a property.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestACountPropertyExists()
        {
            Type type = new LinkedListLibrary.Stack<int>().GetType();
            Assert.That(type.GetProperty("Count"), Is.Not.Null);
        }

        /// <summary>
        /// Tests that a Peek on an empty stack throws an InvalidOperationException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAEmptyPeek()
        {
            LinkedListLibrary.Stack<int> s = new();
            Assert.That(() => s.Peek(), Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        /// Tests that a Pop on an empty stack throws an InvalidOperationException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBEmptyPop()
        {
            LinkedListLibrary.Stack<string> s = new();
            Assert.That(() => s.Pop(), Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        /// Tests whether the count is correctly updated after pushing twice.
        /// The count should be 2.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCCountAfterPush()
        {
            LinkedListLibrary.Stack<int> s = new();
            s.Push(1);
            s.Push(2);
            Assert.That(s, Has.Count.EqualTo(2));
        }

        /// <summary>
        /// Tests whether the count is correctly updated after pushing three times
        /// and popping once.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDCountAfterPop()
        {
            LinkedListLibrary.Stack<char> s = new();
            s.Push('a');
            s.Push('b');
            s.Push('c');
            s.Pop();
            Assert.That(s, Has.Count.EqualTo(2));
        }

        /// <summary>
        /// Tests whether Peek returns the correct value after three items are pushed onto
        /// the stack.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDSimplePeek()
        {
            LinkedListLibrary.Stack<int> s = new();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            Assert.That(s.Peek(), Is.EqualTo(3));
        }

        /// <summary>
        /// Tests whether Pop returns the correct value after three items are pushed onto
        /// the stack.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDSimplePop()
        {
            LinkedListLibrary.Stack<char> s = new();
            s.Push('a');
            s.Push('b');
            s.Push('c');
            Assert.That(s.Pop(), Is.EqualTo('c'));
        }

        /// <summary>
        /// Tests the results of a sequence of 6 Pushes followed by 6 Pops.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestEMultiplePop()
        {
            LinkedListLibrary.Stack<char> s = new();
            for (char c = 'a'; c < 'g'; c++)
            {
                s.Push(c);
            }
            StringBuilder sb = new();
            while (s.Count > 0)
            {
                sb.Append(s.Pop());
            }
            Assert.That(sb.ToString(), Is.EqualTo("fedcba"));
        }
    }
}
