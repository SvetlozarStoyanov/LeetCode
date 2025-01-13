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
            ////DFS Solution
            //levelNodes = new Dictionary<int, IList<int>>();

            //DFS(0, root);
            //foreach (var level in levelNodes)
            //{
            //    resultList.Add(level.Value);
            //}




            // BFS Solution
            var resultList = new List<IList<int>>();
            BFS(resultList, root);
            return resultList;
        }

        private static void BFS(IList<IList<int>> resultList, TreeNode node)
        {
            if (node is null)
            {
                return;
            }
            var bfsQueue = new Queue<TreeNode>();
            var nodesOnLevel = 1;
            bfsQueue.Enqueue(node);
            resultList.Add(new List<int>() { });

            while (bfsQueue.Count > 0)
            {
                var curr = bfsQueue.Dequeue();
                if (curr.left is not null)
                {
                    bfsQueue.Enqueue(curr.left);
                }
                if (curr.right is not null)
                {
                    bfsQueue.Enqueue(curr.right);
                }
                resultList[resultList.Count - 1].Add(curr.val);
                nodesOnLevel--;
                if (nodesOnLevel == 0)
                {
                    if (bfsQueue.Count > 0)
                    {
                        resultList.Add(new List<int>());
                    }
                    nodesOnLevel = bfsQueue.Count;
                }
            }
        }

        private static void DFS(int level, TreeNode node)
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
