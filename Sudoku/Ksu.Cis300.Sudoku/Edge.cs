using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ksu.Cis300.Sudoku
{
    /// <summary>
    /// This class represents an edge connecting a element node and a subset
    /// node in the CoverGraph. Every edge shows up in two adjacency lists,
    /// one for the element side through ElementHeader and one for the subset
    /// side through Subset.
    /// </summary>
    /// <typeparam name="TSubset">Whatever type we're using for subset nodes.</typeparam>
    public class Edge<TSubset> : GraphCell
    {
        /// <summary>
        /// The header of the element node that this edge is connected to.
        /// </summary>
        public Header ElementHeader { get; }
        /// <summary>
        /// The subset node that this edge belongs to.
        /// </summary>
        public TSubset Subset { get; }
        /// <summary>
        /// Builds the edge and sets the element header and subset. Thats
        /// really all there is to it.
        /// </summary>
        /// <param name="header">The element header this edge connects to.</param>
        /// <param name="subset">The subset this edge belongs to.</param>
        public Edge(Header header, TSubset subset)
        {
            ElementHeader = header;
            Subset = subset;
        }
    }
}