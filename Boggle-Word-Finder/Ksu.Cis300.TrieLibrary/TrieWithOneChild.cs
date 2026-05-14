/* TrieWithOneChild.cs
 * Author: Josh Weese
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// A trie node with a single child.
    /// </summary>
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmpty;

        /// <summary>
        /// This node's child.
        /// </summary>
        private ITrie _child;

        /// <summary>
        /// The child's label.
        /// </summary>
        private char _childLabel;

        /// <summary>
        /// Constructs a TrieWithOneChild containing the given string and possibly the empty string.
        /// </summary>
        /// <param name="s">The nonempty string to include. Must be non-null.</param>
        /// <param name="hasEmpty">Indicates whether the empty string should be included.</param>
       public TrieWithOneChild(string s, bool hasEmpty)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }
            if (s == "" || s[0] < ITrie.AlphabetStart || s[0] >= ITrie.AlphabetStart + ITrie.AlphabetSize)
            {
                throw new ArgumentException();
            }
            _childLabel = s[0];
            _child = new TrieWithNoChildren().Add(s.Substring(1));
            _hasEmpty = hasEmpty;
        }

        /// <summary>
        /// Adds the given string to this trie.
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
                return this;
            }
            if (s[0] < ITrie.AlphabetStart || s[0] >= ITrie.AlphabetStart + ITrie.AlphabetSize)
            {
                throw new ArgumentException();
            }
            if (s[0] == _childLabel)
            {
                _child = _child.Add(s.Substring(1));
                return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _hasEmpty, _childLabel, _child);
            }
        }

        /// <summary>
        /// Determines whether this trie contains the given string.
        /// </summary>
        /// <param name="s">The string to look for.</param>
        /// <returns>Whether this trie contains s.</returns>
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
            if (s[0] == _childLabel)
            {
                return _child.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets all of the strings that form words in this trie when appended to the given prefix.
        /// </summary>
        /// <param name="prefix">The prefix</param>
        /// <returns>A trie containing all of the strings that form words in this trie when appended
        /// to the given prefix.</returns>
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
            else if (prefix[0] == _childLabel)
            {
                return _child.GetCompletions(prefix.Substring(1));
            }
            else
            {
                return null;
            }
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
            prefix.Append(_childLabel);
            _child.AddAll(prefix, list);
            prefix.Length--;
        }
    }
}
