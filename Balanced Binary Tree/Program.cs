using System.Collections.Immutable;

namespace Balanced_Binary_Tree
{
    internal class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        private static bool isBalanced = true;

        static void Main(string[] args)
        {
            //var tree = new TreeNode(1, null, new TreeNode(2, null, new TreeNode(3, null)));
            //var tree = new TreeNode(3, new TreeNode(9, null, null), new TreeNode(20, new TreeNode(15, null, null), new TreeNode(7, null, null)));
            //var tree = new TreeNode(1, new TreeNode(2, new TreeNode(4, new TreeNode(8), null), new TreeNode(5)), new TreeNode(3, new TreeNode(6), null));
            var tree = new TreeNode(1, new TreeNode(2, new TreeNode(3, new TreeNode(4), new TreeNode(4)), new TreeNode(3)), new TreeNode(2));
            Console.WriteLine(IsBalanced(null));
        }

        public static bool IsBalanced(TreeNode root)
        {
            DFS(root);

            return isBalanced;
        }

        private static int DFS(TreeNode node)
        {
            if (node is null || !isBalanced)
            {
                return 0;
            }

            var leftHeight = DFS(node.left);
            var rightHeight = DFS(node.right);

            if (Math.Abs(leftHeight - rightHeight) > 1)
            {
                isBalanced = false;
            }

            return 1 + Math.Max(leftHeight, rightHeight);
        }
    }
}
