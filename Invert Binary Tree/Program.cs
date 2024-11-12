namespace Invert_Binary_Tree
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
        static void Main(string[] args)
        {
            
        }

        public TreeNode InvertTree(TreeNode root)
        {
            DFS(root);
            return root;
        }

        private static void DFS(TreeNode node)
        {
            if (node is null)
            {
                return;
            }

            DFS(node.left);
            DFS(node.right);

            SwapChildren(node);
        }

        private static void SwapChildren(TreeNode node)
        {
            var temp = node.left;
            node.left = node.right;
            node.right = temp;
        }
    }
}
