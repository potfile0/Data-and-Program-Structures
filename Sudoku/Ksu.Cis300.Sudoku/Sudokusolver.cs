using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ksu.Cis300.Sudoku
{
    /// <summary>
    /// Static class that handles reading puzzle files, solving puzzles, and
    /// checking if a solution is correct.
    /// </summary>
    public static class SudokuSolver
    {
        /// <summary>
        /// Figures out which block a cell belongs to based on its row and column.
        /// Blocks are numbered left to right, top to bottom starting from 0.
        /// </summary>
        /// <param name="row">Row of the cell.</param>
        /// <param name="column">Column of the cell.</param>
        /// <param name="blockSize">How many rows/columns are in each block.</param>
        /// <returns>The block index for that cell.</returns>
        public static byte GetBlock(int row, int column, int blockSize)
        {
            return (byte)((row / blockSize) * blockSize + column / blockSize);
        }

        /// <summary>
        /// Builds every constraint for a n x n puzzle. There's four types and
        /// each one produces n*n entries so the list ends up pretty big.
        /// </summary>
        /// <param name="size">How many rows/columns the puzzle has.</param>
        /// <returns>All the constraints for the puzzle.</returns>
        private static List<Constraint> GetAllConstraints(int size)
        {
            List<Constraint> list = new List<Constraint>();

            /// Type 1: every cell needs a value.
            for (byte r = 0; r < size; r++)
            {
                for (byte c = 0; c < size; c++)
                {
                    list.Add(new Constraint(1, r, c, 0, 0));
                }
            }

            /// Type 2: every value has to show up in each row.
            for (byte r = 0; r < size; r++)
            {
                for (byte v = 1; v <= size; v++)
                {
                    list.Add(new Constraint(2, r, 0, 0, v));
                }
            }

            /// Type 3: every value has to show up in each column.
            for (byte c = 0; c < size; c++)
            {
                for (byte v = 1; v <= size; v++)
                {
                    list.Add(new Constraint(3, 0, c, 0, v));
                }
            }

            /// Type 4: every value has to show up in each block.
            for (byte b = 0; b < size; b++)
            {
                for (byte v = 1; v <= size; v++)
                {
                    list.Add(new Constraint(4, 0, 0, b, v));
                }
            }

            return list;
        }

        /// <summary>
        /// Returns the four constraints that gets satisfied when we place a
        /// specific value into a specific cell.
        /// </summary>
        /// <param name="row">The row of the cell.</param>
        /// <param name="column">The column of the cell.</param>
        /// <param name="value">The value being placed.</param>
        /// <param name="blockSize">How many rows/columns are in each block.</param>
        /// <returns>A list of the four constraints for this placement.</returns>
        private static List<Constraint> GetConstraintsFor(byte row,
            byte column, byte value, int blockSize)
        {
            List<Constraint> list = new List<Constraint>
            {
                new Constraint(1, row, column, 0, 0),
                new Constraint(2, row, 0, 0, value),
                new Constraint(3, 0, column, 0, value),
                new Constraint(4, 0, 0, GetBlock(row, column, blockSize),
                    value)
            };
            return list;
        }

        /// <summary>
        /// Builds all the possible decisions for the puzzle. Empty cells get
        /// one decision per possible value, filled cells only get one decision.
        /// The out parameter lines up with the returned list one to one.
        /// </summary>
        /// <param name="puzzle">The puzzle array, empty cells are "".</param>
        /// <param name="blockSize">Rows/columns per block.</param>
        /// <param name="constraints">The constraints for each decision.</param>
        /// <returns>All possible decisions.</returns>
        private static List<Decision> GetDecisions(string[,] puzzle,
            int blockSize, out List<IList<Constraint>> constraints)
        {
            int size = puzzle.GetLength(0);
            List<Decision> decisions = new List<Decision>();
            constraints = new List<IList<Constraint>>();

            for (byte r = 0; r < size; r++)
            {
                for (byte c = 0; c < size; c++)
                {
                    string s = puzzle[r, c];
                    if (s == "")
                    {
                        /// Cell is empty so every value is a candidate.
                        for (byte v = 1; v <= size; v++)
                        {
                            decisions.Add(new Decision(r, c, v));
                            constraints.Add(GetConstraintsFor(r, c, v,
                                blockSize));
                        }
                    }
                    else
                    {
                        /// Cell is already filled so theres only one option.
                        byte v = byte.Parse(s);
                        decisions.Add(new Decision(r, c, v));
                        constraints.Add(GetConstraintsFor(r, c, v,
                            blockSize));
                    }
                }
            }
            return decisions;
        }

        /// <summary>
        /// Tries to solve the puzzle by turning it into a exact cover problem.
        /// If it works the solution gets written back into the puzzle array.
        /// </summary>
        /// <param name="puzzle">The puzzle to solve, gets modified in place.</param>
        /// <param name="blockSize">Rows/columns per block.</param>
        /// <returns>True if a solution was found, false otherwise.</returns>
        public static bool Solve(string[,] puzzle, int blockSize)
        {
            int size = puzzle.GetLength(0);
            List<Constraint> allConstraints = GetAllConstraints(size);
            List<IList<Constraint>> decConstraints;
            List<Decision> decisions = GetDecisions(puzzle, blockSize,
                out decConstraints);

            CoverGraph<Constraint, Decision> graph =
                new CoverGraph<Constraint, Decision>(allConstraints,
                    decisions, decConstraints);

            IEnumerable<Decision> cover;
            if (graph.RemoveCover(out cover))
            {
                foreach (Decision d in cover)
                {
                    puzzle[d.Row, d.Column] = d.Value.ToString();
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Reads a puzzle file, validates it, and returns all the puzzle strings.
        /// Throws an IOException if the block size is wrong or any line is invalid.
        /// </summary>
        /// <param name="filename">Path to the puzzle file.</param>
        /// <param name="size">Out: rows/columns per puzzle.</param>
        /// <param name="blockSize">Out: rows/columns per block.</param>
        /// <returns>List of puzzle strings from the file.</returns>
        public static List<string> ReadPuzzles(string filename, out int size,
            out int blockSize)
        {
            List<string> puzzles = new List<string>();
            using (StreamReader reader = new StreamReader(filename))
            {
                string firstLine = reader.ReadLine();
                blockSize = int.Parse(firstLine);
                if (blockSize != 2 && blockSize != 3)
                {
                    throw new IOException("Invalid block size: " +
                        blockSize);
                }
                size = blockSize * blockSize;
                int expectedLength = size * size;
                string pattern = "^[.1-" + size + "]+$";

                int lineNum = 1;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lineNum++;
                    if (line.Length != expectedLength ||
                        !Regex.IsMatch(line, pattern))
                    {
                        throw new IOException("Line " + lineNum +
                            " is invalid.");
                    }
                    puzzles.Add(line);
                }
            }
            return puzzles;
        }

        /// <summary>
        /// Converts a puzzle string into a 2D array we can actually work with.
        /// Dots become empty strings and digits stays as single char strings.
        /// </summary>
        /// <param name="puzzle">The raw puzzle string.</param>
        /// <param name="size">How many rows/columns the puzzle has.</param>
        /// <returns>2D array of cell contents.</returns>
        public static string[,] GetPuzzleArray(string puzzle, int size)
        {
            string[,] arr = new string[size, size];
            int idx = 0;
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    char ch = puzzle[idx++];
                    arr[r, c] = ch == '.' ? "" : ch.ToString();
                }
            }
            return arr;
        }

        /// <summary>
        /// Checks if the puzzle is solved correctly. If something is wrong it
        /// gives back the constraint that was violated through the out parameter.
        /// </summary>
        /// <param name="puzzle">The filled in puzzle to check.</param>
        /// <param name="blockSize">Rows/columns per block.</param>
        /// <param name="badConstraint">The violated constraint if there is one.</param>
        /// <returns>True if the solution is correct, false if not.</returns>
        public static bool IsSolved(string[,] puzzle, int blockSize,
            out Constraint badConstraint)
        {
            List<IList<Constraint>> decConstraints;
            GetDecisions(puzzle, blockSize, out decConstraints);

            HashSet<Constraint> set = new HashSet<Constraint>();
            foreach (IList<Constraint> list in decConstraints)
            {
                foreach (Constraint c in list)
                {
                    if (!set.Add(c))
                    {
                        badConstraint = c;
                        return false;
                    }
                }
            }
            badConstraint = default(Constraint);
            return true;
        }
    }
}