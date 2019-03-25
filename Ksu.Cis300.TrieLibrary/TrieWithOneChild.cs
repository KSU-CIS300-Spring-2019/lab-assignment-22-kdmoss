using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Whether the trie contains the empty string
        /// </summary>
        private bool _hasEmptyString;

        /// <summary>
        /// The only child (an ITrie, as you don't know which implementation it might be)
        /// </summary>
        private ITrie _child;

        /// <summary>
        /// The child's label.
        /// </summary>
        private char _label;


        /// <summary>
        /// Constructs a trie containing the given string and having the given child at the given label.
        /// If s contains any characters other than lower-case English letters,
        /// throws an ArgumentException.
        /// If childLabel is not a lower-case English letter, throws an ArgumentException.
        /// </summary>
        /// <param name="s">The string to include.</param>
        /// <param name="hasEmpty">Indicates whether this trie should contain the empty string.</param>
        public TrieWithOneChild(string s, bool hasEmptyString)
        {
            if (s == "" || s[0] < 'a' || s[0] > 'z')
                throw new ArgumentException();
           
            _hasEmptyString = hasEmptyString;
            _label = s[0];

            _child = new TrieWithNoChildren().Add(s.Substring(1));
        }

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// </summary>
        /// <param name="s">The string to add.</param>
        public ITrie Add(string s)
        {
            if (s == "")
                _hasEmptyString = true;
            else if (s[0] < 'a' || s[0] > 'z')
                throw new ArgumentException();
            else if (s[0] == _label)
                _child = _child.Add(s.Substring(1));
            else
                return new TrieWithManyChildren(s, _hasEmptyString, _label, _child);

            return this;
        }

        /// <summary>
        /// Gets whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie rooted at this node contains s.</returns>
        public bool Contains(string s)
        {
            if (s == "")
                return _hasEmptyString;

            if (s[0] == _label)
            {
                return _child.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
