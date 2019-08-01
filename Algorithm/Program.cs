using Array;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithm
{
    public delegate int TestDelegate(int x, int y);
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
            TestDelegate d2 = (int m ,int n) => { return m + n; };

            d2(1,1);

            Console.WriteLine(ArrayHelper.GetMaxMoney(nums));
            Console.WriteLine(ArrayHelper.FindChongFuNumber(new int[] { 1, 3, 3, 4, 5, 2 }));
            Console.WriteLine(ArrayHelper.FindChongFuNumberPlus(new int[] { 1, 5, 2, 3, 3 }));
            Console.WriteLine(ArrayHelper.FindingInTwoDimensionalArray(nums, 1));
            Console.WriteLine(Others.NumberOf2(7));
            Console.WriteLine(Others.Fibonacci(10,1));
            Console.WriteLine(10 & 9);
            Console.WriteLine(ArrayHelper.NumbersThatAppearMoreThanHalfTheTimeInArray(new int[] { 1,2,3,3,3}));
            Console.WriteLine(DateTime.Now);
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
            //数组是升序数组
            DateTime beforeExcute = DateTime.Now;
            // Thread.Sleep(1000);
            Console.WriteLine(ArrayHelper.TheNumberOfTimesNumberAppears(new int[] { 1,2,2,3,3},3));
            DateTime afterExcute = DateTime.Now;
            TimeSpan ts = afterExcute - beforeExcute;
            Console.WriteLine(ts.TotalMilliseconds);
            // 1、1、2、3、5、8、13、21、32、55
            // Console.WriteLine(nums.GetLength(0)); // 一维长度
            // Console.WriteLine(nums.GetLength(1)); // 二维长度
            // var newhead = node.Reverse(head);
            // node.Print(newhead);
            // [2,3,1],
            // [1,7,1],
            //  [4,6,1] 2 -> 3 -> 7 -> 6 -> 1  total： 19
            Console.ReadKey();
        }
    
    }
}
