using System;
using System.Runtime;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace LeetCode
{


    public class BinaryTree
    {
        public BinaryTree()
        {
        }

        /// <summary>
        /// #144 Recursively PreOrderTraversal
        /// </summary>
        /// <param name="root"></param>
        public void PreOrderTraversalRecursively(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            PreOrderTraversalRecursively(root.left);
            Console.WriteLine(root.val);
            PreOrderTraversalRecursively(root.right);
        }

        /// <summary>
        /// #144 iteratively
        /// </summary>
        public IList<int> PreOrderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
            {
                return result;
            }

            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                result.Add(root.val);

                var node = stack.Pop();

                //right child is pushed first so that left is processed first
                if (node.right != null)
                {
                    stack.Push(node.right);
                }

                if (node.left != null)
                {
                    stack.Push(node.left);
                }
            }

            return result;
        }

        /// <summary>
        /// #94 InOrderTraversal iteration
        /// </summary>
        public IList<int> InOrderTraversal(TreeNode root)
        {
            var sequence = new List<int>();
            var stack = new Stack<TreeNode>();
            while (stack.Count > 0 || root != null)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    root = stack.Pop();
                    sequence.Add(root.val);
                    root = root.right;
                }
            }

            return sequence;
        }

        /// <summary>
        /// #145
        /// </summary>
        public IList<int> PostOrderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root == null)
            {
                return result;
            }

            var stack = new Stack<TreeNode>();
            TreeNode lastNodeVisited = null;
            while (stack.Count > 0 || root != null)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    var peekNode = stack.Peek();
                    // if right child exists and traversing node
                    // from left child, then move right
                    if (peekNode.right != null && lastNodeVisited != peekNode.right)
                    {
                        root = peekNode.right;
                    }
                    else
                    {
                        result.Add(peekNode.val);
                        lastNodeVisited = stack.Pop();
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// #102 level order traversal
        /// </summary>
        public IList<IList<int>> LevelOrderTraversal(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                int level = q.Count;
                var subList = new List<int>();
                for (int i = 0; i < level; i++)
                {
                    var node = q.Dequeue();
                    subList.Add(node.val);
                    if (node.left != null)
                    {
                        q.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        q.Enqueue(node.right);
                    }
                }

                result.Add(subList);
            }

            return result;
        }

        /// <summary>
        /// #107
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrderTraversalReverse(TreeNode root)
        {
            var result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            var stackResult = new Stack<IList<int>>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                int level = q.Count;
                var subList = new List<int>();
                for (int i = 0; i < level; i++)
                {
                    var node = q.Dequeue();
                    subList.Add(node.val);
                    if (node.left != null)
                    {
                        q.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        q.Enqueue(node.right);
                    }
                }

                stackResult.Push(subList);
            }

            while (stackResult.Count > 0)
            {
                result.Add(stackResult.Pop());
            }

            return result;
        }

        /// <summary>
        /// #103
        /// </summary>
        public IList<IList<int>> ZigZagLevelOrderTraversal(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            bool isOrder = true;
            int size = 1;

            while (q.Count > 0)
            {
                List<int> tmp = new List<int>();
                for (int i = 0; i < size; ++i)
                {
                    TreeNode n = q.Dequeue();
                    if (isOrder)
                    {
                        tmp.Add(n.val);
                    }
                    else
                    {
                        tmp.Insert(0, n.val);
                    }

                    if (n.left != null)
                    {
                        q.Enqueue(n.left);
                    }

                    if (n.right != null)
                    {
                        q.Enqueue(n.right);
                    }
                }

                result.Add(tmp);
                size = q.Count;
                isOrder = isOrder ? false : true;
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsSymmetricRecursively(TreeNode root)
        {
            if (root == null)
            {
                return false;
            }

            if (root.left != root.right)
            {
                return false;
            }

            bool L = IsSymmetricRecursively(root.left);
            bool R = IsSymmetricRecursively(root.right);
            return L && R;
        }

        /// <summary>
        /// #101 is Symmetric?
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            var q = new Queue<TreeNode>();
            if (root == null)
            {
                return true;
            }

            q.Enqueue(root.left);
            q.Enqueue(root.right); // Queue can enqueue null value
            while (q.Count > 1)
            {
                TreeNode left = q.Dequeue();
                TreeNode right = q.Dequeue();
                if (left == null && right == null)
                {
                    continue;
                }

                if (left == null ^ right == null)
                {
                    return false;
                }

                if (left.val != right.val)
                {
                    return false;
                }

                q.Enqueue(left.left);
                q.Enqueue(right.right);
                q.Enqueue(left.right);
                q.Enqueue(right.left);
            }

            return true;
        }

        /// <summary>
        /// #98 Is a binary search tree?
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBST(TreeNode root)
        {
            var sequence = new List<int>();
            var stack = new Stack<TreeNode>();
            while (stack.Count > 0 || root != null)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    root = stack.Pop();
                    if (sequence.Count > 0 && sequence.Last() >= root.val)
                    {
                        return false;
                    }

                    sequence.Add(root.val);
                    root = root.right;
                }
            }

            return true;
        }

        /// <summary>
        /// #110 is the binary tree balanced?
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            int L = MaxHeight(root.left);
            int R = MaxHeight(root.right);

            return Math.Abs(L - R) < 2 && IsBalanced(root.left) && IsBalanced(root.right);
        }

        /// <summary>
        /// #100 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSameTree(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
            {
                return true;
            }

            if (t1 == null || t2 == null)
            {
                return false;
            }

            if (t1.val == t2.val)
            {
                return IsSameTree(t1.left, t2.left) && IsSameTree(t1.right, t2.right);
            }

            return false;
        }

        /// <summary>
        /// #226 recursively
        /// </summary>
        public TreeNode Invert(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;
            Invert(root.left);
            Invert(root.right);
            return root;
        }

        /// <summary>
        /// #226 iteratively
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public TreeNode InvertIteratively(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                var left = node.left;
                node.left = node.right;
                node.right = left;

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            return root;
        }

        /// <summary>
        /// #104
        /// </summary>
        /// <returns></returns>
        public int MaxHeight(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int L = MaxHeight(root.left);
            int R = MaxHeight(root.right);
            return Math.Max(L, R) + 1;
        }

        /// <summary>
        /// #111
        /// </summary>
        /// <returns></returns>
        public int MinHeight(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int L = MinHeight(root.left);
            int R = MinHeight(root.right);
            if (L == 0 || R == 0)
            {
                return L + R + 1;
            }

            return Math.Min(L, R) + 1;
        }

        /// <summary>
        /// #230
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int KthSmallest(TreeNode root, int k)
        {
            //in-order to iterate
            int i = 0;
            var sequence = new List<int>();
            var stack = new Stack<TreeNode>();
            while (stack.Count > 0 || root != null)
            {
                if (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else
                {
                    root = stack.Pop();
                    sequence.Add(root.val);
                    if (i++ == k)
                    {
                        return root.val;
                    }

                    root = root.right;
                }
            }

            return i; // not important, never go here.
        }
    }
}