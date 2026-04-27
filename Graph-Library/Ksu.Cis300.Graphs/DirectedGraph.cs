using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ksu.Cis300.LinkedListLibrary;

namespace Ksu.Cis300.Graphs
{
    /// <summary>
    /// Implement a directed graph
    /// </summary>
    /// <typeparam name="TNode"> node </typeparam>
    /// <typeparam name="TEdgeData"> edgedata </typeparam>
    public class DirectedGraph<TNode, TEdgeData> where TNode : notnull
    {
       /// <summary>
       /// dictionary to store the adjacency list for each node
       /// </summary>
        private Dictionary<TNode, LinkedListCell<TNode>?> _adjacencyLists = new();

       /// <summary>
       /// dictionary to store the value associated with each edge
       /// </summary>
        private Dictionary<(TNode, TNode), TEdgeData> _edges = new();

        /// <summary>
        ///  public property Nodes to get an IEnumerable<TNode> containing the nodes in the graph
        /// </summary>
        public IEnumerable<TNode> Nodes => _adjacencyLists.Keys;

        /// <summary>
        /// to get the number of nodes
        /// </summary>
        public int NodeCount => _adjacencyLists.Count;

        /// <summary>
        /// to get number of edges
        /// </summary>
        public int EdgeCount => _edges.Count;

        /// <summary>
        /// to add the given node to the graph
        /// </summary>
        /// <param name="node"> the given node to add </param>
        public void AddNode(TNode node)
        {
            _adjacencyLists.Add(node, null);
        }

        /// <summary>
        /// to get the data associated with the edge from source to dest
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="dest"> dest </param>
        /// <param name="value"> out value </param>
        /// <returns> returns a bool </returns>
        public bool TryGetEdge(TNode source, TNode dest, out TEdgeData? value)
        {
            return _edges.TryGetValue((source, dest), out value);
        }

        /// <summary>
        /// to determine wether there is an edge from source to dest
        /// </summary>
        /// <param name="node"> node to determine for</param>
        /// <returns> returns a bool</returns>
        public bool ContainsNode(TNode node)
        {
            return _adjacencyLists.ContainsKey(node);
        }

        /// <summary>
        /// to determine whether there is an edge from source to dest
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="dest"> dest </param>
        /// <returns> bool </returns>
        public bool ContainsEdge(TNode source, TNode dest)
        {
            return _edges.ContainsKey((source, dest));
        }

        /// <summary>
        ///  try to add an edge from source to dest with the associated data item value
        /// </summary>
        /// <param name="source"> source </param>
        /// <param name="dest"> dest </param>
        /// <param name="value"> out value </param>
        /// <exception cref="ArgumentNullException"> argument is null</exception>
        public void AddEdge(TNode source, TNode dest, TEdgeData value)
        {
            if (source == null || dest == null)
            {
                throw new ArgumentNullException();
            }
            if (source.Equals(dest))
            {
                throw new ArgumentNullException();
            }

            _edges.Add((source, dest), value);

            _adjacencyLists.TryGetValue(source, out LinkedListCell<TNode>?sourceList);
            _adjacencyLists[source] = new LinkedListCell<TNode>(dest, sourceList);

            if (!_adjacencyLists.ContainsKey(dest))
            {
                _adjacencyLists[dest] = null;
            }
        }

        /// <summary>
        /// to implement an enumerator for the outgoing edges from the given node
        /// </summary>
        /// <param name="node"> node to implement</param>
        /// <returns> returns IEnumerable</returns>
        /// <exception cref="ArgumentException"> argexception</exception>
        public IEnumerable<Edge<TNode, TEdgeData>> OutgoingEdges(TNode node)
        {
            if (!_adjacencyLists.TryGetValue(node, out LinkedListCell<TNode>? list))
            {
                throw new ArgumentException();
            }

            for (LinkedListCell<TNode>? cell = list; cell != null; cell = cell.Next)
            {
                _edges.TryGetValue((node, cell.Data), out TEdgeData? data);
                yield return new Edge<TNode, TEdgeData>(node, cell.Data, data!);
            }
        }
    }
}
