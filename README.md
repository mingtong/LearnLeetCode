## 算法与数据基础

### 参考资料：

 - [《算法》第4版中文版](https://item.jd.com/11098789.html)，[英文版官网讲解链接](http://algs4.cs.princeton.edu/home/)，Java语言描述
 - [《算法导论》中文版](https://item.jd.com/11144230.html)，英文名《Introduction to Algorithms, third edition》，伪代码描述

---

### 解题记录

 - [解题](Solution/README.md)

---

### 基础数据结构：

|类型|英文名/类名|特点|有用链接|
| :---|:---  |:---|:---|
|[数组](Theory/Array.md)|Array |快速索引 | |
|[链表](Theory/LinkedList.md)|LinkedList|动态增长 ||
|[跳表](Theory/SkipList.md)|SkipList || |
|[字符串](Theory/String.md)|String | | |
|[栈](Theory/Stack.md) |Stack|先进后出 ||
|[队列](Theory/Queue.md)|Queue |先进先出 ||
|[堆/优先队列](Theory/Sort-Heap.md) |Heap/PriorityQueue| |[Java官方源码](http://grepcode.com/file/repository.grepcode.com/java/root/jdk/openjdk/8u40-b25/java/util/PriorityQueue.java#PriorityQueue)|
|[二叉树](Theory/Tree-BinaryTree.md) |BinaryTree || |
|[二叉搜索树](Theory/Search-BST.md)|BinarySearchTree |有序的二叉树 | |
|[红黑树 ](Theory/Tree-RBTree.md) |RedBlackTree  |平衡的二叉搜索树 | |
|[字典树\|单词查找树](Theory/Tree-Trie.md) |Trie | | |
|[图](Theory/Graph.md)|Graph |||
|[并查集](Theory/UnionFind.md) |DisjointSet \| UnionFind || |


---
### 基础算法：

|算法|英文名|特点|有用链接|
| :---|:---  |:---|:---|
|[位运算](Theory/BitwiseOperation.md) |BitwiseOperation|||
|[排序](Theory/Sort.md)|Sort | | |
|[查找](Theory/Search.md) |Search | | |
|[二分查找](Theory/Search-BinarySearch.md)|Binary Search | | |
|[深度优先查找](Theory/Graph-DFS.md)|DFS | | |
|[广度优先查找](Theory/Graph-BFS.md) |BFS | | |
|[最短路径](Theory/Graph-ShortestPath.md)|ShortestPath| | |
|[动态规划](Theory/DP.md)|DP| |[Codechef教程](https://www.codechef.com/wiki/tutorial-dynamic-programming), [菜鸟教程](https://blog.csdn.net/u013309870/article/details/75193592#commentBox) |
|字符串操作|| | |
|递归算法|Recursion| | |
|贪心算法|Greedy| | |
|分治算法|DevideAndConquer| | |
|回溯算法|Backtracking| | |
|[LRU缓存](Cache-LRUCache.md)|LRU Cache | | |

### 高级算法：

|算法|英文名|特点|有用链接|
| :---|:---  |:---|:---|
|压缩编码|| | |
|线段树|| | |
|Minimax|| | |
|线性规划|| | |
|计算几何|| | |
|近似算法|| | |
|网络流|| | |
|博弈论|| | |
|NP问题|| | | 
 
 ---




<!---
 - [数组](Theory/Array.md)
 - [位运算](Theory/BitwiseOperation.md)
 - [栈](Theory/Stack.md)
 - [x][队列](Theory/Queue.md)
 - [链表](Theory/LinkedList.md)
 - [堆 (优先队列 Priority Queue)](Theory/Sort-Heap.md)
 	- [Java实现源码](http://grepcode.com/file/repository.grepcode.com/java/root/jdk/openjdk/8u40-b25/java/util/PriorityQueue.java#PriorityQueue)
 - [二叉树 基础及题型](Theory/Tree-BinaryTree.md)
	 - [二叉搜索树（已排序的二叉树）](Theory/Search-BST.md)
   	 - [红黑树 (平衡二叉搜索树)](Theory/Tree-RBTree.md) 
	   	 - TreeMap，[JAVA官方源码](http://grepcode.com/file/repository.grepcode.com/java/root/jdk/openjdk/8u40-b25/java/util/TreeMap.java#TreeMap)，内部是红黑树存储，所以key是有序的。
	   	 - SortedSet，[.NET官方源码](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/SortedSet.cs)，内部是红黑树。
	   	 - TreeSet，[.NET官方源码](http://referencesource.microsoft.com/#System/compmod/system/collections/generic/sorteddictionary.cs,07052c0941912f81)，继承于SortedSet红黑树。
	   	 - SortedDictionary, [.NET官方源码](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/SortedDictionary.cs)，内部元素是TreeSet。
	   	 - SortedList，[.NET官方源码](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/SortedList.cs)，内部是两个数组。
 - [HashMap](Theory/HashTable.md)
	 - HashMap(Java键值对), [JAVA官方源码](http://grepcode.com/file/repository.grepcode.com/java/root/jdk/openjdk/8u40-b25/java/util/HashMap.java#HashMap)，当链接长度大于8时使用红黑树存储。
		 - LinkedHashMap
			 - [LRUCache](Theory/CacheLRUCache.md)
	 - Dictionary(.NET泛型键值对)，[.NET官方源码](http://referencesource.microsoft.com/#mscorlib/system/collections/generic/dictionary.cs,d3599058f8d79be0)。
	 - HashSet(only key)，[.NET官方源码](http://referencesource.microsoft.com/#System.Core/System/Collections/Generic/HashSet.cs,2d265edc718b158b)，
 - [Trie（单词查找树）](Theory/Tree-Trie.md)
 - [Disjoint Set(Union Find)](Theory/UnionFind.md)
 - [图](Theory/Graph.md)
	 - [无向图](Theory/Graph-Undirected.md)
	 - [有向图](Theory/Graph-Directed.md)
	 - [连通分量](Theory/Graph-ConnectedComponenet.md)
	 - [拓扑排序](Theory/Topology.md)
	 - [强连通性](Theory/StronglyConnected.md)
	 - [最小生成树](Theory/MinimumSpanningTree.md)
- [排序](Theory/Sort.md)
 - [查找](Theory/Search.md) 
	 - [Binary Search](Theory/Search-BST.md)
 - [图](Theory/Graph.md)
	 - [DFS](Theory/Graph-DFS.md)
	 - [BFS](Theory/Graph-BFS.md) 
	 - [DisjointSet-Union-Find（并查集）](Theory/Union-Find.md)
	 - [最短路径](Theory/Graph-ShortestPath.md)
		 - [Dijkstra 算法](Theory/Graph-Dijkstra.md)
		 - Bellman-Ford 算法
		 - A* 算法
 - [字符串](Theory/String.md)
	 - 字符串排序
	 - 字符串查找(KMP查找)
	 - 压缩编码
 - [动态规划](Theory/DP.md)
 	- [Codechef教程](https://www.codechef.com/wiki/tutorial-dynamic-programming)
	- [菜鸟教程](https://blog.csdn.net/u013309870/article/details/75193592#commentBox)
	 --->
