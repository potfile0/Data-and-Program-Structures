/* Dictionary.cs
 * Author: Josh Weese
 */
using KansasStateUniversity.TreeViewer2;
using Ksu.Cis300.ImmutableBinaryTrees;

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
        private BinaryTreeNode<KeyValuePair<TKey, TValue>>? _elements = null;

        /// <summary>
        /// Gets a drawing of the underlying binary search tree.
        /// </summary>
        public TreeForm Drawing => new(_elements, 100);

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
        /// Finds the node in _elements containing the given key.
        /// </summary>
        /// <param name="key">The key to look for.</param>
        /// <param name="t">The tree in which to look.</param>
        /// <returns>The location containing the given key or null if the key does not exist.</returns>
        private static BinaryTreeNode<KeyValuePair<TKey, TValue>>? Find(TKey key, 
            BinaryTreeNode<KeyValuePair<TKey, TValue>>? t)
        {
            if (t == null)
            {
                return null;
            }
            else
            {
                int comp = key.CompareTo(t.Data.Key);
                if (comp == 0)
                {
                    return t;
                }
                else if (comp < 0)
                {
                    return Find(key, t.LeftChild);
                }
                else
                {
                    return Find(key, t.RightChild);
                }
            }
        }

        /// <summary>
        /// Builds the result of adding the given key and value to the given tree.
        /// If t already contains k, throws an ArgumentException.
        /// </summary>
        /// <param name="t">The tree to which to add.</param>
        /// <param name="k">The key to add.</param>
        /// <param name="v">The value associated with k.</param>
        /// <returns>The result of adding k and v to t.</returns>
        private static BinaryTreeNode<KeyValuePair<TKey, TValue>> Add(BinaryTreeNode<KeyValuePair<TKey, TValue>>? t, 
            TKey k, TValue v)
        {
            if (t == null)
            {
                return BinaryTreeNode<KeyValuePair<TKey, TValue>>.GetAvlTree(new KeyValuePair<TKey, TValue>(k, v),
                    null, null);
            }
            else
            {
                int comp = k.CompareTo(t.Data.Key);
                if (comp == 0)
                {
                    throw new ArgumentException();
                }
                else if (comp < 0)
                {
                    return BinaryTreeNode<KeyValuePair<TKey, TValue>>.GetAvlTree(t.Data, Add(t.LeftChild, k, v), t.RightChild);
                }
                else
                {
                    return BinaryTreeNode<KeyValuePair<TKey, TValue>>.GetAvlTree(t.Data, t.LeftChild, Add(t.RightChild, k, v));
                }
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
            BinaryTreeNode<KeyValuePair<TKey, TValue>>? p = Find(k, _elements);
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
            _elements = Add(_elements, k, v);
        }

        /// <summary>
        /// Builds a binary search tree containing all of the nodes in the given tree except the one
        /// containing the minimum key.
        /// </summary>
        /// <param name="t">A nonempty binary search tree.</param>
        /// <param name="min">The key-value pair with minimum key in t.</param>
        /// <returns>t without the node containing min.</returns>
        private static BinaryTreeNode<KeyValuePair<TKey, TValue>>?
            RemoveMininumKey(BinaryTreeNode<KeyValuePair<TKey, TValue>> t,
            out KeyValuePair<TKey, TValue> min)
        {
            if (t.LeftChild == null)
            {
                min = t.Data;
                return t.RightChild;
            }
            else
            {
                BinaryTreeNode<KeyValuePair<TKey, TValue>>? left = RemoveMininumKey(t.LeftChild, out min);
                return BinaryTreeNode<KeyValuePair<TKey, TValue>>.GetAvlTree(t.Data, left, t.RightChild);
            }
        }

        /// <summary>
        /// Builds the result of removing the given key from the given binary search tree.
        /// </summary>
        /// <param name="key">The key to remove.</param>
        /// <param name="t">The t from which the key is to be removed.</param>
        /// <param name="removed">Whether t contains the given key.</param>
        /// <returns>The result of removing the given key from t.</returns>
        private static BinaryTreeNode<KeyValuePair<TKey, TValue>>?
            Remove(TKey key, BinaryTreeNode<KeyValuePair<TKey, TValue>>? t, out bool removed)
        {
            if (t == null)
            {
                removed = false;
                return null;
            }
            else
            {
                int comp = key.CompareTo(t.Data.Key);
                if (comp == 0)
                {
                    removed = true;
                    if (t.LeftChild == null)
                    {
                        return t.RightChild;
                    }
                    else if (t.RightChild == null)
                    {
                        return t.LeftChild;
                    }
                    else
                    {
                        BinaryTreeNode<KeyValuePair<TKey, TValue>>? right = 
                            RemoveMininumKey(t.RightChild, out KeyValuePair<TKey, TValue> min);
                        return BinaryTreeNode<KeyValuePair<TKey, TValue>>.GetAvlTree(min, t.LeftChild, right);
                    }
                }
                else if (comp < 0)
                {
                    return BinaryTreeNode<KeyValuePair<TKey, TValue>>.GetAvlTree(t.Data, 
                        Remove(key, t.LeftChild, out removed), t.RightChild);
                }
                else
                {
                    return BinaryTreeNode<KeyValuePair<TKey, TValue>>.GetAvlTree(t.Data,
                        t.LeftChild, Remove(key, t.RightChild, out removed));
                }
            }
        }

        /// <summary>
        /// Removes the given key and its associated value from the dictionary.
        /// </summary>
        /// <param name="k">The key to remove.</param>
        /// <returns>Whether the key was found.</returns>
        public bool Remove(TKey k)
        {
            CheckKey(k);
            _elements = Remove(k, _elements, out bool removed);
            return removed;
        }

        /// <summary>
        /// Copies the contents of the given binary search tree to the end of the given list in
        /// order of the keys.
        /// </summary>
        /// <param name="t">The tree to copy.</param>
        /// <param name="list">The list to copy to.</param>
        private static void CopyTo(BinaryTreeNode<KeyValuePair<TKey, TValue>>? t,
            List<KeyValuePair<TKey, TValue>> list)
        {
            if (t != null)
            {
                CopyTo(t.LeftChild, list);
                list.Add(t.Data);
                CopyTo(t.RightChild, list);
            }
        }

        /// <summary>
        /// Copies the contents of the dictionary to the end of the given list in order of the keys.
        /// </summary>
        /// <param name="list">The list to copy to.</param>
        public void CopyTo(List<KeyValuePair<TKey, TValue>> list)
        {
            CopyTo(_elements, list);
        }
    }
}
