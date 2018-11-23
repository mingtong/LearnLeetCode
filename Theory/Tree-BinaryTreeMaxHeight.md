## 求二叉树最大高度

#### 实现
``` C#
public class Solution 
{
    public int maxDepth(TreeNode root) 
    {
        if(root == null) 
        {
            return 0;
        }
        int left = 0, right = 0;
        left = maxDepth(root.left);
        right = maxDepth(root.right);
        return Math.max(left, right) + 1;
    }
}
```
