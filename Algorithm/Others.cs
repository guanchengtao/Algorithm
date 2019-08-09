using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public static class Others
    {
        /// <summary>
        /// 二进制中1的个数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int NumberOf2(int n)
        {
            int count = 0;
            while (n != 0)
            {
                ++count;
                n = n & (n - 1);
            }
            return count;
        }
        /// <summary>
        /// 比特位计数
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>

        public static int[] CountBits(int n)
        {
            int[] res = new int[n + 1];
            if (n <= 0) return res;
            for (int i = 1; i <= n; i++)
            {
                res[i] = res[i & (i - 1)] + 1;
            }
            return res;
        }

        /// <summary>
        /// 斐波那契数列、青蛙爬台阶、拿苹果
        /// </summary>
        /// <param name="n"></param>
        /// <returns>1 1 2 3 5 8 13 21 32 55</returns>
        public static int FibonacciI(int n)
        {
            if (n == 1 || n == 2) return 1;
            return FibonacciI(n - 2) + FibonacciI(n - 1);
        }
        public static int FibonacciII(int n)
        {
            if (n == 1 || n == 2) return 1;
            int[] res = new int[n];
            res[0] = res[1] = 1;
            for (int i = 2; i < n; i++)
            {
                res[i] = res[i - 1] + res[i - 2];
            }
            return res[n - 1];
        }
        public static int FibonacciIII(int n)
        {
            if (n == 1 || n == 2) return 1;
            int num1 = 1, num2 = 1, res = 0;
            for (int i = 2; i < n; i++)
            {
                res = num1 + num2;
                num1 = num2;
                num2 = res;
            }
            return res;
        }
    }
}
