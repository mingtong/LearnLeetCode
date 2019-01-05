## HashTable

假设待查找的对象是这样存在的：[key1, value1], [key2, value2], [keyX, valueX], … 我们可以把key的列表转过转化存入HashTable中。 
使用基于HashTable的查找需要两步：

- 用 Hash 函数将所有 key 都转化为数组的索引（整数）。
- 如果多个 key 转化成为同一个数组的索引，则需要解决碰撞（collision-resolution）。常用的方法有两种： 
  - 拉链法
  - 线性探测法
  
#### Hash 函数：

- 如果我们有一个能够保存 M 个 key-value 对象的数组，那我们就需要一个能够将任意key转化为该数组范围内的索引 [0, M-1] 内的整数。
- 我们要实现的散列函数应该易于计算，且能够均匀分布所有的key。
- 对于每种类型（比如字符串、数字）的 key， 需要单独实现一个 hash 函数。

### 常用的 Hash 函数的实现：

- 正整数：除留余数（modular hashing），选择一个素数（质数） M 作为hash 后的数组大小，对于任意正整数 k，计算 k 除以 M 的余数（k % M）。可以将 key 散布在 0 ~ M-1之间。如果 M 不是素数，则 key 可能不均匀。 

![](https://algs4.cs.princeton.edu/34hash/images/modular-hashing.png)

- 浮点数：如果 key 是 0~1 之间的实数，则将 key 表示为2进制数再作 k % M。
- 字符串：将字符串转换为大整数，再 k % M。算法如下： R 是 一个小的质数（Java的String实现使用的是31）。
``` Java
int hash = 0;
for (int i = 0; i < s.length(); i++){
    hash = (R * hash + s.charAt(i)) % M;
}
```

- 组合实现，比如 年，月，日表示的日期：
``` Java
int hash = (((area * R + exch) % M) * R + ext) % M; 
```

#### Java中的约定：
- 所有基础数据类型都有 hash 函数。即 实现了 返回 int32 的 hashCode() 方法。
- 每种 hashCode() 方法的实现都必须和 equals() 的一致，也就是说如果 a.equals(b) 返回 true，则 a.hashCode() 必须与 b.hashCode() 相等。
- 如果 a.hashCode() 必须与 b.hashCode() 不相等，那么 a.equals(b) 必须返回false。
- 但即使 a.hashCode() 必须与 b.hashCode() 相等，a.equals(b) 未必返回 true，因为多个 key 经过 hash 函数计算后可能会有同样的值。
- 如果自定义的数据类型要实现 hash 函数，则必须要重写 hashCode() 和 equals() 方法。

#### 碰撞处理–拉链法
如果多个 key 经过 hash 函数计算后可能会有同样的数组索引，拉链法的方式是把 M 个数组中的每个元素都指向一条链表，如果有同样的索引，则依次添加在链表中。
- 查找时需要先根据索引找到链表，再沿着链表查找对应的 key。
- Hash 最主要的目的是将 key 均匀分布，而不是排序，所以如果要快速找到最大或最小的 key，hashtable 不合适。

![](https://algs4.cs.princeton.edu/34hash/images/separate-chaining.png)

#### 碰撞处理–开放地址法 
另一种实现散列的方式是用大小为 M 的 HashTable 保存 N 个 key-value 对象。 
利用 HashTable 中的空对象解决碰撞冲突。这种方式叫做开放地址法（Open-Addressing hash 法）。最简单的开放地址法是 线性探测（Linear probing），它的原理是这样的： 
当发生碰撞时，我们就检测 HashTable 中的下一个 key-value 对象（index+1），可能有3种结果：
- 命中。
- 未命中（该位置无 key）。
- 继续查找下一个 key-value 对象。

![](https://algs4.cs.princeton.edu/34hash/images/linear-probing.png)

### 题型
- #1 Two sum
- #3 最长不重复子串
