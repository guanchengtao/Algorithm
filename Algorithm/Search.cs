using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public static class Search
    {
        public static int BinarySearch(int[] nums,int k)
        {
            if (nums.Length == 0) return -1;
            Array.Sort(nums);
            int l = 0, r = nums.Length;
            while(l <= r)
            {
                int mid = (l + r) >> 1;
                if (nums[mid] > k) r = mid;
                else if (nums[mid] < k) l = mid + 1;
                else return mid;
            }
            return -1;
        }
    }
}
