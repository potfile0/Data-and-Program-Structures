using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.PriorityQueueLibrary
{
    public class MinPriorityQueue<TPriority, TValue> where TPriority : notnull, IComparable<TPriority>
    {
        /// <summary>
        /// A leftist heap storing the elements and their priorities.
        /// </summary>
        private LeftistTree<KeyValuePair<TPriority, TValue>>? _elements = null;

        /// <summary>
        /// Gets the number of elements.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets the minimum priority in the queue.
        /// Throws InvalidOperationException if the queue is empty.
        /// </summary>
        public TPriority MinPriority
        {
            get
            {
                if (_elements == null)
                {
                    throw new InvalidOperationException("The priority queue is empty.");
                }
                return _elements.Data!.Key;
            }
        }

        /// <summary>
        /// Adds the given element with the given priority.
        /// </summary>
        /// <param name="p">The priority of the element.</param>
        /// <param name="x">The element to add.</param>
        public void Add(TPriority p, TValue x)
        {
            LeftistTree<KeyValuePair<TPriority, TValue>> node =
                new(new KeyValuePair<TPriority, TValue>(p, x), null, null);
            _elements = Merge(_elements, node);
            Count++;
        }

        /// <summary>
        /// Removes and returns the element with the minimum priority.
        /// Throws InvalidOperationException if the queue is empty.
        /// </summary>
        /// <returns>The element with the minimum priority.</returns>
        public TValue RemoveMinPriorityElement()
        {
            if (_elements == null)
            {
                throw new InvalidOperationException("The priority queue is empty.");
            }

            TValue minValue = _elements.Data!.Value;
            _elements = Merge(_elements.LeftChild, _elements.RightChild);
            Count--;
            return minValue;
        }

        /// <summary>
        /// Merges the given leftist heaps into one leftist heap.
        /// </summary>
        /// <param name="h1">One of the leftist heaps to merge.</param>
        /// <param name="h2">The other leftist heap to merge.</param>
        /// <returns>The resulting leftist heap.</returns>
        public static LeftistTree<KeyValuePair<TPriority, TValue>>? Merge(LeftistTree<KeyValuePair<TPriority, TValue>>? h1, LeftistTree<KeyValuePair<TPriority, TValue>>? h2)
        {
            if (h1 == null)
            {
                return h2;
            }
            if (h2 == null)
            {
                return h1;
            }

            if (h1.Data!.Key.CompareTo(h2.Data!.Key) <= 0)
            {
                LeftistTree<KeyValuePair<TPriority, TValue>>? mergedRight =
                    Merge(h1.RightChild, h2);
                return new LeftistTree<KeyValuePair<TPriority, TValue>>(
                    h1.Data, h1.LeftChild, mergedRight);
            }
            else
            {
                LeftistTree<KeyValuePair<TPriority, TValue>>? mergedRight =
                    Merge(h1, h2.RightChild);
                return new LeftistTree<KeyValuePair<TPriority, TValue>>(
                    h2.Data, h2.LeftChild, mergedRight);
            }
        }

    }
}
