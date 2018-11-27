## Reverse Integer

#### 描述： 
给一个32位有符号整数，按位反转。 
如果溢出则返回0。 
比如：
```
Input: 123 
Output: 321 
Input: -123 
Output: -321 
Input: 120 
Output: 21
```

#### 思路： 
第一反应是转换成 string，再反转，但这肯定不是最高效的。 
可以从右向左按位逐个取出数字，保存进一个新的数字。 
比如： 1234-> 123-[4] -> 12-[43] -> 1-[432] -> [4321] 
有点像反转链表的思路，不过按位取出数字的过程要麻烦一些。

#### 实现：
``` C#
public class Solution
{
    public int Reverse(int x)
    {
        int result = 0;
        while (x != 0)
        {
            int tail = x % 10; //对10求余得到末位数字
            int newResult = result * 10 + tail; //新结果*10进位，然后把上一步得到的末位数字插入新结果的后面
            if ((newResult - tail) / 10 != result)
            {
                //如果上一步反算不成立，则说明 stack overflow
                return 0;
            }

            result = newResult;
            x /= 10; //除以10相当于原数字舍去末位数字
        }
        return result;
    }
}
```
