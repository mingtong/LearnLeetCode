##  Invert Binary Tree
Easy

#### 描述： 
Invert a binary tree.

Input:
```
     4
   /   \
  2     7
 / \   / \
1   3 6   9
```
Output:
```
     4
   /   \
  7     2
 / \   / \
9   6 3   1
```

#### 思路：



#### 迭代实现代码：
``` kotlin
/**
 * Example:
 * var ti = TreeNode(5)
 * var v = ti.`val`
 * Definition for a binary tree node.
 * class TreeNode(var `val`: Int) {
 *     var left: TreeNode? = null
 *     var right: TreeNode? = null
 * }
 */
class Solution {
    fun invertTree(root: TreeNode?): TreeNode? {
        if(root == null){
            return null;
        }
        var tmp = invertTree(root.left);
        root.left = invertTree(root.right);
        root.right = tmp;
        
        return root;
    }
}
```

#### 总结：

- 


