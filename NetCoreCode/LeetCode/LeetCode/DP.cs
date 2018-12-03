using System;

namespace LeetCode
{
    public class DP
    {
        private int[] cache;
        private int[] price = new int[] {1, 5, 8, 9, 10, 17, 17, 20, 24, 30};
        private int[] subArray = new[] {-2, 1, -3, 4, -1, 2, 1, -5, 4};

        /// <summary>
        /// calculate Fibonacci 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FibonacciRecursive(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            var v1 = FibonacciRecursive(n - 1);
            Console.WriteLine("calculate v1= " + v1);
            var v2 = FibonacciRecursive(n - 2);
            Console.WriteLine("calculate v2= " + v2);
            return v1 + v2;
        }

        public int StartFibonacciMemoization(int n)
        {
            cache = new int[n + 1];
            var v = FibonacciMemoization(n);
            return v;
        }

        private int FibonacciMemoization(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            if (cache[n - 1] != 0)
            {
                return cache[n];
            }

            //暂存每个子集的和
            cache[n] = FibonacciMemoization(n - 1) + FibonacciMemoization(n - 2);
            Console.WriteLine("calculate cache[" + (n) + "]= " + cache[n]);
            return cache[n];
        }

        /// <summary>
        /// bottom-up
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FibonacciBottomUp(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            cache = new int[n + 1]; //暂存每个子集的和
            cache[0] = 0;
            cache[1] = 1;
            for (int i = 2; i < n + 1; i++)
            {
                cache[i] = cache[i - 1] + cache[i - 2];
                Console.WriteLine("calculate cache[" + (i) + "]= " + cache[i]);
            }

            return cache[n];
        }

        /// <summary>
        /// 钢条切割
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int BottomUpCut(int n)
        {
            int[] amount = new int[n + 1];
            amount[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                int optimal = -1;
                //get the optimal solution
                for (int j = 1; j <= i; j++)
                {
                    var v = price[j - 1] + amount[i - j];
                    Console.Write("price[" + (j - 1) + "]= " + price[j - 1] + ";");
                    Console.Write("amount[" + (i - j) + "]= " + amount[i - j] + "---");
                    Console.WriteLine(price[j - 1] + amount[i - j]);
                    optimal = Math.Max(optimal, v);
                }

                amount[i] = optimal;
                Console.WriteLine("calculate amount[" + (i) + "]= " + amount[i]);
            }

            return amount[n];
        }

        public int MaxSubArray()
        {
            int[] dp = new int[subArray.Length];//dp[i] means the maximum subarray ending with A[i];
            dp[0] = subArray[0];
            int result = dp[0];

            for (int i = 1; i < subArray.Length; i++)
            {
                dp[i] = Math.Max(subArray[i], dp[i - 1] + subArray[i]);
                Console.WriteLine("dp[" + i + "]=" + dp[i]);
                result = Math.Max(result, dp[i]);
                Console.WriteLine("result=" + result);
            }

            return result;
        }
    }
}