## DFS

**DFS**：Depth First Search，深度优先搜索，基于[**Tremaux Tree**](https://en.wikipedia.org/wiki/Trémaux_tree)。

走迷宫的过程：
1. 选择一条没有标记过的通道，在走过的路上铺一条绳子。
2. 标记所有你第一次路过的路口和通道。
3. 当到达一个标记过的路口时（用绳子）回退到上个路口。
4. 当回退到的路口已经没有可走的通道时继续回退。 
5. 绳子可以保证你总能找到一条出路，标记则能保证你不会两次经过同一条通道或同一个路口。

遍历的具体实现思路是：用一个递归方法遍历所有顶点，在访问其中一个顶点时：
- 将这个顶点标记为已访问的（marked）。
- 递归地访问这个顶点所有没有被标记过的邻接顶点。
- 类似树的前序遍历。

代码如下：
``` C#
class DFS
{
    private bool[] marked;
    private int count;
    public DFS(Graph g, int s)
    {
        marked = new bool[g.V()];
        dfs(g, s);
    }
    private void dfs(Graph g, int v)
    {
        marked[v] = true;
        count++;
        foreach(int w in g.adj(v))
        {
            if(!marked[w])
            {
                dfs(g, w);
            }
        }
    }
    public bool marked(int w)
    {
        return marked[w];
    }
    public int count()
    {
        return count;
    }
}
```

图解流程：

![](https://img-blog.csdn.net/20171106225629423?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

图的相关概念：
- **连通性**：给定一幅图，可以用 DFS 算法回答“两个给定的顶点是否连通”，“图中有多少连通子图”等问题。 
- **单点路径**：给定一幅图，给出其中一个顶点 s，是否有 顶点 s 到 顶点 v 的一条路径，如果有，找出这条路径。
- **路径查找**：下面的代码实现了路径的查找，主要是扩展了 DFS 的代码，添加了一个变量 edgeTo[] 整型数组，作为用于搜索的绳子。这个数组可以找到每个与顶点 s 连通的顶点再回到顶点 s 的路径，可以记住每个顶点到起点的路径，而不是记录当前顶点到起点的路径。

路径查找的图解示例：
![](https://img-blog.csdn.net/20171106225447492?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

实现代码如下：
``` C#
class DFSPaths
{
    private bool[] marked;//
    private int[] edgeTo; //
    private final int s; //起点
    public DFSPaths(Graph g, int s)
    {
        marked = new bool[g.V()];
        edgeTo = new int[g.V()];
        this.s = s;
        dfs(g, s);
    }
    private void dfs(Graph g, int v)
    {
        marked[v] = true;
        foreach(int w in g.adj(v))
        {
            if(!marked[w])
            {
                edgeTo[w] = v;
                dfs(g, w);
            }
        }
    }
    public bool hasPathTo(int v)
    {
        return marked[v];
    }
    public List<int> pathTo(int v)
    {
        if(!hasPathTo(v))
        {
            return null;
        }
        Stack<int> path = new Stack<int>();
        foreach(int x = v; x != s; x = edgeTo[x])
        {
            path.push(x);
        }
        path.push(s);
        return path;
    }
}
```
图解如下：

![](https://img-blog.csdn.net/20171106225423413?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

            
