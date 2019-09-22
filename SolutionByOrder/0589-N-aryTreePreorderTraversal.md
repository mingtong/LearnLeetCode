## N-ary Tree Preorder Traversal
Easy

#### 描述： 
Given an n-ary tree, return the preorder traversal of its nodes' values.
For example, given a 3-ary tree:

```
![img](https://assets.leetcode.com/uploads/2018/10/12/narytreeexample.png)
```
Return its preorder traversal as: [1,3,5,6,2,4].


#### 思路：

前序遍历n叉树

#### 迭代实现代码：
``` C#
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node(){}
    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
}
*/
public class Solution {
    public IList<int> Preorder(Node root) {
        IList<int> result = new List<int>();
        
        if(root == null){
            return result;
        }
        
        Stack<Node> q = new Stack<Node>();
        q.Push(root);
        
        while(q.Count > 0){
            Node tmp = q.Pop();
            result.Add(tmp.val);
            //need to push to stack with the reversed the order  
            for(int i = tmp.children.Count-1; i >=0; i--){
                q.Push(tmp.children[i]);
            }
            
        }
        
        return result;
    }
}
```

#### 总结：

- 在入栈时需要用逆序的子结点


