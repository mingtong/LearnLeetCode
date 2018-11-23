## 二叉树ZigZag遍历

#### 描述：
- ZigZag方式遍历二叉树，即：根->左子->右子->右子的左子->右子的右子->XXX 

#### 实现：
``` C#
public class Solution 
{
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) 
    {
        IList<IList<int>> result = new List<IList<int>>();
        if(root == null) 
        {
            return result;
        }
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        bool isOrder = true;
        int size = 1;

        while(q.Count > 0) 
        {
            List<int> tmp = new List<int>();
            for(int i = 0; i < size; ++i) {
                TreeNode n = q.Dequeue();
                if(isOrder) 
                {
                    tmp.Add(n.val);
                } 
                else 
                {
                    tmp.Insert(0, n.val);
                }
                if(n.left != null) 
                {
                    q.Enqueue(n.left);
                }
                if(n.right != null) 
                {
                    q.Enqueue(n.right);
                }
            }
            result.Add(tmp);
            size = q.Count;
            isOrder = isOrder ? false : true;
        }
        return result;
    }
}
```
