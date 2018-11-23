### 最小生成树

#### 概念点
- **加权图**：为每条边关联一个权值或者说成本的图模型。 
- **图的生成树**：含有图的所有顶点的无环连通子图。 
- **最小生成树**：加权无向图的最小生成树（MST）是它的一棵权值最小（所有边的权值之和）的生成树。 


下图是加权无向图与它的最小生成树。

![](https://algs4.cs.princeton.edu/43mst/images/mst.png)

最小生成树有两个经典算法：
- Prim 算法
- Kruskal 算法

如果一幅图是非连通的，则只能用这个算法计算所有连通分量的最小生成树，合并在一起叫做**最小生成森林**。

还有几点要注意的：
- 边的权重未必是距离。
- 边的权重可能小于等于 0。
- 所有边的权重都可能相同也可能不相同。

两个性质：
- 用一条边连接树中的任意两个顶点都会产生一个新的环。 

![](https://algs4.cs.princeton.edu/43mst/images/tree-add-edge.png)

- 从树中删去一条边可以得到两棵独立的树。 

![](https://algs4.cs.princeton.edu/43mst/images/tree-add-edge.png)

图的一种切分是把图的所有顶点分为两个 **非空** 且 **不重复** 的集合。横切片是一条连接两个属于不同集合的边。

通常，我们指定一个顶点集，然后隐式地认为它的补集是另一个顶点集。 
给定任意的切分，它的横切边中的权重最小者必然属于图的最小生成树。 
假设所有边的权重不相同，则每幅连通图都只有唯一的最小生成树。

贪心算法得到最小生成树：

![](https://algs4.cs.princeton.edu/43mst/images/mst-greedy.png)

### 带权重的边的数据结构：

``` Java
public class Edge implements Comparable<Edge> {
    private final int v; // one vertex
    private final int w; // the other vertex
    private final double weight; // edge weight

    public Edge(int v, int w, double weight) {
        this.v = v;
        this.w = w;
        this.weight = weight;
    }

    public double weight() {
        return weight;
    }

    public int either() {
        return v;
    }

    public int other(int vertex) {
        if (vertex == v) {
            return w;
        } else if (vertex == w) {
            return v;
        } else {
            throw new RuntimeException("Inconsistent edge");
        }
    }

    public int compareTo(Edge that) {
        if (this.weight() < that.weight()) {
            return -1;
        } else if (this.weight() > that.weight()) {
            return +1;
        } else {
            return 0;
        }
    }

    public String toString() {
        return String.format("%d-%d %.2f", v, w, weight);
    }
}
```

#### 加权无向图的数据结构：
``` Java
public class EdgeWeightedGraph {
    private final int V; // number of vertices
    private int E; // number of edges
    private Bag[] adj; // adjacency lists

    public EdgeWeightedGraph(int V) {
        this.V = V;
        this.E = 0;
        adj = (Bag<Edge>[]) new Bag[V];
        for (int v = 0; v < V; v++) {
            adj[v] = new Bag<Edge>();
        }
    }

    public int V() {
        return V;
    }

    public int E() {
        return E;
    }

    public void addEdge(Edge e) {
        int v = e.either(), w = e.other(v);
        adj[v].add(e);
        adj[w].add(e);
        E++;
    }

    public Iterable<Edge> adj(int v) {
        return adj[v];
    }

    public Iterable<Edge> edges() {
        Bag<Edge> list = new Bag<Edge>();
        for (int v = 0; v < V; v++) {
            int selfLoops = 0;
            foreach(Edge e in adj(v))
            {
                if (e.other(v) > v) {
                    list.add(e);
                }
                // only add one copy of each self loop (self loops will be consecutive)
                else if (e.other(v) == v) {
                    if (selfLoops % 2 == 0) list.add(e);
                    selfLoops++;
                }
            }
        }
        return list;
    }
}
```

#### Prim算法

Prim算法能够得到任意加权无向图的最小生成树。 
每一步都会为成长中的树加一条边。

Lazy实现：

![](https://algs4.cs.princeton.edu/43mst/images/prim-lazy.png)

Eager实现：

![](https://algs4.cs.princeton.edu/43mst/images/prim-eager.png)

#### Kruskal 算法

Kruskal 算法的思想是按照边的权重顺序（从小到大）加入到树中，加入的边不会构成环。
![](https://algs4.cs.princeton.edu/43mst/images/kruskal.png)


