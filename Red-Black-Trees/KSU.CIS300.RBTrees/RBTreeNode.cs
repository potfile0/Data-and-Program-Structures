using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace KSU.CIS300.RBTrees
{
    /// <summary>
    /// Enum representing the color of a red-black tree node.
    /// </summary>
    public enum NodeColor
    {
        Red,
        Black
    }

    /// <summary>
    /// Represents a single node in a Red-Black Tree.
    /// </summary>
    public class RBTreeNode<T> : ITree where T : IComparable
    {
        /// <summary>
        /// stores the color of this node
        /// </summary>
        public NodeColor Color { get; set; }

        /// <summary>
        /// The left child of this node
        /// </summary>
        public RBTreeNode<T> LeftChild { get; set; }

        /// <summary>
        /// The right child of this node
        /// </summary>
        public RBTreeNode<T> RightChild { get; set; }

        /// <summary>
        /// The parent of this node, null if this node is the root
        /// </summary>
        public RBTreeNode<T> Parent { get; set; }

        /// <summary>
        /// The actual data stored in this node
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// returns this node as the root
        /// </summary>
        public object Root => this;

        /// <summary>
        /// returns left and right child as an array
        /// </summary>
        public ITree[] Children => new RBTreeNode<T>[] { LeftChild, RightChild };

        /// <summary>
        /// Returns true if this node has no data
        /// </summary>
        public bool IsEmpty => Data == null || Data.Equals(default(T));

        /// <summary>
        /// Constructor with data and children.
        /// </summary>
        public RBTreeNode(T data, RBTreeNode<T> left, RBTreeNode<T> right)
        {
            Data = data;
            LeftChild = left;
            RightChild = right;
        }

        /// <summary>
        /// Default constructor - creates a NIL node (Black).
        /// </summary>
        public RBTreeNode()
        {
            Color = NodeColor.Black;
        }

        /// <summary>
        /// Returns this node as a string in the format "Color: Data"
        /// </summary>
        /// <returns>A string representation of this node</returns>
        public override string ToString()
        {
            return $"{Color}: {Data}";
        }
    }
}
