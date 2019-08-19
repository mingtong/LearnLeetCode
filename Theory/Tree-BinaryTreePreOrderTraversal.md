## 二叉树前序遍历

前序： 根->左->右

#### 递归实现
``` C#
public class Solution {
    public IList<int> PreorderTraversal(TreeNode root) 
    {
        List<int> result = new List<int>();
        if (root != null)
        {
            result.Add(root.val);
            result.AddRange(PreorderTraversal(root.left));
            result.AddRange(PreorderTraversal(root.right));
        }
        return result;
    }
}
```

#### 非递归实现：

1. 创建一个栈，把 root 结点入栈。
2. 栈不为空时就执行下面的流程。 
  - 从栈中弹出一个元素，并输出这个元素。 
  - 把弹出元素的右子结点入栈。 
  - 把弹出元素的左子结点入栈。

``` C#
public class Solution {
    public IList<int> PreorderTraversal(TreeNode root) 
    {
        List<int> result = new List<int>();
        if(root == null)
        {
            return result;
        }

        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode runNode = root;
        while(stack.Count > 0 || runNode != null)
        {
            if(runNode != null)
            {
                stack.Push(runNode);
                result.Add(runNode.val);
                runNode = runNode.left;
            }
            else
            {
                runNode = stack.Peek();
                stack.Pop();
                runNode = runNode.right;
            }
        }
        return result; 
    }
}
