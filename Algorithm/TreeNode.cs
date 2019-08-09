using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm;

namespace Algorithm
{
    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode() { }
        public TreeNode(int data)
        {
            val = data;
            left = null;
            right = null;
        }

        /// <summary>
        /// 创建静态二叉树，捞，仅限学习用
        ///      1
        ///   2     3
        /// 4   5
        /// </summary>
        /// <returns></returns>
        public TreeNode Create()
        {
            List<int> list = new List<int>();
            TreeNode root = new TreeNode(1);
            TreeNode left1 = new TreeNode(2);
            TreeNode right1 = new TreeNode(3);
            root.left = left1;
            root.right = right1;
            TreeNode left2 = new TreeNode(4);
            TreeNode right2 = new TreeNode(5);
            left1.left = left2;
            left1.right = right2;
            TreeNode left22 = new TreeNode(5);
            TreeNode right22 = new TreeNode(4);
            right1.left = left22;
            right1.right = right22;
            left2.left = new TreeNode(2);
            return root;
        }
        /// <summary>
        /// 前序遍历递归
        /// </summary>
        /// <param name="root"></param>
        public void PreOrder(TreeNode root)
        {
            if (root == null) return;
            Console.Write(root.val + "\t");
            PreOrder(root.left);
            PreOrder(root.right);
        }
        /// <summary>
        /// 前序遍历非递归
        /// </summary>
        /// <param name="root"></param>
        public void PreorderTraversal(TreeNode root)
        {
            if (root == null) return;
            Stack<TreeNode> stk = new Stack<TreeNode>();
            while (root!=null || stk.Count > 0)
            {
                if(root!=null)
                {
                    Console.Write(root.val +"\t");
                    stk.Push(root);
                    root = root.left;
                }
                else
                {
                    TreeNode node = stk.Peek();
                    stk.Pop();
                    root = node.right;
                }
            }
        }
        /// <summary>
        /// 中序遍历递归
        /// </summary>
        /// <param name="root"></param>
        public void InOrder(TreeNode root)
        {
            if (root == null) return;
            InOrder(root.left);
            Console.Write(root.val + "\t");
            InOrder(root.right);
        }

        public void InorderTraversal(TreeNode root)
        {
            if (root == null) return;
            Stack<TreeNode> stk = new Stack<TreeNode>();
            while (root != null || stk.Count > 0)
            {
                if (root != null)
                {
                    stk.Push(root);
                    root = root.left;
                }
                else
                {
                    TreeNode node = stk.Peek();
                    stk.Pop();
                    Console.Write(node.val + "\t");
                    root = node.right;
                }
            }

        }
        /// <summary>
        /// 后序遍历递归
        /// </summary>
        /// <param name="root"></param>
        public void PostOrder(TreeNode root)
        {
            if (root == null) return;
            PostOrder(root.left);
            PostOrder(root.right);
            Console.Write(root.val + "\t");
        }
        public void PostOrderTraversal(TreeNode root)
        {
            //思路：每个元素进栈2次，出栈时如果和栈顶元素相同，就说明其子树还未被访问，将孩子进栈，否则就访问 
            if (root ==null) return;
            Stack<TreeNode> stk = new Stack<TreeNode>();
            TreeNode P = root;
            stk.Push(P);
            stk.Push(P);
            while (stk.Count > 0)
            {
                P = stk.Peek();
                stk.Pop();
                if (stk.Count > 0 && P == stk.Peek())
                {
                    if (P.right != null)
                    {
                        stk.Push(P.right);
                        stk.Push(P.right);
                    }
                    if (P.left != null)
                    {
                        stk.Push(P.left);
                        stk.Push(P.left);
                    }
                }
                else
                {
                    Console.Write(P.val + "\t");
                }
            }
        }
        bool res = true;
        /// <summary>
        /// 平衡二叉树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(TreeNode root)
        {
            Dfs(root);
            return res;
        }
        public int Dfs(TreeNode root)
        {
            if (root == null) return 0;
            int left_h = Dfs(root.left);
            int right_h = Dfs(root.right);
            if (Math.Abs(left_h - right_h) > 1) res = false;
            return Math.Max(left_h, right_h) + 1;
        }
        /// <summary>
        /// 对称二叉树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            return Dfs(root.left, root.right);
        }
        public bool Dfs(TreeNode p_left, TreeNode p_right)
        {
            if (p_left == null || p_right == null) return p_left == null && p_right == null;
            if (p_left.val != p_left.val) return false;
            return Dfs(p_left.left, p_right.right) && Dfs(p_right.right, p_right.left);
        }
        public int GetLength(TreeNode root)
        {
            if (root == null) return 0;
            int left_h = GetLength(root.left);
            int right_h = GetLength(root.right);
            return Math.Max(left_h, right_h) + 1;
        }
    }
}
