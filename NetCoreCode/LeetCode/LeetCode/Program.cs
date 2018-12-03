using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
//            var dp = new DP();
//            var v = dp.MaxSubArray();
//            Console.WriteLine(v);
            var tree = new BinaryTree();
            var root = BuildTree();
            tree.PreOrderTraversal(root);
        }

        private static TreeNode BuildTree()
        {
            TreeNode root = new TreeNode(1);
            //root.Left = new TreeNode(2);
            root.Right = new TreeNode(3);

            //root.Left.Left = new TreeNode(4);
            //root.Left.Right = new TreeNode(5);
            root.Right.Left = new TreeNode(6);
            return root;
        }
    }
}