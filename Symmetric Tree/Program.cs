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



        static void Main(string[] args)
        {
            var result = IsSymmetric(new TreeNode(1, new TreeNode(2, new TreeNode(3, null, null), null), new TreeNode(2, new TreeNode(3, null, null))));
            Console.WriteLine(result);
        }


        public static bool IsSymmetric(TreeNode root)
        {
            var leftQueue = new Queue<TreeNode>();
            var rightQueue = new Queue<TreeNode>();

            LeftFavoringDFS(leftQueue, root.left);
            RightFavoringDFS(rightQueue, root.right);

            if (leftQueue.Count != rightQueue.Count)
            {
                return false;
            }
            else
            {
                while (rightQueue.Count > 0)
                {
                    var left = leftQueue.Dequeue();
                    var right = rightQueue.Dequeue();

                    if (left is not null && right is not null)
                    {
                        if (left.val != right.val)
                        {
                            return false;
                        }
                    }
                    else if (left is null && right is null)
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
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
            queue.Enqueue(node);
            if (node == null)
            {
                return;
            }
            RightFavoringDFS(queue, node.right);
            RightFavoringDFS(queue, node.left);
        }
    }
}
