## N-ary Tree Postorder Traversal
Easy

#### 描述： 
Given an n-ary tree, return the postorder traversal of its nodes' values.
For example, given a 3-ary tree:

<img src="https://assets.leetcode.com/uploads/2018/10/12/narytreeexample.png" width="400">

Return its postorder traversal as: [5,6,3,2,4,1].
#### 思路：

后叉遍历n叉树

#### 迭代实现代码：
``` c#
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
   
    public IList<int> Postorder(Node root) {
        List<int> result = new List<int>();
        if(root == null)
        {
            return result;
        }
        
        Stack<Node> stack1 = new Stack<Node>();
        Stack<Node> stack2 = new Stack<Node>();
        stack1.Push(root);
        
        while(stack1.Count > 0)
        {
            Node n = stack1.Pop();
            stack2.Push(n);
            
            foreach(Node node in n.children)
            {
                stack1.Push(node);
            }
        }
        while(stack2.Count > 0)
        {
            result.Add(stack2.Pop().val);
        }
        return result;
    }
}
```

#### 总结：


