## 判断二叉树是否对称

####描述： 
判断一个二叉树是否左右对称，比如： 
```
1 
/ \ 
2 2 
/ \ / \ 
3 4 4 3
```

#### 思路： 
对称的条件是：

左子树的左子结点等于右子树的右子结点，并且左子树的右子结点等于右子树的左子结点。

#### 递归实现:
``` Java
public class Solution {
    public bool IsSymmetric(TreeNode root) {
        if (root == null) {
            return true;
        }

        return IsSubSymmetric(root.left, root.right);
    }

    public bool IsSubSymmetric(TreeNode left, TreeNode right) {
        if (left == null && right == null) {
            return true;
        }

        if (left == null || right == null) {
            return false;
        }

        return (left.val == right.val) && IsSubSymmetric(left.left, right.right) &&
                IsSubSymmetric(left.right, right.left);
    }
}
```

#### 非递归实现
``` Java
public class Solution {
    public boolean isSymmetric(TreeNode root) {
        Queue<TreeNode> q = new LinkedList<TreeNode>();
        if (root == null) return true;
        q.add(root.left);
        q.add(root.right);
        while (q.size() > 1) {
            TreeNode left = q.poll();
            TreeNode right = q.poll();
            if (left == null && right == null) {
                continue;
            }
            if (left == null ^ right == null) {
                return false;
            }
            if (left.val != right.val) {
                return false;
            }
            q.add(left.left);
            q.add(right.right);
            q.add(left.right);
            q.add(right.left);
        }
        return true;
    }
}
```
