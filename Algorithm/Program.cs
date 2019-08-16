using Arrays;
using LinkNodeHelper;
using SortHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithm
{
    class InterviewInfo
    {
        public int ID { get; set; }
        public List<InterviewFeedBack> FeedBackList { get; set; }
    }
    class InterviewFeedBack
    {
        public int FeedBackId { get; set; }
        public int TenantId { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region Linq-Select
            //List<InterviewInfo> list = new List<InterviewInfo>();
            //InterviewInfo interviewInfo = new InterviewInfo()
            //{
            //    ID = 1,
            //    FeedBackList = new List<InterviewFeedBack>()
            //    {
            //        new InterviewFeedBack(){TenantId = 127796,FeedBackId = 101},
            //        new InterviewFeedBack(){TenantId = 127796,FeedBackId = 102},
            //        new InterviewFeedBack(){TenantId = 127796,FeedBackId = 103},

            //    }
            //};
            //InterviewInfo interviewInfo1 = new InterviewInfo()
            //{
            //    ID = 2
            //};
            //InterviewInfo interviewInfo2 = new InterviewInfo()
            //{
            //    ID = 3,
            //    FeedBackList = new List<InterviewFeedBack>()
            //    {
            //        new InterviewFeedBack(){TenantId = 127796,FeedBackId = 301},
            //        new InterviewFeedBack(){TenantId = 127796,FeedBackId = 302}
            //    }
            //};
            //InterviewInfo interviewInfo3 = new InterviewInfo()
            //{
            //    ID = 4
            //};
            //list.Add(interviewInfo);
            //list.Add(interviewInfo1);
            //list.Add(interviewInfo2);
            //list.Add(interviewInfo3);
            //List<int> Ids = new List<int>();
            //foreach (var interview in list)
            //{
            //    if(interview.FeedBackList!=null && interview.FeedBackList.Count() > 0)
            //    {
            //        Ids.AddRange(interview.FeedBackList.Select(x => x.FeedBackId));
            //    }
            //}
            //foreach (var item in Ids)
            //{
            //    Console.Write(item + "、");
            //} 
            #endregion
            //17.3*16+1.5房补+期权
            //狗东本科白菜 17*14
            Console.WriteLine($"Kuaishou：{17.3 * 16}");
            Console.WriteLine($"Jingdong：{ 17*14}");
            Console.WriteLine($"Beisen:{20*14}");
            Console.WriteLine("$EestMoney:{}");
            //  SearchMethods();
            // DPMethods();
            //  ArrayMethods();
            //  StackAndQueue();
            //OthersMethods();
            //LinkListMethods();
            //  TreeNodeMethods();
            //  StringMethods();
            // SortMethods();
            //Console.WriteLine(1024 * 39);
            Console.ReadKey();
        }
        static void StringMethods()
        {
            Console.WriteLine(String.LongestSubstringWithoutDuplication("aabbcc"));
        }
        static void TreeNodeMethods()
        {
            TreeNode tree = new TreeNode();
            var root = tree.Create();
            tree.PreOrder(root);
            Console.WriteLine();
            tree.PreorderTraversal(root);
            Console.WriteLine();
            tree.InOrder(root);
            Console.WriteLine();
            tree.InorderTraversal(root);
            Console.WriteLine();
            tree.PostOrder(root);
            Console.WriteLine();
            tree.PostOrderTraversal(root);
            Console.WriteLine();
            Console.WriteLine(tree.IsBalanced(root));
            Console.WriteLine(tree.IsSymmetric(root));
            Console.WriteLine(tree.GetLength(root));
        }
        static void LinkListMethods()
        {
            ListNode list = new ListNode();
            #region reverse
            //int[] nums = { 1,2,3,4,5,6};
            //var head=  list.Create(nums);
            //list.Print(head);
            //var newhead = list.Reverse(head);
            //list.Print(newhead); 
            #endregion
            #region merge
            int[] nums1 = { 1, 3, 4, 6, 7, 8 };
            int[] nums2 = { 2, 3, 4, 5 };
            var head1 = list.Create(nums1);
            var head2 = list.Create(nums2);
            var mergehead = list.MergeLinkList(head1, head2);
            list.Print(mergehead);
            Console.WriteLine(list.GetLength(mergehead));
            #endregion

            #region firstcommonnode
            //int[] nums1 = { 1, 7 };
            //int[] nums2 = { 4, 7 };
            //var head1 = list.Create(nums1);
            //var head2 = list.Create(nums2);
            //Console.WriteLine(list.FirstCommonNode(head1, head2));
            #endregion

            ListNode delhead =  list.DeleteDuplicates(mergehead);
            list.Print(delhead);

            
        }
        static void SearchMethods()
        {
            Console.WriteLine(Search.BinarySearch(new int[] { 1, 4, 5, 3, 2 }, 1));
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
            Console.WriteLine(DynamicProgramming.CoinsChange(new int[] { 1,2,3,5},14));
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
            var arr = ArrayHelper.ReverseArray(new int[] { 1,2,3,4,5});
            foreach (int item in arr)
            {
                Console.Write(item+"\t");
            }
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
        static void SortMethods()
        {
            int[] nums = new int[] { 2, 5, 3, 2, 1, 4 };
            Sort.QuickSort(ref nums, 0, nums.Length - 1);
            Sort.Print(nums);
        }
    }
}
