/* BinaryTreeNode.cs
 * Author: Josh Weese */
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
    /// An immutable generic binary tree node that can draw itself.
    /// </summary>
    /// <typeparam name="T">The type of the elements stored in the tree.</typeparam>
    public partial class BinaryTreeNode<T> : ITree
    {
        /// <summary>
        /// Gets the data stored in this node.
        /// </summary>
        public T? Data { get; }

        /// <summary>
        /// Gets this node's left child.
        /// </summary>
        public BinaryTreeNode<T>? LeftChild { get; }

        /// <summary>
        /// Gets this node's right child.
        /// </summary>
        public BinaryTreeNode<T>? RightChild { get; }

        /// <summary>
        /// Constructs a BinaryTreeNode with the given data, left child, and right child.
        /// </summary>
        /// <param name="data">The data stored in the node.</param>
        /// <param name="left">The left child.</param>
        /// <param name="right">The right child.</param>
        public BinaryTreeNode(T? data, BinaryTreeNode<T>? left, BinaryTreeNode<T>? right)
        {
            Data = data;
            LeftChild = left;
            RightChild = right;
        }
    }
}
