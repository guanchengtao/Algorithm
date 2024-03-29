﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkNodeHelper
{
    class ListNode
    {
        public object Data { get; set; }
        public ListNode Next { get; set; }
        public ListNode(){}
        public ListNode(object value)
        {
            Data = value;
            Next = null;
        }
        /// <summary>
        /// 创建带头节点的链表
        /// </summary>
        /// <returns></returns>
        public ListNode Create(int[] nums)
        {
            int n = nums.Length;
            if (n == 0) return null;
            var head = new ListNode(nums[0]);
            var virhead = head;
            for (int i = 1; i < n; i++)
            {
                var curnode = new ListNode(nums[i]);
                virhead.Next = curnode;
                virhead = curnode;
            }
            return head;
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="head"></param>
        public void Print(ListNode head)
        {
            var node = head;
            while (node != null)
            {
                Console.Write(node.Data + "\t");
                node = node.Next;
            }
            Console.WriteLine();
        }
        /// <summary>
        /// 列表长度
        /// </summary>
        /// <param name="head"></param>
        public int GetLength(ListNode head)
        {
            int length = 0;
            if (head == null) return length;
            var node = head;
            while (node != null)
            {
                ++length;
                node = node.Next;
            }
            return length;
        }
        /// <summary>
        /// 判断链表是否有环
        /// </summary>
        /// <param name="head">1、2、3、4、5、6</param>
        /// <returns></returns>
        public bool IsRing(ListNode head)
        {
            if (head == null || head.Next == null) return false;
            var slow = head;
            var fast = head;
            while(fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast) return true;
            }
            return false;
        }
        /// <summary>
        /// 求环的入口
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode RingProtal(ListNode head)
        {
            if (head == null || head.Next == null) return null;
            var slow = head;
            var fast = head;
            while (fast !=null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if(slow == fast)
                {
                    fast = head;
                    while(slow !=fast)
                    {
                        slow = slow.Next;
                        fast = fast.Next;
                    }
                    return slow;
                }
            }
            return null;
        }

        /// <summary>
        /// 反转链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode Reverse(ListNode head)
        {
            var cur = head;
            ListNode pre = head;
            while(cur != null)
            {
                var nextp = cur.Next;
                cur.Next = pre;
                pre = cur;
                cur = nextp;
            }
            return pre;
        }
        /// <summary>
        /// 合并链表
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public ListNode MergeLinkList(ListNode p, ListNode q)
        {
            if (p == null && q == null) return null;
            var head = new ListNode(1);
            var node = head;
            while (p != null && q != null)
            {
                if ((int)p.Data < (int)q.Data)
                {
                    node.Next = p;
                    node = p;
                    p = p.Next;
                }
                else
                {
                    node.Next = q;
                    node = q;
                    q = q.Next;
                }
            }
            if (p != null)
            {
                node.Next = p;
            }
            else
            {
                node.Next = q;
            }
            return head;
        }

        public int FirstCommonNode(ListNode headA, ListNode headB)
        {
            #region 借助栈
            /*
            if (p == null || q == null) return -1;
            Stack<int> stk1 = new Stack<int>();
            Stack<int> stk2 = new Stack<int>();
            while (p!=null)
            {
                stk1.Push((int)p.Data);
                p = p.Next;
            }
            while (q != null)
            {
                stk2.Push((int)q.Data);
                q = q.Next;
            }
            int res = -1;
            while (stk1.Peek() == stk2.Peek())
            {
                res = stk1.Peek();
                stk1.Pop();
                stk2.Pop();
            }
            return res;
            */
            #endregion
            #region 先让短的走两步
            /*
            if (p == null || q == null) return -1;
            int l1 = GetLength(p), l2 = GetLength(q);
            ListNode longlist = p, shortlist = q;
            if(l1<l2)
            {
                longlist = q;
                shortlist = p;
            }
            int k = Math.Abs(l1 - l2);
            for (int i = 0; i < k; i++)
            {
                longlist = longlist.Next;
            }
            while(longlist!=null && shortlist!=null)
            {
                if ((int)longlist.Data == (int)shortlist.Data) return (int)longlist.Data;
                else
                {
                    longlist = longlist.Next;
                    shortlist = shortlist.Next;
                }
            }
            return -1;
            */
            #endregion

            //ListNode p = headA, q = headB;
            //while (p != q)
            //{
            //    if (p!=null) p = p = p.Next;
            //    else p = headB;
            //    if (q!=null) q = q.Next;
            //    else q = headA;
            //}
            //return (int)p.Data;
            return -1;
        }
        /// <summary>
        /// 删除重复节点
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode cur = head;
            while (cur != null && cur.Next != null)
            {
                if(cur.Data==cur.Next.Data)
                {
                    cur.Next = cur.Next.Next;
                }
                else
                {
                    cur = cur.Next;
                }
            }
            return head;
        }
    }
}
