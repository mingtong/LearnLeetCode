## 图的表示

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
