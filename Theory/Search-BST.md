## 二叉搜索树

二叉查找树有链表的快速插入的优点，以及符号表快速查找的优点。 

二叉查找树的性质是这样的：
- 每个结点的 key 都大于其左结点的 key，小于其右结点的 key。
- 按值从小到大遍历二叉树即是中序遍历。

二叉查找树的查找操作：
- 如果树是空的，则返回null。
- 如果被查找的 key 和根结点的键相待，查找命中。
- 否则就递归地子树中继续查找。
- 如果被查找的 key 小于当前结点，就选择左子树，反之选择右子树。

![](https://algs4.cs.princeton.edu/32bst/images/bst-search.png)

基于二叉查找树的符号表的定义：
```
public class BST
{
    private Node root;
    private class Node
    {
        private int key;
        public int val;
        private Node left;
        private Node right;
        private int N; //以该结点为根结点的子树中的结点总数
        public Node(int key, int value, int N)
        {
            this.key = key;
            this.val = value;
            this.N = N;
        }
    }
    //查找
    public int get(Node root, int key)
    {
        if(root == null)
        {
            return -1;
        }
        if(key < root.key)
        {
            return get(root.left, key);
        }
        else if(key > root.key)
        {
            return get(root.right, key);
        }
        else
        {
            return root.val;
        }
    }
    //插入结点
    public void put(Node node, int key, int value)
    {
        if(node == null)
        {
            return new Node(key, value, 1);
        }
        if(key < root.key)
        {
            node.left = put(node.left, key, val);
        }
        else if(key > root.key)
        {
            node.right = put(node.right, key, val);
        }
        else
        {
            node.val = val;
        }
        return node;
    }
}
```

下图是插入过程：
![](https://algs4.cs.princeton.edu/32bst/images/bst-insert.png)

#### 分析： 
二叉查找树的运行时间取决于树的形状，而树的形状取决于 key 被插入的顺序。理想情况下，含有N个结点的树是完全平衡的，每个空结点到根结点的距离都是~lgN，而最坏情况下，距离可能是N。

#### 删除操作： 
删除一个有两个子结点的结点 x 的思路是用它的后继结点替换它的位置： 
1. 查找删除结点右子树中最小的那个值，也就是右子树中位于最左方的那个结点。然后将这个结点的值的父节点记录下来。并且将该节点的值赋给我们要删除的结点。也就是覆盖。 
2. 然后将右子树中最小的那个结点进行删除。

#### 如下图： 
![](https://algs4.cs.princeton.edu/32bst/images/bst-delete.png)

删除代码如下：
```
public Node delete(Node x, int key)
{
    if(x == null)
    {
        return null;
    }
    if(key < x.key)
    {
        delete(x.left, key);
    }
    else if(key > x.key)
    {
        delete(x.right, key);
    }
    else
    {
        if(x.right == null)
        {
            return x.left;
        }
        if(x.left == null)
        {
            return x.right;
        }       
        Node t = x;
        x = min(t.right); //找到t的右子树中的最小结点, 覆盖x
        x.right = deleteMin(t.right); //x的右链接指向删除t的右子树中的最小结点后的结点
        x.left = t.left; //x的左链接指向t的左子树
    }
    return x;
}
```
