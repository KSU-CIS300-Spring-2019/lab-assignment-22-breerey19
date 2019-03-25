/*TrieWithOneChild.cs
 * Bree Reynoso
 */ 



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// 
        /// </summary>
        private bool _IsEmpty;
        private ITrie _child;
        private char _label;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        public TrieWithOneChild(string s, bool b)
        {
            if(s == "" || (_label > 'a' && _label < 'z'))
            {
                throw new ArgumentException();
            }
            _IsEmpty = b;
            _label = s[0];

            ITrie t = new TrieWithNoChildren();
            _child = t.Add(s.Substring(1));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _IsEmpty = true;
                return this;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {
                ITrie t = new TrieWithManyChildren(s, _IsEmpty,_label,_child);
                return t;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _IsEmpty;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
           
            else
            {
                return _child.Contains(s.Substring(1));
            }


        }
    }
}
