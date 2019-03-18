﻿/* Trie.cs
 * Author: Rod Howell
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// A node of a trie for storing strings made up of lower-case English letters.
    /// </summary>
    public class Trie
    {
        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmptyString;

        /// <summary>
        /// The children of this node.
        /// </summary>
        private Trie[] _children = new Trie[26];

        /// <summary>
        /// Gets whether the trie rooted at this node contains the given string.
        /// </summary>
        /// <param name="s">The string to look up.</param>
        /// <returns>Whether the trie rooted at this node contains s.</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else
            {
                int loc = s[0] - 'a';
                if (loc < 0 || loc >= _children.Length || _children[loc] == null)
                {
                    return false;
                }
                else
                {
                    return _children[loc].Contains(s.Substring(1));
                }
            }
        }

        /// <summary>
        /// Adds the given string to the trie rooted at this node.
        /// </summary>
        /// <param name="s">The string to add.</param>
        public void Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {
                int loc = s[0] - 'a';
                if (_children[loc] == null)
                {
                    _children[loc] = new Trie();
                }
                _children[loc].Add(s.Substring(1));
            }
        }
    }
}
