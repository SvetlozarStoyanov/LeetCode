namespace Binary_Tree_Level_Order_Traversal
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

        private static Dictionary<int, IList<int>> levelNodes; 

        static void Main(string[] args)
        {

        }

        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            levelNodes = new Dictionary<int, IList<int>>();

            DFS(0, root);

            var resultList = new List<IList<int>>();
            foreach (var level in levelNodes)
            {
                resultList.Add(level.Value);
            }

            return resultList;
        }

        public static void DFS(int level, TreeNode node)
        {
            if (node is null)
            {
                return;
            }
            if (!levelNodes.ContainsKey(level))
            {
                levelNodes.Add(level, new List<int>());
            }
            levelNodes[level].Add(node.val);

            DFS(level + 1, node.left);
            DFS(level + 1, node.right);
        }
    }
}
