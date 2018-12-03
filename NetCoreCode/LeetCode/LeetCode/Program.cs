using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var dp = new DP();
            var v = dp.MaxSubArray();
            Console.WriteLine(v);
        }
    }
}