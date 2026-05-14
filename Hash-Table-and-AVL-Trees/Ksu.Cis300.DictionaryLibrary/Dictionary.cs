/* Dictionary.cs
 * Author: Josh Weese
 */
using Ksu.Cis300.LinkedListLibrary;
using static System.Net.Mime.MediaTypeNames;

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
        /// mutable hash table size
        /// </summary>
        private const int _hashTableSize = 23;

        /// <summary>
        /// bitmask to get the postive value
        /// </summary>
        private const int _bitMask = 0x7fffffff;

        /// <summary>
        /// array of linkedlistcell  
        /// </summary>
        private LinkedListCell<KeyValuePair<TKey, TValue>>?[] _elements = new LinkedListCell<KeyValuePair<TKey, TValue>>[_hashTableSize];

        /// <summary>
        /// method to get location of the key
        /// </summary>
        /// <param name="k">key</param>
        /// <returns>return the location for the array</returns>
        private int GetLocation(TKey k)
        {
            int hash = k.GetHashCode() & _bitMask;
            int hashToBeReturned = hash % _hashTableSize;
            return hashToBeReturned;
        }

        /// <summary>
        /// find and return the cell with the given key in the given linked list
        /// </summary>
        /// <param name="k">given key</param>
        /// <param name="list">given linked list</param>
        /// <returns>returns the cell</returns>
        private static LinkedListCell<KeyValuePair<TKey, TValue>>? 
          GetCell(TKey k, LinkedListCell<KeyValuePair<TKey, TValue>>? list)
        {
            while (list != null)
            {
                if (k.Equals(list.Data.Key))
                {
                    return list;
                }
                list = list.Next; 
            }
            return null;
        }

        /// <summary>
        /// insert the given cell into the beginning of the linked list at the given location of the table
        /// </summary>
        /// <param name="cell"> given cell to insert</param>
        /// <param name="loc">given location</param>
        private void Insert
            (LinkedListCell<KeyValuePair<TKey, TValue>> cell, int loc)
        {
            cell.Next = _elements[loc];
            _elements[loc] = cell;
        }

        /// <summary>
        ///  insert the given key and value into the beginning of the linked list at the given location of the table
        /// </summary>
        /// <param name="k">key</param>
        /// <param name="v">value</param>
        /// <param name="loc">location</param>
        private void Insert(TKey k, TValue v, int loc)
        {
            LinkedListCell<KeyValuePair<TKey, TValue>> cell =
    new LinkedListCell<KeyValuePair<TKey, TValue>>(
        new KeyValuePair<TKey, TValue>(k, v), null);

            Insert(cell, loc);

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
        /// a method to get value for the key
        /// </summary>
        /// <param name="k">key</param>
        /// <param name="v">value</param>
        /// <returns>returns a bool</returns>

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

                LinkedListCell<KeyValuePair<TKey, TValue>>? existing =
                    GetCell(k, _elements[loc]);

            if (existing != null)
            {
                throw new ArgumentException("Duplicate key");
            }
            else
            {


                Insert(k, v, loc);
            }
        }

    }
}
