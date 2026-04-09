// Author: Josh Weese
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
