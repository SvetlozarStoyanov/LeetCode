namespace Count_Complete_Tree_Nodes
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

        private static int CountNodes(TreeNode root)
        {
            return BFS(root);
        }

        private static int BFS(TreeNode treeNode)
        {
            var queue = new Queue<TreeNode>();

            var nodeCount = 0;

            queue.Enqueue(treeNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node is not null)
                {
                    nodeCount++;
                    queue.Enqueue(node.left);
                    if (node.left is not null && node.right is null)
                    {
                        nodeCount += queue.Count;
                        break;
                    }
                    queue.Enqueue(node.right);
                }
                
            }

            return nodeCount;
        }
    }
}
