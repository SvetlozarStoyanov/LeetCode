namespace Symmetric_Tree
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


        private static bool isSymmetrical = true;
        static void Main(string[] args)
        {
            var result = IsSymmetric(new TreeNode(1, new TreeNode(2, new TreeNode(3, null, null), null), new TreeNode(2, new TreeNode(3, null, null))));
            Console.WriteLine(result);
        }


        public static bool IsSymmetric(TreeNode root)
        {
            var queue = new Queue<TreeNode>();

            LeftFavoringDFS(queue, root.left);
            RightFavoringDFS(queue, root.right);

            if (queue.Count > 0)
            {
                return false;
            }

            return isSymmetrical;
        }

        private static void LeftFavoringDFS(Queue<TreeNode> queue, TreeNode node)
        {
            queue.Enqueue(node);
            if (node == null)
            {
                return;
            }
            LeftFavoringDFS(queue, node.left);
            LeftFavoringDFS(queue, node.right);
        }

        private static void RightFavoringDFS(Queue<TreeNode> queue, TreeNode node)
        {
            if (!isSymmetrical)
            {
                return;
            }
            var curr = queue.Dequeue();
            if (curr is not null && node is not null)
            {
                if (curr.val != node.val)
                {
                    isSymmetrical = false;
                }
            }
            else if (curr is null && node is null)
            {

            }
            else
            {
                isSymmetrical = false;
            }
            
            if (node == null)
            {
                return;
            }
            RightFavoringDFS(queue, node.right);
            RightFavoringDFS(queue, node.left);
        }
    }
}
