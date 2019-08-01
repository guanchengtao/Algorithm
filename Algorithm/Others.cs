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
        public static int Fibonacci(int n)
        {
            if (n == 1 || n == 2) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        public static int Fibonacci(int n,int ii)
        {
            int num1 = 1;
            int num2 = 1;
            int res = 0;
            for (int i = 3; i <= n; i++)
            {
                res = num1 + num2;
                num2 = num1;
                num1 = res;
            }
            return res;
        }
    }
}
