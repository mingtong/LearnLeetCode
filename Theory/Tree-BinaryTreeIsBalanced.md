## 判断二叉树是否平衡

#### 思路：
即：左右子树的高度差小于等于1

#### 实现：
``` C#
public class Solution 
{
    public bool IsBalanced(TreeNode root) 
    {
        if(root == null)
        {
            return true;
        }
        int L = Depth(root.left);
        int R = Depth(root.right);
        return Math.Abs(L-R) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
    }
    private int Depth(TreeNode root)
    {
        if(root == null)
        {
            return 0;
        }
        return Math.Max(Depth(root.left), Depth(root.right)) + 1;
    }
}
```
