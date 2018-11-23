## 判断二叉树是否为BST

#### 递归实现

``` C#
public class Solution 
{
    public bool IsValidBST(TreeNode root) 
    {
        return isValidBST(root, long.MinValue, long.MaxValue);
    }
    private bool isValidBST(TreeNode root, long minVal, long maxVal)
    {
        if(root == null)
        {
            return true;
        }
        if(root.val >= maxVal || root.val <= minVal)
        {
            return false;
        }
        return isValidBST(root.left, minVal, root.val) && isValidBST(root.right, root.val, maxVal);
    }
}
```

#### 非递归实现
``` C#
public class Solution {
    public bool IsValidBST(TreeNode root) {
        if(root == null)
        {
            return true;
        }
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode pre = null;
        while(root != null || stack.Count != 0)
        {
            while(root != null)
            {
                stack.Push(root);
                root = root.left;
            }
            root = stack.Pop();
            if(pre != null && root.val <= pre.val)
            {
                return false;
            }
            pre = root;
            root = root.right;
        }
        return true;
    }
}
```
