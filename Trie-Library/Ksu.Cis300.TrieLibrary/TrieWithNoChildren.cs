using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        private bool _containsEmpty = false;

        public bool Contains(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }
                
            if (s.Length == 0)
            {
                return _containsEmpty;
            }

            return false;
        }

        public ITrie Add(string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException(nameof(s));
            }

            if (s.Length == 0)
            {
                _containsEmpty = true;
                return this;
            }

            if (s[0] < ITrie.AlphabetStart || s[0] >= ITrie.AlphabetStart + ITrie.AlphabetSize)
            {
                throw new ArgumentException();
            }

            return new TrieWithOneChild(s, _containsEmpty);
        }
    }
}
