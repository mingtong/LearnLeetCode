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

## 队列


Queue 在C#和Java中都有现成的定义，且在LeetCode中也可以直接使用。 
其泛型版本定义的主要属性和方法如下：
``` C#
public class Queue<T>
{
    public int Count;
    public void Clear();
    public T Enqueue(); //向 Queue 末尾添加一个元素。
    public T Dequeue();  //取出 Queue 第一个元素。
}
```

### 技巧/题型
- #20 判断有效括号是否配对
- #232 用两个栈实现一个队列(两次栈的反向进出即是正向进出)。
    - 在多线程时，可以用一个栈读，一个栈写，来实现读写安全的队列。
- 用两个队列实现一个栈()(来回倒腾数据)
    - 也可以用一个队列实现，每次pop之前把队列循环地头取出来继续塞进队尾
- #20 判断括号是否有效配对
- #94 二叉树中序遍历
- #144 二叉树前序遍历
- #145 二叉树后序遍历
- 二叉搜索树的遍历
- #104 二叉树以ZigZag方式遍历
- #155 设计一个支持获取min元素的Stack类
    - push新值时如果小于min元素，则连min元素也push进去
- 直方图中的最大矩形
- #5 最长回文子串
