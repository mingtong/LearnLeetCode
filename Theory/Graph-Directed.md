### 有向图

在有向图中，边是有方向的（单向的）。

#### 概念点
  - **出度**：在有向图中，一个顶点的出度为该顶点指出的边的总数。 
  - **入度**：在有向图中，一个顶点的出度为指向该顶点的边的总数。 
  - **表示**：用 v->w 来表示 一条由 v 指向 w 的边。v 与 w 也可能是双向的。
  
代码定义：
``` C#
public class Digraph
{
    private final int V;
    private int E;
    private Bag<int>[] adj;
    public Digraph(int V)
    {
        this.V = V;
        this.E = 0;
        adj = (Bag<int>[]) new Bag[V];
        for (int v = 0; v < V; v++)
        {
            adj[v] = new Bag<int>();
        }
    }
    public int V() { return V; }
    public int E() { return E; }
    public void addEdge(int v, int w)
    {
        adj[v].add(w);
        E++;
    }
    public List<int> adj(int v)
    { 
        return adj[v]; 
    }
    public Digraph reverse()
    {
        Digraph R = new Digraph(V);
        for (int v = 0; v < V; v++)
        for (int w : adj(v))
        R.addEdge(w, v);
        return R;
    }
}
```

图解流程：
![](https://img-blog.csdn.net/20171107221250348?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

#### 可达性
要理解无向图中的 连通性 与 有向图中的 可达性 的区别。
DFS 本质上是一种适用于处理有向图的算法，每条边都只会被表示一次。 

下面的代码实现了从给定的一个点找到能够到达的其他顶点：
``` C#
public DirectedDFS(Digraph G, int s) 
{
    marked = new boolean[G.V()];
    validateVertex(s);
    dfs(G, s);

    public DirectedDFS(Digraph G, List<int> sources) {
        marked = new boolean[G.V()];
        for (int v : sources) 
        {
            if (!marked[v]) 
            {
                dfs(G, v);
            }
        }
    }

    private void dfs(Digraph G, int v) { 
        count++;
        marked[v] = true;
        for (int w : G.adj(v)) 
        {
            if (!marked[w]) 
            {
                dfs(G, w);
            }
        }
    }
    public boolean marked(int v) {
        return marked[v];
    }
}
```

#### 垃圾回收（GC）算法中的 “标记-清除”
在 .NET 以及 JAVA 的内存管理系统中，用一个顶点表示一个对象，用一边条表示这个对象对其他对象的引用，这样可以用有向图在合适的时机运行 DirectedDFS 以判断是否可以执行回收。
下图描述了用DFS查找有向图中从顶点0 能够到达的所有顶点的轨迹：

![](https://img-blog.csdn.net/20171108085823173?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)



