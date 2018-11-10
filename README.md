# 算法与数据基础

**参考书籍**：

 - [《算法》第4版中文版](https://item.jd.com/11098789.html)，[英文版官网讲解链接](http://algs4.cs.princeton.edu/home/)，Java语言描述
 - [《算法导论》中文版](https://item.jd.com/11144230.html)，英文名《Introduction to Algorithms, third edition》，伪代码描述

**基础数据结构**：

 - 数组
 - [位运算](http://blog.csdn.net/cuit/article/details/78665808)
 - [栈](http://blog.csdn.net/cuit/article/details/78389400)
 - 队列
 - [链表](http://blog.csdn.net/cuit/article/details/78374569)
 - [堆 (优先队列 Priority Queue)](http://blog.csdn.net/cuit/article/details/78410039)，[Java源码链接](http://grepcode.com/file/repository.grepcode.com/java/root/jdk/openjdk/8u40-b25/java/util/PriorityQueue.java#PriorityQueue)
 - [二叉树 基础及题型](http://blog.csdn.net/cuit/article/details/78639583)
	 - [二叉搜索树（已排序）](http://blog.csdn.net/cuit/article/details/78430508)
   	 - [红黑树 (平衡二叉搜索树)](http://blog.csdn.net/cuit/article/details/78430639) 
	   	 - TreeMap，[JAVA源码链接](http://grepcode.com/file/repository.grepcode.com/java/root/jdk/openjdk/8u40-b25/java/util/TreeMap.java#TreeMap)，内部是红黑树存储，所以key是有序的。
	   	 - SortedSet，[C#源码链接](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/SortedSet.cs)，内部是红黑树。
	   	 - TreeSet，[C#源码链接](http://referencesource.microsoft.com/#System/compmod/system/collections/generic/sorteddictionary.cs,07052c0941912f81)，继承于SortedSet红黑树。
	   	 - SortedDictionary, [C#源码链接](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/SortedDictionary.cs)，内部元素是TreeSet。
	   	 - SortedList，[C#源码链接](https://github.com/dotnet/corefx/blob/master/src/System.Collections/src/System/Collections/Generic/SortedList.cs)，内部是两个数组。
 - [HashMap](http://blog.csdn.net/cuit/article/details/78446565)
	 - HashMap(Java-kv), [JAVA源码链接](http://grepcode.com/file/repository.grepcode.com/java/root/jdk/openjdk/8u40-b25/java/util/HashMap.java#HashMap)，当链接长度大于8时使用红黑树存储。
		 - LinkedHashMap
			 - [LRUCache](http://blog.csdn.net/cuit/article/details/78447285)
	 - Dictionary(.NET-kv)，[C#源码链接](http://referencesource.microsoft.com/#mscorlib/system/collections/generic/dictionary.cs,d3599058f8d79be0)。
	 - HashSet(only key)，[C#源码链接](http://referencesource.microsoft.com/#System.Core/System/Collections/Generic/HashSet.cs,2d265edc718b158b)，
 - [Trie（单词查找树）](http://blog.csdn.net/cuit/article/details/78495561)
 - [Disjoint Set(Union Find)](http://blog.csdn.net/cuit/article/details/78633729)
 - [图](http://blog.csdn.net/cuit/article/details/78449007)
	 - [无向图](http://blog.csdn.net/cuit/article/details/78449464)
	 - [有向图](http://blog.csdn.net/cuit/article/details/78474746)

**基础算法**：

 - [排序](http://blog.csdn.net/cuit/article/details/78399258)
 - [查找](http://blog.csdn.net/cuit/article/details/78420808) 
	 - [Binary Search](http://blog.csdn.net/cuit/article/details/78420881)
 - [图](http://blog.csdn.net/cuit/article/details/78449007)
	 - [DFS](http://blog.csdn.net/cuit/article/details/78453419)
	 - [BFS](http://blog.csdn.net/cuit/article/details/78463322) 
	 - [连通分量](http://blog.csdn.net/cuit/article/details/78463464)
	 - [DisjointSet-Union-Find（并查集）](http://blog.csdn.net/cuit/article/details/78633729)
	 - [有向图](http://blog.csdn.net/cuit/article/details/78474746)
	 - [拓扑排序](http://blog.csdn.net/cuit/article/details/78484097)
	 - [强连通性](http://blog.csdn.net/cuit/article/details/78484351)
	 - [最小生成树](http://blog.csdn.net/cuit/article/details/78484777)
	 - [最短路径](http://blog.csdn.net/cuit/article/details/78485414)
		 - [Dijkstra 算法](http://blog.csdn.net/cuit/article/details/78494668)
		 - Bellman-Ford 算法
		 - A* 算法
 - 字符串
	 - 字符串排序
	 - 字符串查找(KMP查找)
	 - 压缩编码
 - [动态规划](http://blog.csdn.net/cuit/article/details/78620381)
 - 贪心算法
 - 分治算法
 - 背包算法
 - 拓扑排序
 - 递归算法

**高级算法**：

 - 线段树
 - Minimax
 - 线性规划
 - 计算几何
 - 近似算法
 - 网络流
 - 博弈论
 - NP问题 

**Java 数据结构关系图：**

![Java 数据结构关系图](http://img.blog.csdn.net/20171110151742337?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvY3VpdA==/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

--- 

# LeetCode 解题
| 序号        | 标题    |  知识点  | 难度 | 推荐指数
| :--------  | :-----  | :----   |:---:|:---:
| 1 | [Two sum](http://blog.csdn.net/cuit/article/details/78505630) | HashMap | Easy | 9 
| 2 | [Add two numbers](http://blog.csdn.net/cuit/article/details/78505880)      |   链表合并  | Medium | 8
| 3 | [Longest Substring Without Repeating Characters](http://blog.csdn.net/cuit/article/details/78506294) | HashSet | Medium | 9
| 4 | [Median of Two Sorted Arrays](http://blog.csdn.net/cuit/article/details/78506332) | 数学-中值 | Hard | 7
| 5 | Longest Palindromic Substring | | Medium |8
| 6 | ZigZag Conversion  
| 7 | [Reverse Integer](http://blog.csdn.net/cuit/article/details/78509086) | 数学 | Easy| 5
| 8 | String to Integer (atoi)   
| 9 | [Palindrome Number](http://blog.csdn.net/cuit/article/details/78516512) | 数学 | Easy | 5
| 10 | Regular Expression Matching  
| 11 | Container With Most Water
| 12 | Integer to Roman   
| 13 | Roman to Integer
| 14 | [Longest Common Prefix](http://blog.csdn.net/cuit/article/details/78556278) | Trie | Easy　| 5
| 15 | 3Sum  
| 16 | 3Sum Closest 
| 17 | Letter Combinations of a Phone Number 
| 18 | 4Sum   
| 19 | Remove Nth Node From End of List  | 链表 |　Medium　|　9
| 20 | [Valid Parentheses](http://blog.csdn.net/cuit/article/details/78573941) | Stack|　Easy　|　9
| 21 | Merge Two Sorted Lists  | 链表|　Easy　|　9
| 22 | Generate Parentheses   
| 23 | Merge k Sorted Lists
| 24 | Swap Nodes in Pairs | 链表|　Medium　|　9
| 25 | Reverse Nodes in k-Group  
| 26 | Remove Duplicates from Sorted Array | 数组|　Easy　|　3
| 27 | Remove Element   | 数组 |　Easy　|　3
| 28 | Implement strStr() | 数组 |　Easy　|　4
| 35 | Search Insert Position | |　Easy　|　8
| 53 | [Maximum subarray problem](http://blog.csdn.net/cuit/article/details/78572326) | DP | Easy |　9　
| 54 | Spiral Matrix
| 61 | Rotate List | 链表 |　Medium　|　3
| 67 | Add Binary  |  |　Easy　|　8
| 70 | Climbing Stairs |  |　Easy　|　9
| 74 | Search a 2D Matrix
| 75 | Sort Colors 
| 82 | Remove Duplicates from Sorted List II  
| 83 | Remove Duplicates from Sorted List 
| 86 | Partition List 
| 92 | Reverse Linked List II 
| 94 | Binary Tree Inorder Traversal 
| 100 | Same Tree  
| 104 | Maximum Depth of Binary Tree
| 121 | Best Time to Buy and Sell Stock
| 136 | Single Number 
| 141 | Linked List Cycle
| 142 | Linked List Cycle II
| 144 | Binary Tree Preorder Traversal
| 147 | Insertion Sort List
| 160 | Intersection of Two Linked Lists
| 169 | Majority Element 
| 203 | Remove Linked List Elements
| 206 | Reverse Linked List 
| 217 | Contains Duplicate
| 226 | Invert Binary Tree
| 230 | Kth Smallest Element in a BST 
| 234 | Palindrome Linked List 
| 237 | Delete Node in a Linked List 
| 242 | Valid Anagram
| 258 | Add Digits
| 268 | Missing Number
| 283 | Move Zeroes
| 292 | Nim Game
| 328 | Odd Even Linked List
| 344 | Reverse String
| 347 | Top K Frequent Elements 
| 349 | Intersection of Two Arrays 
| 350 | Intersection of Two Arrays II 
| 412 | Fizz Buzz 
| 445 | Add Two Numbers II 
| 451 | Sort Characters By Frequency 
| 461 | Hamming Distance 
| 463 | Island Perimeter 
| 500 | Keyboard Row
| 557 | Reverse Words in a String III 
| 595 | Big Countries
| 617 | Merge Two Binary Trees
| 637 | Average of Levels in Binary Tree 
| 657 | Judge Route Circle 
