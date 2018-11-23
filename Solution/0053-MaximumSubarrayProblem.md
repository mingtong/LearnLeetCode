## Maximum subarray problem

#### 描述： 
找出一个 int 数组中的最大子数组的和。（数组长度 >= 1） 
比如：
```
[-2,1,-3,4,-1,2,1,-5,4] 的最大子数组是 
[4,-1,2,1] 
和是 6
```

#### 思路： 
表面上这是一个最优化问题（optimization problem），可以试着用 DP 去解。DP 的第一步就是找出子问题： 
maxSubArray(int A[], int i, int j)，即：找到 A[i] 到 A[j] 的最大的和。 
以 [-2,1,-3,4,-1,2,1,-5,4] 为例 
dp[i] 就是以 A[i] 为结尾的最大子数组的和。 
dp[0] 是第 1 个数字的和，也即A[0]：-2 
dp[1] 是第 dp[0] + A[1] 的和与 A[1] 相比较的选更大的和，max(1, 1+(-2)) = 1 
dp[2] 是第 dp[1] + A[2] 的和与 A[2] 相比较的选更大的和，max(-3, -3+1) = -2 
依次可得： 
dp[0] = -2; 
dp[1] = max(1, 1-2) = 1; 
dp[2] = max(-3, -3+1) = -2; 
dp[3] = max(4, 4-2) = 4; 
dp[4] = max(-1, -1+4) = 3; 
dp[5] = max(2, 2+3) = 5; 
dp[6] = max(1, 1+5) = 6; 
dp[7] = max(-5, -5+6) = 1; 
dp[8] = max(4, 4+1) = 5;

这得出的最大结果即是 dp[6] = 6;

这道题其实也是 Kadane 算法 的应用，也是 maximum likelihood 最大相似度算法的数字图片的估算模型。

#### 实现：
``` C#
public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        int[] dp = new int[nums.Length];
        dp[0] = nums[0];
        int result = dp[0];

        for (int i = 1; i < nums.Length; i++)
        {
            dp[i] = Math.Max(nums[i], dp[i - 1] + nums[i]);
            result = Math.Max(result, dp[i]);
        }

        return result;
    }
}
```
