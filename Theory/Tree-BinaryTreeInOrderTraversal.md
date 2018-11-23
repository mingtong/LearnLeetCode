## 二叉树中序遍历

中序： 左->根->右

#### 递归实现
``` C#
public class Solution {
    public IList<int> InOrderTraversal(TreeNode root) 
    {
        List<int> result = new List<int>();
        if (root != null)
        {
            result.AddRange(PreorderTraversal(root.left));
            result.Add(root.val);
            result.AddRange(PreorderTraversal(root.right));
        }
        return result;
    }
}
```

#### 非递归实现：

``` C#
public class Solution 
{
    public IList<int> InorderTraversal(TreeNode root) 
    {
        List<int> result = new List<int>();
        if(root == null)
        {
            return result;
        }
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode runNode = root;
        while(runNode != null || stack.Count > 0)
        {
            if(runNode != null)
            {
                stack.Push(runNode);
                runNode = runNode.left;                
            }
            else
            {
                runNode = stack.Peek();
                result.Add(stack.Pop().val);
                runNode = runNode.right;
            }
        }
        return result;
    }
}
```
