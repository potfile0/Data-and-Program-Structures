/* Board.cs
 * Author: Josh Weese
 */
namespace Ksu.Cis300.NimBoard
{
    /// <summary>
    /// Represents a Nim board.
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
        /// a constant giving the multiplier to use for polynomial hashing
        /// </summary>
        private const int _multiplier = 37;

        /// <summary>
        /// The hash code for this board
        /// </summary>
        private int _hashCode;

        /// <summary>
        /// Whether the hash code has been computed
        /// </summary>
        private bool _hashCodeComputed;

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
        /// Constructs a new board with the given number of stones and limit
        /// for each pile.
        /// </summary>
        /// <param name="piles">The number of stones on each pile.</param>
        /// <param name="limits">The limit for each pile.</param>
        public Board(int[] piles, int[] limits)
        {
            if (piles.Length != limits.Length)
            {
                throw new ArgumentException();
            }
            _piles = new int[piles.Length];
            piles.CopyTo(_piles, 0);
            _limits = new int[limits.Length];
            limits.CopyTo(_limits, 0);
        }

        /// <summary>
        /// Compares the two given boards for equality.
        /// </summary>
        /// <param name="x">The first board.</param>
        /// <param name="y">The second board.</param>
        /// <returns>Whether the two boards represent the same game configuration.</returns>
        public static bool operator ==(Board? x, Board? y)
        {
            if (Equals(x, null))
            {
                return (Equals(y, null));
            }
            else if (Equals(y, null))
            {
                return false;
            }
            else
            {
                if (x.NumberOfPiles != y.NumberOfPiles)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < x.NumberOfPiles; i++)
                    {
                        if (x._piles[i] != y._piles[i] || x._limits[i] != y._limits[i])
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
        }

        /// <summary>
        /// Determines whether the given boards are different.
        /// </summary>
        /// <param name="x">The first board.</param>
        /// <param name="y">The second board.</param>
        /// <returns>Whether the given boards represent different configurations.</returns>
        public static bool operator !=(Board? x, Board? y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Compares this board with the given object for equality.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>Whether obj is a nim board representing the same configuration as this board.</returns>
        public override bool Equals(object? obj)
        {
            return obj as Board == this;
        }

        /// <summary>
        /// Gets a hash code for this board.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            if (!_hashCodeComputed)
            {
                int hash = 0;

                hash = hash * _multiplier + NumberOfPiles;

                for (int i = 0; i < NumberOfPiles; i++)
                {
                    hash = hash * _multiplier + _piles[i];
                    hash = hash * _multiplier + _limits[i];
                }

                _hashCode = hash;
                _hashCodeComputed = true;
            }
            return _hashCode;
        }

        /// <summary>
        /// Gets the result of making the given play from this board position.
        /// </summary>
        /// <param name="p">The play to make.</param>
        /// <returns>The resulting board position.</returns>
        public Board MakePlay(Play p)
        {
            if (p.Pile > _piles.Length || p.Number > _limits[p.Pile])
            {
                throw new ArgumentException();
            }
            Board b = new(_piles, _limits);
            b._piles[p.Pile] -= p.Number;
            b._limits[p.Pile] = Math.Min(b._piles[p.Pile], 2 * p.Number);
            return b;
        }
    }
}
