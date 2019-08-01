using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortHelper
{
   public static class Sort
    {
        //ref : 引用传递  不加ref只能是值传递
        public static void Swap(ref int a, ref int b)
        {
            int t = a; a = b; b = t;
        }

        public static void Print(int[] nums)
        {
            foreach (int num in nums)
            {
                Console.Write(num + "\t");
            }
            Console.WriteLine();
        }

        public static void SelectSort(ref int[] nums)
        {
            int k = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                k = i;
                //遍历一次最小在最前
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[k] > nums[j]) k = j;
                }
                if (k != i)
                {
                    Swap(ref nums[k], ref nums[i]);
                }
            }
        }

        public static void BubbleSort(ref int[] nums)
        {
            bool flag = false;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                //遍历一次最大在最后
                for (int j = 0; j < nums.Length - i - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        Swap(ref nums[j], ref nums[j + 1]);
                        flag = true;
                    }
                }
                if (!flag) break;
            }
        }

        public static void QuickSort(ref int[] nums, int l, int r)
        {
            if (l >= r) return;
            int i = l - 1, j = r + 1, mid = nums[(l + r) >> 1];
            while (i < j)
            {
                do i++; while (nums[i] < mid);
                do j--; while (nums[j] > mid);
                if (i < j)
                {
                    Swap(ref nums[i], ref nums[j]);
                }
                else
                {
                    QuickSort(ref nums, l, j);
                    QuickSort(ref nums, j + 1, r);
                }
            }
        }


        public static void InsertSort(ref int[] nums)
        {
            // 2 1
            for (int i = 1; i < nums.Length; i++)
            {
                int t = nums[i], j;
                for (j = i - 1; j >= 0; j--)
                {
                    if (t < nums[j]) nums[j + 1] = nums[j];
                    else break;
                }
                nums[j + 1] = t;
            }
        }
        public static void CountSort(ref int[] nums)
        {
            int[] count = new int[9];
            for (int i = 0; i < nums.Length; i++)
            {
                count[nums[i]]++;//count数组实际存的nums数组中每个元素出现的次数
            }
            for (int j = 0, k = 0; j < count.Length; j++)
            {
                while (count[j] != 0)
                {
                    nums[k++] = j;
                    count[j]--;
                }
            }
        }
    }
}
