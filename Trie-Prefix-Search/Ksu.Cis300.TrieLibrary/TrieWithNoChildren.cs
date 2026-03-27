/* TrieWithNoChildren.cs
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
    /// A trie node with no children.
    /// </summary>
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmpty = false;

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
                return null;
            }
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
            else
            {
                return new TrieWithOneChild(s, _hasEmpty);
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
            else
            {
                return false;
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
        }
    }
}
