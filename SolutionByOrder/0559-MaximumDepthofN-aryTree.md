## Maximum Depth of N-ary Tree
Easy

#### 描述： 
Given a n-ary tree, find its maximum depth.
The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
For example, given a 3-ary tree:

<img src="https://assets.leetcode.com/uploads/2018/10/12/narytreeexample.png" width="400">

We should return its max depth, which is 3.
The depth of the tree is at most 1000.
The total number of nodes is at most 5000.

#### 思路：

递归求高度，并累加

#### 递归实现代码：
``` C#
/*
// Definition for a Node.
class Node {
    public int val;
    public List<Node> children;

    public Node() {}

    public Node(int _val,List<Node> _children) {
        val = _val;
        children = _children;
    }
};
*/
public class Solution {
    public int MaxDepth(Node root) {
        if(root == null){
            return 0;
        }
        
        int result = 0;
        foreach(Node n in root.children){
            int v = MaxDepth(n);
            result = Math.Max(v, result);
        }
        return result + 1;
    }
}
```

#### 总结：

- 


