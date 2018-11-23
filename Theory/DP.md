## DP

DP: 即 **动态规划（dynamic programming）**，是用过去的知识解决未来的问题。

动态规划常用于字符串问题，可以通过解决原始问题的子问题，然后用这个子问题的结果来解决更复杂的原始问题。 
通常把子问题的结果存放在一个一维或二维数组中，然后在需要时查询。

动态规划还可以用在递归问题中，以避免重复地计算同一个子问题。 
比如 Fibonacci 数列问题，F<sub>n</sub> = F<sub>n-1</sub>+ F<sub>n-2</sub> 而 F<sub>0</sub> = 0， F<sub>1</sub>= 1。 

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

#### 而用动态规划的思路的话：
``` C#
int Fibonacci(int n)
{
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

找出问题中的递归。
找到解决问题的正确顺序，然后把子问题的结果利用起来。 
动态规划一般用于解决从左到右顺序的问题，比如字符串，树，整数集合等。如果递归算法不会重复计算子问题，那么动态规划也不会有什么帮助。

#### 参考资料
> - http://en.wikipedia.org/wiki/Dynamic_programming
> - https://stackoverflow.com/questions/1065433/what-is-dynamic-programming 
> - http://www.cs.berkeley.edu/~vazirani/algorithms/chap6.pdf 
> - http://www.topcoder.com/tc?d1=tutorials&d2=dynProg&module=Static 
> - http://sist.sysu.edu.cn/~isslxm/DSA/textbook/Skiena.-.TheAlgorithmDesignManual.pdf

#### 练习题

> - https://people.cs.clemson.edu/~bcdean/dp_practice/ 
> - https://www.hackerrank.com/domains/algorithms/dynamic-programming
