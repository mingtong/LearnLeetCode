## 栈

Stack在C#和Java中都有现成的定义，且在LeetCode中也可以直接使用。 
其泛型版本定义的主要属性和方法如下：
``` C#
public class Stack<T>
{
    public int Count;
    public void Clear();
    public T Peek(); //返回的对象顶部的 Stack 而不删除它。
    public T Pop();  //删除并返回 Stack 顶部的对象。
    public void Push(T); //在 Stack 的顶部插入一个对象。
}
```

### 技巧/题型

- 用两个栈实现一个队列(#232)(两次栈的反向进出即是正向进出)。
    - 在多线程时，可以用一个栈读，一个栈写，来实现读写安全的队列。
- 判断括号是否有效配对（包括小，中，大括号）
- 二叉树中序遍历
- 二叉树前序遍历
- 二叉树后序遍历
- 二叉搜索树的遍历
- 二叉树以ZigZag方式遍历
- 设计一个支持获取最小元素的Stack类
- 直方图中的最大矩形
