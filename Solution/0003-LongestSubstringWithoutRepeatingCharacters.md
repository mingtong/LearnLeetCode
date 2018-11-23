## Longest Substring Without Repeating Characters

#### 描述： 
给出一个字符串，找出最长不重复的子串（连续的）。比如：
```
Given “abcabcbb“, the answer is “abc“, which the length is 3. 
Given “bbbbb“, the answer is “b“, with the length of 1. 
Given “pwwkew“, theanswer is “wke“, with the length of 3. Note that the answer must be a substring, “pwke” is a subsequence and not a substring.
```
#### 思路1： HashSet 
用一个 HashSet 保存遍历过的元素，遇到重复的元素，首先依次删除之前的元素，直到 set 中与要当前元素重复时。再把这个元素添加进 set。分别用快慢两个指针来判断删除还是添加元素。 
比如 “pwwkew”，set 中保存的字符依次是 
[p] //无复杂，添加 
[pw] //无复杂，添加 
[w] //有重复，依次删除之前的元素 p 
[] //有重复，依次删除之前的元素 w 
[w] //无复杂，添加 
[wk] //无复杂，添加 
[wke] //无复杂，添加 
[ke] //有重复，依次删除之前的元素 w 
[kew] //无复杂，添加 
//到头

#### 实现：
``` C#
public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        int result = 0;
        HashSet<int> set = new HashSet<int>();
        int slowPoint = 0;
        int fastPoint = 0;
        while (fastPoint < s.Length)
        {
            if (!set.Contains(s[fastPoint]))
            {
                set.Add(s[fastPoint++]);
                result = Math.Max(result, set.Count);
            }
            else
            {
                set.Remove(s[slowPoint++]);
            }
        }

        return result;
    }
}
```

#### 思路2
动态规划的思想

#### 实现2
``` C#
int lengthOfLongestSubstring(string s) {
    // for ASCII char sequence, use this as a hashmap
    vector<int> charIndex(256, -1);
    int longest = 0, m = 0;

    for (int i = 0; i < s.length(); i++) {
        m = max(charIndex[s[i]] + 1, m);    // automatically takes care of -1 case
        charIndex[s[i]] = i;
        longest = max(longest, i - m + 1);
    }

    return longest;
}
```
