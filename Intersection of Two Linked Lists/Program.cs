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
            var foundValues = new HashSet<ListNode>();
            while (headA != null && headB != null)
            {
                if (foundValues.Contains(headA))
                {
                    return headA;
                }
                foundValues.Add(headA);
                if (foundValues.Contains(headB))
                {
                    return headB;
                }
                foundValues.Add(headB);
                headA = headA.next;
                headB = headB.next;
            }
            while (headA != null)
            {
                if (foundValues.Contains(headA))
                {
                    return headA;
                }
                headA = headA.next;
            }
            while (headB != null)
            {
                if (foundValues.Contains(headB))
                {
                    return headB;
                }
                headB = headB.next;
            }
            return null;
        }
    }
}
