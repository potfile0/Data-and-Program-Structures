/* Trie.cs
 * Author: Josh Weese
 */
namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// A single node of a trie.
    /// </summary>
    public class Trie
    {
        /// <summary>
        /// The first character of the alphabet used.
        /// </summary>
        private const char _alphabetStart = 'a';

        /// <summary>
        /// The size of the alphabet used.
        /// </summary>
        private const int _alphabetSize = 26;

        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmpty = false;

        /// <summary>
        /// This node's children.
        /// </summary>
        private Trie?[] _children = new Trie[_alphabetSize];

        /// <summary>
        /// Determines whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie at this node contains s.</returns>
        public bool Contains(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            if (s == "")
            {
                return _hasEmpty;
            }
            else
            {
                int loc = s[0] - _alphabetStart;
                if (loc < 0 || loc >= _alphabetSize)
                {
                    return false;
                }
                else 
                {
                    Trie? child = _children[loc];
                    if (child == null)
                    {
                        return false;
                    }
                    return child.Contains(s.Substring(1));
                }
            }
        }

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// </summary>
        /// <param name="s">The string to add.</param>
        public void Add(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            if (s == "")
            {
                _hasEmpty = true;
            }
            else
            {
                int loc = s[0] - _alphabetStart;
                if (loc < 0 || loc >= _alphabetSize)
                {
                    throw new ArgumentException();
                }
                Trie? child = _children[loc];
                if (child == null)
                {
                    child = new Trie();
                }
                child.Add(s.Substring(1));
                _children[loc] = child;
            }
        }
    }
}
