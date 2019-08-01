using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    static class QueueStack
    {
        public static Queue<int> Queue { get; } = new Queue<int>();
        public static Queue<int> Queue_Help { get; } = new Queue<int>();
        public static Stack<int> Stack { get;} = new Stack<int>();
        public static Stack<int> Stack_Help { get; } = new Stack<int>();

        #region TwoQueueBuildOneStack
        /// <summary>
        /// 进栈
        /// </summary>
        /// <param name="val"></param>
        public static void Push_s(int val)
        {
            Queue.Enqueue(val);
        }
        /// <summary>
        /// 弹出栈
        /// </summary>
        /// <returns></returns>
        public static int Pop_s()
        {
            while (Queue.Count > 1)
            {
                int x = Queue.Dequeue();
                Queue_Help.Enqueue(x);
            }
            int res = Queue.Dequeue();
            while (Queue_Help.Count > 0)
            {
                int x = Queue_Help.Dequeue();
                Queue.Enqueue(x);
            }
            return res;
        }
        /// <summary>
        /// 返回栈顶
        /// </summary>
        /// <returns></returns>
        public static int Top_s()
        {
            while (Queue.Count > 1)
            {
                int x = Queue.Dequeue();
                Queue_Help.Enqueue(x);
            }
            int res = Queue.Dequeue();
            Queue_Help.Enqueue(res);
            while (Queue_Help.Count > 0)
            {
                int x = Queue_Help.Dequeue();
                Queue.Enqueue(x);
            }
            return res;
        }
        #endregion

        /// <summary>
        /// 进队
        /// </summary>
        /// <param name="val"></param>
        public static void Push_q(int val)
        {
            Stack.Push(val);
        }
        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public static int Pop_q()
        {
            while(Stack.Count > 1)
            {
                Stack_Help.Push(Stack.Pop());
            }
            int res = Stack.Pop();
            while(Stack_Help.Count > 0)
            {
                Stack.Push(Stack_Help.Pop());
            }
            return res;
        }
        /// <summary>
        /// 返回队首
        /// </summary>
        /// <returns></returns>
        public static int Top_q()
        {
            while (Stack.Count > 1)
            {
                Stack_Help.Push(Stack.Pop());
            }
            int res = Stack.Pop();
            Stack_Help.Push(res);
            while (Stack_Help.Count > 0)
            {
                Stack.Push(Stack_Help.Pop());
            }
            return res;
        }
    }
}
