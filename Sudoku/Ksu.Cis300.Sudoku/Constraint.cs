using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ksu.Cis300.Sudoku
{
    /// <summary>
    /// Represents one constraint in the sudoku puzzle. These are the element
    /// nodes in our bipartite graph. Using bytes to store everything so the
    /// struct stays small and don't eat up too much memory.
    /// </summary>
    public struct Constraint
    {
        /// <summary>
        /// Tells us what kind of constraint this is:
        ///   1 = row/column (some value needs to go in this cell)
        ///   2 = row/value  (this value has to appear somewhere in the row)
        ///   3 = column/value (this value has to appear somewhere in the column)
        ///   4 = block/value (this value has to appear somewhere in the block)
        /// </summary>
        public byte Type { get; }
        /// <summary>
        /// The row this constraint is about, only matters for certain types.
        /// </summary>
        public byte Row { get; }
        /// <summary>
        /// The column this constraint is about, only matters for certain types.
        /// </summary>
        public byte Column { get; }
        /// <summary>
        /// The block this constraint is about, only matters for certain types.
        /// </summary>
        public byte Block { get; }
        /// <summary>
        /// The value this constraint is about, only matters for certain types.
        /// </summary>
        public byte Value { get; }
        /// <summary>
        /// Just builds a constraint and sets all the fields, pretty straightforward.
        /// </summary>
        public Constraint(byte type, byte row, byte column, byte block,
            byte value)
        {
            Type = type;
            Row = row;
            Column = column;
            Block = block;
            Value = value;
        }
    }
}