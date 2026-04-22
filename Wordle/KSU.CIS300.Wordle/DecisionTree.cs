using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSU.CIS300.Wordle
{


    public class DecisionTreeNode<T>
    {
        /// <summary>
        /// The value stored at this node (e.g., the optimal guess word)
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The label on the edge from this node's parent to this node
        /// (e.g., the pattern string such as "GYGXX" that caused the solver to reach this node)
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The child nodes of this node, each representing a possible pattern outcome
        /// </summary>
        public List<DecisionTreeNode<T>> Children { get; }

        /// <summary>
        /// Returns true if this node has no children, indicating a terminal state
        /// </summary>
        public bool IsLeaf => Children.Count == 0;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="label">label</param>
        public DecisionTreeNode(T value, string label = "")
        {
            Value = value;
            Label = label;
            Children = new List<DecisionTreeNode<T>>();
        }

        /// <summary>
        /// creates a new child node, adds it and returnas it
        /// </summary>
        /// <param name="value">value to store in new child node</param>
        /// <param name="label">pattern label for this child, defaults to empty string</param>
        /// <returns>newly created child node</returns>
        public DecisionTreeNode<T> AddChild(T value, string label = "")
        {
            DecisionTreeNode<T> child = new DecisionTreeNode<T>(value, label);
            Children.Add(child);
            return child;
        }

        /// <summary>
        /// Returns all node values in breadth-first order, visiting each level of the tree
        /// before descending to the next
        /// </summary>
        /// <returns>A list of values in breadth-first traversal order</returns>
        public List<T> GetAllValuesBreadthFirst()
        {
            List<T> nodes = new List<T>();
            Queue<DecisionTreeNode<T>> queue = new Queue<DecisionTreeNode<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                DecisionTreeNode<T> node = queue.Dequeue();
                nodes.Add(node.Value);

                foreach (DecisionTreeNode<T> child in node.Children)
                    queue.Enqueue(child);
            }
            return nodes;
        }
    }
}
