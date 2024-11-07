namespace Binary_Tree_Inorder_Traversal
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

        private static List<int> visited = new List<int>();
        static void Main(string[] args)
        {

        }


        public static IList<int> InorderTraversal(TreeNode root)
        {
            DFS(root);
            return visited;
        }

        private static void DFS(TreeNode node)
        {
            if (node is null)
            {
                return;
            }

            DFS(node.left);
            visited.Add(node.val);
            DFS(node.right);
        }
    }
}
