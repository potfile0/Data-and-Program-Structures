/* SudokuSolverTests.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ksu.Cis300.Sudoku.Tests
{
    /// <summary>
    /// Unit tests for the SudokuSolver class.
    /// </summary>
    [TestFixture]
    public class SudokuSolverTests
    {
        /// <summary>
        /// Tests GetBlock for 4x4 puzzles.
        /// </summary>
        [Test, CancelAfter(1000), Category("H: GetBlock")]
        public void TestGetBlock4x4()
        {
            Assert.Multiple(() =>
            {
                Assert.That(SudokuSolver.GetBlock(0, 0, 2), Is.EqualTo(0), "Row 0, Column 0 should be block 0.");
                Assert.That(SudokuSolver.GetBlock(1, 1, 2), Is.EqualTo(0), "Row 1, Column 1 should be block 0.");
                Assert.That(SudokuSolver.GetBlock(0, 2, 2), Is.EqualTo(1), "Row 0, Column 2 should be block 1.");
                Assert.That(SudokuSolver.GetBlock(1, 3, 2), Is.EqualTo(1), "Row 1, Column 3 should be block 1.");
                Assert.That(SudokuSolver.GetBlock(2, 0, 2), Is.EqualTo(2), "Row 2, Column 0 should be block 2.");
                Assert.That(SudokuSolver.GetBlock(3, 1, 2), Is.EqualTo(2), "Row 3, Column 1 should be block 2.");
                Assert.That(SudokuSolver.GetBlock(2, 2, 2), Is.EqualTo(3), "Row 2, Column 2 should be block 3.");
                Assert.That(SudokuSolver.GetBlock(3, 3, 2), Is.EqualTo(3), "Row 3, Column 3 should be block 3.");
            });
        }

        /// <summary>
        /// Tests GetBlock for a 9x9 puzzle.
        /// </summary>
        [Test, CancelAfter(1000), Category("H: GetBlock")]
        public void TestGetBlock9x9()
        {
            Assert.Multiple(() =>
            {
                Assert.That(SudokuSolver.GetBlock(0, 2, 3), Is.EqualTo(0), "Row 0, Column 2 should be block 0.");
                Assert.That(SudokuSolver.GetBlock(2, 2, 3), Is.EqualTo(0), "Row 2, Column 2 should be block 0.");
                Assert.That(SudokuSolver.GetBlock(0, 3, 3), Is.EqualTo(1), "Row 0, Column 3 should be block 1.");
                Assert.That(SudokuSolver.GetBlock(3, 0, 3), Is.EqualTo(3), "Row 3, Column 0 should be block 3.");
            });
        }

        /// <summary>
        /// Tests GetPuzzleArray.
        /// </summary>
        [Test, CancelAfter(1000), Category("J: GetPuzzleArray")]
        public void TestGetPuzzleArray()
        {
            string s1 = "2.43432132141432";
            string[,] a1 = new string[,]
            {
                {"2", "", "4", "3" },
                {"4", "3", "2", "1" },
                {"3", "2", "1", "4" },
                {"1", "4", "3", "2" }
            };
            string s2 = "93.817256728653419615942738176425893452398167389176542897564321563281974241739685";
            string[,] a2 = new string[,]
            {
                {"9", "3", "", "8", "1", "7", "2", "5", "6" },
                {"7", "2", "8", "6", "5", "3", "4", "1", "9" },
                {"6", "1", "5", "9", "4", "2", "7", "3", "8" },
                {"1", "7", "6", "4", "2", "5", "8", "9", "3" },
                {"4", "5", "2", "3", "9", "8", "1", "6", "7" },
                {"3", "8", "9", "1", "7", "6", "5", "4", "2" },
                {"8", "9", "7", "5", "6", "4", "3", "2", "1" },
                {"5", "6", "3", "2", "8", "1", "9", "7", "4" },
                {"2", "4", "1", "7", "3", "9", "6", "8", "5" }
            };
            Assert.Multiple(() =>
            {
                Assert.That(SudokuSolver.GetPuzzleArray(s1, 4), Is.EqualTo(a1), "String s1");
                Assert.That(SudokuSolver.GetPuzzleArray(s2, 9), Is.EqualTo(a2), "String s2");
            });
        }

        /// <summary>
        /// Tests IsSolved.
        /// </summary>
        [Test, CancelAfter(1000), Category("K: IsSolved")]
        public void TestIsSolved()
        {
            string s1 = "3421213412434312";
            string s2 = "396428517152379486847615923281936754735142698964857231419263875678591342523784169";
            string s3 = "3421213412134312";
            Constraint[] c3 = new Constraint[]
            {
                new Constraint(2, 2, 0, 0, 1),
                new Constraint(3, 0, 2, 0, 1),
                new Constraint(4, 0, 0, 3, 1)
            };
            string s4 = "596428517152379486847615923281936754735142698964857231419263875678591342523784169";
            Constraint[] c4 = new Constraint[]
            {
                new Constraint(2, 0, 0, 0, 5),
                new Constraint(3, 0, 0, 0, 5),
                new Constraint(4, 0, 0, 0, 5),
            };
            Assert.Multiple(() =>
            {
                Assert.That(SudokuSolver.IsSolved(SudokuSolver.GetPuzzleArray(s1, 4), 2, out Constraint failed), Is.True, "Puzzle s1");
                Assert.That(SudokuSolver.IsSolved(SudokuSolver.GetPuzzleArray(s2, 9), 3, out failed), Is.True, "Puzzle s2");
                Assert.That(SudokuSolver.IsSolved(SudokuSolver.GetPuzzleArray(s3, 4), 2, out failed), Is.False, "Puzzle s3");
                Assert.That(new Constraint[] { failed }, Is.SubsetOf(c3), "Failed constraint for s3");
                Assert.That(SudokuSolver.IsSolved(SudokuSolver.GetPuzzleArray(s4, 9), 3, out failed), Is.False);
                Assert.That(new Constraint[] { failed }, Is.SubsetOf(c4), "Failed constraint for s4");
            });
        }

        /// <summary>
        /// Checks whether the initial values in an unsolved puzzle are unchanged in a solved puzzle.
        /// </summary>
        /// <param name="initial">The unsolved puzzle.</param>
        /// <param name="solved">The solved puzzle.</param>
        /// <returns>Whether the initial values are unchanged.</returns>
        private bool InitialValuesUnchanged(string[,] initial, string[,] solved)
        {
            for (int i = 0; i < initial.GetLength(0); i++)
            {
                for (int j = 0; j < initial.GetLength(1); j++)
                {
                    if (initial[i, j] != "" && initial[i, j] != solved[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        [Test, CancelAfter(1000), Category("L: Solve")]
        [TestCase(2, true, "..1313.23....13.")]
        [TestCase(3, true, "...82.4..52..4..1.6.......7.4...9.2...25.....9.37....6..8.1.......2...3.........5")]
        [TestCase(2, false, "2..443213...1432")]
        [TestCase(3, false, "...81.....2........1.9..7...7..25.934.2............5...975.....563.....41.....68.")]
        public void TestSolve(int blockSize, bool isSolvable, string puzzle)
        {
            int size = blockSize * blockSize;
            string[,] initial = SudokuSolver.GetPuzzleArray(puzzle, size);
            string[,] toSolve = new string[size, size];
            Array.Copy(initial, toSolve, size * size);
            bool solved = SudokuSolver.Solve(toSolve, blockSize);
            bool initUnchanged = InitialValuesUnchanged(initial, toSolve);
            bool isSolved = SudokuSolver.IsSolved(toSolve, blockSize, out Constraint failed);
            if (isSolvable)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(solved, Is.True, "A solution wasn't found.");
                    Assert.That(initUnchanged, Is.True, "The initial values were changed.");
                    Assert.That(isSolved, Is.True, "The solution provided violates constraint: Type "
                        + failed.Type + ", Row " + failed.Row + " , Col " + failed.Column + ", "
                        + failed.Block + ", Value" + failed.Value);
                });
            }
            else
            {
                Assert.Multiple(() =>
                {
                    Assert.That(solved, Is.False, "A solution was supposedly found.");
                    Assert.That(initUnchanged, Is.True, "The initial values were changed.");
                    Assert.That(toSolve, Is.EqualTo(initial), "The puzzle was changed.");
                });
            }
        }
    }
}
