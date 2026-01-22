/* Dictionary.cs
 * Author: Josh Weese
 */
using Ksu.Cis300.LinkedListLibrary;

namespace Ksu.Cis300.DictionaryLibrary
{
    /// <summary>
    /// An implementation of a dictionary using an ordered linked list.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys.</typeparam>
    /// <typeparam name="TValue">The type of the values.</typeparam>
    public class Dictionary<TKey, TValue> where TKey: notnull
    {
        /// <summary>
        /// The size of the hash table.
        /// </summary>
        private const int _tableSize = 23;

        /// <summary>
        /// The mask to use when stripping the sign bit.
        /// </summary>
        private const int _nonnegativeMask = 0x7fffffff;

        /// <summary>
        /// The keys and values of the dictionary, ordered by key.
        /// </summary>
        private LinkedListCell<KeyValuePair<TKey, TValue>>?[] _elements = 
            new LinkedListCell<KeyValuePair<TKey, TValue>>[_tableSize];

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
        }
    }
}
