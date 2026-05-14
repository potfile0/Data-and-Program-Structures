using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.Sudoku
{
    /// <summary>
    /// The main form for the sudoku solver. Handles loading files, navigating
    /// puzzles, editing cells, solving, and checking solutions.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// All the puzzles loaded from the current file, stored as raw strings.
        /// </summary>
        private List<string> _puzzles;

        /// <summary>
        /// The current puzzle as a 2D array, empty cells are "" and filled
        /// cells has a single character string.
        /// </summary>
        private string[,] _puzzle;

        /// <summary>
        /// How many rows/columns are in each block for the loaded file.
        /// </summary>
        private int _blockSize;

        /// <summary>
        /// How many rows/columns are in the puzzle for the loaded file.
        /// </summary>
        private int _size;

        /// <summary>
        /// All the TextBox controls that make up the puzzle grid.
        /// </summary>
        private TextBox[,] _cells;

        /// <summary>
        /// Tracks how many cells are still empty in the displayed puzzle.
        /// </summary>
        private int _emptyCells;

        /// <summary>
        /// Random number generator for picking a random puzzle.
        /// </summary>
        private Random _randomNumbers = new Random();

        /// <summary>
        /// Flag that stops Cell_TextChanged from doing anything while we're
        /// filling in cells programmatically.
        /// </summary>
        private bool _loading = false;

        /// <summary>
        /// Just calls InitializeComponent, nothing else going on here.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fires whenever a cell's text changes. If the input is invalid it
        /// restores the old value, otherwise it updates the puzzle array and
        /// empty cell count. Enables the check button when all cells is filled.
        /// </summary>
        /// <param name="sender">The cell TextBox that changed.</param>
        /// <param name="e">Event data, not used here.</param>
        private void Cell_TextChanged(object sender, EventArgs e)
        {
            if (_loading)
            {
                return;
            }
            TextBox cell = (TextBox)sender;
            string[] parts = cell.Name.Split(',');
            int row = int.Parse(parts[0]);
            int col = int.Parse(parts[1]);
            string newText = cell.Text;
            string oldText = _puzzle[row, col];
            bool valid;
            if (newText == "")
            {
                valid = true;
            }
            else if (newText.Length == 1)
            {
                char ch = newText[0];
                valid = ch >= '1' && ch <= (char)('0' + _size);
            }
            else
            {
                valid = false;
            }
            if (valid)
            {
                _puzzle[row, col] = newText;
                if (oldText == "" && newText != "")
                {
                    _emptyCells--;
                }
                else if (oldText != "" && newText == "")
                {
                    _emptyCells++;
                }
                uxCheckSolution.Enabled = (_emptyCells == 0);
            }
            else
            {
                _loading = true;
                cell.Text = oldText;
                _loading = false;
            }
        }

        /// <summary>
        /// Creates a single cell TextBox and encodes it's row and column in
        /// the Name so the TextChanged handler can find it later.
        /// </summary>
        /// <param name="row">The row this cell belongs to.</param>
        /// <param name="col">The column this cell belongs to.</param>
        /// <returns>A configured TextBox ready to drop into the grid.</returns>
        private TextBox GetCell(int row, int col)
        {
            TextBox cell = new TextBox();
            cell.Name = row + "," + col;
            cell.Text = "";
            cell.Width = 30;
            cell.Font = new Font(new FontFamily(GenericFontFamilies.SansSerif),
                20, GraphicsUnit.Pixel);
            cell.Margin = new Padding(0);
            cell.TextAlign = HorizontalAlignment.Center;
            cell.TextChanged += Cell_TextChanged;
            return cell;
        }

        /// <summary>
        /// Adds all the block panels to the puzzle panel and sizes everything
        /// correctly. The 1px margin on each block is what creates the visible
        /// border between blocks.
        /// </summary>
        private void AddBlocks()
        {
            TextBox sample = GetCell(0, 0);
            int cellW = sample.Width;
            int cellH = sample.Height;
            int blockW = _blockSize * cellW;
            int blockH = _blockSize * cellH;

            /// Each block has 1px margin on all sides so add 2 to each dimension.
            int outerW = _blockSize * (blockW + 2);
            int outerH = _blockSize * (blockH + 2);
            uxPuzzleLayoutPanel.Size = new Size(outerW, outerH);

            for (int i = 0; i < _size; i++)
            {
                FlowLayoutPanel block = new FlowLayoutPanel();
                block.Size = new Size(blockW, blockH);
                block.Margin = new Padding(1);
                block.Padding = new Padding(0);
                uxPuzzleLayoutPanel.Controls.Add(block);
            }
        }

        /// <summary>
        /// Creates a TextBox for every cell and drops it into the right
        /// block panel based on it's position in the grid.
        /// </summary>
        private void AddCells()
        {
            _cells = new TextBox[_size, _size];
            for (int r = 0; r < _size; r++)
            {
                for (int c = 0; c < _size; c++)
                {
                    TextBox cell = GetCell(r, c);
                    _cells[r, c] = cell;
                    int blockIdx = SudokuSolver.GetBlock(r, c, _blockSize);
                    FlowLayoutPanel block =
                        (FlowLayoutPanel)uxPuzzleLayoutPanel.Controls[blockIdx];
                    block.Controls.Add(cell);
                }
            }
        }

        /// <summary>
        /// Wipes the puzzle panel and rebuilds everything from scratch.
        /// </summary>
        private void DrawBoard()
        {
            uxPuzzleLayoutPanel.Controls.Clear();
            AddBlocks();
            AddCells();
        }

        /// <summary>
        /// Loads whichever puzzle the NumericUpDown is pointing at, redraws
        /// the board, and locks the pre-filled cells as ReadOnly.
        /// </summary>
        private void LoadCurrentPuzzle()
        {
            int idx = (int)uxPuzzleNumber.Value;
            _puzzle = SudokuSolver.GetPuzzleArray(_puzzles[idx], _size);
            DrawBoard();

            _loading = true;
            _emptyCells = 0;
            for (int r = 0; r < _size; r++)
            {
                for (int c = 0; c < _size; c++)
                {
                    string s = _puzzle[r, c];
                    _cells[r, c].Text = s;
                    _cells[r, c].ReadOnly = (s != "");
                    if (s == "")
                    {
                        _emptyCells++;
                    }
                }
            }
            _loading = false;
            uxCheckSolution.Enabled = (_emptyCells == 0);
        }

        /// <summary>
        /// Shows the file dialog and tries to load the chosen puzzle file.
        /// If anything goes wrong it shows the error in a MessageBox. Exits
        /// the app on cancel if exitOnCancel is true, otherwise just returns false.
        /// </summary>
        /// <param name="exitOnCancel">Whether to exit the app if the user cancels.</param>
        /// <returns>True if the file loaded successfully, false if it didn't.</returns>
        private bool TryLoadFile(bool exitOnCancel)
        {
            DialogResult result = uxOpenPuzzleDialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                if (exitOnCancel)
                {
                    Application.Exit();
                }
                return false;
            }
            try
            {
                int size;
                int blockSize;
                List<string> puzzles = SudokuSolver.ReadPuzzles(
                    uxOpenPuzzleDialog.FileName, out size, out blockSize);
                _puzzles = puzzles;
                _size = size;
                _blockSize = blockSize;
                uxPuzzleNumber.Maximum = _puzzles.Count - 1;
                if (uxPuzzleNumber.Value != 0)
                {
                    uxPuzzleNumber.Value = 0;
                }
                else
                {
                    LoadCurrentPuzzle();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (exitOnCancel)
                {
                    Application.Exit();
                }
                return false;
            }
        }

        /// <summary>
        /// Runs when the form loads and immediately asks for a puzzle file.
        /// Exits the app if the user hit cancel.
        /// </summary>
        /// <param name="sender">The control that fired the event.</param>
        /// <param name="e">Event data, not used here.</param>
        private void UserInterface_Load(object sender, EventArgs e)
        {
            TryLoadFile(true);
        }

        /// <summary>
        /// Lets the user pick a new puzzle file without closing the app.
        /// Keeps the old file loaded if they cancels or the file is bad.
        /// </summary>
        /// <param name="sender">The control that fired the event.</param>
        /// <param name="e">Event data, not used here.</param>
        private void uxOpenPuzzleFile_Click(object sender, EventArgs e)
        {
            TryLoadFile(false);
        }

        /// <summary>
        /// Picks a random puzzle from the loaded file. If it's the same index
        /// as the current one we reload manually since ValueChanged won't fire.
        /// </summary>
        /// <param name="sender">The control that fired the event.</param>
        /// <param name="e">Event data, we don't need this one.</param>
        private void uxLoadRandomPuzzle_Click(object sender, EventArgs e)
        {
            if (_puzzles == null)
            {
                return;
            }
            int n = _randomNumbers.Next(_puzzles.Count);
            if (uxPuzzleNumber.Value == n)
            {
                LoadCurrentPuzzle();
            }
            else
            {
                uxPuzzleNumber.Value = n;
            }
        }

        /// <summary>
        /// Reloads the original puzzle, tries to solve it, then updates the
        /// cells to show the result. ReadOnly state on cells don't change.
        /// </summary>
        /// <param name="sender">The control that fired the event.</param>
        /// <param name="e">Event data, not really needed here.</param>
        private void uxSolve_Click(object sender, EventArgs e)
        {
            if (_puzzles == null)
            {
                return;
            }
            int idx = (int)uxPuzzleNumber.Value;
            _puzzle = SudokuSolver.GetPuzzleArray(_puzzles[idx], _size);
            bool solved = SudokuSolver.Solve(_puzzle, _blockSize);
            if (!solved)
            {
                MessageBox.Show("The puzzle has no solution.");
            }
            _loading = true;
            _emptyCells = 0;
            for (int r = 0; r < _size; r++)
            {
                for (int c = 0; c < _size; c++)
                {
                    string s = _puzzle[r, c];
                    _cells[r, c].Text = s;
                    if (s == "")
                    {
                        _emptyCells++;
                    }
                }
            }
            _loading = false;
            uxCheckSolution.Enabled = (_emptyCells == 0);
        }

        /// <summary>
        /// Checks if the puzzle is solved correctly and shows a message. If
        /// its wrong it tells the user which row, column, or block has a
        /// duplicate value.
        /// </summary>
        /// <param name="sender">The control that fired the event.</param>
        /// <param name="e">Event data, we don't really use this.</param>
        private void uxCheckSolution_Click(object sender, EventArgs e)
        {
            Constraint bad;
            bool ok = SudokuSolver.IsSolved(_puzzle, _blockSize, out bad);
            if (ok)
            {
                MessageBox.Show("The solution is correct!");
            }
            else
            {
                string group;
                int k;
                if (bad.Type == 2)
                {
                    group = "Row";
                    k = bad.Row;
                }
                else if (bad.Type == 3)
                {
                    group = "Column";
                    k = bad.Column;
                }
                else
                {
                    group = "Block";
                    k = bad.Block;
                }
                MessageBox.Show(group + " " + k + " contains too many " +
                    bad.Value + "s.");
            }
        }

        /// <summary>
        /// Fires when the puzzle number changes and loads the new puzzle.
        /// The null check is there so it don't crash before a file is loaded.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">events</param>
        private void uxPuzzleNumber_ValueChanged(object sender, EventArgs e)
        {
            if (_puzzles != null)
            {
                LoadCurrentPuzzle();
            }
        }
    }
}