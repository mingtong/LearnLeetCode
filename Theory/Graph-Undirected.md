## 无向图

图由 **边（Edge）** 和 **顶点(Vertex)** 组成：
- 一般用 0 到 V-1 来表示 V 个顶点组成的图中的各个顶点。
- 一般用 v-w 来表示连接顶点 v 到 顶点 w 的边。

![](https://algs4.cs.princeton.edu/41graph/images/graph.png)

#### 图的相关术语
- 特殊的图：
  - 自环：有一条边连接一个顶点和其自身。英文称作：self-loop。
  - 平行边：有两条边连接同样的同个顶点。英文称作：parallel。
- **多重图**：含有平行边的图。 
- **简单图**：不含平行边或自环的图。 
- **相邻**：两个顶点由一条边相连，则说这两个顶点相邻（adjacent）。而这条边认为是依附（incident）于这两个顶点。 
- **度数**：顶点的度数（degree）即依附于它的边的数量。 
- **子图**：一幅的边及相连接的顶点的一个子集组成的图，特别是顺序连接一系列顶点的边组成的子图。英文称作：subgraph。 
- **路径**：由边顺序连接的一系列顶点。英文称作：path。 
- **简单路径**：没有重复顶点的路径。英文称作：simple path。 
- **环**：至少含有一条边且起点和终点相同的一条路径。英文称作 circle。 
- **简单环**：不含有重复顶点和边的环。英文称作 simple circle。 
- **路径或环的长度**：路径或环包含的边的数量。 
- **两个顶点连通**：当两个顶点之间存在一条连通的路径时，称这两个顶点是连通的。英文称作：connected。 
- **连通图**：如果任意两个顶点都存在一条连通路径，则这幅图是连通图。

![](https://algs4.cs.princeton.edu/41graph/images/graph-anatomy.png)

- **非连通图**：由若于个极大连通子图组成。 
- **路径的表示**：用 u-v-w-x 表示 u 到 x 的一条路径。 
- **环的表示**：用 u-v-w-x-u 表示 u 到 u 的一条环。 
- **无环图**：不包括环的图。英文称作：acyclic graph。 
- **森林**：树是一个无环连通图，互不相连的树组成的集合叫作 森林。英文称作："disjoint set of trees"。

![](https://algs4.cs.princeton.edu/41graph/images/tree.png)

- **生成树**：边通图的生成树（spanning tree ）是它的一幅子图。它含有图中的所有顶点，且是一棵树。 
- **生成树森林**：图的所有连通子图的生成树（union of the spanning trees ）的集合。

![](https://algs4.cs.princeton.edu/41graph/images/forest.png)


- **图–>树**：
  - 当 V 个顶点的图 G 满足以下5个条件之一时，就是一棵树：
    - G 有 V-1 条边且不含有环。
    - G 有 V-1 条边且是连通的。
    - G 是连通的，但删除任意一条边都会使它不再连通。
    - G 是无环图，但添加任意一条边都会产生一条环。
    - G 中的任意一对顶点之间仅存在一条简单路径。
  
- **图的密度**：已经连接的顶点 对 所有可能被连接的顶点 的比例。 
- **稀疏图**：连接的 顶点对 很少。 
- **稠密图**：只有少部分顶点对 之间没有边连接。 
- **二分图**：将所有顶点分成两部分的图，使图的每条边所连接的两个顶点都分别属于不同的部分。

#### 图类要实现的接口
- Graph(int v)，构造一个含有 V 个顶点但不含边的图。
- int V()，返回顶点数。
- int E()，返回边数。
- addEdge(int v, int w)，返回连接 v-w 的一条边。
- int[] adj(int v)，返回与 v 相邻的所有顶点。
- int degree(Graph g, int v)，返回 v 的度数。
- int maxDegree(Graph g)，计算所有顶点的具有最大度数的度数。
- avgDegree(Graph g)，返回所有顶点的平均度数。
- numberOfSelfLoops(Graph g)，返回自环的个数。

#### 图的表示
**邻接表数组** adjacency-lists
以顶点为索引的数组，其中的每个元素都是与该顶点相邻的顶点列表。**适合非稠密图**。 
如下图是图的结点：

![](https://algs4.cs.princeton.edu/41graph/images/graph.png)

下面是结点存储方式：

![](https://algs4.cs.princeton.edu/41graph/images/adjacency-lists.png)

``` C#
public class Graph {
    private final int V;
    private int E;
    private Bag<Integer>[] adj; //邻接点的集合，Bag是链表。
    public Graph(int V) {
        this.V = V;
        this.E = 0;
        adj = (Bag<Integer>[]) new Bag[V];
        for (int v = 0; v < V; v++) {
            adj[v] = new Bag<Integer>();
        }
    }
    public int V() {
        return V;
    }
    public int E() {
        return E;
    }
    //添加一条边
    public void addEdge(int v, int w) {
        validateVertex(v);
        validateVertex(w);
        E++;
        adj[v].add(w);
        adj[w].add(v);
    }
    //与 v 相邻的所有顶点
    public Iterable<Integer> adj(int v) {
        validateVertex(v);
        return adj[v];
    }
}
```
