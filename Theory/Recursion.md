## 递归

**递归**，Recursion

- #### Recursive Case，递归继续的条件。
- #### Base Case, 递归终止的条件，可以有多个。

### 递归类型
  - 单递归：Single Recursion，递归函数中只包含一次自引用的调用，比如 链表遍历，阶乘。
  - 多递归：Multiple Recursion，递归函数中只包含多次自引用的调用，比如 二叉树遍历，Fibonacci数列。
  - 直接递归：Direct recursion，自己直接调用自己，比如 f 调用 f。
  - 间接递归：Indirect Recursion，自己不直接调用自己，比如 f 调用 g, g 调用 f。也叫做 **互递归(Mutual Recursion)**。
  - 匿名递归：Anonymous Recursion，不显示地通过函数名调用自己，用于 匿名函数。
  - 结构化递归：Structural Recursion，把数学归纳法 公式化。
    - 链表
    - 二叉树
    - 文件系统
  - 生成式递归：Generative Recursion，

#### 尾递归 Tail Recursion

### 单递归 Convert to 栈迭代

### 应用程序

- **Factorial** (阶乘)

  ![](https://wikimedia.org/api/rest_v1/media/math/render/svg/fbc0a05bb5402570afdac251df1661194639d397)
  
- **Greatest Common Divisor** (最大公约数，欧几里得算法)

  ![](https://wikimedia.org/api/rest_v1/media/math/render/svg/66b3eae7c177b5a9738c42383c664048d8f239a0)
  
- **Towers of Hanoi** (汉诺塔)

  ![](https://wikimedia.org/api/rest_v1/media/math/render/svg/52078a04ec62c4a55887e2cd9011acb238c34452)
  
- **二分搜索**

### 实现问题

  - 包装函数(wrapper function)，验证入参，初始化变量，处理异常，调用递归函数。
  - 短路(Short-circuiting the base case)，调用递归之前，验证是否是base case。比如：
    - 二叉树DFS的正常操作：
      - base case: 如果当前结点是 null，返回 false。
      - recurisive case: 检查当前结点，match 就返回 true，否则递归子结点。
    - 二叉树的DFS的Short-circuiting：
      - base case: 检查当前结点的值，match 就返回 true。
      - recurisive case: 检查子结点，如果为null，就递归。
  - 混合算法(Hybrid algorithm)，当数据量小时切换算法。
    - Merge Sort 在数据量小时 使用 Insertion Sort。



