### 最短路径

#### 概念点：
- **最短路径**：从图中的一个顶点到另一个顶点的成本最小的路径。 
- **单点最短路径**：在加权有向图中，给出一个起点 s，找到是否有一条到顶点 v 的路径，如果有，找出权重最小的那条。

![](https://algs4.cs.princeton.edu/44sp/images/shortest-path.png)

#### 最短路径的性质：
- 路径是有向的。
- 权重不定表示距离。
- 并不是所有顶点都是可达的。
- 负权重会使问题变复杂。
- 最短路径一般都是简单的（不含零权重边的环）。
- 最短路径不定是唯一的。
- 可能存在平行边和自环。平行边中权重最小的才会被选中。也不包含自环（除非自环的权重为零)

#### 最短路径树（SPT）：
在加权有向图中，有一个顶点 s，以 s 为起点的最短路径树是图的一幅子图，包含 s 和从 s 到达的所有顶点。
这棵树的根结点是 s，树的每条路径都是有向图中的一条最短路径。

![](https://img-blog.csdn.net/20171109084514989?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

#### 加权有向边的数据结构：
``` Java
public class DirectedEdge {
    private final int v; // edge source
    private final int w; // edge target
    private final double weight; // edge weight

    public DirectedEdge(int v, int w, double weight) {
        this.v = v;
        this.w = w;
        this.weight = weight;
    }

    public double weight() {
        return weight;
    }

    public int from() {
        return v;
    }

    public int to() {
        return w;
    }

    public String toString() {
        return String.format("%d->%d %.2f", v, w, weight);
    }
}
```

#### 加权有向图的数据结构：
``` Java
public class EdgeWeightedDigraph {
    private final int V; // number of vertices
    private int E; // number of edges
    private Bag<DirectedEdge>[] adj; // adjacency lists

    public EdgeWeightedDigraph(int V) {
        this.V = V;
        this.E = 0;
        adj = (Bag<DirectedEdge>[]) new Bag[V];
        for (int v = 0; v < V; v++) {
            adj[v] = new Bag<DirectedEdge>();
        }
    }

    public int V() {
        return V;
    }

    public int E() {
        return E;
    }

    public void addEdge(DirectedEdge e) {
        adj[e.from()].add(e);
        E++;
    }

    public Iterable<Edge> adj(int v) {
        return adj[v];
    }

    public Iterable<DirectedEdge> edges() {
        Bag<DirectedEdge> bag = new Bag<DirectedEdge>();
        for (int v = 0; v < V; v++) {
            for (DirectedEdge e : adj[v]) {
                bag.add(e);
            }
        }
        return bag;
    }
}
```

如下图所示：

![](https://algs4.cs.princeton.edu/44sp/images/edge-weighted-digraph-representation.png)

最短路径的数据结构图示：

![](https://algs4.cs.princeton.edu/44sp/images/spt.png)

- **最短路径树中的边**：使用一个由顶点索引的DirectedEdge对象的父连接数组edgeTo[]，edgeTo[v] 的值是树中连接 v 和它的父结点的边（也是 s 到 v 的最短路径上的最后一条边。edgeTo[s] = null;
- **到达起点的距离**：一个由顶点索引的数组 distTo[]，其中 distTo[v] 是从 s 到 v 的已知最短路径的长度。distTo[s] = 0;

#### 边的松驰（Relaxation） 
- 定义：要放松（relax）一条边 v->w，意味着检查从 s 到 w 的最短路径是否是先从 s 到 v，然后从 v 到 w，如果是，则更新数据结构的内容。

``` Java
    private void relax(DirectedEdge e) {
        int v = e.from();
        int w = e.to();
        if (distTo[w] > distTo[v] + e.weight()) {
            distTo[w] = distTo[v] + e.weight();
            edgeTo[w] = e;
        }
    }
```

#### 边的松驰的两种情况： 
- 一种是边失效，不更新数据。图左。 
- 一种是 v -> w 就是到达 w 的最短路径。图右。

![](https://algs4.cs.princeton.edu/44sp/images/relaxation-edge.png)

#### 顶点的松驰（Relaxation） 
- 顶点的松驰即是放松一个顶点的所有出边。
``` Java
    private void relax(EdgeWeightedDigraph G, int v) {
        for (DirectedEdge e : G.adj(v)) {
            int w = e.to();
            if (distTo[w] > distTo[v] + e.weight()) {
                distTo[w] = distTo[v] + e.weight();
                edgeTo[w] = e;
            }
        }
    }
```
如下图所示：

![](https://img-blog.csdn.net/20171109090442115?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)



