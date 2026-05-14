using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.PriorityQueueLibrary
{
    /// <summary>
    /// An immutable generic leftist tree node that can draw itself.
    /// </summary>
    /// <typeparam name="T">The type of the elements stored in the tree.</typeparam>
    public partial class LeftistTree<T> : ITree
    {
        /// <summary>
        /// Gets the data stored in this node.
        /// </summary>
        public T? Data { get; }

        /// <summary>
        /// Gets this node's left child.
        /// </summary>
        public LeftistTree<T>? LeftChild { get; }

        /// <summary>
        /// Gets this node's right child.
        /// </summary>
        public LeftistTree<T>? RightChild { get; }

        /// <summary>
        /// Stores the null path length of this node.
        /// </summary>
        private int _nullPathLength;

        /// <summary>
        /// Returns the null path length of the given tree.
        /// Returns 0 if the tree is null, otherwise returns its stored NPL.
        /// </summary>
        /// <param name="t">The tree to get the NPL of.</param>
        /// <returns>The null path length.</returns>
        public static int NullPathLength(LeftistTree<T>? t)
        {
            if (t == null)
            {
                return 0;
            }

            return t._nullPathLength;
        }

        /// <summary>
        /// Constructs a LeftistTree node with the given data and children,
        /// placing the child with the smaller NPL on the right.
        /// </summary>
        /// <param name="data">The data stored in the node.</param>
        /// <param name="left">One child subtree.</param>
        /// <param name="right">The other child subtree.</param>
        public LeftistTree(T? data, LeftistTree<T>? left, LeftistTree<T>? right)
        {
            Data = data;

            if (NullPathLength(left) >= NullPathLength(right))
            {
                LeftChild = left;
                RightChild = right;
            }
            else
            {
                LeftChild = right;
                RightChild = left;
            }

            _nullPathLength = 1 + NullPathLength(RightChild);
        }
    }
}
