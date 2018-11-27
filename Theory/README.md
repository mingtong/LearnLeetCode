## LeetCode Theory

### Hash
|类型|英文名/类名|特点|有用链接|
|:---|:---  |:---|:---|
|[哈希](HashTable.md) |Hash |快速查找 ||
|.NET哈希表 |Dictionary |泛型，HashTable非泛型 |[.NET官方源码](http://referencesource.microsoft.com/#mscorlib/system/collections/generic/dictionary.cs)|
|Java哈希表 |HashMap |链接长度大于8时改用红黑树 |[JAVA官方源码](http://grepcode.com/file/repository.grepcode.com/java/root/jdk/openjdk/8u40-b25/java/util/HashMap.java#HashMap) |
|[Java链式Hash表](https://docs.oracle.com/javase/7/docs/api/java/util/LinkedHashMap.html)|LinkedHashMap | | |
|去重Hash数据集 |HashSet |hash方式存储的去重key列表 |[.NET官方源码](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/HashSet.cs) |

### Tree
|类型|英文名/类名|特点|有用链接|
|:---|:---  |:---|:---|
|[二叉树](Tree-BinaryTree.md) |BinaryTree|| |
|[二叉搜索树](Search-BST.md)|BinarySearchTree |有序的二叉树 | |
|[红黑树](Tree-RBTree.md) |RBTree  |平衡的二叉搜索树 | |
|Java红黑树kv列表|TreeMap |Java实现  ||[JAVA官方源码](http://grepcode.com/file/repository.grepcode.com/java/root/jdk/openjdk/8u40-b25/java/util/TreeMap.java#TreeMap) |
|[.NET红黑树kv列表](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=netframework-4.7.2) |SortedDictionary |.NET实现，内部用TreeSet存储 |[.NET官方源码](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/SortedDictionary.cs) |
|Java.红黑树k列表|TreeSet |红黑树方式存储的去重key列表 |[Java官方介绍](https://docs.oracle.com/javase/7/docs/api/java/util/TreeSet.html) |
|[.NET红黑树k列表](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedset-1?view=netframework-4.7.2) |SortedSet |红黑树方式存储的去重key列表|[.NET官方源码](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/SortedSet.cs) |
|~~[SortedList(kv)](https://docs.microsoft.com/en-us/dotnet/api/system.collections.sortedlist?view=netframework-4.7.2)~~|~~SortedList~~ |~~内部是两个数组,使用二分查找~~ |~~[.NET官方源码](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/SortedList.cs) ~~|

#### 注意：
- SortSet 在Java中是接口，在.NET中是具体类
- List在 Java中是接口，在.NET中是具体类
- TreeSet 在Java中是具体类，在.NET中是内部类
- HashMap 当取空key时，Java返回null
- Dictionary 当取空key时，.NET抛异常
- SortedList 的内部是数组实现，并非红黑树

---

### Graph

|类型|英文名/类名|特点|有用链接|
|:---|:---  |:---|:---|
|[图](Graph.md)|Graph ||[微软doc中关于图的介绍](https://docs.microsoft.com/en-us/previous-versions/ms379574(v=vs.80)) |
|图的表示-邻接列表|Adjacency List || |
|图的表示-邻接矩阵|Adjacency Matrix || |
|[无向图](Graph-Undirected.md)| Graph || |
|[有向图](Graph-Directed.md)| Graph || |
|[连通分量](Graph-ConnectedComponent.md)|ConnectedComponent || |
|[强连通图](Graph-StronglyConnected.md)|StronglyConnected || |
|无权重图|Unweighted Graph || |
|有权重图|Weighted Graph || |
|稀疏图|Sparse Graph || |
|稠密图|Dense Graph || |

<!---
- #### Array

- ### String

- ### [LinkedList](LinkedList.md) 

- ### Queue

- ### Stack

- ### Heap

- ### Hash (HashSet HashMap)

- ### Tree (Binary Tree)
- ### Trie (Dictionary Tree)

- ### Graph
- ### Geometry
---
- ### Sort
---
- ### Recursion

- ### DFS
- ### BFS
- ### DP
  - Basic Theory
  - [Top 50 Dynamic Programming Practice Problems](https://medium.com/@codingfreak/top-50-dynamic-programming-practice-problems-4208fed71aa3)
  - [Top Coder DP introduction](https://www.topcoder.com/community/competitive-programming/tutorials/dynamic-programming-from-novice-to-advanced/)
- ### UnionFind
- ### Greedy
- ### Backtracking
- ### BitOperation
- ### Minimax
- ### DivideAndConquer
- ### Regex

- ### Math
- ### Shortest Path
---
- ### Cache

--->
