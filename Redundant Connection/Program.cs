namespace Redundant_Connection
{
    internal class Program
    {
        private static bool targetReached;
        private static List<int> visited;
        static void Main(string[] args)
        {
            //FindRedundantConnection([[1, 2], [2, 3], [1, 5], [3, 4], [1, 4]]);
            FindRedundantConnection([[1, 2], [1, 3], [2, 3]]);
            //FindRedundantConnection([[9, 10], [5, 8], [2, 6], [1, 5], [3, 8], [4, 9], [8, 10], [4, 10], [6, 8], [7, 9]]);
        }

        public static int[] FindRedundantConnection(int[][] edges)
        {
            var graph = new Dictionary<int, List<int>>();
            var extraEdge = new int[2];
            visited = new List<int>();
            foreach (var edge in edges)
            {
                if (!graph.ContainsKey(edge[1]))
                {
                    graph.Add(edge[1], new List<int>());
                }
                if (!graph.ContainsKey(edge[0]))
                {
                    graph.Add(edge[0], new List<int>());
                }
                if (graph[edge[0]].Count + 1 > 1 && graph[edge[1]].Count + 1 > 1)
                {
                    targetReached = false;
                    if (visited.Count > 0)
                    {
                        visited.Clear();
                    }
                    DFS(edge[1], edge[0], graph);
                    if (targetReached)
                    {
                        extraEdge[0] = edge[0];
                        extraEdge[1] = edge[1];
                    }
                }
                graph[edge[1]].Add(edge[0]);
                graph[edge[0]].Add(edge[1]);
            }

            return extraEdge;
        }

        private static void DFS(int node, int target, Dictionary<int, List<int>> graph)
        {
            if (targetReached || visited.Contains(node))
            {
                return;
            }
            if (node == target)
            {
                targetReached = true;
                return;
            }
            visited.Add(node);
            foreach (var currNode in graph[node])
            {
                DFS(currNode, target, graph);
            }
        }
    }
}
