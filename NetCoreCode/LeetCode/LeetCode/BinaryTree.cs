using System;
using System.Runtime;
using System.Collections.Generic;
using System.Collections;

namespace LeetCode
{
    public class TreeNode
    {
        public int Val;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(int v)
        {
            this.Val = v;
        }
    }

    public class BinaryTree
    {
        public BinaryTree()
        {
        }

        /// <summary>
        /// Recursively PreOrderTraversal
        /// </summary>
        /// <param name="root"></param>
        public void PreOrderTraversalRecursively(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            PreOrderTraversalRecursively(root.Left);
            Console.WriteLine(root.Val);
            PreOrderTraversalRecursively(root.Right);
        }

        /// <summary>
        /// 
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
                result.Add(root.Val);

                var node = stack.Pop();

                //right child is pushed first so that left is processed first
                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }

            return result;
        }

        /// <summary>
        /// InOrderTraversal iteration
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
                    root = root.Left;
                }
                else
                {
                    root = stack.Pop();
                    sequence.Add(root.Val);
                    root = root.Right;
                }
            }

            return sequence;
        }

        /// <summary>
        /// 
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
                    root = root.Left;
                }
                else
                {
                    var peekNode = stack.Peek();
                    // if right child exists and traversing node
                    // from left child, then move right
                    if (peekNode.Right != null && lastNodeVisited != peekNode.Right)
                    {
                        root = peekNode.Right;
                    }
                    else
                    {
                        result.Add(peekNode.Val);
                        lastNodeVisited = stack.Pop();
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 
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
                    subList.Add(node.Val);
                    if (node.Left != null)
                    {
                        q.Enqueue(node.Left);
                    }

                    if (node.Right != null)
                    {
                        q.Enqueue(node.Right);
                    }
                }

                result.Add(subList);
            }

            return result;
        }

        public IList<IList<int>> LevelOrderTraversalRevrese(TreeNode root)
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
                    subList.Add(node.Val);
                    if (node.Left != null)
                    {
                        q.Enqueue(node.Left);
                    }

                    if (node.Right != null)
                    {
                        q.Enqueue(node.Right);
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
        /// 
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
                        tmp.Add(n.Val);
                    }
                    else
                    {
                        tmp.Insert(0, n.Val);
                    }

                    if (n.Left != null)
                    {
                        q.Enqueue(n.Left);
                    }

                    if (n.Right != null)
                    {
                        q.Enqueue(n.Right);
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
        public bool IsSymmetry()
        {
            return false;
        }

        public bool IsBST(TreeNode root)
        {
            if (root == null)
            {
                return false;
            }

            if (root.Left != null)
            {
                if (root.Left.Val > root.Val)
                {
                    return false;
                }
            }
            if (root.Right != null)
            {
                if (root.Right.Val < root.Val)
                {
                    return false;
                }
            }
            
            return IsBST(root.Left) && IsBST(root.Right);
        }

        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            int L = MaxHeight(root.Left);
            int R = MaxHeight(root.Right);

            return Math.Abs(L - R) < 2 && IsBalanced(root.Left) && IsBalanced(root.Right);
        }

        /// <summary>
        /// 
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

            if (t1.Val == t2.Val)
            {
                return IsSameTree(t1.Left, t2.Left) && IsSameTree(t1.Right, t2.Right);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public TreeNode Invert(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            TreeNode temp = root.Left;
            root.Left = root.Right;
            root.Right = temp;
            Invert(root.Left);
            Invert(root.Right);
            return root;
        }

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
                var left = node.Left;
                node.Left = node.Right;
                node.Right = left;

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }

            return root;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int MaxHeight(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int L = MaxHeight(root.Left);
            int R = MaxHeight(root.Right);
            return Math.Max(L, R) + 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int MinHeight(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int L = MinHeight(root.Left);
            int R = MinHeight(root.Right);
            if (L == 0 || R == 0)
            {
                return L + R + 1;
            }

            return Math.Min(L, R) + 1;
        }
    }
}