## UnionFind (Disjoint Set)

Union Find，也叫作 Disjoint Set，中文通常译作 “并查集”。 
Union Find 有两种操作：Union 和 Find，即“连接”和“查找”。

并查集用于：一个集合被分成几组的情况，集合中的每个数据只属于一个单独的组，无向图的连通分量就是这样一个例子。
如下图：

![](https://img-blog.csdn.net/20171125182934247?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

1~9 的集合中的 3 个连通分量，或者说 3 个 Disjoint Set。

Disjoint Set 数据结构可以快速地判断集合中的两个元素是否属于同一个分组，(或者说判断 两个顶点是不是在一个连通分量中)。还可以快速地连通（unite）两个分组（或者说把两个连通分量连成一个连通分量）。

在最简单的形式中，集合就是一个整数数组，然后用另一个同样大小的数组表示各项的父元素。 
如下图：
![](https://img-blog.csdn.net/20171125185348620?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

两棵树分别都是 disjoint set。

如果两个元素在同一棵树上，则属于同一个 disjoint set。 
每个树的根结点叫作这个set的“代表”，每个set永远都有一个唯一的“代表”。如果第 i 个元素是“代表”，则 parent[i] = i。如果如果第 i 个元素不是“代表”，则可以顺着其父元素找到“代表”。也即 Find() 操作：

``` C#
public int Find(int i) 
{
    if (Parent[i] == i) 
    {
        return i;
    }
    else 
    { 
        return Find(Parent[i]);
    }
}
```

而 Union 操作的入参是两个数值，分别用 Find() 操作找到这两个数值所在 set 的“代表”，然后把其中一棵树挂在另一棵树的 Root 结点上，
如下图：

![](https://img-blog.csdn.net/20171125190622688?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

注意：
哪棵树挂在哪棵树上是无所谓的。 
所以也可以是下面这样：

![](https://img-blog.csdn.net/20171125190809581?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

Union 操作的实现如下：
``` C#
public void Union(int i, int j) 
{
    // 先分别找到两个数值的“代表”
    int irep = Find(i);   
    int jrep = Find(j);

    // 将 i 的代表指向 j 的代表。
    Parent[irep] = jrep;
}
```

Disjoint Set 的数据类可以封装成这样：
``` C#
public class DisjointSet 
{
    // 集合的元素数量.
    public int Count { get; private set; }
    // 集合的各元素数量的父元素.
    private int[] Parent;
    // 初始化集合.
    public DisjointSet(int count) 
    {
        this.Count = count;
        this.Parent = new int[this.Count];
        // 初始状态下，所有元素都是单独的set.
        for (int i = 0; i < this.Count; i++) 
        {
            this.Parent[i] = i;
        }
    }
}
```
还可以优化一下树的高度，有两种方式：

- 路径压缩：通过在Find过程中插入一个缓存机制:
``` C#
public int Find(int i) 
{
    if (Parent[i] == i) 
    {
        return i;
    }
    else 
    { 
        int result = Find(Parent[i]);
        // 可以通过把 i 移动到集合的“代表”下，以缓存结果 
        Parent[i] = result;
        return result;
    }
}
```

如下图所示：

![](https://img-blog.csdn.net/20171125192701013?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)


- Union by Rank 
添加一个同样 size 的数组，叫作 rank，如果第 i 个元素就是“代表”，则 rank[i] 就是代表树的高度:
``` C#
private int[] Rank;
public DisjointSet(int count) 
{
    this.Count = count;
    this.Parent = new int[this.Count];
    this.Rank = new int[this.Count];
    for (int i = 0; i < this.Count; i++) 
    {
        this.Parent[i] = i;
        this.Rank[i] = 0;
    }
}
```
前面提到过，当我们合并两个set或者说两棵树时，顺序是无所谓的，
我们称丙个set是 左树 和 右树，如果 左树的 rank 小于 右树的 rank，那么最好把左树放在右树下，这样高度不变，反之一样。 
如下图：
![](https://img-blog.csdn.net/20171125193344562?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

实现：
``` C#
public void Union(int i, int j) 
{
    int irep = this.Find(i);
    int jrep = this.Find(j);
    irank = Rank[irep];
    jrank = Rank[jrep];
    if (irep == jrep){
        return;
    }
    if (irank <= jrank) 
    {
        this.Parent[irep] = jrep;

    }
    else if (jrank < irank) 
    {
        this.Parent[jrep] = irep;

    }
}
```

#### 参考资料：
> - http://www.mathblog.dk/disjoint-set-data-structure/ 
> - https://www.hackerearth.com/zh/practice/notes/disjoint-set-union-union-find/ 
> - https://en.wikipedia.org/wiki/Disjoint-set_data_structure
