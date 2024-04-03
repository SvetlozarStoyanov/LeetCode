using System.Xml.Linq;

namespace Maximum_Depth_of_Binary_Tree
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
        private static int maxDepth = 0;

        static void Main(string[] args)
        {

        }

        public int MaxDepth(TreeNode root)
        {
            return maxDepth;
        }

        public static void DepthFirstSearch(int currDepth, TreeNode node)
        {
            if (currDepth > maxDepth)
            {
                maxDepth = currDepth;
            }
            if (node.right != null)
            {
                DepthFirstSearch(currDepth + 1, node.right);
            }
            if (node.left != null)
            {
                DepthFirstSearch(currDepth + 1, node.left);
            }
        }
    }
}
