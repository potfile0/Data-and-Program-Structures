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
    public class Dictionary<TKey, TValue> where TKey: notnull, IComparable<TKey>
    {
        /// <summary>
        /// The keys and values of the dictionary, ordered by key. Includes a header cell whose
        /// Data.Key and/or Data.Value may be null.
        /// </summary>
        private LinkedListCell<KeyValuePair<TKey, TValue>> _elements = new(default, null);

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
        /// Finds the last cell in _elements whose key is less than the given key, assuming the
        /// header cell has a key less than any given key.
        /// </summary>
        /// <param name="key">The key to look for.</param>
        /// <returns>The last cell containing a key less than the given key.</returns>
        private LinkedListCell<KeyValuePair<TKey, TValue>> FindLastLessThan(TKey key)
        {
            LinkedListCell<KeyValuePair<TKey, TValue>> p = _elements;
            while (p.Next != null && p.Next.Data.Key.CompareTo(key) < 0)
            {
                p = p.Next;
            }
            return p;
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
            LinkedListCell<KeyValuePair<TKey, TValue>> p = FindLastLessThan(k);
            if (p.Next == null || !p.Next.Data.Key.Equals(k))
            {
                v = default;
                return false;
            }
            else
            {
                v = p.Next.Data.Value;
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
            LinkedListCell<KeyValuePair<TKey, TValue>> p = FindLastLessThan(k);
            if (p.Next == null || !p.Next.Data.Key.Equals(k))
            {
                LinkedListCell<KeyValuePair<TKey, TValue>> cell = 
                    new(new KeyValuePair<TKey, TValue>(k, v), p.Next);
                p.Next = cell;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
