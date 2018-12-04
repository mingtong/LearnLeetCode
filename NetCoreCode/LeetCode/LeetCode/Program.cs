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
            var list = tree.IsSymmetric(root);
        }

        private static TreeNode BuildTree()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            //root.right = new TreeNode(3);

//            root.left.left = new TreeNode(4);
//            root.left.right = new TreeNode(5);
//            root.right.left = new TreeNode(6);
            return root;
        }
    }
}