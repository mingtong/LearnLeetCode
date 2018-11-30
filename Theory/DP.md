## DP

DP: 即 **动态规划（dynamic programming）**，是用过去的知识解决未来的问题。

动态规划常用于字符串问题，可以通过解决原始问题的子问题，然后用这个子问题的结果来解决更复杂的原始问题。 
通常把子问题的结果存放在一个一维或二维数组中，然后在需要时查询。

动态规划还可以用在递归问题中，以避免重复地计算同一个子问题。 
比如 Fibonacci 数列问题，F<sub>n</sub> = F<sub>n-1</sub>+ F<sub>n-2</sub> 
而 F<sub>0</sub> = 0， F<sub>1</sub>= 1。 

#### 用递归来解决的话：

```C#
int Fibonacci(int n)
{
    if(n == 0)
    {
        return 0;
    }
    if(n == 1)
    {
        return 1;
    }
    return Fibonacci(n-1) + Fibonacci(n-2);
}
```

#### 而用动态规划的思路的话，有两种方式：

- 从上到下 - 也就是备忘录模式(Memoization)
``` C#
int Fibonacci(int n)
{
    if(n < 1)
    {
        return n;
    }
    int[] cache = new int[n]; //暂存每个子集的和
    cache[0] = 0;
    cache[1] = 1;
    for(int i = 2; i < n+1; i++)
    {
        cache[i] = cache(n-1) + cache(n-2);
    } 
    return cache[n];
}
```

- 从下到上
``` C#
int Fibonacci(int n)
{
    if(n < 1)
    {
        return n;
    }
    int[] cache = new int[n]; //暂存每个子集的和
    cache[0] = 0;
    cache[1] = 1;
    for(int i = 2; i < n+1; i++)
    {
        cache[i] = cache(n-1) + cache(n-2);
    } 
    return cache[n];
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
> - [CSDN-HankingHu](https://blog.csdn.net/u013309870/article/details/75193592)

#### 练习题

> - [clemson](https://people.cs.clemson.edu/~bcdean/dp_practice/) 
> - [hackerrank](https://www.hackerrank.com/domains/algorithms/dynamic-programming)
> - [50道DP练习题](https://medium.com/@codingfreak/top-50-dynamic-programming-practice-problems-4208fed71aa3)
