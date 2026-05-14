using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.Sudoku
{
    /// <summary>
    /// This enum just tracks the two directions we use for the adjacency lists
    /// in the bipartite graph. Element has to come first or the unit tests will
    /// break since they expect the subset lists to live at index [1].
    /// </summary>
    public enum AdjacencyList
    {
        /// <summary>
        /// This is the direction going from a element node.
        /// </summary>
        Element,
        /// <summary>
        /// This is the direction going from a subset node.
        /// </summary>
        Subset
    }
}