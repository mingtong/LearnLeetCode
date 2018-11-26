## 算法与数据基础

### 参考资料：

 - [《算法》第4版中文版](https://item.jd.com/11098789.html)，[英文版官网讲解链接](http://algs4.cs.princeton.edu/home/)，Java语言描述
 - [《算法导论》中文版](https://item.jd.com/11144230.html)，英文名《Introduction to Algorithms, third edition》，伪代码描述

### 基础数据结构：

|类型|英文名/类名|特点|有用链接|
| :---|:---  |:---|:---|
| 数组|Array | | |
| [位运算](Theory/BitwiseOperation.md) |BitwiseOperation|||
| [栈](Theory/Stack.md) |Stack| ||
| 队列 |Queue | ||
| [链表](Theory/LinkedList.md)|LinkedList| ||
| [堆/优先队列](Theory/Sort-Heap.md) |Heap/PriorityQueue| |[Java官方源码](http://grepcode.com/file/repository.grepcode.com/java/root/jdk/openjdk/8u40-b25/java/util/PriorityQueue.java#PriorityQueue)|
| [二叉树基础](Theory/Tree-BinaryTree.md) |BinaryTree || |
| [二叉搜索树](Theory/Search-BST.md)|BinarySearchTree |有序的二叉树 | |
|[红黑树基础 ](Theory/Tree-RBTree.md) |RBTree  |平衡的二叉搜索树 | |
|TreeMap |TreeMap |内部是红黑树存储, key有序 ||[JAVA官方源码](http://grepcode.com/file/repository.grepcode.com/java/root/jdk/openjdk/8u40-b25/java/util/TreeMap.java#TreeMap) |
|SortedSet |SortedSet |内部是红黑树存储|[.NET官方源码](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/SortedSet.cs) |
|TreeSet |TreeSet |继承于SortedSet红黑树 |[.NET官方源码](http://referencesource.microsoft.com/#System/compmod/system/collections/generic/sorteddictionary.cs,07052c0941912f81) |
SortedDictionary |SortedDictionary |内部元素是TreeSet |[.NET官方源码](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/SortedDictionary.cs) |
SortedList |SortedList |内部是两个数组 |[.NET官方源码](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/SortedList.cs) |
| [x][HashMap(Java)](Theory/HashTable.md) | |链接长度大于8使用红黑树 |[JAVA官方源码](http://grepcode.com/file/repository.grepcode.com/java/root/jdk/openjdk/8u40-b25/java/util/HashMap.java#HashMap) |
|LinkedHashMap| | | |
|Dictionary  | |.NET-kv |[.NET官方源码](http://referencesource.microsoft.com/#mscorlib/system/collections/generic/dictionary.cs,d3599058f8d79be0) |
|HashSet | |only key |[.NET官方源码](http://referencesource.microsoft.com/#System.Core/System/Collections/Generic/HashSet.cs,2d265edc718b158b) |
| [单词查找树/字典树](Theory/Tree-Trie.md) |Trie | | |
| [并查集](Theory/UnionFind.md) |DisjointSet/UnionFind || |
| [图](Theory/Graph.md)|Graph || |

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
	 --->
---
### 基础算法：

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
 - [x][字符串](Theory/String.md)
	 - 字符串排序
	 - 字符串查找(KMP查找)
	 - 压缩编码
 - [动态规划](Theory/DP.md)
 	- [Codechef教程](https://www.codechef.com/wiki/tutorial-dynamic-programming)
	- [菜鸟教程](https://blog.csdn.net/u013309870/article/details/75193592#commentBox)
 - 贪心算法
 - 分治算法
 - 背包算法
 - 拓扑排序
 - 递归算法

### 高级算法：

 - 线段树
 - Minimax
 - 线性规划
 - 计算几何
 - 近似算法
 - 网络流
 - 博弈论
 - NP问题 

### Java 数据结构关系图：

![Java 数据结构关系图](SolutionByTag/img/java-ds.png)

--- 


