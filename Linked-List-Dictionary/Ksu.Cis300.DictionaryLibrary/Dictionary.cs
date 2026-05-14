using Ksu.Cis300.LinkedListLibrary;
using System.ComponentModel;

namespace Ksu.Cis300.DictionaryLibrary
{
    /// <summary>
    /// A class Dictionary that uses a linked list to store sorted key value pairs
    /// </summary>
    /// <typeparam name="TKey">The key for the Dictionary</typeparam>
    /// <typeparam name="TValue">The value pair for the dictionary</typeparam>
    public class Dictionary<TKey, TValue> where TKey : notnull, IComparable<TKey>
    {

        /// <summary>
        /// A private field of type LinkedListCell that represents the head of the linked list.
        /// </summary>
        private LinkedListCell<KeyValuePair<TKey, TValue>> _head = new LinkedListCell<KeyValuePair<TKey, TValue>>(default, null);

        /// <summary>
        /// A method to check wether the key is null or not
        /// if it is null, throw an ArgumentNullException
        /// </summary>
        /// <param name="key"> The key provided to check if it is null</param>
        /// <exception cref="ArgumentNullException">the argument exception</exception>
        private static void CheckWetherNull(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
        }

        /// <summary>
        /// A method that returns the last cell in the linked list whose key is less than the given key.
        /// </summary>
        /// <param name="key">the given key to compare to the linked list of which the cell is to be returned</param>
        /// <returns>returns the last cell in above list whose key is less than the given key</returns>
        private LinkedListCell<KeyValuePair<TKey,TValue>> LastCell(TKey key)
        {
            LinkedListCell<KeyValuePair<TKey, TValue>> current = _head;
            while (current.Next != null && current.Next.Data.Key.CompareTo(key) < 0)
            {
                current = current.Next;
            }
            return current;
        }

        /// <summary>
        /// A method that tries to get the value associated with the given key. 
        /// If the key is found, it returns true and sets the out parameter to the value. 
        /// If the key is not found, it returns false and sets the out parameter to default.
        /// </summary>
        /// <param name="k">The given key to compare</param>
        /// <param name="v">The out value</param>
        /// <returns>return ture if the next cell is non null and contains the given key, else false</returns>
        public bool TryGetValue(TKey k, out TValue? v)
        {
            CheckWetherNull(k);
            LinkedListCell<KeyValuePair<TKey, TValue>> cell = LastCell(k);
            if (cell.Next != null &&
                cell.Next.Data.Key.CompareTo(k) == 0)
            {
                v = cell.Next.Data.Value;
                return true;
            }

            v = default;
            return false;
        }

        /// <summary>
        /// A method that adds a new key value pair to the dictionary.
        /// </summary>
        /// <param name="k">The given key to add</param>
        /// <param name="v">The given value to add</param>
        /// <exception cref="ArgumentException">exception</exception>
        public void Add(TKey k, TValue v)
        {
            CheckWetherNull(k);
            LinkedListCell<KeyValuePair<TKey, TValue>> cell = LastCell(k);
            if (cell.Next != null &&
                cell.Next.Data.Key.CompareTo(k) == 0)
            {
                throw new ArgumentException();
            }
            else
            {
                LinkedListCell<KeyValuePair<TKey, TValue>> newCell = new LinkedListCell<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(k, v), cell.Next);
                cell.Next = newCell;
            }
        }
    }
}
