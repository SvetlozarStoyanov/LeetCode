namespace Binary_Tree_Preorder_Traversal
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

        private static IList<int> preorderTraversalList;
        static void Main(string[] args)
        {

        }

        public static IList<int> PreorderTraversal(TreeNode root)
        {
            preorderTraversalList = new List<int>();
            DFS(root);
            return preorderTraversalList;
        }

        private static void DFS(TreeNode node)
        {
            if (node is null)
            {
                return;
            }

            preorderTraversalList.Add(node.val);

            DFS(node.left);
            DFS(node.right);
        }
    }
}
