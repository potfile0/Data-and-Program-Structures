using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ksu.Cis300.Sudoku
{
    /// <summary>
    /// Represents a decision we can make in the puzzle, basically just saying
    /// "put this value in this cell". These are the subset nodes in the bipartite
    /// graph. Using bytes to keep the struct small and not waste memory.
    /// </summary>
    public struct Decision
    {
        /// <summary>
        /// The row where we're placing the value.
        /// </summary>
        public byte Row { get; }
        /// <summary>
        /// The column where we're placing the value.
        /// </summary>
        public byte Column { get; }
        /// <summary>
        /// The actual value that getting placed in the cell.
        /// </summary>
        public byte Value { get; }
        /// <summary>
        /// Just a simple constructor that takes a row, column, and value and
        /// sets everything up, nothing fancy going on here.
        /// </summary>
        public Decision(byte row, byte column, byte value)
        {
            Row = row;
            Column = column;
            Value = value;
        }
    }
}