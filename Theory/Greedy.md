## 贪心算法(Greedy)

### 思想：
在对问题求解时，总是做出在当前看来是最好的选择。也就是说，不从整体最优上加以考虑，他所做出的是在某种意义上的局部最优解。

### 缺点：
它需要证明后才能真正运用到题目的算法中。因为局部最优解未必是整体最优解。
如下图：

![](https://ds055uzetaobb.cloudfront.net/image_optimizer/1e48fa5499c2b71b19ae7c9606d73673c972f3ad.gif)

### 使用案例
- 最小生成树：**Prim 算法** 和 **Kruskal 算法**
- 最短路径：**Dijkstra 算法**，**A* search algorithm**
- 霍夫曼编码：Huffman Coding
- 拓扑排序：Topological Sort
- 决策树：Decision Tree Learning，https://en.wikipedia.org/wiki/Decision_tree_learning
