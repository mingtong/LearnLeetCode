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
    }

    public class BinaryTree
    {
        public BinaryTree()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void PreOrderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            var stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                Console.WriteLine(root.Val);
                //right child is pushed first so that left is processed first
                if (node.Right != null)
                {
                    stack.Push(root.Right);
                }

                if (node.Left != null)
                {
                    stack.Push(root.Left);
                }
            }


            PreOrderTraversal(root.Left);
            PreOrderTraversal(root.Right);
        }

        /// <summary>
        /// 
        /// </summary>
        public void InOrderTraversal(TreeNode root)
        {
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
                    Console.WriteLine(root.Val);
                    root = root.Right;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void PostOrderTraversal(TreeNode root)
        {
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
                        Console.WriteLine(peekNode.Val);
                        lastNodeVisited = stack.Pop();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void LevelOrderTraversal()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void ZigZagOrderTraversal()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsSymmetry()
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSame(BinaryTree t)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reverse()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int MaxHeight()
        {
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int MinHeight()
        {
            return -1;
        }
    }
}