## Search in a Binary Search Tree
Easy

#### 描述： 
Given the root node of a binary search tree (BST) and a value. You need to find the node in the BST that the node's value equals the given value. Return the subtree rooted with that node. If such node doesn't exist, you should return NULL.

For example, 

```
Given the tree:
        4
       / \
      2   7
     / \
    1   3

And the value to search: 2
```
In the example above, if we want to search the value 5, since there is no node with value 5, we should return NULL.
Note that an empty tree is represented by NULL, therefore you would see the expected output (serialized tree format) as [], not null.

#### 思路：

标准的二叉树查找

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
    fun searchBST(root: TreeNode?, `val`: Int): TreeNode? {
        if(root == null){
            return null;
        }
        if(root.`val` == `val`){
            return root;
        } else if (root.`val` < `val`){
            return searchBST(root.right, `val`);
        } else {
            return searchBST(root.left,`val`);
        }
        return null;
    }
}
```
