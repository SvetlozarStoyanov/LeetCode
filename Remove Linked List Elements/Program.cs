namespace Remove_Linked_List_Elements
{
    internal class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        static void Main(string[] args) 
        {
            RemoveElements(new ListNode(1, new ListNode(2, new ListNode(6, new ListNode(4, new ListNode(5, new ListNode(6)))))), 6);
        }
        public static ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null)
            {
                return null;
            }
            var start = head;
            var curr = head;
            var prev = (ListNode?)null;

            while (true)
            {
                if (curr.val == val)
                {
                    if (prev != null)
                    {
                        prev.next = curr.next;
                    }
                    else
                    {
                        start = curr.next;
                    }
                }
                else
                {
                    prev = curr;
                }
                if (curr.next == null)
                {
                    break;
                }
                curr = curr.next;
            }

            return start;
        }
    }
}
