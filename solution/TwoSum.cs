public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int[] result = new int[2];
        Dictionary<int, int> map = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; ++i)
        {
            if(map.ContainsKey(target - nums[i]))
            {
                result[1] = i;
                result[0] = map[target - nums[i]];
                return result;
            }
            if(!map.ContainsKey(nums[i]))
            {
                map.Add(nums[i], i);
            }       
        }
        return result;
    }
}
