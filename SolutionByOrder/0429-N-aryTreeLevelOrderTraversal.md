## N-ary Tree Level Order Traversal
Easy

#### 描述： 
Given an n-ary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).
For example, given a 3-ary tree:

<img src="https://assets.leetcode.com/uploads/2018/10/12/narytreeexample.png" width="400">

We should return its level order traversal:
 ```
[
     [1],
     [3,2,4],
     [5,6]
]
```

#### 思路：



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
    public IList<IList<int>> LevelOrder(Node root) {
        IList<IList<int>> result = new List<IList<int>>();
        
        if(root == null)
        {
            return result;
        }
        
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);
        
        while(q.Count > 0)
        {
            List<int> list = new List<int>();
            int size = q.Count;
            for(int i = 0; i < size; i++)
            {
                Node temp = q.Dequeue();
                list.Add(temp.val);
                foreach(Node n in temp.children)
                {
                    q.Enqueue(n);
                } 
            }
            result.Add(list);
        }
        
        return result;
    }
}
```

#### 总结：

- 


