using System.Linq;
using System.Text;

namespace Smallest_String_Starting_From_Leaf
{
    internal class Program
    {
        private static Stack<int> valueStack;
        private static List<int> minValueList;
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

        public static string SmallestFromLeaf(TreeNode root)
        {
            valueStack = new Stack<int>();
            minValueList = new List<int>();
            valueStack.Push(root.val);
            DepthFirstSearch(root);
            var result = TurnToString(minValueList);
            return result;
        }

        public static void DepthFirstSearch(TreeNode node)
        {
            if (node.left == null && node.right == null)
            {
                if (minValueList.Count == 0)
                {
                    minValueList = valueStack.ToList();
                }
                else if (CompareLists(valueStack.ToList(), minValueList))
                {
                    minValueList = valueStack.ToList();
                }
            }
            if (node.left != null)
            {
                valueStack.Push(node.left.val);
                DepthFirstSearch(node.left);
                valueStack.Pop();
            }
            if (node.right != null)
            {
                valueStack.Push(node.right.val);
                DepthFirstSearch(node.right);
                valueStack.Pop();
            }
        }

        private static bool CompareLists(List<int> listOne, List<int> listTwo)
        {
            var reachedIndex = 0;
            while (reachedIndex < listOne.Count && reachedIndex < listTwo.Count)
            {
                if (listOne[reachedIndex] < listTwo[reachedIndex])
                {
                    return true;
                }
                else if (listOne[reachedIndex] > listTwo[reachedIndex])
                {
                    return false;
                }
                reachedIndex++;
            }
            if (listOne.Count < listTwo.Count)
            {
                return true;
            }
            return false;
        }

        private static string TurnToString(List<int> list)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                sb.Append((char)(list[i] + 97));
            }
            return sb.ToString();
        }
    }
}
