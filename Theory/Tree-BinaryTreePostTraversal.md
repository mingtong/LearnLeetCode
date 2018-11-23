## 二叉树后序遍历

后序： 左->右->根

#### 递归实现
``` C#
public class Solution {
    public IList<int> PreorderTraversal(TreeNode root) 
    {
        List<int> result = new List<int>();
        if (root != null)
        {
            result.AddRange(PreorderTraversal(root.left));
            result.AddRange(PreorderTraversal(root.right));
            result.Add(root.val);
        }
        return result;
    }
}
```

#### 非递归实现：

``` C#
public class Solution {
    public IList<int> PostorderTraversal(TreeNode root) {
        List<int> result = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode p = root;
        while(stack.Count!=0 || p != null) 
        {
            if(p != null) 
            {
                stack.Push(p);
                result.Insert(0, p.val);  // Reverse the process of preorder
                p = p.right;             // Reverse the process of preorder
            } else {
                TreeNode node = stack.Pop();
                p = node.left;           // Reverse the process of preorder
            }
        }
        return result;        
    }
}
