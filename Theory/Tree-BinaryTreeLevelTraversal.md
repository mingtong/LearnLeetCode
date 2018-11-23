## 二叉树层次遍历

``` C#
public class Solution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        var result = new List<IList<int>>();
        if (root == null)
        {
            return result;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            int level = queue.Count;
            List<int> subList = new List<int>();
            for (int i = 0; i < level; i++)
            {
                TreeNode node = queue.Dequeue();
                subList.Add(node.val);
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            result.Add(subList);
        }

        return result;
    }
}
```
