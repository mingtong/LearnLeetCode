using System.Collections.Generic;

namespace LeetCode
{
    public class Trie
    {
        class TrieNode
        {
            public char Val;
            public Dictionary<char, TrieNode> Children;
            public bool IsLeaf;

            public TrieNode()
            {
                Children = new Dictionary<char, TrieNode>();
            }
            public TrieNode(char val)
            {
                this.IsLeaf = false;
                Children = new Dictionary<char, TrieNode>();
                this.Val = val;
            }
        }

        private TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }
        public bool Search(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }

            var runNode = root;
            foreach (var c in word)
            {
                if (runNode.Children.ContainsKey(c))
                {
                    runNode = runNode.Children[c];
                }
                else
                {
                    return false;
                }
            }

            return runNode.IsLeaf;
        }

        public void Insert(string word)
        {
            var runNode = root;
            foreach (var c in word)
            {
                if (!runNode.Children.ContainsKey(c))
                {
                    runNode.Children.Add(c, new TrieNode(c));
                }
                runNode = runNode.Children[c];
            }

            runNode.IsLeaf = true;
        }

        public bool StartsWith(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }
            
            var runNode = root;
            foreach (var c in word)
            {
                if (runNode.Children.ContainsKey(c))
                {
                    runNode = runNode.Children[c];
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}