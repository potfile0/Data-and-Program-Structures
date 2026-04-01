using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace KSU.CIS300.RBTrees
{
    /// <summary>
    /// Represents a Red-Black Tree.
    /// </summary>
    public class RBTree<T> : ITree where T : IComparable, IComparable<T>
    {
        /// <summary>
        /// NIL to represent the children of all leaves of the tree
        /// </summary>
        public static readonly RBTreeNode<T> NIL = new RBTreeNode<T>();

        /// <summary>
        /// Holds the top node of the tree
        /// </summary>
        public RBTreeNode<T> Root { get; private set; }

        /// <summary>
        /// returns root
        /// </summary>
        object ITree.Root => Root;

        /// <summary>
        /// passes down to the root's children
        /// </summary>
        public ITree[] Children => Root.Children;

        /// <summary>
        /// Tree is empty if there is no root yet
        /// </summary>
        public bool IsEmpty => Root == null;

        /// <summary>
        /// Finds the smallest node in the given subtree
        /// </summary>
        /// <param name="node">The node to start searching from</param>
        /// <returns>The smallest node in the subtree</returns>
        public RBTreeNode<T> FindMin(RBTreeNode<T> node)
        {
            while (node.LeftChild != NIL)
                node = node.LeftChild;
            return node;
        }

        /// <summary>
        /// Searches the tree for the given data and returns the node if found
        /// </summary>
        /// <param name="search">The data to search for</param>
        /// <param name="result">The node that contains the data, null if not found</param>
        /// <returns>True if the data was found, false if not</returns>
        private bool Find(T search, out RBTreeNode<T> result)
        {
            RBTreeNode<T> current = Root;
            while (current != NIL)
            {
                int cmp = search.CompareTo(current.Data);
                if (cmp == 0) { result = current; return true; }
                else if (cmp < 0) current = current.LeftChild;
                else current = current.RightChild;
            }
            result = null;
            return false;
        }

        /// <summary>
        /// Searches the tree for the given data and returns the data itself if found
        /// </summary>
        /// <param name="search">The data we are looking for</param>
        /// <param name="result">The actual data stored in the tree, default if not found</param>
        /// <returns>True if the data was found, false if not</returns>
        public bool Find(T search, out T result)
        {
            if (Root == null) { result = default; return false; }
            if (Find(search, out RBTreeNode<T> node))
            {
                result = node.Data;
                return true;
            }
            result = default;
            return false;
        }

        /// <summary>
        /// Rotates the pivot node to the left, C moves up and takes pivot's spot
        /// </summary>
        /// <param name="pivot">The node to rotate left on</param>
        public void RotateLeft(RBTreeNode<T> pivot)
        {
            RBTreeNode<T> c = pivot.RightChild;
            pivot.RightChild = c.LeftChild;

            if (c.LeftChild != NIL)
                c.LeftChild.Parent = pivot;

            c.Parent = pivot.Parent;

            if (pivot.Parent == null)
                Root = c;
            else if (pivot == pivot.Parent.LeftChild)
                pivot.Parent.LeftChild = c;
            else
                pivot.Parent.RightChild = c;

            c.LeftChild = pivot;
            pivot.Parent = c;
        }

        /// <summary>
        /// Rotates the pivot node to the right, B moves up and takes pivot's spot
        /// </summary>
        /// <param name="pivot">The node to rotate right on</param>
        public void RotateRight(RBTreeNode<T> pivot)
        {
            RBTreeNode<T> b = pivot.LeftChild;
            pivot.LeftChild = b.RightChild;

            if (b.RightChild != NIL)
                b.RightChild.Parent = pivot;

            b.Parent = pivot.Parent;

            if (pivot.Parent == null)
                Root = b;
            else if (pivot == pivot.Parent.RightChild)
                pivot.Parent.RightChild = b;
            else
                pivot.Parent.LeftChild = b;

            b.RightChild = pivot;
            pivot.Parent = b;
        }

        /// <summary>
        /// Inserts new data into the tree, throws an exception if the data already exists
        /// </summary>
        /// <param name="data">The data to insert into the tree</param>
        /// <exception cref="InvalidOperationException">Thrown if the data already exists in the tree</exception>
        public void Insert(T data)
        {
            if (Root == null)
            {
                Root = new RBTreeNode<T>(data, NIL, NIL);
                Root.Color = NodeColor.Black;
                return;
            }
            if (Root.Data.CompareTo(data) == 0)
                throw new InvalidOperationException();

            Insert(new RBTreeNode<T>(data, NIL, NIL));
        }

        /// <summary>
        /// Finds the correct spot for the new node and inserts it, then fixes any RB violations
        /// </summary>
        /// <param name="newNode">The new node to be inserted into the tree</param>
        /// <exception cref="InvalidOperationException">Thrown if the data already exists in the tree</exception>
        private void Insert(RBTreeNode<T> newNode)
        {
            RBTreeNode<T> current = Root;
            while (true)
            {
                int cmp = newNode.Data.CompareTo(current.Data);
                if (cmp == 0)
                {
                    throw new InvalidOperationException();
                }
                else if (cmp < 0)
                {
                    if (current.LeftChild == NIL)
                    {
                        current.LeftChild = newNode;
                        newNode.Parent = current;
                        break;
                    }
                    current = current.LeftChild;
                }
                else
                {
                    if (current.RightChild == NIL)
                    {
                        current.RightChild = newNode;
                        newNode.Parent = current;
                        break;
                    }
                    current = current.RightChild;
                }
            }
            newNode.Color = NodeColor.Red;
            FixInsert(newNode);
        }

        /// <summary>
        /// Fixes any red-red violations that happened after inserting a node using recoloring and rotations
        /// </summary>
        /// <param name="node">The newly inserted node to start fixing from</param>
        private void FixInsert(RBTreeNode<T> node)
        {
            while (node != Root && node.Parent.Color == NodeColor.Red)
            {
                if (node.Parent == node.Parent.Parent.LeftChild)
                {
                    RBTreeNode<T> uncle = node.Parent.Parent.RightChild;
                    if (uncle != NIL && uncle.Color == NodeColor.Red)
                    {
                        node.Parent.Color = NodeColor.Black;
                        uncle.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.RightChild)
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }
                        node.Parent.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        RotateRight(node.Parent.Parent);
                    }
                }
                else
                {
                    RBTreeNode<T> uncle = node.Parent.Parent.LeftChild;
                    if (uncle != NIL && uncle.Color == NodeColor.Red)
                    {
                        node.Parent.Color = NodeColor.Black;
                        uncle.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.LeftChild)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }
                        node.Parent.Color = NodeColor.Black;
                        node.Parent.Parent.Color = NodeColor.Red;
                        RotateLeft(node.Parent.Parent);
                    }
                }
            }
            Root.Color = NodeColor.Black;
        }

        /// <summary>
        /// Swaps node a out for node b and updates the parent pointer accordingly
        /// </summary>
        /// <param name="a">The node being removed from its spot</param>
        /// <param name="b">The node taking a's spot</param>
        private void Replace(RBTreeNode<T> a, RBTreeNode<T> b)
        {
            if (a.Parent == null)
                Root = b;
            else if (a == a.Parent.LeftChild)
                a.Parent.LeftChild = b;
            else
                a.Parent.RightChild = b;

            b.Parent = a.Parent;
        }

        /// <summary>
        /// Removes the node that matches the given item from the tree and fixes any RB violations after
        /// </summary>
        /// <param name="item">The data we want to remove from the tree</param>
        /// <returns>True if the item was found and removed, false if it was not in the tree</returns>
        public bool Remove(T item)
        {
            if (!Find(item, out RBTreeNode<T> r))
                return false;

            NodeColor oldColor = r.Color;
            RBTreeNode<T> fix;

            if (r.LeftChild == NIL)
            {
                fix = r.RightChild;
                Replace(r, r.RightChild);
            }
            else if (r.RightChild == NIL)
            {
                fix = r.LeftChild;
                Replace(r, r.LeftChild);
            }
            else
            {
                RBTreeNode<T> successor = FindMin(r.RightChild);
                oldColor = successor.Color;
                fix = successor.RightChild;

                if (successor.Parent == r)
                    fix.Parent = successor;
                else
                {
                    Replace(successor, successor.RightChild);
                    successor.RightChild = r.RightChild;
                    successor.RightChild.Parent = successor;
                }

                Replace(r, successor);
                successor.LeftChild = r.LeftChild;
                successor.LeftChild.Parent = successor;
                successor.Color = r.Color;
            }

            if (oldColor == NodeColor.Black)
                FixDelete(fix);

            return true;
        }

        /// <summary>
        /// Fixes any black-height violations that happened after removing a black node using recoloring and rotations
        /// </summary>
        /// <param name="current">The node that moved into the removed node's spot</param>
        private void FixDelete(RBTreeNode<T> current)
        {
            while (current != Root && current.Color == NodeColor.Black)
            {
                if (current == current.Parent.LeftChild)
                {
                    RBTreeNode<T> sibling = current.Parent.RightChild;

                    if (sibling.Color == NodeColor.Red)
                    {
                        sibling.Color = NodeColor.Black;
                        current.Parent.Color = NodeColor.Red;
                        RotateLeft(current.Parent);
                        sibling = current.Parent.RightChild;
                    }

                    if (sibling.LeftChild.Color == NodeColor.Black &&
                        sibling.RightChild.Color == NodeColor.Black)
                    {
                        sibling.Color = NodeColor.Red;
                        current = current.Parent;
                    }
                    else
                    {
                        if (sibling.RightChild.Color == NodeColor.Black)
                        {
                            sibling.LeftChild.Color = NodeColor.Black;
                            sibling.Color = NodeColor.Red;
                            RotateRight(sibling);
                            sibling = current.Parent.RightChild;
                        }
                        sibling.Color = current.Parent.Color;
                        current.Parent.Color = NodeColor.Black;
                        sibling.RightChild.Color = NodeColor.Black;
                        RotateLeft(current.Parent);
                        current = Root;
                    }
                }
                else
                {
                    RBTreeNode<T> sibling = current.Parent.LeftChild;

                    if (sibling.Color == NodeColor.Red)
                    {
                        sibling.Color = NodeColor.Black;
                        current.Parent.Color = NodeColor.Red;
                        RotateRight(current.Parent);
                        sibling = current.Parent.LeftChild;
                    }

                    if (sibling.RightChild.Color == NodeColor.Black &&
                        sibling.LeftChild.Color == NodeColor.Black)
                    {
                        sibling.Color = NodeColor.Red;
                        current = current.Parent;
                    }
                    else
                    {
                        if (sibling.LeftChild.Color == NodeColor.Black)
                        {
                            sibling.RightChild.Color = NodeColor.Black;
                            sibling.Color = NodeColor.Red;
                            RotateLeft(sibling);
                            sibling = current.Parent.LeftChild;
                        }
                        sibling.Color = current.Parent.Color;
                        current.Parent.Color = NodeColor.Black;
                        sibling.LeftChild.Color = NodeColor.Black;
                        RotateRight(current.Parent);
                        current = Root;
                    }
                }
            }
            current.Color = NodeColor.Black;
        }
    }
}
