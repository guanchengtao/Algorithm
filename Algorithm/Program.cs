using Array;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // LinkNode node = new LinkNode(1);
            // Console.WriteLine(node.data);
            //var head=node.Create();
            // node.Print(head);
            int[,] nums = new int[4, 4] {
              { 1, 2, 8, 9  },
              { 2, 4, 9, 12 },
              { 4, 7, 10,13 },
              { 6, 8, 11,15 }
            };
            Console.WriteLine(ArrayHelper.GetMaxMoney(nums));
            Console.WriteLine(ArrayHelper.FindChongFuNumber(new int[] { 1, 3, 3, 4, 5, 2 }));
            Console.WriteLine(ArrayHelper.FindChongFuNumberPlus(new int[] { 1, 5, 2, 3, 3 }));
            Console.WriteLine(ArrayHelper.FindingInTwoDimensionalArray(nums, 1));

            //Console.WriteLine(nums.GetLength(0)); // 一维长度
            // Console.WriteLine(nums.GetLength(1)); // 二维长度
            // var newhead = node.Reverse(head);
            // node.Print(newhead);
            //  [2,3,1],
            //  [1,7,1],
            //  [4,6,1] 2 -> 3 -> 7 -> 6 -> 1  total： 19
            Console.ReadKey();
        }
    }
}
