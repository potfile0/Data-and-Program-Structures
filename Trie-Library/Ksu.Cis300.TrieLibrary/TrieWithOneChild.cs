using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        private bool _hasEmpty;
        private ITrie _child;
        private char _label;

        public TrieWithOneChild(string s, bool hasEmpty)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            if (s.Length == 0 ||
                s[0] < ITrie.AlphabetStart ||
                s[0] >= ITrie.AlphabetStart + ITrie.AlphabetSize)
            {
                throw new ArgumentException();
            }

            _hasEmpty = hasEmpty;
            _label = s[0];
            _child = new TrieWithNoChildren().Add(s.Substring(1));
        }

        public bool Contains(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            if (s.Length == 0)
            {
                return _hasEmpty;
            }

            if (s[0] == _label)
            {
                return _child.Contains(s.Substring(1));
            }

            return false;
        }

        public ITrie Add(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException();
            }

            if (s.Length == 0)
            {
                _hasEmpty = true;
                return this;
            }

            if (s[0] < ITrie.AlphabetStart || s[0] >= ITrie.AlphabetStart + ITrie.AlphabetSize)
            {
                throw new ArgumentException();
            }

            if (s[0] == _label)
            {
                _child = _child.Add(s.Substring(1));
                return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _hasEmpty, _label, _child);
            }
        }
    }
}
