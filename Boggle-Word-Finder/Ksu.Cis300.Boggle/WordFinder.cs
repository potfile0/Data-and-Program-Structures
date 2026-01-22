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
    }
}
