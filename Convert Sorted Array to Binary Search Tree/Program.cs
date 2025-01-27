namespace Convert_Sorted_Array_to_Binary_Search_Tree
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

        private static bool[] visited;

        static void Main(string[] args)
        {
            //SortedArrayToBST(new int[] { -10, -3, 0, 5, 9 });
            //SortedArrayToBST(new int[] { 1, 3 });
            //SortedArrayToBST(new int[] { 0, 1, 2, 3, 4, 5 });
            //SortedArrayToBST(new int[] { -1, 0, 1, 2 });
            SortedArrayToBST(new int[] { 0, 1, 2, 3, 4, 5, 6 });
        }

        public static TreeNode SortedArrayToBST(int[] nums)
        {
            visited = new bool[nums.Length];
            var middleIndex = nums.Length / 2;
            var head = new TreeNode(nums[middleIndex], null, null);
            DFS(middleIndex, 0, nums.Length, head, nums);
            return head;
        }

        public static void DFS(int index, int leftBoundary, int rightBoundary, TreeNode node, int[] nums)
        {
            if (visited[index] || node is null)
            {
                return;
            }

            visited[index] = true;

            var leftIndex = (leftBoundary + index) / 2;

            var rightIndex = (rightBoundary + index) / 2;

            if (leftIndex == rightIndex)
            {
                return;
            }

            if (!visited[leftIndex])
            {
                node.left = new TreeNode(nums[leftIndex], null, null);
            }

            if (!visited[rightIndex])
            {
                node.right = new TreeNode(nums[rightIndex], null, null);
            }


            DFS(leftIndex, leftBoundary, index, node.left, nums);
            DFS(rightIndex, index, rightBoundary, node.right, nums);
        }
    }
}
