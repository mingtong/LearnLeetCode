## Two Sum

#### 题目描述： 
给出一个数组 nums，找出其中两个和为 target 值的元素的索引，注意：有且只有一对值符合要求。如：

```
Given nums = [2, 7, 11, 15], target = 9, 
Because nums[0] + nums[1] = 2 + 7 = 9, 
return [0, 1].
```

#### 思路：

第一反应会去暴力双重循环地判断 nums[0] + nums[i++]，num[1] + nums[i++]。而这样的时间复杂度是 O(n2)，空间复杂度是O(1)。

而巧妙的做法是用一个 HashMap 去缓存已经遍历过的元素，这样使得空间复杂度是O(n)，但是只需要一轮循环，就可以遍历出结果，只需要判断当前的遍历元素与遍历过的元素之和即可，这样的时间复杂度是 O(n)。

实现代码：
``` C#
public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        int[] result = new int[2];
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; ++i)
        {
            if (map.ContainsKey(target - nums[i]))
            {
                result[1] = i;
                result[0] = map[target - nums[i]];
                return result;
            }

            if (!map.ContainsKey(nums[i]))
            {
                map.Add(nums[i], i);
            }
        }

        return result;
    }
}
```
