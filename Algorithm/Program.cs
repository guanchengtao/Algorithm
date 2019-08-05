using Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {

          //  SearchMethods();
            DPMethods();
          //  ArrayMethods();
          //  StackAndQueue();
            //OthersMethods();



            Console.ReadKey();
        }
        static void SearchMethods()
        {
            Console.WriteLine(Search.BinarySearch(new int[] {1,4,5,3,2 },1));
            //Console.WriteLine(Search.Bsearch_1(new int[] { 1,2,3,4,5 }, 10,0,5));
        }
        static void DPMethods()
        {
            int[,] nums = new int[3, 3] {
              {1, 3, 1},
              {1, 5, 1},
              {4, 2, 1}
            };
            Console.WriteLine("=====DynamicProgramming========");
            Console.WriteLine(DynamicProgramming.UniquePaths(7, 3));
            int[,] nums1 = new int[3, 3] {
              { 0, 0, 0 },
              { 0, 0, 0 },
              { 0, 0, 1 }
            };
            int[,] num2 = new int[4, 4]
            {
              {       1,  0,  0,  0},
              {     3,  1,  0,  0},
              {   6,  5,  1,  0},
              { 4,  1,  8,  3}
            };
            Console.WriteLine(DynamicProgramming.UniquePathsWithObstacles(nums1));
            Console.WriteLine(DynamicProgramming.GetMaxMoney(nums));
            Console.WriteLine(DynamicProgramming.GetMinMoney(nums));
            Console.WriteLine(DynamicProgramming.ClimbStairs(3));
            Console.WriteLine(DynamicProgramming.MinimumTotal(num2));
            Console.WriteLine(DynamicProgramming.MaxProfit(new int[] { 7, 1, 5, 8, 6, 4 }));
            Console.WriteLine(DynamicProgramming.Rob(new int[] { 2, 7, 9, 3, 1 }));
            Console.WriteLine(DynamicProgramming.RobII(new int[] { 2, 7, 9, 3, 1 }));
            Console.WriteLine(DynamicProgramming.DoTackForMoney());
            Console.WriteLine("======DynamicProgramming========");
        }
        static void ArrayMethods()
        {
            Console.WriteLine("=====Array========");
            int[,] nums = new int[4, 4] {
              { 1, 2, 8, 9  },
              { 2, 2, 9, 12 },
              { 4, 1, 10,13 },
              { 6, 1, 1, 1  }
            };
            Console.WriteLine(ArrayHelper.FindChongFuNumber(new int[] { 1, 3, 3, 4, 5, 2 }));
            Console.WriteLine(ArrayHelper.FindChongFuNumberPlus(new int[] { 1, 5, 2, 3, 3 }));
            Console.WriteLine(ArrayHelper.FindingInTwoDimensionalArray(nums, 1));
            Console.WriteLine(ArrayHelper.NumbersThatAppearMoreThanHalfTheTimeInArray(new int[] { 1, 2, 3, 3, 3 }));
            //数组是升序数组
            Console.WriteLine(ArrayHelper.TheNumberOfTimesNumberAppears(new int[] { 1, 2, 2, 3, 3 }, 3));
            Console.WriteLine("=====Array========");
        }
        static void StackAndQueue()
        {
            Console.WriteLine("=======StackAndQueue======");
            for (int i = 1; i <= 5; i++)
            {
                QueueStack.Push_s(i);
            }
            Console.WriteLine(QueueStack.Top_s());
            QueueStack.Pop_s();
            Console.WriteLine(QueueStack.Top_s());


            for (int i = 1; i <= 5; i++)
            {
                QueueStack.Push_q(i);
            }
            Console.WriteLine(QueueStack.Top_q());
            QueueStack.Pop_q();
            Console.WriteLine(QueueStack.Top_q());
            Console.WriteLine("=======StackAndQueue======");
        }
        static void OthersMethods()
        {
            Console.WriteLine("=======OthersMethods======");
            Console.WriteLine(Others.NumberOf2(7));
            Console.WriteLine(Others.FibonacciI(10));
            Console.WriteLine(Others.FibonacciII(10));
            Console.WriteLine(Others.FibonacciIII(10));
            int[] res = Others.CountBits(5);
            for (int i = 0; i < res.Length; i++)
            {
                Console.Write(res[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine("=======OthersMethods======");
        }
    }
}
