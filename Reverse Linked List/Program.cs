namespace Reverse_Linked_List
{
    internal class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x, ListNode next = null)
            {
                val = x;
                this.next = next;
            }
        }

        private static ListNode tail;
        static void Main(string[] args)
        {
            //ReverseList(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4)))));
            ReverseList(new ListNode(1, new ListNode(2)));
        }

        private static ListNode ReverseList(ListNode head)
        {
            if (head is null)
            {
                return null;
            }
            if (head.next is null)
            {
                return head;
            }
            tail = head;

            Recursion(head, head.next);
            head.next = null;

            return tail;
        }

        private static void Recursion(ListNode prev, ListNode curr)
        {
            if (curr.next is null)
            {
                tail = curr;
                tail.next = prev;
                return;
            }

            Recursion(curr, curr.next);

            curr.next = prev;
        }
    }
}
