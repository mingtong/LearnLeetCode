## 位运算(in progress)

### Bitwise XOR
XOR(^) ：异或，数学符号为 ^
```
1^0 = 1  
0^1 = 1  
0^0 = 0
1^1 = 0  
```
XOR by 1 可以像开发一样从 1 到 0 或者 从 0 到 1. 
还有一个有意思的：
```
x^0 = x 
x^x = 0
```
- 应用 1：翻转数字 N 的所有二进制位。 
解决方案：如果 N 是32位数字，则：
```
N ^((1 << 32) - 1 )
```
- 应用 2：不用运算符交换两个数字。 
解决方案：
```
A = A ^ B;
B = A ^ B;
A = A ^ B;
```

### Bitwise AND
```
1 & 1 = 1
1 & 0 = 0
0 & 1 = 0
0 & 0 = 0
```
### Bitwise Inclusive OR
```
1 | 1 = 1
1 | 0 = 1
0 | 1 = 1
0 | 0 = 0
```

#### 参考资料
> - https://xijunlee.github.io/2017/04/01/efficiently/ 
> - https://discuss.leetcode.com/topic/50315/a-summary-how-to-use-bit-manipulation-to-solve-problems-easily-and-efficiently 
> - http://blog.csdn.net/fanoluo/article/details/49456275 
> - https://www.hackerrank.com/topics/bit-manipulation
