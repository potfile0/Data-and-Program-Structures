/* WordFinder.cs
 * Author: Josh Weese
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ksu.Cis300.TrieLibrary;
using System.IO;

namespace Ksu.Cis300.Boggle
{
    /// <summary>
    /// Instances will find all words on a Boggle board.
    /// </summary>
    public class WordFinder
    {
        /// <summary>
        /// The minimum allowed length of a word.
        /// </summary>
        private const int _minimumWordLength = 4;

        /// <summary>
        /// The list of allowable words.
        /// </summary>
        private readonly ITrie _wordList = new TrieWithNoChildren();

        /// <summary>
        /// The Boggle board contents.
        /// </summary>
        private string[,] _board;

        /// <summary>
        /// Constructs a new WordFinder for the given Boggle board and word list.
        /// </summary>
        /// <param name="board">The Boggle board.</param>
        /// <param name="fn">The name of the file containing the word list.</param>
        public WordFinder(string[,] board, string fn)
        {
            if (board == null || fn == null)
            {
                throw new ArgumentNullException();
            }
            _board = board;
            using (StreamReader input = File.OpenText(fn))
            {
                while (!input.EndOfStream)
                {
                    // Because input is not at EndOfStream, ReadLine shouldn't return null.
                    string word = input.ReadLine()!;
                    if (word.Length >= _minimumWordLength)
                    {
                        _wordList = _wordList.Add(word);
                    }
                }
            }
        }
        /// <summary>
        /// Recursively find all words starting from the given position
        /// </summary>
        /// <param name="row"> row count of current die</param>
        /// <param name="col"> column count of current die</param>
        /// <param name="used"> array indicating which dice are already used. </param>
        /// <param name="prefix"> StringBuilder containing the letters chosen so far along the current path.</param>
        /// <param name="completions"> A trie containing all valid completions of the current prefix.</param>
        /// <param name="results"> atrie containing all previous words and new found words</param>
        /// <returns> returns words starting from the given position</returns>
        private ITrie FindWords(int row, int col, bool[,] used, StringBuilder prefix, ITrie completions, ITrie results)
        {

            ITrie? next = completions.GetCompletions(_board[row, col]);

            if (next == null)
            {
                return results;
            }

            used[row, col] = true;
            prefix.Append(_board[row, col]);


            if (next.Contains(""))
            {
                results = results.Add(prefix.ToString());
            }

            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (r >= 0 && r < UserInterface.GridSize && c >= 0 && c < UserInterface.GridSize && !used[r, c])
                    {
                        results = FindWords(r, c, used, prefix, next, results);
                    }
                }
            }

            used[row, col] = false;
            prefix.Length = prefix.Length - _board[row, col].Length;

            return results;
        }

        /// <summary>
        /// Finds all the words on the board.
        /// </summary>
        /// <returns>A trie containing all the words on the board.</returns>
        public ITrie GetAllWords()
        {
            ITrie results = new TrieWithNoChildren();
            bool[,] used = new bool[UserInterface.GridSize, UserInterface.GridSize];
            StringBuilder prefix = new();

            for (int r = 0; r < UserInterface.GridSize; r++)
            {
                for (int c = 0; c < UserInterface.GridSize; c++)
                {
                    results = FindWords(r, c, used, prefix, _wordList, results);
                }
            }

            return results;
        }
    }
}
