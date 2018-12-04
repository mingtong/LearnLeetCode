namespace LeetCode
{
    public class BinarySearchTree
    {
        private TreeNode root;
        public BinarySearchTree()
        {}

        public TreeNode Insert(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }
            if (root == null)
            {
                root = node;
            }

            if (root.val > node.val)
            {
                root.left = Insert(node.left);
            }
            else if (root.val < node.val)
            {
                root.right = Insert(node.right);
            }
            else
            {
                //root.val =
            }

            return node;
        }
    }
}