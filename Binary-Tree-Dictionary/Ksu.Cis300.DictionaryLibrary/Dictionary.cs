/* Dictionary.cs
 * Author: Josh Weese
 */
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
        /// The keys and values of the dictionary, ordered by key.
        /// </summary>
        private List<KeyValuePair<TKey, TValue>> _elements = new();

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
        /// Finds the location in _elements containing the given key, or the location at which
        /// this key could be inserted if the key does not exist.
        /// </summary>
        /// <param name="key">The key to look for.</param>
        /// <returns>The location containing the given key or the location at which it could be
        /// inserted.</returns>
        private int Find(TKey key)
        {
            int start = 0;
            int end = _elements.Count;
            while (start < end)
            {
                int mid = (start + end) / 2;
                int comp = key.CompareTo(_elements[mid].Key);
                if (comp < 0)
                {
                    end = mid;
                }
                else if (comp == 0)
                {
                    return mid;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return start;
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
            int p = Find(k);
            if (p >= _elements.Count || !_elements[p].Key.Equals(k))
            {
                v = default;
                return false;
            }
            else
            {
                v = _elements[p].Value;
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
            int p = Find(k);
            if (p >= _elements.Count || !_elements[p].Key.Equals(k))
            {
                _elements.Insert(p, new KeyValuePair<TKey, TValue>(k, v));
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
