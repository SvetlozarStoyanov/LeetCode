using System.Text;

namespace Binary_Tree_Paths
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

        private static List<string> paths = new List<string>();
        private static Stack<int> stack = new Stack<int>();

        static void Main(string[] args)
        {
            Console.WriteLine(string.Join("\n", BinaryTreePaths(new TreeNode(1, new TreeNode(2, null, new TreeNode(5)), new TreeNode(3)))));
        }

        public static IList<string> BinaryTreePaths(TreeNode root)
        {
            DFS(root);

            return paths;
        }

        private static void DFS(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            stack.Push(node.val);

            if (node.left is null && node.right is null)
            {
                paths.Add(string.Join("->", stack.Reverse()));
                stack.Pop();
                return;
            }

            DFS(node.left);
            DFS(node.right);
            stack.Pop();
        }
    }
}
