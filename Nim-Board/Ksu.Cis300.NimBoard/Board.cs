namespace Ksu.Cis300.NimBoard
{
    /// <summary>
    /// a class defining an immutable representation of a board for the variation of Nim
    /// </summary>
    public class Board
    {
        /// <summary>
        /// The number of stones on each pile.
        /// </summary>
        private int[] _piles;

        /// <summary>
        /// The limit for each pile.
        /// </summary>
        private int[] _limits;

        /// <summary>
        /// Gets the number of piles.
        /// </summary>
        public int NumberOfPiles => _piles.Length;

        /// <summary>
        /// Gets the number of stones on the given pile.
        /// </summary>
        /// <param name="pile">The pile.</param>
        /// <returns>The number of stones on the given pile.</returns>
        public int GetValue(int pile)
        {
            if (pile < 0 || pile >= NumberOfPiles)
            {
                throw new ArgumentException();
            }
            return _piles[pile];
        }

        /// <summary>
        /// Gets the limit for the given pile.
        /// </summary>
        /// <param name="pile">The pile.</param>
        /// <returns>The limit for the given pile.</returns>
        public int GetLimit(int pile)
        {
            if (pile < 0 || pile >= NumberOfPiles)
            {
                throw new ArgumentException();
            }
            return _limits[pile];
        }

        /// <summary>
        /// Constructor for Board
        /// </summary>
        /// <param name="piles"> number of stone on each pile</param>
        /// <param name="limits"> limit for each pile</param>
        /// <exception cref="ArgumentException"> two parameters have different lengths</exception>
        public Board(int[] piles, int[] limits)
        {
            if (piles.Length != limits.Length)
            {
                throw new ArgumentException();
            }

            _piles = new int[piles.Length];
            _limits = new int[limits.Length];

            for (int i = 0; i < piles.Length; i++)
            {
                _piles[i] = piles[i];
                _limits[i] = limits[i];
            }
        }

        /// <summary>
        /// Defines equality for two board instances
        /// </summary>
        /// <param name="x"> first board</param>
        /// <param name="y"> second board </param>
        /// <returns> returns a bool</returns>
        public static bool operator ==(Board? x, Board? y)
        {
            if (Equals(x, null))
            {
                return Equals(y, null);
            }
            else if (Equals(y, null))
            {
                return false;
            }
            else
            {
                if (x._piles.Length != y._piles.Length)
                {
                    return false;
                }

                for (int i = 0; i < x._piles.Length; i++)
                {
                    if (x._piles[i] != y._piles[i] || x._limits[i] != y._limits[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(Board x, Board y)
        {
            return !(x == y);
        }

        /// <summary>
        /// turn to non static equals method
        /// </summary>
        /// <param name="obj"> defined object </param>
        /// <returns> returns </returns>
        public override bool Equals(object? obj)
        {
            return obj as Board == this;
        }

        /// <summary>
        /// Override method for GetHashCode
        /// </summary>
        /// <returns> returns 0</returns>
        public override int GetHashCode()
        {
            return 0;
        }
    }
}
