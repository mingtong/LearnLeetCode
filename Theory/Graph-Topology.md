### 拓扑排序

#### 概念
**拓扑排序**：
一幅有向图，把所有的顶点排序，使所有的有向边都从 排在前面的顶点 指向排在后面的顶点。（或者证明不能做到，比如有环） 
拓扑排序可以用来解决优先级调度的问题。（前后顶点有依赖关系） 

比如下面的课程学习顺序：

![](https://img-blog.csdn.net/20171108091234939?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

比如 任务x 必须在 任务y 之前完成， 任务y 必须在 任务z 之前完成，但 任务z 必须在 任务x 之前完成，这肯定是图中有环，这样就无法完成拓扑排序了。

![](https://img-blog.csdn.net/20171108091300128?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/300/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

所以首先要检查有向图中是否有环才能进行拓扑排序。 
可以用DFS来判断，但找到一条边 v->w 且 w 已经存在于栈中，就找到了环，因为栈表示的是一条由 w 到 v 的有向路径，而 v->w 使它成环。如果找不到，就说明无环。

![](https://img-blog.csdn.net/20171108091342525?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

代码如下：
``` Java
public class DirectedCycle {
    private boolean[] marked;        // 
    private int[] edgeTo;            //
    private boolean[] onStack;       // 
    private Stack<Integer> cycle;    // 

    public DirectedCycle(Digraph G) {
        marked = new boolean[G.V()];
        onStack = new boolean[G.V()];
        edgeTo = new int[G.V()];
        for (int v = 0; v < G.V(); v++) {
            if (!marked[v] && cycle == null) {
                dfs(G, v);
            }
        }
    }

    private void dfs(Digraph G, int v) {
        onStack[v] = true;
        marked[v] = true;
        for (int w : G.adj(v)) {
            // short circuit if directed cycle found
            if (cycle != null) {
                return;
            }
            // found new vertex, so recur
            else if (!marked[w]) {
                edgeTo[w] = v;
                dfs(G, w);
            }

            // trace back directed cycle
            else if (onStack[w]) {
                cycle = new Stack<Integer>();
                for (int x = v; x != w; x = edgeTo[x]) {
                    cycle.push(x);
                }
                cycle.push(w);
                cycle.push(v);
                assert check();
            }
        }
        onStack[v] = false;
    }

    public boolean hasCycle() {
        return cycle != null;
    }

    public List<int> cycle() {
        return cycle;
    }
}
```

代码的执行流程如下：

![](https://img-blog.csdn.net/20171108091400398?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

#### 算法原理：

有向图的 DFS 对每个顶点只访问一次，有3种常见遍历的顺序来排序顶点：
- 前序：在递归之前将顶点放入队列。
- 后序：在递归之后将顶点放入队列。
- 反向后序：在递归之后将顶点放入栈。 

算法实现如下：
``` Java
public class DepthFirstOrder {
    private boolean[] marked;
    private Queue<int> pre; // vertices in preorder
    private Queue<int> post; // vertices in postorder
    private Stack<int> reversePost; // vertices in reverse postorder

    public DepthFirstOrder(Digraph G) {
        pre = new Queue<Integer>();
        post = new Queue<Integer>();
        reversePost = new Stack<Integer>();
        marked = new boolean[G.V()];
        for (int v = 0; v < G.V(); v++)
            if (!marked[v]) {
                dfs(G, v);
            }
    }

    private void dfs(Digraph G, int v) {
        pre.enqueue(v);
        marked[v] = true;
        foreach( int w in G.adj(v))
        {
            if (!marked[w]) {
                dfs(G, w);
            }
        }
        post.enqueue(v);
        reversePost.push(v);
    }

    public Iterable<Integer> pre() {
        return pre;
    }

    public Iterable<Integer> post() {
        return post;
    }

    public Iterable<Integer> reversePost() {
        return reversePost;
    }
}
```
三种遍历流程的图解如下：

![](https://algs4.cs.princeton.edu/42digraph/images/depth-first-orders.png)

因此，拓扑排序只需要先判断无环，再用反向后序遍历即可得到拓扑排序后的顶点列表:

``` Java
        DirectedCycle finder = new DirectedCycle(G);
        if (!finder.hasCycle()) {
            DepthFirstOrder dfs = new DepthFirstOrder(G);
            order = dfs.reversePost(); //即是排序后的顶点列表
            rank = new int[G.V()];
            int i = 0;
            foreach( int v in order)
            {
                rank[v] = i++;
            }
        }
```

解决任务调度类的应用通常需要3步：
1. 指明任务和优先级条件。
2. 检测环，并去除环，确保方案可行。
3. 使用拓扑排序解决调度问题。
任务的依赖关系改变之后都需要再次检查是否存在环，然后再进行排序。
