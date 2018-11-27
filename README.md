## 算法与数据基础

### 参考资料：

 - [《算法》第4版中文版](https://item.jd.com/11098789.html)，[英文版官网讲解链接](http://algs4.cs.princeton.edu/home/)，Java语言描述
 - [《算法导论》中文版](https://item.jd.com/11144230.html)，英文名《Introduction to Algorithms, third edition》，伪代码描述

---

### 解题记录

[Solution](Solution/README.md)

### 基础数据结构：

|类型|英文名/类名|特点|有用链接|
| :---|:---  |:---|:---|
|数组|Array |快速索引 | |
|[链表](Theory/LinkedList.md)|LinkedList|动态增长 ||
|[字符串](Theory/String.md)|String | | |
|[栈](Theory/Stack.md) |Stack|先进后出 ||
|队列 |Queue |先进先出 ||
|[堆/优先队列](Theory/Sort-Heap.md) |Heap/PriorityQueue| |[Java官方源码](http://grepcode.com/file/repository.grepcode.com/java/root/jdk/openjdk/8u40-b25/java/util/PriorityQueue.java#PriorityQueue)|
|[二叉树](Theory/Tree-BinaryTree.md) |BinaryTree || |
|[二叉搜索树](Theory/Search-BST.md)|BinarySearchTree |有序的二叉树 | |
|[红黑树 ](Theory/Tree-RBTree.md) |RBTree  |平衡的二叉搜索树 | |
|[Java红黑树kv列表](https://docs.oracle.com/javase/7/docs/api/java/util/TreeMap.html) |TreeMap |Java实现  ||[JAVA官方源码](http://grepcode.com/file/repository.grepcode.com/java/root/jdk/openjdk/8u40-b25/java/util/TreeMap.java#TreeMap) |
|[.NET红黑树kv列表](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=netframework-4.7.2) |SortedDictionary |.NET实现，内部用TreeSet存储 |[.NET官方源码](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/SortedDictionary.cs) |
|[SortedList(kv)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.sortedlist?view=netframework-4.7.2) |SortedList |内部是两个数组 |[.NET官方源码](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/SortedList.cs) |
|[Java.红黑树k列表](https://docs.oracle.com/javase/7/docs/api/java/util/TreeSet.html) |TreeSet |红黑树方式存储的去重key列表 | |
|[.NET红黑树k列表](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedset-1?view=netframework-4.7.2) |SortedSet |红黑树方式存储的去重key列表|[.NET官方源码](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/SortedSet.cs) |
|[哈希](Theory/HashTable.md) |Hash |快速查找 ||
|[.NET哈希表](Theory/HashTable.md) |Dictionary |泛型的HashTable |[.NET官方源码](http://referencesource.microsoft.com/#mscorlib/system/collections/generic/dictionary.cs)|
|[Java哈希表](Theory/HashTable.md) |HashMap |链接长度大于8时改用红黑树 |[JAVA官方源码](http://grepcode.com/file/repository.grepcode.com/java/root/jdk/openjdk/8u40-b25/java/util/HashMap.java#HashMap) |
|[链式Hash表](https://docs.oracle.com/javase/7/docs/api/java/util/LinkedHashMap.html)|LinkedHashMap | | |
|去重Hash数据集 |HashSet |hash方式存储的去重key列表 |[.NET官方源码](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/HashSet.cs) |
|[字典树\|单词查找树](Theory/Tree-Trie.md) |Trie | | |
|[并查集](Theory\UnionFind.md) |DisjointSet \| UnionFind || |
|跳表 |SkipList || |
|[图](Theory/Graph.md)|Graph ||[微软关于图的介绍](https://docs.microsoft.com/en-us/previous-versions/ms379574(v=vs.80)) |


**注意**：
- SortSet 在Java中是接口，在.NET中是具体类
- List在 Java中是接口，在.NET中是具体类
- TreeSet 在Java中是具体类，在.NET中是内部类
- HashMap 当取空key时，Java返回null
- Dictionary 当取空key时，.NET抛异常

### Java 数据结构关系图：

![Java 数据结构关系图](SolutionByTag/img/java-ds.png)

---
### 基础算法：

|算法|英文名|特点|有用链接|
| :---|:---  |:---|:---|
|[位运算](Theory/BitwiseOperation.md) |BitwiseOperation|||
|[排序](Theory/Sort.md)|Sort | | |
|[查找](Theory/Search.md) |Search | | |
|二分查找|Binary Search | | |
|[深度优先查找](Theory/Graph-DFS.md)|DFS | | |
|[广度优先查找](Theory/Graph-BFS.md) |BFS | | |
|[最小生成树](Theory/Graph-MinimumSpanningTree.md)|Minimum Spanning Tree| | |
|[最短路径](Theory/Graph-ShortestPath.md)|ShortestPath| | |
|[Dijkstra 算法](Theory/Graph-Dijkstra.md)|ShortestPath| | |
|A* 算法|A* ShortestPath| | |
|字符串排序|| | |
|字符串查找|KMP| | |
|[动态规划](Theory/DP.md)|DP| |[Codechef教程](https://www.codechef.com/wiki/tutorial-dynamic-programming), [菜鸟教程](https://blog.csdn.net/u013309870/article/details/75193592#commentBox) |
|递归算法|Recursion| | |
|贪心算法|Greedy| | |
|分治算法|DevideAndConquer| | |
|回溯算法|Backtracking| | |
|[拓扑排序](Graph-Topology.md)|Topological| | |

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
