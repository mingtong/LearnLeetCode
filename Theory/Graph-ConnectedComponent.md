### 图的连通量

#### 概念点
- 在无向图G中，若从顶点 v 到顶点 w 有路径(当然从vj到vi也一定有路径)，则称v和 w 是连通的。 
- 若图 G 中任意两个不同的顶点 v 和 w 都连通(即有路径)，则称G为连通图。 
- 无向图 G 的极大连通子图称为 G 的最强连通分量。
- 任何连通图的连通分量只有一个，即是其自身。
- 非连通的无向图有多个连通分量。

可以用 DFS 查找所有连通分量：
``` Java
class CC {
    private boolean[] marked;   // 标记 marked[v]
    private int[] id;           // id[v] 即连通分量的id
    private int[] size;         // size[id] 即连通分量中的顶点数量
    private int count;          // 连通分量的数量
    public CC(Graph G) {
        marked = new boolean[G.V()];
        id = new int[G.V()];
        size = new int[G.V()];
        for (int v = 0; v < G.V(); v++) {
            if (!marked[v]) {
                dfs(G, v);
                count++;
            }
        }

    private void dfs(Graph G, int v) {
        marked[v] = true;
        id[v] = count;
        size[count]++;
        for (int w : G.adj(v)) {
            if (!marked[w]) {
                dfs(G, w);
            }
        }
    }

    public boolean connected(int v, int w) {
        return id(v) == id(w);
    }

    public int id(int v) {
        return id[v];
    }
}
```

图解流程如下：

![](https://img-blog.csdn.net/20171107001045734?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

