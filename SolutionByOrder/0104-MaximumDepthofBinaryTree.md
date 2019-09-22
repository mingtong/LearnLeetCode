## Maximum Depth of Binary Tree
Easy

#### 描述： 
Given a binary tree, find its maximum depth.
The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
Note: A leaf is a node with no children.

Example:

Given binary tree [3,9,20,null,null,15,7]

```
    3
   / \
  9  20
    /  \
   15   7
```

return its depth = 3.


#### 思路：

递归实现

#### 实现代码：
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
    fun maxDepth(root: TreeNode?): Int {
        var h = 0;
        if(root == null){
            return h;
        }
       
        h = Math.max(maxDepth(root.left), maxDepth(root.right));
        return h + 1;
    }
}
```

#### 总结：

- 


