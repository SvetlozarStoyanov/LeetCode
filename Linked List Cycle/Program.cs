namespace Linked_List_Cycle
{
    internal class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static bool HasCycle(ListNode head)
        {
            var curr = head;
            var visited = new HashSet<ListNode>();
            while (curr != null)
            {
                if (visited.Contains(curr))
                {
                    return true;
                }
                visited.Add(curr);
                curr = curr.next;
            }
            return false;
        }
    }
}
