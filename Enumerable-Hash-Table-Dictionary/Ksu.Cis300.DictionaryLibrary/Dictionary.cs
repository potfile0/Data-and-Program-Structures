/* Dictionary.cs
 * Author: Josh Weese
 */
using Ksu.Cis300.LinkedListLibrary;
using System.Runtime.ConstrainedExecution;
using System.Collections;

namespace Ksu.Cis300.DictionaryLibrary
{
    /// <summary>
    /// An implementation of a dictionary using an ordered linked list.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys.</typeparam>
    /// <typeparam name="TValue">The type of the values.</typeparam>
    public class Dictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
        where TKey : notnull
    {
        /// <summary>
        /// The initial size of the hash table.
        /// </summary>
        private const int _initialTableSize = 5;

        /// <summary>
        /// The mask to use when stripping the sign bit.
        /// </summary>
        private const int _nonnegativeMask = 0x7fffffff;

        /// <summary>
        /// The keys and values of the dictionary, ordered by key.
        /// </summary>
        private LinkedListCell<KeyValuePair<TKey, TValue>>?[] _elements = 
            new LinkedListCell<KeyValuePair<TKey, TValue>>[_initialTableSize];

        /// <summary>
        /// The allowable sizes for the hash table.
        /// </summary>
        private int[] _tableSizes =
        {
            _initialTableSize, 11, 23, 47, 97, 197, 397, 797, 1597, 3203, 6421, 12853, 25717,
            51437, 102877, 205759, 411527, 823117, 1646237, 3292489, 6584983,
            13169977, 26339969, 52679969, 105359939, 210719881, 421439783,
            842879579, 1685759167
        };

        /// <summary>
        /// The index in _tableSizes of the current hash table size.
        /// </summary>
        private int _sizeIndex = 0;

        /// <summary>
        /// The number of pairs of keys and values in the dictionary.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Gets or sets the value associated with the given key
        /// </summary>
        /// <param name="k">The key to look up or set</param>
        /// <returns>The value associated with k</returns>
        public TValue this[TKey k]
        {
            get
            {
                if (TryGetValue(k, out TValue? v))
                {
                    return v!;
                }
                throw new KeyNotFoundException();
            }
            set
            {
                CheckKey(k);
                int loc = GetLocation(k);
                LinkedListCell<KeyValuePair<TKey, TValue>>? p = GetCell(k, _elements[loc]);
                if (p == null)
                {
                    Insert(k, value, loc);
                }
                else
                {
                    p.Data = new KeyValuePair<TKey, TValue>(k, value);
                }
            }
        }

        /// <summary>
        /// Gets an IEnumerable for the keys in the dictionary.
        /// </summary>
        public IEnumerable<TKey> Keys
        {
            get
            {
                foreach (KeyValuePair<TKey, TValue> pair in this)
                {
                    yield return pair.Key;
                }
            }
        }

        /// <summary>
        /// Gets an IEnumerable for the values in the dictionary.
        /// </summary>
        public IEnumerable<TValue> Values
        {
            get
            {
                foreach (KeyValuePair<TKey, TValue> pair in this)
                {
                    yield return pair.Value;
                }
            }
        }

        /// <summary>
        /// Checks that the given key is not null.
        /// </summary>
        /// <param name="key">The key to check.</param>
        private static void CheckKey(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
        }
        
        /// <summary>
        /// Gets the value associated with the given key.
        /// </summary>
        /// <param name="k">The key to look up.</param>
        /// <param name="v">The value associated with k, or the default value if k is not found.</param>
        /// <returns>Whether k was found.</returns>
        public bool TryGetValue(TKey k, out TValue? v)
        {
            CheckKey(k);
            int loc = GetLocation(k);
            LinkedListCell<KeyValuePair<TKey, TValue>>? p = GetCell(k, _elements[loc]);
            if (p == null)
            {
                v = default;
                return false;
            }
            else
            {
                v = p.Data.Value;
                return true;
            }
        }

        /// <summary>
        /// Adds the given key and value to the dictionary.
        /// </summary>
        /// <param name="k">The key.</param>
        /// <param name="v">The value to be associated with k.</param>
        public void Add(TKey k, TValue v)
        {
            CheckKey(k);
            int loc = GetLocation(k);
            LinkedListCell<KeyValuePair<TKey, TValue>>? p = GetCell(k, _elements[loc]);
            if (p == null)
            {
                Insert(k, v, loc);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Gets the table location in which the given key belongs.
        /// </summary>
        /// <param name="k">The key.</param>
        /// <returns>The table location for k.</returns>
        private int GetLocation(TKey k)
        {
            return (k.GetHashCode() & _nonnegativeMask) % _elements.Length;
        }

        /// <summary>
        /// Gets the cell in containing the given key in the given list, or null if the list
        /// contains no such cell.
        /// </summary>
        /// <param name="k">The key to look for.</param>
        /// <param name="list">The list to look in.</param>
        /// <returns>The cell in list having key k, or null if no such cell exists.</returns>
        private static LinkedListCell<KeyValuePair<TKey, TValue>>? GetCell(TKey k, 
            LinkedListCell<KeyValuePair<TKey, TValue>>? list)
        {
            while (list != null)
            {
                if (list.Data.Key.Equals(k))
                {
                    return list;
                }
                list = list.Next;
            }
            return null;
        }

        /// <summary>
        /// Inserts the given cell into the beginning of the list at the given table location.
        /// </summary>
        /// <param name="cell">The cell to insert.</param>
        /// <param name="loc">The table location in which to insert the cell.</param>
        private void Insert(LinkedListCell<KeyValuePair<TKey, TValue>> cell, int loc)
        {
            cell.Next = _elements[loc];
            _elements[loc] = cell;
        }

        /// <summary>
        /// Inserts a cell containing the given key and value into the list at the given table
        /// location.
        /// </summary>
        /// <param name="k">The key.</param>
        /// <param name="v">The value.</param>
        /// <param name="loc">The table location in which to insert.</param>
        private void Insert(TKey k, TValue v, int loc)
        {
            KeyValuePair<TKey, TValue> p = new(k, v);
            LinkedListCell<KeyValuePair<TKey, TValue>> cell = new(p, null);
            Insert(cell, loc);
            Count++;
            if (Count > _elements.Length && _sizeIndex < _tableSizes.Length - 1)
            {
                LinkedListCell<KeyValuePair<TKey, TValue>>?[] old = _elements;
                _sizeIndex++;
                _elements = new LinkedListCell<KeyValuePair<TKey, TValue>>?[_tableSizes[_sizeIndex]];
                foreach(LinkedListCell<KeyValuePair<TKey, TValue>>? list in old)
                {
                    LinkedListCell<KeyValuePair<TKey, TValue>>? cur = list;
                    while (cur != null)
                    {
                        LinkedListCell<KeyValuePair<TKey, TValue>> toMove = cur;
                        cur = cur.Next;
                        Insert(toMove, GetLocation(toMove.Data.Key));
                    }
                }
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through all key value pairs
        /// </summary>
        /// <returns>An enumerator for the dictionary</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (LinkedListCell<KeyValuePair<TKey, TValue>>? list in _elements)
            {
                LinkedListCell<KeyValuePair<TKey, TValue>>? current = list;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }

        /// <summary>
        /// Returns a non generic enumerator
        /// </summary>
        /// <returns>A non generic enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
