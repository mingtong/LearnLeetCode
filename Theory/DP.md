## DP

DP: 即 **动态规划（dynamic programming）**，是用过去的知识解决未来的问题。

动态规划常用于字符串问题，可以通过解决原始问题的子问题，然后用这个子问题的结果来解决更复杂的原始问题。 
通常把子问题的结果存放在一个一维或二维数组中，然后在需要时查询。

动态规划还可以用在递归问题中，以避免重复地计算同一个子问题。 

动态规划分为：
- 线性动规（一维）
- 区域动规（二维）
- 树形动规
- 背包问题

#### Case 1:

比如 Fibonacci 数列问题:
> - F<sub>n</sub> = F<sub>n-1</sub>+ F<sub>n-2</sub> 
> - 而 F<sub>0</sub> = 0， F<sub>1</sub>= 1。 

#### 用递归来解决的话：
按照传统思路

![](https://www.interviewcake.com/images/svgs/fibonacci__binary_tree_recursive.svg)
```C#
        public int FibonacciRecursive(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            var v1 = FibonacciRecursive(n - 1);
            Console.WriteLine("calculate v1= " + v1);
            var v2 = FibonacciRecursive(n - 2);
            Console.WriteLine("calculate v2= " + v2);
            return v1 + v2;
        }
```
可以看到共执行了8次

#### 而用动态规划的思路的话，有两种方式：

记录每次值，避免重复计算：

![](https://www.interviewcake.com/images/svgs/fibonacci__binary_tree_memoized.svg)

- 从上到下 - 也就是备忘录模式(Memoization)，仍然是递归，但是如果有计算过的值，就直接查表

``` C#
        public int StartFibonacciMemoization(int n)
        {
            cache = new int[n];
            var v = FibonacciMemoization(n);
            return v;
        }

        private int FibonacciMemoization(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            if (cache[n - 1] != 0)
            {
                return cache[n];
            }

            //暂存每个子集的和
            cache[n - 1] = FibonacciMemoization(n - 1) + FibonacciMemoization(n - 2);
            Console.WriteLine("calculate cache[" + n + "-1]= " + cache[n - 1]);
            return cache[n - 1];
        }
```
可以看到一共只执行了3次计算，也就是FibonacciMemoization被调用了3次：
从上到下的方式，使用迭代的方式，按n，n-1，n-2，n-3，n-i...4..3..2..1..0的顺序记录缓存的值。
```
calculate cache[1]= 1
calculate cache[2]= 2
calculate cache[3]= 4
```


- 从下到上，也就是从小的范围向大的范围计算
``` C#
        public int FibonacciBottomUp(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            cache = new int[n+1]; //暂存每个子集的和
            cache[0] = 0;
            cache[1] = 1;
            for (int i = 2; i < n+1; i++)
            {
                cache[i] = cache[i - 1] + cache[i - 2];
                Console.WriteLine("calculate cache[" + (i) + "]= " + cache[i]);
            }

            return cache[n];
        }
```

而从下到上的方式，只有一次调用，使用迭代的方式，按0，1，2，3，4...n的顺序记录缓存的值。

#### Case2

算法导论中的钢条切割问题：卖出8种长度的钢条，长度以及长度对应的价值分别是：
> - {1, 2, 3, 4, 5,  6,  7,  8,  9,  10}
> - {1, 5, 8, 9, 10, 17, 17, 20, 24, 30}

如果给出原钢条的长度，求问如何切割使利益最大化？
如果给出长度是1的钢条，则只有一种切法，即价值是1。
如果给出长度是2的钢条，则有两种切法，两个长度1，或一个长度2。一个长度2的价值最大，为5。
如果给出长度是2的钢条，则有三种切法，三个长度1，或一个长度2+一个长度1，或一个长度3。一个长度3的价值最大，为8。
以此类推。

从下到上的代码实现如下：
``` C#
        public int BottomUpCut(int n)
        {
            int[] amount = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                int optimal = -1;
                //get the optimal solution
                for (int j = 1; j <= i; j++)
                {
                    var v = price[j - 1] + amount[i - j];
                    optimal = Math.Max(optimal, v);
                }

                amount[i] = optimal;
                Console.WriteLine("calculate amount[" + (i) + "]= " + amount[i]);
            }

            return amount[n];
        }
```

#### 使用动态规划的步骤是：

 1. 找出问题中的递归。
 2. 从上到下：把每个子问题的结果保存在列表中，避免重复计算。
 3. 从下到上：找到解决问题的正确顺序，然后在需要时利用子问题的结果。 
 
- 动态规划一般用于解决从左到右顺序的问题，比如字符串，树，整数序列等。
- 如果递归算法不会重复计算子问题，那么动态规划也不会有什么帮助。
- DP 算法可以用递归实现，但不是必须用递归。
- DP 算法不会因为 Memoization 而加速，因为每个子问题只被解决了一次。




#### 参考资料
> - [wiki](http://en.wikipedia.org/wiki/Dynamic_programming)
> - [StackOverflow](https://stackoverflow.com/questions/1065433/what-is-dynamic-programming)
> - [berkeley](http://www.cs.berkeley.edu/~vazirani/algorithms/chap6.pdf) 
> - [topcoder](http://www.topcoder.com/tc?d1=tutorials&d2=dynProg&module=Static)
> - [TopCoder之DP介绍](https://www.topcoder.com/community/competitive-programming/tutorials/dynamic-programming-from-novice-to-advanced/)
> - [sysu](http://sist.sysu.edu.cn/~isslxm/DSA/textbook/Skiena.-.TheAlgorithmDesignManual.pdf)
> - [Codechef教程](https://www.codechef.com/wiki/tutorial-dynamic-programming)
> - [CnBlogs-QingLiXueShi](https://www.cnblogs.com/mengwang024/p/4342796.html)

#### 练习题

> - [clemson](https://people.cs.clemson.edu/~bcdean/dp_practice/) 
> - [hackerrank](https://www.hackerrank.com/domains/algorithms/dynamic-programming)
> - [50道DP练习题](https://medium.com/@codingfreak/top-50-dynamic-programming-practice-problems-4208fed71aa3)
