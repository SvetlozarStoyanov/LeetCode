namespace Same_Tree
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

        private static bool areSame = true;

        static void Main(string[] args)
        {

        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            DepthFirstSearch(p, q);
            return areSame;
        }

        public static void DepthFirstSearch(TreeNode treeOne, TreeNode treeTwo)
        {
            if (!areSame || (treeOne == null && treeTwo == null))
            {
                return;
            }
            if ((treeOne != null && treeTwo == null)
                || (treeOne == null && treeTwo != null)
                || (treeOne.val != treeTwo.val))
            {
                areSame = false;
                return;
            }

            DepthFirstSearch(treeOne.left, treeTwo.left);
            DepthFirstSearch(treeOne.right, treeTwo.right);
        }
    }
}
