using System;
using System.Collections.Generic;

namespace KSU.CIS300.Checkers
{
    /// <summary>
    /// Contains all game logic for a checkers match, including board setup,
    /// piece movement, jumping, and turn management.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The checkers board stored as a dictionary of linked lists.
        /// Each key is a row number (1-8) and each value is the first cell
        /// of a linked list of BoardSquares representing that row.
        /// </summary>
        private Dictionary<int, LinkedListCell<BoardSquare>> _board = null;

        /// <summary>
        /// The number of red pieces currently on the board.
        /// </summary>
        public int RedCount { get; private set; }

        /// <summary>
        /// The number of black pieces currently on the board.
        /// </summary>
        public int BlackCount { get; private set; }

        /// <summary>
        /// The piece the current player has selected to move.
        /// Null if no piece is currently selected.
        /// </summary>
        public BoardSquare SelectedPiece { get; set; }

        /// <summary>
        /// The color of the player whose turn it currently is.
        /// </summary>
        public SquareColor Turn { get; set; }

        /// <summary>
        /// Creates a new Game, builds the board, and sets Black to move first.
        /// </summary>
        public Game()
        {
            CreateBoard();
            Turn = SquareColor.Black;
        }

        /// <summary>
        /// Initializes the board and places all pieces in their starting positions.
        /// Red occupies rows 1-3 and Black occupies rows 6-8, on dark squares only.
        /// </summary>
        private void CreateBoard()
        {
            _board = new Dictionary<int, LinkedListCell<BoardSquare>>();
            RedCount = 0;
            BlackCount = 0;

            for (int row = 8; row >= 1; row--)
            {
                LinkedListCell<BoardSquare> head = null;

                for (int col = 8; col >= 1; col--)
                {
                    BoardSquare square = new BoardSquare(row, col);

                    // Only dark squares (odd row+col sum) can hold pieces.
                    if ((row + col) % 2 != 0)
                    {
                        if (row <= 3)
                        {
                            square.Color = SquareColor.Red;
                            RedCount++;
                        }
                        else if (row >= 6)
                        {
                            square.Color = SquareColor.Black;
                            BlackCount++;
                        }
                    }

                    // Prepend so the head of the list is column 1.
                    LinkedListCell<BoardSquare> cell = new LinkedListCell<BoardSquare> { Data = square, Next = head };
                    head = cell;
                }

                _board[row] = head;
            }
        }

        /// <summary>
        /// Returns the first cell of the linked list for the given row,
        /// or null if the row does not exist on the board.
        /// </summary>
        /// <param name="row">The row number to retrieve (1-8).</param>
        /// <returns>The first LinkedListCell of the given row, or null if the row does not exist.</returns>
        public LinkedListCell<BoardSquare> GetRow(int row)
        {
            return _board.ContainsKey(row) ? _board[row] : null;
        }

        /// <summary>
        /// Finds and returns the BoardSquare at the given row and column.
        /// If the square belongs to the current player, it is stored as
        /// the selected piece and marked as selected.
        /// </summary>
        /// <param name="row">The row of the square.</param>
        /// <param name="col">The column of the square.</param>
        /// <returns>The BoardSquare at that position, or null if not found.</returns>
        public BoardSquare SelectSquare(int row, int col)
        {
            LinkedListCell<BoardSquare> cell = GetRow(row);
            while (cell != null)
            {
                if (cell.Data.Column == col)
                {
                    BoardSquare square = cell.Data;
                    if (square.Color == Turn)
                    {
                        if (SelectedPiece != null)
                            SelectedPiece.Selected = false;
                        SelectedPiece = square;
                        square.Selected = true;
                    }
                    else
                    {
                        square.Selected = false;
                    }
                    return square;
                }
                cell = cell.Next;
            }
            return null;
        }

        /// <summary>
        /// Searches the given row for a square at the target column and checks
        /// whether its color matches the target color.
        /// The out parameter is set to the square found at that column.
        /// </summary>
        /// <param name="cell">The first cell of the row to search.</param>
        /// <param name="targetCol">The column to find.</param>
        /// <param name="targetColor">The color to match.</param>
        /// <param name="result">The square found at the target column.</param>
        /// <returns>True if the square exists and its color matches targetColor.</returns>
        public bool CheckCapture(LinkedListCell<BoardSquare> cell, int targetCol,
                                 SquareColor targetColor, out BoardSquare result)
        {
            result = null;
            while (cell != null)
            {
                if (cell.Data.Column == targetCol)
                {
                    result = cell.Data;
                    return cell.Data.Color == targetColor;
                }
                cell = cell.Next;
            }
            return false;
        }

        /// <summary>
        /// Searches the given row for a square at the target column and checks
        /// whether its color matches the target color.
        /// </summary>
        /// <param name="cell">The first cell of the row to search.</param>
        /// <param name="targetCol">The column to find.</param>
        /// <param name="targetColor">The color to match.</param>
        /// <returns>True if the square exists and its color matches targetColor.</returns>
        public bool CheckCapture(LinkedListCell<BoardSquare> cell, int targetCol, SquareColor targetColor)
        {
            BoardSquare dummy;
            return CheckCapture(cell, targetCol, targetColor, out dummy);
        }

