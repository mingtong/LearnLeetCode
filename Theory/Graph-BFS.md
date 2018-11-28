## BFS

**BFS**：Breadth First Search，广度优先搜索。

用于计算图中两点之间的最短距离。
BFS 也是很多图算法的基石。

**想要找到顶点 s 到 顶点 v 的最短路径，从 s 开始，在所有距离 s 一条边长度的顶点中寻找 v，如果找不到，就继续在与 s 距离两条边长度的顶点中寻找 v，如此下去，走到找到 v**。

- 深度优先搜索就好像是一个人在走迷宫，
- 而广度优先搜索就像是一组人在朝各个方向走这个迷宫，每个人都有自己的绳子，当出现叉路时，假设一个探路人可以分裂成多个人继续，当两个探路人相遇时，合并，使用先到达者的绳子。

- 深度优先搜索就像是前序遍历一棵树（递归隐式使用了栈），
- 而广度优先就像是层次遍历一棵树（显示使用队列）。

- 深度优先搜索不断地在栈中保存分叉的顶点。
- 广度优先搜索则向扇形扫描，用队列保存访问过的最前端的顶点。

![](https://img-blog.csdn.net/20171106232439314?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

逐步图解流程如下:

![](https://img-blog.csdn.net/20171106233144772?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

BFS查找路径的实现代码如下：

``` C#
class BFSPaths
{
    private bool[] marked;//
    private int[] edgeTo; //到达该顶点的已知路径上的最后一个顶点
    private final int s; //起点
    public BFSPaths(Graph g, int s)
    {
        marked = new bool[g.V()];
        edgeTo = new int[g.V()];
        this.s = s;
        bfs(g, s);
    }
    private void bfs(Graph g, int s)
    {
        Queue<int> queue = new Queue<int>();
        marked[s] = true; //标记起点
        queue.enqueue(s); //入队列
        while(!queue.isEmpty())
        {
            int v = queue.dequeue(); //从队列中删去下一顶点
            foreach(int w in g.adj(v))
            {
                if(!marked[w])
                {
                    edgeTo[w] = v; //保存最短路径的最后一条边
                    marked[w] = true; //标记它，因为已知最短路径
                    queue.enqueue(w); //将它添加到队列中
                }               
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
