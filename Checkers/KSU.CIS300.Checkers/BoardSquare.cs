namespace KSU.CIS300.Checkers
{
    /// <summary>
    /// Represents a single square on the checkers board.
    /// Each square tracks its position, whether it contains a piece,
    /// whether that piece is a king, and whether it is currently selected.
    /// </summary>
    public class BoardSquare
    {
        /// <summary>
        /// Indicates whether the piece on this square has been promoted to a King.
        /// Initialized to false by default.
        /// </summary>
        public bool King { get; set; } = false;

        /// <summary>
        /// Indicates the color of the piece on this square.
        /// Set to SquareColor.None if there is no piece on this square.
        /// </summary>
        public SquareColor Color { get; set; }

        /// <summary>
        /// Indicates whether this square is currently selected by the player.
        /// Initialized to false by default.
        /// </summary>
        public bool Selected { get; set; } = false;

        /// <summary>
        /// The row position of this square on the board (1–8).
        /// Row 1 is at the top and row 8 is at the bottom.
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// The column position of this square on the board (1–8).
        /// Column 1 is the leftmost and column 8 is the rightmost.
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// Constructs a new BoardSquare at the given row and column.
        /// The square is initialized with no piece (SquareColor.None).
        /// </summary>
        /// <param name="row">The row position of this square on the board (1–8).</param>
        /// <param name="col">The column position of this square on the board (1–8).</param>
        public BoardSquare(int row, int col)
        {
            Row = row;
            Column = col;
            Color = SquareColor.None;
        }
    }

    /// <summary>
    /// Represents the color of a piece on a board square.
    /// Red and Black correspond to the two players' pieces.
    /// None indicates that the square has no piece on it.
    /// </summary>
    public enum SquareColor
    {
        /// <summary>The square contains a red piece.</summary>
        Red,
        /// <summary>The square contains a black piece.</summary>
        Black,
        /// <summary>The square contains no piece.</summary>
        None
    }
}