        /// <summary>
        /// Determines whether a jump over an enemy piece to a landing square is valid.
        /// </summary>
        /// <param name="enemyRow">Row of the enemy piece being jumped over.</param>
        /// <param name="targetRow">Row of the landing square.</param>
        /// <param name="enemyCol">Column of the enemy piece being jumped over.</param>
        /// <param name="targetCol">Column of the landing square.</param>
        /// <param name="enemy">The color of the enemy piece.</param>
        /// <returns>True if the jump is valid.</returns>
        public bool TestCheckJump(int enemyRow, int targetRow, int enemyCol, int targetCol, SquareColor enemy)
        {
            return CheckJump(enemyRow, targetRow, enemyCol, targetCol, enemy);
        }

        /// <summary>
        /// Determines whether a jump is valid by checking that the enemy square
        /// contains an enemy piece and the landing square is empty.
        /// Both squares must exist on the board.
        /// </summary>
        /// <param name="enemyRow">Row of the enemy piece being jumped over.</param>
        /// <param name="targetRow">Row of the landing square.</param>
        /// <param name="enemyCol">Column of the enemy piece being jumped over.</param>
        /// <param name="targetCol">Column of the landing square.</param>
        /// <param name="enemy">The color of the enemy piece.</param>
        /// <returns>True if the jump is valid.</returns>
        public bool CheckJump(int enemyRow, int targetRow, int enemyCol, int targetCol, SquareColor enemy)
        {
            if (!_board.ContainsKey(enemyRow) || !_board.ContainsKey(targetRow))
                return false;

            bool enemyValid = CheckCapture(GetRow(enemyRow), enemyCol, enemy);
            bool targetEmpty = CheckCapture(GetRow(targetRow), targetCol, SquareColor.None);

            return enemyValid && targetEmpty;
        }

