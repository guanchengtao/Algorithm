using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public static class DP
    {
        //               _ _ _ _
        //               _ _ _ _
        //  [2,3,1],     _ _ _ _ 
        //  [1,7,1],     _ _ _ _
        //  [4,6,1] 2 -> 3 -> 7 -> 6 -> 1  total： 19
        //寻找最优解
        /// <summary>
        /// 九宫格获取最大利润
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int GetMaxMoney(int[,] nums)
        {
            int m = nums.GetLength(0), n = nums.GetLength(1);
            int[,] opts = new int[m + 1, n + 1];
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    opts[i, j] = Math.Max(opts[i, j - 1], opts[i - 1, j]) + nums[i - 1, j - 1];
                }
            }
            return opts[m, n];
        }
        /// <summary>
        /// 最小利润
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int GetMinMoney(int[,] nums)
        {
            // 1 1 1 
            // 2 3 1
            // 1 1 1
            int m = nums.GetLength(0), n = nums.GetLength(1);
            int[,] opts = new int[m + 1, n + 1];
            int val = -1;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i == 1) val = opts[i, j - 1];
                    else if (j == 1) val = opts[i - 1, j];
                    else val = Math.Min(opts[i, j - 1], opts[i - 1, j]);
                    opts[i, j] = val + nums[i - 1, j - 1];
                }
            }
            return opts[m, n];
        }
        /// <summary>
        /// 唯一的路径
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int UniquePaths(int m, int n)
        {
        // 递归只会超出时间限制，所以这种问题最好用dp来解决（记忆化搜索）
        /*
        if(n == 1 || m == 1) return 1;
        return uniquePaths(m-1,n)+uniquePaths(m,n-1);
        */
            int[,] opts = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0) opts[i, j] = 1;
                    else
                    {
                        opts[i, j] = opts[i - 1, j] + opts[i, j - 1];
                    }
                }
            }
            return opts[m - 1, n - 1];
        }
        /// <summary>
        /// 唯一的路径II
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int UniquePathsWithObstacles(int[,] nums)
        {
            int m = nums.GetLength(0);
            int n = nums.GetLength(1);
            int[,] opts = new int[m, n];
            if (nums[0, 0] == 0) opts[0, 0] = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != 0 || j != 0) opts[i, j] = 0;
                    if(nums[i,j] == 0)
                    {
                        if (i != 0) opts[i, j] += opts[i - 1, j];
                        if (j != 0) opts[i, j] += opts[i, j - 1];
                    }
                }
            }
            return opts[m - 1, n - 1];
        }
        /// <summary>
        /// 爬楼梯
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int ClimbStairs(int n)
        {
            //就是一fib数列,但是会超时
            /*
            if (n == 1 || n == 2) return n;
            else return ClimbStairs(n - 1) + ClimbStairs(n - 2);
            */
            if (n <= 2) return n;
            int[] nums = new int[n];
            nums[0] = 1;
            nums[1] = 2;
            for (int i = 2; i < n; i++)
            {
                nums[i] = nums[i - 1] + nums[i - 2];
            }
            return nums[n - 1];
        }
        /// <summary>
        /// 三角形最小路径和
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static int MinimumTotal(int[,] triangle)
        {
            /*
            // 复制三角形最后一行，作为用来更新的一维数组。然后逐个遍历这个DP数组
            // 对于每个数字，和它之后的元素比较选择较小的再加上上面一行相邻位置的元素做为新的元素，
            // 然后一层一层的向上扫描，整个过程和冒泡排序的原理差不多，最后最小的元素都冒到前面，第一个元素即为所求。
                 [2],
                [3,4],
               [6,5,7],
              [4,1,8,3]      
           */
            int n = triangle.GetLength(0);
            int[] opts = { 4, 1, 8, 3 };
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    opts[j] = Math.Min(opts[j], opts[j + 1]) + triangle[i,j];
                }
            }
            return opts[0];
        }
    }
}
