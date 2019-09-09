using SortHelper;
using System;

namespace Arrays
{
   public static class ArrayHelper
    {
        //在0 ~ n-1 有 n 个数字
        public static int FindChongFuNumber(int[] nums)
        {
            int n = nums.Length;
            foreach (int x in nums)
            {
                if (x < 0 || x >= n) return -1;
            }
            for (int i = 0; i < n; i++)
            {
                while (nums[i] != i && nums[nums[i]] != nums[i]) Sort.Swap(ref nums[nums[i]], ref nums[i]);
                if (nums[i] != i && nums[nums[i]] == nums[i]) return nums[i];
            }
            return -1;
        }
        //1,5,2,3,3
        public static int FindChongFuNumberPlus(int[] nums)
        {
            int l = 1, r = nums.Length - 1;
            while (l < r)
            {
                int mid = l + r >> 1;
                int sum = 0;
                foreach (int x in nums)
                {
                    if (x >= l && x <= mid) sum++;
                }
                if (sum > mid - l + 1) r = mid;
                else l = mid + 1;
            }
            return r;
        }

        public static int TheNumberOfTimesNumberAppears(int[] nums,int k)
        {
            //这可不是暴力，O(lgn) time
            if (nums.Length==0) return 0;
            int l = 0, r = nums.Length - 1;
            while (l < r)
            {
                int mid = l + r >> 1;
                if (nums[mid] < k) l = mid + 1;
                else r = mid;
            }
            if (nums[l] != k) return 0;
            int left = l;
            l = 0;
            r = nums.Length - 1;
            while (l < r)
            {
                int mid = l + r + 1 >> 1;
                if (nums[mid] <= k) l = mid;
                else r = mid - 1;
            }
            return r - left + 1;
            /*
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == k) count++;
            }
            return count; */
        }
        /// <summary>
        /// 数组的众数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int NumbersThatAppearMoreThanHalfTheTimeInArray(int[] nums)
        {
            //O(1) space O(n) time
            int count = 0;
            int res = 0;
            foreach (int x in nums)
            {
                if(count == 0)
                {
                    res = x;
                    count++;
                }
                else if(res == x) count++;
                else count--;
            }
            return res;
        }
        //从Two-dimensional array中find one number
        /// <summary>
        /// 二维数组查询数
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool FindingInTwoDimensionalArray(int[,] nums, int key)
        { 
            int row = 0;
            int col = nums.GetLength(1) - 1;
            while (row < nums.GetLength(0) && col >= 0)
            {
                if (nums[row, col] > key) col--;
                else if (nums[row, col] < key) row++;
                else return true;
            }
            return false;
        }
        /// <summary>
        /// 反转数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static  int[] ReverseArray(int[] nums)
        {
            //方法一：创建一个新数组
            //方法二：
            for (int i = 0; i < nums.Length/2; i++)
            {
                int temp = nums[i];
                nums[i] = nums[nums.Length - 1 - i];
                nums[nums.Length - 1 - i] = temp;
            }
            return nums;

        }
        /// <summary>
        /// 寻找最长上升子序列,非连续
        /// </summary>
        /// <param name="nums">[1,2,3,4,2,3,4,5,7,3,1]</param>
        /// <returns></returns>
        public static int FindLongestUpChildQueue(int[] nums)
        {
            int[] dp = new int[1000];
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                        res = Math.Max(res, dp[i]);
                    }
                }
            }
            return res + 1;
            // 3, 1, 2, 1, 8, 5, 6
        }

        public static int GetMaxMoney(int[,] nums)
        {
            int m = nums.GetLength(0), n = nums.GetLength(1);
            int[,] opts = new int[m + 1, n + 1];
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    opts[i, j] = nums[i - 1, j - 1] + Math.Max(opts[i - 1, j], opts[i, j - 1]);
                }
            }
            return opts[m, n];
        }
        public static int GetMinMoney(int[,] nums)
        {
            int m = nums.GetLength(0), n = nums.GetLength(1);
            int[,] opts = new int[m + 1, n + 1];
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    int minval = Math.Min(opts[i - 1, j], opts[i, j - 1]);
                    if (i == 1) minval = opts[i, j - 1];
                    if (j == 1) minval = opts[i - 1, j];
                    opts[i, j] = nums[i - 1, j - 1] + minval;
                }
            }
            return opts[m, n];
        }
        public static int GetAllPaths(int m, int n)
        {
            int[,] opts = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == 0 || i == 0) opts[i, j] = 1;
                    else
                    {
                        opts[i, j] = opts[i - 1, j] + opts[i, j - 1]; 
                    }
                }
            }
            return opts[m - 1, n - 1];
        }
    }
}
