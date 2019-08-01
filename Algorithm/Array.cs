using SortHelper;
using System;

namespace Array
{
   public static class ArrayHelper
    {
        //               _ _ _ _
        //               _ _ _ _
        //  [2,3,1],     _ _ _ _ 
        //  [1,7,1],     _ _ _ _
        //  [4,6,1] 2 -> 3 -> 7 -> 6 -> 1  total： 19
        //寻找最优解
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
        public static bool FindingInTwoDimensionalArray(int[,] nums, int key)
        {
            /* This solution is two low.
            int m = nums.GetLength(0);
            int n = nums.GetLength(1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (nums[i, j] == key) return true;
                }
            }
            return false;
            //key = 10
              { 1, 2, 8, 9  },
              { 2, 4, 9, 12 },
              { 4, 7, 10,13 },
              { 6, 8, 11,15 }
             */
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
    }
}
