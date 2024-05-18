namespace Intersection_of_Two_Linked_Lists
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
            }
        }

        static void Main(string[] args)
        {

        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var visited = new HashSet<ListNode>();
            var headATail = headA;
            while (headATail != null)
            {
                visited.Add(headATail);
                headATail = headATail.next;
            }
            var headBTail = headB;
            while (headBTail != null)
            {
                if (visited.Contains(headBTail))
                {
                    return headBTail;
                }
                visited.Add(headBTail);
                headBTail = headBTail.next;
            }
            return null;
        }
    }
}
