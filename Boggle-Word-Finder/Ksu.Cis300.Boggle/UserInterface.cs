/* UserInterface.cs
 * Author: Josh Weese
 */

using System.Collections;
using System.Text;

namespace Ksu.Cis300.Boggle
{
    /// <summary>
    /// A GUI for a program that finds all words on a Boggle board.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The number of rows/columns on the board.
        /// </summary>
        public static readonly int GridSize = 5;

        /// <summary>
        /// The font size for the dice in pixels.
        /// </summary>
        private const int _fontSize = 50;

        /// <summary>
        /// The width and height of each die.
        /// </summary>
        private const int _dieSize = 2 * _fontSize;

        /// <summary>
        /// The font to use for the dice.
        /// </summary>
        private readonly Font _diceFont = new(FontFamily.GenericSansSerif, _fontSize, 
            GraphicsUnit.Pixel);

        /// <summary>
        /// The random number generator.
        /// </summary>
        private readonly Random _random = new();

        /// <summary>
        /// The dice.
        /// </summary>
        private readonly string[][] _dice = new string[][]
        {
            new string[] { "A", "F", "I", "R", "S", "Y" },
            new string[] { "A", "D", "E", "N", "N", "N" },
            new string[] { "A", "E", "E", "E", "E", "M" },
            new string[] { "A", "A", "A", "F", "R", "S" },
            new string[] { "A", "E", "G", "M", "N", "N" },
            new string[] { "A", "A", "E", "E", "E", "E" },
            new string[] { "A", "E", "E", "G", "M", "U" },
            new string[] { "A", "A", "F", "I", "R", "S" },
            new string[] { "B", "J", "K", "Qu", "X", "Z" },
            new string[] { "C", "C", "E", "N", "S", "T" },
            new string[] { "C", "E", "I", "L", "P", "T" },
            new string[] { "C", "E", "I", "I", "L", "T" },
            new string[] { "C", "E", "I", "P", "S", "T" },
            new string[] { "D", "H", "L", "N", "O", "R" },
            new string[] { "D", "H", "L", "N", "O", "R" },
            new string[] { "D", "D", "H", "N", "O", "T" },
            new string[] { "D", "H", "H", "L", "O", "R" },
            new string[] { "E", "N", "S", "S", "S", "U" },
            new string[] { "E", "M", "O", "T", "T", "T" },
            new string[] { "E", "I", "I", "I", "T", "T" },
            new string[] { "F", "I", "P", "R", "S", "Y" },
            new string[] { "G", "O", "R", "R", "V", "W" },
            new string[] { "I", "P", "R", "R", "R", "Y" },
            new string[] { "N", "O", "O", "T", "U", "W" },
            new string[] { "O", "O", "O", "T", "T", "U" }
        };

        /// <summary>
        /// The visual representations of the dice.
        /// </summary>
        private Button[,] _diceView = new Button[GridSize, GridSize];

        /// <summary>
        /// The board contents.
        /// </summary>
        private string[,] _board = new string[GridSize, GridSize];

        /// <summary>
        /// The word finder.
        /// </summary>
        private WordFinder? _wordFinder;

        /// <summary>
        /// Constructs the GUI.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
            DrawBoard();
            NewBoard();
        }

        /// <summary>
        /// Draws the dice on the board with no letters.
        /// </summary>
        private void DrawBoard()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Button b = new();
                    b.Font = _diceFont;
                    b.Size = new Size(_dieSize, _dieSize);
                    b.Margin = new Padding(0);
                    _diceView[i, j] = b;
                    uxBoard.Controls.Add(b);
                }
            }
            uxBoard.Size = new Size(GridSize * _dieSize, GridSize * _dieSize);
        }

        /// <summary>
        /// Generates a new board.
        /// </summary>
        private void NewBoard()
        {
            int k = _dice.Length;
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    int loc = _random.Next(k);
                    k--;
                    string[] temp = _dice[loc];
                    _dice[loc] = _dice[k];
                    _dice[k] = temp;
                    loc = _random.Next(_dice[k].Length);
                    _board[i, j] = _dice[k][loc].ToLower();
                    _diceView[i, j].Text = _dice[k][loc];
                }
            }
        }

        /// <summary>
        /// Handles a Click event on the "New Board" menu item.
        /// </summary>
        /// <param name="sender">The object signaling the event.</param>
        /// <param name="e">Information about the event.</param>
        private void NewBoardClick(object sender, EventArgs e)
        {
            NewBoard();
        }

        /// <summary>
        /// Signals a Load event on the form.
        /// </summary>
        /// <param name="e">Information about the event.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Visible = true;
            uxOpenDialog.ShowDialog();
            try
            {
                _wordFinder = new WordFinder(_board, uxOpenDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Application.Exit();
            }
        }
    }
}
