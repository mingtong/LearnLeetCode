## 求二叉树最小高度

#### 实现
``` C#
public class Solution 
{
    public int MinDepth(TreeNode root) 
    {
        if (root == null) 
        {
            return 0;
        }
        int L = MinDepth(root.left);
        int R = MinDepth(root.right);
        return (L == 0 || R == 0) ? (L+R+1) : Math.Min(L,R) + 1;
    }
}
```
