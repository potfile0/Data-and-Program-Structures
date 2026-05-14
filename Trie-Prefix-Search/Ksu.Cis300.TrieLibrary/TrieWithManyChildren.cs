/* Trie.cs
 * Author: Josh Weese
 */
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// A single node of a trie.
    /// </summary>
    public class TrieWithManyChildren : ITrie
    {
        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmpty = false;

        /// <summary>
        /// This node's children.
        /// </summary>
        private ITrie?[] _children = new ITrie?[ITrie.AlphabetSize];

        /// <summary>
        /// Constructs a trie containing the given string and having the given child at the given label.
        /// If s contains any characters other than lower-case English letters,
        /// throws an ArgumentException.
        /// If childLabel is not a lower-case English letter, throws an ArgumentException.
        /// </summary>
        /// <param name="s">The string to include.</param>
        /// <param name="hasEmpty">Indicates whether this trie should contain the empty string.</param>
        /// <param name="childLabel">The label of the child.</param>
        /// <param name="child">The child labeled childLabel.</param>
        public TrieWithManyChildren(string s, bool hasEmpty, char childLabel, ITrie child)
        {
            if (s == null || child == null)
            {
                throw new ArgumentNullException();
            }
            if (childLabel < ITrie.AlphabetStart || childLabel >= ITrie.AlphabetStart + ITrie.AlphabetSize)
            {
                throw new ArgumentException();
            }
            _hasEmpty = hasEmpty;
            _children[childLabel - ITrie.AlphabetStart] = child;
            Add(s);
        }

        /// <summary>
        /// Method that gets all of the strings that form words in this trie when appended to the given prefix.
        /// </summary>
        /// <param name="prefix"> the prefix to get completion for</param>
        /// <returns>A trie containing all of the strings that form words in this trie when appended
        /// to the given prefix. </returns>
        /// <exception cref="ArgumentNullException">Argument to throw if the prefix is null</exception>
        public ITrie? GetCompletions(string prefix)
        {
            if (prefix == null)
            {
                throw new ArgumentNullException();
            }
            if (prefix == "")
            {
                return this;
            }
            else
            {
                int loc = prefix[0] - ITrie.AlphabetStart;

                if (loc < 0 || loc >= ITrie.AlphabetSize)
                {
                    return null;
                }

                ITrie? child = _children[loc];

                if (child == null)
                {
                    return null;
                }

                return child.GetCompletions(prefix.Substring(1));
            }
        }

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
                int loc = s[0] - ITrie.AlphabetStart;
                if (loc < 0 || loc >= ITrie.AlphabetSize)
                {
                    return false;
                }
                else
                {
                    ITrie? child = _children[loc];
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
        /// <returns>The resulting trie.</returns>
        public ITrie Add(string s)
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
                int loc = s[0] - ITrie.AlphabetStart;
                if (loc < 0 || loc >= ITrie.AlphabetSize)
                {
                    throw new ArgumentException();
                }
                ITrie? child = _children[loc];
                if (child == null)
                {
                    child = new TrieWithNoChildren();
                }
                _children[loc] = child.Add(s.Substring(1));
            }
            return this;
        }

        /// <summary>
        /// Adds all of the strings in this trie alphabetically to the end of the given list, with each
        /// string prefixed by the given prefix.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="list">The list to which the strings are to be added.</param>
        public void AddAll(StringBuilder prefix, IList list)
        {
            if (prefix == null || list == null)
            {
                throw new ArgumentNullException();
            }

            if (_hasEmpty)
            {
                list.Add(prefix.ToString());
            }

            for (int i = 0; i < ITrie.AlphabetSize; i++)
            {
                ITrie? child = _children[i];

                if (child != null)
                {
                    char c = (char)(ITrie.AlphabetStart + i);

                    prefix.Append(c);
                    child.AddAll(prefix, list);
                    prefix.Length--; 
                }
            }
        }
    }
}
