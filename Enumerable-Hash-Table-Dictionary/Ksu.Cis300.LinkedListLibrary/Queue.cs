/* Queue.cs
 * Author: Josh Weese
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.LinkedListLibrary
{
    /// <summary>
    /// A generic queue implemented using a linked list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    public class Queue<T>
    {
        /// <summary>
        /// The element at the front of the queue if the queue is nonempty.
        /// </summary>
        private LinkedListCell<T>? _front;

        /// <summary>
        /// The element at the back of the queue if the queue is nonempty.
        /// </summary>
        private LinkedListCell<T>? _back;

        /// <summary>
        /// Gets the number of elements in the queue.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Places the given element at the back of the queue.
        /// </summary>
        /// <param name="x">The element to enqueue.</param>
        public void Enqueue(T x)
        {
            LinkedListCell<T> cell = new(x, null);
            if (Count == 0)
            {
                _front = cell;
            }
            else
            {
                // If Count is positive, _back will not be null.
                _back!.Next = cell;
            }
            _back = cell;
            Count++;
        }

        /// <summary>
        /// Gets the element at the front of the queue.
        /// </summary>
        /// <returns>The element at the front of the queue.</returns>
        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            // If Count is positive, _front will not be null.
            return _front!.Data;
        }

        /// <summary>
        /// Removes the element at the front of the queue.
        /// </summary>
        /// <returns>The element removed.</returns>
        public T Dequeue()
        {
            T x = Peek();

            // Peek makes sure _front isn't null.
            _front = _front!.Next;
            Count--;
            return x;
        }
    }
}
