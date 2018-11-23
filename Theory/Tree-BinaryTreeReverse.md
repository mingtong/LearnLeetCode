## 反转二叉树的左右子树

#### 实现

递归方式：
``` C#
public class Solution 
{
    public TreeNode InvertTree(TreeNode root) 
    {
        if(root == null)
        {
            return null;
        }
        TreeNode tmp = root.left;
        root.left = InvertTree(root.right);
        root.right = InvertTree(tmp);
        return root;
    }
}
```
