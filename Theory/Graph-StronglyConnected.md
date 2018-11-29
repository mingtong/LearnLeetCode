## 有向图的强连通

#### 概念：
- 在有向图中，如果两个顶点 v 和 w 是互相有向的，则称它们是强连通的。 
- 在有向图中，如果任意两个顶点都是互相有向的，则称这幅图是强连通图。 

所以有以下命题：
- 任意顶点 v 和自身也是强连通的。
- 如果 v 和 w 强连通的，则 w 和 v 也是强连通的。
- 如果 v 和 w 强连通，w 和 x 强连通，则 v 和 x 也是强连通的。

强连通性将所有顶点分成了一些平等的部分，每个部分都是由 相互为强连通的顶点 的最大子集 组成。这些子集叫作 **强连通分量**。
强连通分量的定义基于顶点，而不是边。

![](https://img-blog.csdn.net/20171108225401294?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

上图是有向图中的强连通分量

![](https://img-blog.csdn.net/20171108225626727?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

上图是表示食物链的有向图的一个子集

使用 DFS 查找有向图 G 中的反向图 G<sup>R</sup>，得到所有顶点的反向后序，再次使用 DFS 处理有向图 G（Kosaraju算法）。
构造函数的每一次递归调用所标记的顶点都在同一个强连通分量中。

**Kosaraju 算法**的实现：
``` Java
public class KosarajuSCC {
    private boolean[] marked; // reached vertices
    private int[] id; // component identifiers
    private int count; // number of strong components

    public KosarajuSCC(Digraph G) {
        marked = new boolean[G.V()];
        id = new int[G.V()];
        DepthFirstOrder order = new DepthFirstOrder(G.reverse());
        foreach( int s in order.reversePost())
        {
            if (!marked[s]) {
                dfs(G, s);
                count++;
            }
        }
    }

    private void dfs(Digraph G, int v) {
        marked[v] = true;
        id[v] = count;
        foreach( int w in G.adj(v))
        {
            if (!marked[w]) {
                dfs(G, w);
            }
        }
    }

    public boolean stronglyConnected(int v, int w) {
        return id[v] == id[w];
    }

    public int id(int v) {
        return id[v];
    }

    public int count() {
        return count;
    }
}
```
算法的图解过程如下：

![](https://img-blog.csdn.net/20171108230703857?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)



