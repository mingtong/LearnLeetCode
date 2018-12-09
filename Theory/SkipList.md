## SkipList

1989 William Pugh, a computer science professor at the University of Maryland.
让一个有序链表的节点有两个指针，其中一个指针指向更远的结点，如下图：

![](https://docs.microsoft.com/zh-cn/previous-versions/images/ms379573.datastructures_guide4-fig11%28en-us%2cvs.80%29.gif)

有两个特点：
- 让链表有序
- 让结点有不高的高度（假的头结点与最高高度相同）

## 查找的过程

从左向右，假设要找的是Cal，先使用高链接向右找，依次是 head->Bob->Dave->..，按照abc的顺序，当发现Bob的下一个结点是Dave，会意识到已经错过了Cal，这时候需要从Bob用低链接向右开始找，这样寻找的时间就可以减半。

很容易想到，如果增加关键结点的高度，时间可以进一步缩短，如下图:

![](https://docs.microsoft.com/zh-cn/previous-versions/images/ms379573.datastructures_guide4-fig12%28en-us%2cvs.80%29.gif)

Pugh 的思路是如果有8个结点，就把高度定为log<sub>n</sub><sup>8</sup>，n=3。
1. 这样的缺点是，当插入或删除结点时，需要重新设置结点的高度，是个麻烦事儿。
2. 后来Pugh决定随机选择结点来设置高度，但依然是50%的结点高度为1，25%的结点高度为2，12.5%的结点高度为3。
3. 这样查找的速度仍然是og<sub>2</sub><sup>n</sup>。
4. Pugh把它叫做 SkipList。

## SkipList的查找过程
如图：

![](https://docs.microsoft.com/zh-cn/previous-versions/images/ms379573.datastructures_guide4-fig13%28en-us%2cvs.80%29.gif)

## SkipList的插入过程
如图：

![](https://docs.microsoft.com/zh-cn/previous-versions/images/ms379573.datastructures_guide4-fig14%28en-us%2cvs.80%29.gif)

## SkipList的删除过程
如图：

![](https://docs.microsoft.com/zh-cn/previous-versions/images/ms379573.datastructures_guide4-fig15%28en-us%2cvs.80%29.gif)


### 定义结点，Node即是链表结点
``` C#
public class SkipListNode<T> : Node<T>
{
    private SkipListNode() {}   // no default constructor available, must supply height
    public SkipListNode(int height)
    {
        base.Neighbors = new SkipListNodeList<T>(height);
    }

    public SkipListNode(T value, int height) : base(value)
    {
        base.Neighbors = new SkipListNodeList<T>(height);
    }

    public int Height
    {
        get { return base.Neighbors.Count; }
    }

    public SkipListNode<T> this[int index]
    {
        get { return (SkipListNode<T>) base.Neighbors[index]; }
        set { base.Neighbors[index] = value; }
    }
}
```

### 定义SkipListNodeList
```C#
public class SkipListNodeList<T> : NodeList<T>
{
    public SkipListNodeList(int height) : base(height) { }

    internal void IncrementHeight()
    {
        // add a dummy entry
        base.Items.Add(default(Node<T>));
    }

    internal void DecrementHeight()
    {
        // delete the last entry
        base.Items.RemoveAt(base.Items.Count - 1);
    }
}
```

### 定义SkipList
``` c#
public class SkipList<T> : IEnumerable<T>, ICollection<T>
{
   SkipListNode<T> _head; //头结点
   int _count; //结点数
   Random _rndNum; //随机变量，用于随机选择结点设置不同的高度
   private IComparer<T> comparer = Comparer<T>.Default;

   protected readonly double _prob = 0.5;

   public int Height
   {
      get { return _head.Height; }
   }

   public int Count
   {
      get { return _count; }
   }

   public SkipList() : this(-1, null) {}
   public SkipList(int randomSeed) : this(randomSeed, null) {}
   public SkipList(IComparer<T> comparer) : this(-1, comparer) {}
   public SkipList(int randomSeed, IComparer<T> comparer)
   {
      _head = new SkipListNode<T>(1);
      _count = 0;
      if (randomSeed < 0)
         _rndNum = new Random();
      else
         _rndNum = new Random(randomSeed);

      if (comparer != null) this.comparer = comparer;
   }

   protected virtual int ChooseRandomHeight(int maxLevel)
   {
      ...
   }

   public bool Contains(T value)
   {
      ...
   }

   public void Add(T value)
   {
      ...
   }

   public bool Remove(T value)
   {
      ...
   }
}
```


### 参考
- > https://docs.microsoft.com/zh-cn/previous-versions/ms379573(v=vs.80)#skip-lists-a-linked-list-with-self-balancing-bst-like-properties
