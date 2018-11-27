## Valid Parentheses

#### 描述： 
给一个只包含”(“, “),”, “[“, “]”, “{“, “}” 的字符串，判断这个字符串是否有效（配对）。 
比如：
```
“()[]{}” 是有效的。 
“([)]” 是无效的。
```

#### 思路： 
让 3 种括号能有效的原则要依次配对，左开口的 3 种扩号是 ：”(“, “[“, “{“, 右开口的 3 种扩号是 “)”, “]”, “}”, 要让左右都配对，那就必须保证右开口扩号的前一个扩号一定要与它上一个扩号配对。 
可以用栈来处理这种问题，遇到左扩号就入栈，遇到右扩号就出栈，进而判断出栈的扩号与遇到的扩号是否配对，直到栈中没有扩号，如果到最后栈中还有扩号则配对失败。

#### 代码实现：
``` C#
public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> p = new Stack<char>();

        for (int i = 0; i < s.Length; ++i)
        {
            if (s[i] == '(' || s[i] == '[' || s[i] == '{')
            {
                p.Push(s[i]);
            }
            else
            {
                if (s[i] == ')')
                {
                    if (p.Count == 0 || p.Peek() != '(')
                    {
                        return false;
                    }
                }
                else if (s[i] == ']')
                {
                    if (p.Count == 0 || p.Peek() != '[')
                    {
                        return false;
                    }
                }
                else if (s[i] == '}')
                {
                    if (p.Count == 0 || p.Peek() != '{')
                    {
                        return false;
                    }
                }
                p.Pop();
            }
        }
        if (p.Count > 0)
        {
            return false;
        }
        return true;
    }
}
```
