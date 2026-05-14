using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ksu.Cis300.Sudoku
{
    /// <summary>
    /// Base class for all the cells in our doubly-linked adjacency lists inside
    /// the CoverGraph. This class just handles the linking stuff, any extra data
    /// like edge counts or subset info are handled by the Header and Edge subclasses.
    /// </summary>
    public class GraphCell
    {
        /// <summary>
        /// Array of length 2 that holds the next cell in each adjacency list.
        /// Index 0 is the element direction and index 1 is the subset direction.
        /// </summary>
        public GraphCell[] Next { get; } = new GraphCell[2];
        /// <summary>
        /// Array of length 2 that holds the previous cell in each adjacency list.
        /// Index 0 is the element direction and index 1 is the subset direction.
        /// </summary>
        public GraphCell[] Previous { get; } = new GraphCell[2];
    }
}