        /// <summary>
        /// Checks whether any jump is available from the given square.
        /// Kings may jump in all four diagonal directions; normal pieces
        /// may only jump forward.
        /// </summary>
        /// <param name="current">The square to check jumps from.</param>
        /// <param name="enemy">The color of the pieces to jump over.</param>
        /// <returns>True if at least one jump is possible.</returns>
        private bool CheckAnyJump(BoardSquare current, SquareColor enemy)
        {
            if (current == null) return false;

            int row = current.Row;
            int col = current.Column;

            int[] rowOffsets = current.King
                ? new int[] { -1, 1 }
                : (current.Color == SquareColor.Black ? new int[] { -1 } : new int[] { 1 });

            foreach (int rOff in rowOffsets)
            {
                foreach (int cOff in new int[] { -1, 1 })
                {
                    int enemyRow = row + rOff;
                    int enemyCol = col + cOff;
                    int targetRow = row + rOff * 2;
                    int targetCol = col + cOff * 2;

                    if (CheckJump(enemyRow, targetRow, enemyCol, targetCol, enemy))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Calculates the board position of the enemy piece that would be jumped over,
        /// based on where the selected piece is and where the player wants to land.
        /// Returns false if the move is not a valid two-square diagonal jump, or if
        /// a non-king piece attempts to jump backwards.
        /// </summary>
        /// <param name="target">The intended landing square.</param>
        /// <param name="enemy">The color of the enemy player.</param>
        /// <param name="row">The row of the enemy piece to jump over.</param>
        /// <param name="col">The column of the enemy piece to jump over.</param>
        /// <returns>True if a valid enemy position was found.</returns>
        public bool GetJumpSquare(BoardSquare target, SquareColor enemy, out int row, out int col)
        {
            row = -1;
            col = -1;

            if (SelectedPiece == null) return false;

            int rowDiff = target.Row - SelectedPiece.Row;
            int colDiff = target.Column - SelectedPiece.Column;

            if (Math.Abs(rowDiff) != 2 || Math.Abs(colDiff) != 2)
                return false;

            if (!SelectedPiece.King)
            {
                if (SelectedPiece.Color == SquareColor.Black && rowDiff != -2) return false;
                if (SelectedPiece.Color == SquareColor.Red && rowDiff != 2) return false;
            }

            row = SelectedPiece.Row + rowDiff / 2;
            col = SelectedPiece.Column + colDiff / 2;
            return true;
        }

        /// <summary>
        /// Executes a jump from the current square to the target square, removing
        /// the enemy piece in between. Updates piece counts and checks whether
        /// another jump is available from the new position.
        /// </summary>
        /// <param name="current">The piece that is jumping.</param>
        /// <param name="target">The square to land on after the jump.</param>
        /// <param name="enemy">The color of the piece being captured.</param>
        /// <param name="jumpMore">True if another jump is available from the landing square.</param>
        /// <returns>True if the jump was successfully executed.</returns>
        private bool Jump(BoardSquare current, BoardSquare target, SquareColor enemy, out bool jumpMore)
        {
            jumpMore = false;

            if (!_board.ContainsKey(target.Row))
                return false;

            int enemyRow, enemyCol;
            if (!GetJumpSquare(target, enemy, out enemyRow, out enemyCol))
                return false;

            BoardSquare enemySquare, targetSquare;
            if (!CheckCapture(GetRow(enemyRow), enemyCol, enemy, out enemySquare)) return false;
            if (!CheckCapture(GetRow(target.Row), target.Column, SquareColor.None, out targetSquare)) return false;

            // Remove the captured piece and update the count.
            enemySquare.Color = SquareColor.None;
            if (enemy == SquareColor.Red) RedCount--;
            else BlackCount--;

            // Move the jumping piece to the landing square.
            target.Color = current.Color;
            target.King = current.King;
            current.Color = SquareColor.None;
            current.King = false;

            SelectedPiece = target;
            jumpMore = CheckAnyJump(target, enemy);
            return true;
        }

        /// <summary>
        /// Determines whether the selected piece can legally move to the target square.
        /// If a jump is required, attempts the jump. Otherwise validates a normal
        /// one-step diagonal move to an empty square.
        /// </summary>
        /// <param name="forceJump">If true, a jump is required and will be attempted.</param>
        /// <param name="targetSquare">The square the player wants to move to.</param>
        /// <param name="enemy">The color of the opposing player.</param>
        /// <param name="jumpMore">True if another jump is available after this move.</param>
        /// <returns>True if the move is legal.</returns>
        public bool CanMove(bool forceJump, BoardSquare targetSquare, SquareColor enemy, out bool jumpMore)
        {
            jumpMore = false;

            if (SelectedPiece == null || targetSquare == null)
                return false;

            if (forceJump)
                return Jump(SelectedPiece, targetSquare, enemy, out jumpMore);

            int rowDiff = targetSquare.Row - SelectedPiece.Row;
            int colDiff = Math.Abs(targetSquare.Column - SelectedPiece.Column);

            if (Math.Abs(rowDiff) != 1 || colDiff != 1) return false;
            if (targetSquare.Color != SquareColor.None) return false;
            if (SelectedPiece.King) return true;

            // Black moves toward row 1; Red moves toward row 8.
            if (SelectedPiece.Color == SquareColor.Black && rowDiff == -1) return true;
            if (SelectedPiece.Color == SquareColor.Red && rowDiff == 1) return true;

            return false;
        }

        /// <summary>
        /// Processes a player's click on the board at the given row and column.
        /// Handles piece selection, enforces mandatory jumps, executes normal moves
        /// and jumps, promotes pieces to kings, and switches turns when appropriate.
        /// </summary>
        /// <param name="targetRow">The row that was clicked.</param>
        /// <param name="targetCol">The column that was clicked.</param>
        /// <returns>True if a piece was selected or a legal move was made.</returns>
        public bool MoveSelectedPiece(int targetRow, int targetCol)
        {
            BoardSquare target = SelectSquare(targetRow, targetCol);

            if (target == null || SelectedPiece == null)
                return false;

            // The player clicked one of their own pieces — selection updated.
            if (target == SelectedPiece)
                return true;

            // Target is occupied by an opponent — invalid.
            if (target.Color != SquareColor.None)
                return false;

            SquareColor enemy = (Turn == SquareColor.Black) ? SquareColor.Red : SquareColor.Black;

            bool jumpAvailable = CheckAnyJump(SelectedPiece, enemy);

            // If the selected piece cannot jump, check if any other friendly piece can.
            // If so, the player must jump with that piece instead.
            if (!jumpAvailable)
            {
                for (int r = 1; r <= 8; r++)
                {
                    LinkedListCell<BoardSquare> cell = GetRow(r);
                    while (cell != null)
                    {
                        if (cell.Data.Color == Turn && CheckAnyJump(cell.Data, enemy))
                            return false;
                        cell = cell.Next;
                    }
                }
            }

            BoardSquare originalPiece = SelectedPiece;
            bool jumpMore;
            bool moved = CanMove(jumpAvailable, target, enemy, out jumpMore);

            if (moved)
            {
                if (!jumpAvailable)
                {
                    // Apply the normal move.
                    target.Color = originalPiece.Color;
                    target.King = originalPiece.King;
                    originalPiece.Color = SquareColor.None;
                    originalPiece.King = false;
                }

                // Promote to king upon reaching the opposite end of the board.
                if (target.Color == SquareColor.Black && target.Row == 1) target.King = true;
                if (target.Color == SquareColor.Red && target.Row == 8) target.King = true;

                originalPiece.Selected = false;

                if (!jumpMore)
                {
                    // No further jumps — clear selection and pass the turn.
                    if (SelectedPiece != null) SelectedPiece.Selected = false;
                    SelectedPiece = null;
                    Turn = (Turn == SquareColor.Black) ? SquareColor.Red : SquareColor.Black;
                }
                else
                {
                    // Another jump is available — keep the piece selected.
                    if (SelectedPiece != null) SelectedPiece.Selected = true;
                }

                return true;
            }

            return false;
        }
    }
}