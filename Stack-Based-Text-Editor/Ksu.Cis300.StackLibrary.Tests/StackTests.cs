/* StackTests.cs
 * Author: Josh Weese
 */

namespace Ksu.Cis300.StackLibrary.Tests
{
    /// <summary>
    /// A unit tests class for the class library Ksu.Cis300.StackLibrary.
    /// </summary>
    [TestFixture]
    public class StackTests
    {
        /// <summary>
        /// Tests that the Count property is indeed a property
        /// </summary>
        [Test, Timeout(1000)]
        public void TestACountPropertyExists()
        {
            Type type = new Stack<int>().GetType();
            Assert.That(type.GetProperty("Count"), Is.Not.EqualTo(null));
        }

        /// <summary>
        /// Tests that the Capacity property is indeed a property.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestACapacityPropertyExists()
        {
            Type type = new Stack<int>().GetType();
            Assert.That(type.GetProperty("Capacity"), Is.Not.EqualTo(null));
        }

        /// <summary>
        /// Tests whether the array size is initially 5.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBInitialCapacity()
        {
            Stack<double> s = new();
            Assert.That(s.Capacity, Is.EqualTo(5));
        }
        /// <summary>
        /// Tests a Peek on an empty stack. The test will pass if an InvalidOperationException
        /// is thrown; otherwise, it will fail.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBEmptyPeek()
        {
            Stack<string> s = new();
            Assert.That(() => s.Peek(), Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        /// Tests a Pop on an empty stack. The test will pass if an InvalidOperationException
        /// is thrown. Otherwise, it will fail.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBEmptyPop()
        {
            Stack<string> s = new();
            Assert.That(() => s.Pop(), Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        /// Tests whether the count is correctly updated after pushing twice.
        /// The count should be 2.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCCountAfterPush()
        {
            Stack<int> s = new();
            s.Push(1);
            s.Push(2);
            Assert.That(s, Has.Count.EqualTo(2));
        }

        /// <summary>
        /// Tests whether the count is correctly updated after pushing three times
        /// and popping once.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCCountAfterPop()
        {
            Stack<char> s = new();
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
            Stack<int> s = new();
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
            StackLibrary.Stack<char> s = new();
            s.Push('a');
            s.Push('b');
            s.Push('c');
            Assert.That(s.Pop(), Is.EqualTo('c'));
        }

        /// <summary>
        /// Tests that upon clearing a stack, its Count is 0 and its Capacity is 5.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestEClear()
        {
            Stack<string> s = new();
            s.Push("abc");
            s.Push("xyz");
            s.Clear();

            // Assert that the Count is 0 and the Capacity is 5
            Assert.That(new Tuple<int, int>(s.Count, s.Capacity), Is.EqualTo(new Tuple<int, int>(0, 5)));
        }

        /// <summary>
        /// Tests a sequence of three Pushes followed by three Pops.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestFMultiplePop()
        {
            Stack<int> s = new();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            int first = s.Pop();
            int second = s.Pop();
            int third = s.Pop();
            Assert.That(new Tuple<int, int, int>(first, second, third), Is.EqualTo(new Tuple<int, int, int>(3, 2, 1)));
        }

        /// <summary>
        /// Pushes k values onto s. The values are successive powers of 2.
        /// </summary>
        /// <param name="k">The number of values to push</param>
        /// <param name="s">The stack on which to push.</param>
        /// <returns>The sum of the elements pushed.</returns>
        private static int PushMultiple(int k, Stack<int> s)
        {
            int val = 1;
            int sum = 0;
            for (int i = 0; i < k; i++)
            {
                sum += val;
                s.Push(val);
                val *= 2;
            }
            return sum;
        }

        /// <summary>
        /// Tests whether the capacity is still 5 after 5 Pushes.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestGFiveCapacity()
        {
            Stack<int> s = new();
            PushMultiple(5, s);
            Assert.That(s.Capacity, Is.EqualTo(5));
        }

        /// <summary>
        /// Tests whether the capacity is 10 after 6 Pushes.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestHExpandCapacity()
        {
            Stack<int> s = new();
            PushMultiple(6, s);
            Assert.That(s.Capacity, Is.EqualTo(10));
        }

        /// <summary>
        /// Tests whether the capacity is 20 after 11 Pushes.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestIDoubleExpandCapacity()
        {
            Stack<int> s = new();
            PushMultiple(11, s);
            Assert.That(s.Capacity, Is.EqualTo(20));
        }

        /// <summary>
        /// Removes all elements from the stack, computing their sum.
        /// </summary>
        /// <param name="s">The stack.</param>
        /// <returns>The sum of the elements removed from the stack.</returns>
        private static int SumAll(Stack<int> s)
        {
            int sum = 0;
            while (s.Count > 0)
            {
                sum += s.Pop();
            }
            return sum;
        }

        /// <summary>
        /// Tests whether a single expansion preserves all elements. The test is done
        /// by summing the elements as the are popped from the stack, and comparing
        /// with the sum of the elements pushed onto the stack.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestHExpand()
        {
            Stack<int> s = new();
            int inSum = PushMultiple(6, s);
            int outSum = SumAll(s);
            Assert.That(outSum, Is.EqualTo(inSum));
        }

        /// <summary>
        /// Tests whether two expansions preserve all elements.  The test is done by
        /// summing the elements as they are popped from the stack, and comparing
        /// with the sum of the elements pushed onto the stack.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestIDoubleExpand()
        {
            Stack<int> s = new();
            int inSum = PushMultiple(11, s);
            int outSum = SumAll(s);
            Assert.That(outSum, Is.EqualTo(inSum));
        }

        /// <summary>
        /// Tests that after expanding the array, a Clear resets the capacity to 5.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestJClearAfterExpand()
        {
            Stack<int> s = new();
            PushMultiple(6, s);
            s.Clear();
            Assert.That(s.Capacity, Is.EqualTo(5));
        }
    }
}
