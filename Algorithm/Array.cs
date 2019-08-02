using SortHelper;
using System;

namespace Array
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
