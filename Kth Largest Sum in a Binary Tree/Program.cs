namespace Kth_Largest_Sum_in_a_Binary_Tree
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

        private static Dictionary<int, long> treeLevelSums = new Dictionary<int, long>();

        static void Main(string[] args)
        {
        }

        public static long KthLargestLevelSum(TreeNode root, int k)
        {
            DFS(root, 1);
            var orderedLevelSums = treeLevelSums.Values.OrderByDescending(x => x).ToList();

            if (k > orderedLevelSums.Count)
            {
                return -1;
            }

            return orderedLevelSums[k - 1];
        }

        private static void DFS(TreeNode node, int level)
        {
            if (node == null)
            {
                return;
            }

            if (!treeLevelSums.ContainsKey(level))
            {
                treeLevelSums[level] = 0;
            }

            treeLevelSums[level] += node.val;

            DFS(node.left, level + 1);
            DFS(node.right, level + 1);
        }
    }
}
