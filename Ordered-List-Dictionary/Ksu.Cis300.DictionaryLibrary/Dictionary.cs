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
        /// a list that holds the key value pair
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
        /// A method to find if the key exists in the list and if not
        /// it returns the index where the key should be placed
        /// </summary>
        /// <param name="key">they key to find</param>
        /// <returns>returns the key in form of integer</returns>
        private int Find(TKey key)
        {
            int start = 0;
            int end = _elements.Count;

            while (start < end)
            {
                int midPoint = (start + end) / 2;
                int comp = _elements[midPoint].Key.CompareTo(key);

                if (comp == 0)
                {
                    return midPoint;
                }
                else if(comp == 1){
                    end = midPoint;
                }
                else
                {
                    start = midPoint + 1;
                }
            }
            return start;

        }

        /// <summary>
        /// A method to check if the key exists in the list and if yes
        /// it returns a bool if the key is found and sets the value for that key
        /// else just sets the value of that key to default
        /// </summary>
        /// <param name="k">the key to look for</param>
        /// <param name="v">the value to set</param>
        /// <returns>return true if the key exists and value is set else false</returns>
        public bool TryGetValue(TKey k, out TValue? v)
        {
            CheckKey(k);
            int p = Find(k);

            if (p < _elements.Count && _elements[p].Key.CompareTo(k) == 0)
            {
                v = _elements[p].Value;
                return true;
            }

            v = default;
            return false;
        }

        /// <summary>
        /// A method to add the key value pair to the list
        /// </summary>
        /// <param name="k">the key to add</param>
        /// <param name="v">the value to add</param>
        /// <exception cref="ArgumentException">exception if the key alreay exists</exception>
        public void Add(TKey k, TValue v)
        {
            CheckKey(k);
            int p = Find(k);

            if (p < _elements.Count && _elements[p].Key.CompareTo(k) == 0)
            {
                throw new ArgumentException();
            }

            _elements.Insert(p, new KeyValuePair<TKey, TValue>(k, v));
        }
    }
}
