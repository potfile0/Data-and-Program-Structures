/* Dictionary.cs
 * Author: Josh Weese
 */
using KansasStateUniversity.TreeViewer2;
using Ksu.Cis300.ImmutableBinaryTrees;
namespace Ksu.Cis300.DictionaryLibrary
{
    /// <summary>
    /// An implementation of a dictionary using a binary search tree.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys.</typeparam>
    /// <typeparam name="TValue">The type of the values.</typeparam>
    public class Dictionary<TKey, TValue> where TKey: notnull, IComparable<TKey>
    {
        /// <summary>
        /// A binary tree node name _elements that consists of a key value pair
        /// </summary>
        private BinaryTreeNode<KeyValuePair<TKey, TValue>>? _elements = null;

        /// <summary>
        /// Gets a drawing of the underlying binary search tree.
        /// </summary>
        public TreeForm Drawing => new(_elements, 100);

        /// <summary>
        /// A method to check if the given key is null
        /// </summary>
        /// <param name="key">the givne key to check for</param>
        /// <exception cref="ArgumentNullException">the exception to throw if the key is null</exception>
        private static void CheckKey(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// A method find to find the node containing the given key and to return that node
        /// </summary>
        /// <param name="key">the key to check for</param>
        /// <param name="node">the node to check in</param>
        /// <returns>returns the node where the key is found</returns>
        private static BinaryTreeNode<KeyValuePair<TKey, TValue>>? Find(TKey key,BinaryTreeNode<KeyValuePair<TKey, TValue>>? node)
        {
            if (node == null)
            {
                return null;
            }

            int comparison = key.CompareTo(node.Data.Key);

            if (comparison == 0)
            {
                return node;
            }
            else if (comparison < 0)
            {
                return Find(key, node.LeftChild);
            }
            else
            {
                return Find(key, node.RightChild);
            }
        }

        /// <summary>
        /// A method to add a key value pair to node and return the  result of adding the given key and value to the given binary search tree
        /// </summary>
        /// <param name="t">the node we are processing</param>
        /// <param name="k">the key to add</param>
        /// <param name="v">the value respective to that key</param>
        /// <returns>returns the node with added key value parir</returns>
        /// <exception cref="ArgumentException"></exception>
        private static BinaryTreeNode<KeyValuePair<TKey, TValue>> Add(BinaryTreeNode<KeyValuePair<TKey, TValue>>? t,TKey k,TValue v)
        {
            if (t == null)
            {
                return new BinaryTreeNode<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(k, v),null,null);
            }

            int comparison = k.CompareTo(t.Data.Key);

            if (comparison == 0)
            {
                throw new ArgumentException();
            }
            else if (comparison < 0)
            {
                return new BinaryTreeNode<KeyValuePair<TKey, TValue>>(
                    t.Data,
                    Add(t.LeftChild, k, v),
                    t.RightChild);
            }
            else
            {
                return new BinaryTreeNode<KeyValuePair<TKey, TValue>>(
                    t.Data,
                    t.LeftChild,
                    Add(t.RightChild, k, v));
            }
        }

        /// <summary>
        /// method to look up the given key in the binary search tree field using the Find method above
        /// </summary>
        /// <param name="k">the key to lookup</param>
        /// <param name="v">the value to set</param>
        /// <returns>returns true if we can set the value and false if we cannot</returns>
        public bool TryGetValue(TKey k, out TValue? v)
        {
            CheckKey(k);

            var node = Find(k, _elements);

            if (node == null)
            {
                v = default;
                return false;
            }
            else
            {
                v = node.Data.Value;
                return true;
            }
        }

        /// <summary>
        /// method to add the given key and value to the binary search tree using the private static Add method
        /// </summary>
        /// <param name="k">the key to add</param>
        /// <param name="v">the value to add</param>
        public void Add(TKey k, TValue v)
        {
            CheckKey(k);

            _elements = Add(_elements, k, v);
        }
    }
}
