namespace Minimum_Depth_of_Binary_Tree
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

        private static int minDepth = int.MaxValue;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static int MinDepth(TreeNode root)
        {
            DFS(1, root);
            return minDepth;
        }


        private static void DFS(int currDepth, TreeNode node)
        {
            if (node is null)
            {
                return;
            }
            else if (node.left is null && node.right is null)
            {
                if (currDepth < minDepth)
                {
                    minDepth = currDepth;
                }
                return;
            }

            DFS(currDepth + 1, node.left);
            DFS(currDepth + 1, node.right);
        }
    }
}
