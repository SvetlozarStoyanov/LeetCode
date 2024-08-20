using System.Diagnostics;

namespace Validate_Binary_Search_Tree
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

    internal class Program
    {
        private static bool treeIsValid = true;

        static void Main(string[] args)
        {
            var node = new TreeNode(0, null, null);
            var isValid = IsValidBST(node);
        }

        public static bool IsValidBST(TreeNode root)
        {
            DepthFirstSearch(root, null, false);
            DepthFirstSearchExperimental(root, long.MinValue, long.MaxValue);

            return treeIsValid;
        }

        private static void DepthFirstSearch(TreeNode node, TreeNode previous, bool isIncreasing)
        {
            if (node == null || !treeIsValid)
            {
                return;
            }

            if (node.left != null)
            {
                if (node.val <= node.left.val)
                {
                    treeIsValid = false;
                    return;
                }
                else if (previous != null)
                {
                    if (isIncreasing)
                    {
                        if (previous.val >= node.left.val)
                        {
                            treeIsValid = false;
                        }
                    }
                    else
                    {
                        if (previous.val <= node.left.val)
                        {
                            treeIsValid = false;
                        }
                    }
                }
                DepthFirstSearch(node.left, node, false);
            }
            if (node.right != null)
            {
                if (node.val >= node.right.val)
                {
                    treeIsValid = false;
                    return;
                }
                else if (previous != null)
                {
                    if (isIncreasing)
                    {
                        if (previous.val >= node.right.val)
                        {
                            treeIsValid = false;
                        }
                    }
                    else
                    {
                        if (previous.val <= node.right.val)
                        {
                            treeIsValid = false;
                        }
                    }
                }
                DepthFirstSearch(node.right, node, true);
            }
        }

        private static void DepthFirstSearchExperimental(TreeNode node, long min, long max)
        {
            if (node == null || !treeIsValid)
            {
                return;
            }

            if (node.left != null)
            {
                if (node.val <= node.left.val)
                {
                    treeIsValid = false;
                }
                else if (!(node.left.val > min && node.left.val < max))
                {
                    treeIsValid = false;
                }
                DepthFirstSearchExperimental(node.left, min, node.val);
            }

            if (node.right != null)
            {
                if (node.val >= node.right.val)
                {
                    treeIsValid = false;
                }
                else if (!(node.right.val > min && node.right.val < max))
                {
                    treeIsValid = false;
                }
                DepthFirstSearchExperimental(node.right, node.val, max);
            }
        }
    }
}
