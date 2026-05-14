/*
 * UserInterface.cs
 * Author: Josh Weese
 */
using KSU.CIS300.Checkers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KSU.CIS300.Checkers
{
    /// <summary>
    /// The main form for the checkers game. Responsible for drawing the board,
    /// updating the UI after each move, and responding to player input.
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The current game of checkers being played.
        /// </summary>
        private Game _game = null;

        /// <summary>
        /// Image for a standard red piece.
        /// </summary>
        private Image _red;

        /// <summary>
        /// Image for a red king piece.
        /// </summary>
        private Image _redKing;

        /// <summary>
        /// Image for a standard black piece.
        /// </summary>
        private Image _black;

        /// <summary>
        /// Image for a black king piece.
        /// </summary>
        private Image _blackKing;

        /// <summary>
        /// Initializes the form, loads piece images, starts a new game,
        /// and draws the board.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();

            string picsPath = System.IO.Path.Combine(Application.StartupPath, "img");
            _red = Image.FromFile(System.IO.Path.Combine(picsPath, "red.png"));
            _redKing = Image.FromFile(System.IO.Path.Combine(picsPath, "red_king.png"));
            _black = Image.FromFile(System.IO.Path.Combine(picsPath, "black.png"));
            _blackKing = Image.FromFile(System.IO.Path.Combine(picsPath, "black_king.png"));

            _game = new Game();
            uxToolStripStatusLabel_Turn.Text = "Black's Turn";
            DrawBoard();
        }

        /// <summary>
        /// Clears the board panel and populates it with a Label for each square.
        /// Each label is colored, sized, and assigned a click handler.
        /// The row and column number is displayed in the top-left corner of each square.
        /// </summary>
        private void DrawBoard()
        {
            uxFlowLayoutPanel_board.Controls.Clear();
            uxFlowLayoutPanel_board.Width = 60 * 8;
            uxFlowLayoutPanel_board.Height = (60 * 8) + 30;

            for (int row = 1; row <= 8; row++)
            {
                LinkedListCell<BoardSquare> boardRow = _game.GetRow(row);
                while (boardRow != null)
                {
                    BoardSquare square = boardRow.Data;

                    Label squareLabel = new Label
                    {
                        Width = 60,
                        Height = 60,
                        BackColor = (row + square.Column) % 2 == 0 ? Color.White : Color.Gray,
                        Margin = new Padding(0),
                        Name = $"{row},{square.Column}",
                        Image = GetSquareImage(square),
                        Text = $"{row}.{square.Column}",
                        TextAlign = System.Drawing.ContentAlignment.TopLeft,
                        Font = new Font("Arial", 6f, FontStyle.Regular),
                        ForeColor = Color.Black,
                        ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
                    };

                    squareLabel.Click += new EventHandler(BoardSquare_Click);
                    uxFlowLayoutPanel_board.Controls.Add(squareLabel);

                    boardRow = boardRow.Next;
                }
            }
        }

        /// <summary>
        /// Updates every square label on the board to reflect the current game state.
        /// Highlights the selected square in aqua and updates the turn indicator.
        /// </summary>
        private void RedrawBoard()
        {
            foreach (Control control in uxFlowLayoutPanel_board.Controls)
            {
                if (control is Label squareLabel)
                {
                    string[] pos = squareLabel.Name.Split(',');
                    int row = int.Parse(pos[0]);
                    int col = int.Parse(pos[1]);

                    BoardSquare square = null;
                    LinkedListCell<BoardSquare> cell = _game.GetRow(row);
                    while (cell != null)
                    {
                        if (cell.Data.Column == col)
                        {
                            square = cell.Data;
                            break;
                        }
                        cell = cell.Next;
                    }

                    if (square == null) continue;

                    squareLabel.Image = GetSquareImage(square);
                    squareLabel.BackColor = square.Selected
                        ? Color.Aqua
                        : ((row + col) % 2 == 0 ? Color.White : Color.Gray);
                }
            }

            uxToolStripStatusLabel_Turn.Text =
                _game.Turn == SquareColor.Black ? "Black's Turn" : "Red's Turn";
        }

        /// <summary>
        /// Returns the correct piece image for the given square based on its
        /// color and whether the piece is a king. Returns null if the square is empty.
        /// </summary>
        /// <param name="square">The board square to get an image for.</param>
        /// <returns>The image for the piece on the square, or null if empty.</returns>
        private Image GetSquareImage(BoardSquare square)
        {
            if (square.Color == SquareColor.Black)
                return square.King ? _blackKing : _black;
            if (square.Color == SquareColor.Red)
                return square.King ? _redKing : _red;
            return null;
        }

        /// <summary>
        /// Handles a click on any board square. Passes the clicked position to the
        /// game logic, redraws the board if a move was made, and shows a message
        /// if the game is won or the move is invalid.
        /// </summary>
        /// <param name="sender">The label that was clicked.</param>
        /// <param name="e">The event data associated with the click.</param>
        private void BoardSquare_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (clickedLabel == null) return;

            string[] pos = clickedLabel.Name.Split(',');
            int row = int.Parse(pos[0]);
            int col = int.Parse(pos[1]);

            // Record state before the move to determine if an actual move occurred.
            int redBefore = _game.RedCount;
            int blackBefore = _game.BlackCount;
            SquareColor turnBefore = _game.Turn;

            bool result = _game.MoveSelectedPiece(row, col);

            if (result)
            {
                RedrawBoard();

                // A real move occurred if the turn changed or a piece was captured.
                bool actualMove = (_game.Turn != turnBefore)
                               || (_game.RedCount != redBefore)
                               || (_game.BlackCount != blackBefore);

                if (actualMove)
                {
                    if (_game.RedCount == 0)
                        MessageBox.Show("Black wins!", "Game Over", MessageBoxButtons.OK);
                    else if (_game.BlackCount == 0)
                        MessageBox.Show("Red wins!", "Game Over", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Invalid move!", "Warning", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Resets the game and redraws the board when File → New Game is clicked.
        /// </summary>
        /// <param name="sender">The menu item that was clicked.</param>
        /// <param name="e">The event data associated with the click.</param>
        private void uxNewGame_Click(object sender, EventArgs e)
        {
            _game = new Game();
            uxToolStripStatusLabel_Turn.Text = "Black's Turn";
            DrawBoard();
        }
    }
}