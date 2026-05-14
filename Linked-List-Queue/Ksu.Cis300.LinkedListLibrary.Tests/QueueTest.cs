/* QueueTest.cs
 * Author: Josh Weese
 */
using System.Text;

namespace Ksu.Cis300.LinkedListLibrary.Tests
{
    /// <summary>
    /// A unit test class for the class Queue.
    /// </summary>
    [TestFixture]
    public class QueueTest
    {
        /// <summary>
        /// The lower-case English alphabet.
        /// </summary>
        private const string _alphabet = "abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// Enqueues onto the given queue n letters of the alphabet, starting with the one at location start.
        /// </summary>
        /// <param name="q">The queue.</param>
        /// <param name="start">The location in the alphabet of the first letter to enqueue.</param>
        /// <param name="n">The number of letters to enqueue.</param>
        private static void EnqueueMultiple(LinkedListLibrary.Queue<char> q, int start, int n)
        {
            for (int i = start; i < start + n; i++)
            {
                q.Enqueue(_alphabet[i]);
            }
        }

        /// <summary>
        /// Dequeues n chars from the given queue, and appends them to the given StringBuilder.
        /// </summary>
        /// <param name="q">The queue.</param>
        /// <param name="n">The number of elements to dequeue.</param>
        /// <param name="sb">The StringBuilder.</param>
        private static void DequeueMultiple(LinkedListLibrary.Queue<char> q, int n, StringBuilder sb)
        {
            for (int i = 0; i < n; i++)
            {
                sb.Append(q.Dequeue());
            }
        }

        /// <summary>
        /// Tests that Count is implemented as a property, not a field.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestACountIsProperty()
        {
            Type type = new LinkedListLibrary.Queue<char>().GetType();
            Assert.That(type.GetProperty("Count"), Is.Not.Null);
        }

        /// <summary>
        /// Tests that a Peek on an empty queue throws an InvalidOperationException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestAEmptyPeek()
        {
            LinkedListLibrary.Queue<int> q = new();
            Assert.That(() => q.Peek(), Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        /// Tests that a Dequeue on an empty stack throws an InvalidOperationException.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestBEmptyDequeue()
        {
            LinkedListLibrary.Queue<string> q = new();
            Assert.That(() => q.Dequeue(),Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        /// Tests whether the count is correctly updated after enqueueing twice.
        /// The count should be 2.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestCCountAfterEnqueue()
        {
            LinkedListLibrary.Queue<int> q = new();
            q.Enqueue(1);
            q.Enqueue(2);
            Assert.That(q, Has.Count.EqualTo(2));
        }

        /// <summary>
        /// Tests whether the count is correctly updated after enqueueing three times
        /// and dequeueing once.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDCountAfterDequeue()
        {
            LinkedListLibrary.Queue<char> q = new();
            EnqueueMultiple(q, 0, 3);
            q.Dequeue();
            Assert.That(q, Has.Count.EqualTo(2));
        }

        /// <summary>
        /// Tests whether Peek returns the correct value after three items are enqueued onto
        /// the queue.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDSimplePeek()
        {
            LinkedListLibrary.Queue<int> q = new();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            Assert.That(q.Peek(), Is.EqualTo(1));
        }

        /// <summary>
        /// Tests whether Dequeue returns the correct value after three items are enqueued onto
        /// the queue.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestDSimpleDequeue()
        {
            LinkedListLibrary.Queue<char> q = new();
            EnqueueMultiple(q, 0, 3);
            Assert.That(q.Dequeue(), Is.EqualTo('a'));
        }

        /// <summary>
        /// Tests the results of a sequence of 6 Enqueues followed by 6 Dequeues.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestEMultipleDequeue()
        {
            LinkedListLibrary.Queue<char> q = new();
            EnqueueMultiple(q, 0, 6);
            StringBuilder sb = new();
            DequeueMultiple(q, 6, sb);
            Assert.That(sb.ToString(), Is.EqualTo("abcdef"));
        }

        /// <summary>
        /// Tests the result of a sequence of 4 Enqueues, followed by 4 Dequeues, followed
        /// by 5 Enqueues, followed by 3 Dequeues, followed by 3 Enqueues, followed by 5 Dequeues.
        /// </summary>
        [Test, Timeout(1000)]
        public void TestFMultipleEnqueueDequeue()
        {
            LinkedListLibrary.Queue<char> q = new();
            EnqueueMultiple(q, 0, 4);
            StringBuilder sb = new();
            DequeueMultiple(q, 4, sb);
            EnqueueMultiple(q, 4, 5);
            DequeueMultiple(q, 3, sb);
            EnqueueMultiple(q, 9, 3);
            DequeueMultiple(q, 5, sb);
            Assert.That(sb.ToString(), Is.EqualTo(_alphabet.Substring(0, 12)));
        }
    }
}
