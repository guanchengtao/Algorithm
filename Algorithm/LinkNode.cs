using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkNode
{
    class LinkNode
    {
        public object data { get; set; }
        public LinkNode next { get; set; }
        public LinkNode(object value)
        {
            data = value;
            next = null;
        }
        public LinkNode Create()
        {
            var head = new LinkNode(1);
            var virhead = head;
            int i = 1;
            while (i++ < 10)
            {
                var curnode = new LinkNode(i);
                virhead.next = curnode;
                virhead = curnode;
            }
            return head;
        }
        public void Print(LinkNode head)
        {
            while (head != null)
            {
                Console.Write(head.data + "\t");
                head = head.next;
            }
            Console.WriteLine();
        }

        public LinkNode Reverse(LinkNode head)
        {
            LinkNode cur = head;
            LinkNode pre = null;
            while (cur != null)
            {
                LinkNode nextp = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
            return pre;
        }

        public void MergeLinkList(LinkNode p, LinkNode q)
        {
            if (p == null && q == null) return;
            var head = new LinkNode(1);
            while (p != null && q != null)
            {
                if ((int)p.data >= (int)q.data)
                {
                    head.next = p;
                    head = p;
                    p = p.next;
                }
                else
                {
                    head.next = q;
                    head = q;
                    q = q.next;
                }
            }
            while (p != null)
            {
                head.next = p;
            }
            while (q != null)
            {
                head.next = q;
            }
        }
    }
}
