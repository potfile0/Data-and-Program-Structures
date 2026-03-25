using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild
    {
        private bool _hasOneChild;

        private ITrie _trie;

        private char _label;

        public TrieWithOneChild(string s , bool wetherEmpty)
        {
            if(s == null)
            {
                throw new ArgumentNullException("s");
            }

            if (s == '' || s)
        }

    }
}
