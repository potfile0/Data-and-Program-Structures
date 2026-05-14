using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ksu.Cis300.Sudoku
{
    /// <summary>
    /// This is the header cell for a element node's adjacency list in the
    /// CoverGraph. It just keeps track of how many edges are currently hanging
    /// off of it, the header itself don't count toward that number.
    /// </summary>
    public class Header : GraphCell
    {
        /// <summary>
        /// How many edges are in this header's adjacency list right now.
        /// The header cell itself isn't included in the count.
        /// </summary>
        public int EdgeCount { get; set; }
    }
}