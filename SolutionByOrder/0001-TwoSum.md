## Two Sum
Easy

#### 描述： 
Given an array of integers, return indices of the two numbers such that they add up to a specific target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.

```
Given nums = [2, 7, 11, 15], target = 9, 
Because nums[0] + nums[1] = 2 + 7 = 9, 
return [0, 1].
```

#### 思路：

用一个 HashMap 去缓存已经遍历过的元素，然后只需要判断当前的遍历元素与遍历过的元素之和是否是要求结果即可，这样的时间复杂度是 O(n)。

#### 实现代码：
``` kotlin
class Solution {
    fun twoSum(nums: IntArray, target: Int): IntArray {
        var map = mutableMapOf<Int, Int>();

        for((i,num) in nums.withIndex()){
            if(map.containsKey(target - num)){
                return intArrayOf(map[target - num] as Int,i);
            } else {
                map.putIfAbsent(num,i);
            }
        }
        return intArrayOf();
    }
}
```

#### 总结：

- C# 使用 Dictionary，Java 使用 HashMap，Kotlin使用 MutableHashmap.


