/* Stack.cs
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
    /// Queue made utilizing linked lists
    /// </summary>
    /// <typeparam name="T">A generic type</typeparam>
    public class Queue<T>
    {
        /// <summary>
        /// Keeping track of top
        /// </summary>
        private LinkedListCell<T>? _top;
        /// <summary>
        /// Keeping track of bottom
        /// </summary>
        public LinkedListCell<T>? _bottom;

        /// <summary>
        /// Count property to keep track of count of objects
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// A method Enqueue to add the object
        /// </summary>
        /// <param name="data">The data to add</param>
        public void Enqueue(T data)
        {
            LinkedListCell<T> cell = new LinkedListCell<T>(data, null);

            if (Count == 0)
            {
                _top = cell;
            }
            else
            {
                _bottom!.Next = cell;
            }

            _bottom = cell;
            Count++;

        }

        /// <summary>
        /// A method to Peek whats in the top of queue
        /// </summary>
        /// <returns>Returns the object at the top of the queue</returns>
        /// <exception cref="InvalidOperationException"> An exception when there is nothing to peek</exception>
        public T Peek()
        {
            if (_top == null)
            {
                throw new InvalidOperationException("Nothing to Peek");
            }
            return _top.Data;
        }

        /// <summary>
        /// A method to Dequeue an object from the queue
        /// </summary>
        /// <returns>returns the object at the top of the queue</returns>
        public T Dequeue()
        {
            
            T x = Peek();

            // The above call to Peek ensures that _top isn't null.
            _top = _top!.Next;
            Count--;
            return x;
        }
    }
}
