namespace Remove_Nth_Node_From_End_of_List
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
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstTestNode = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, null)))));
            RemoveNthFromEnd(firstTestNode, 2);
            //var secondTestNode = new ListNode(1, new ListNode(2, null));
            //RemoveNthFromEnd(secondTestNode, 1);
            //var thirdTestNode = new ListNode(1, null);
            //RemoveNthFromEnd(thirdTestNode, 1);
            //var fourthTestNode = new ListNode(1, new ListNode(2, null));
            //RemoveNthFromEnd(fourthTestNode, 2);
            var fifthTestNode = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, null)))));
            RemoveNthFromEnd(fifthTestNode, 4);

        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var tail = head;

            while (true)
            {
                var prev = tail;
                var tempTail = tail;
                var iterations = 0;
                while (iterations <= n)
                {
                    if (tempTail == null)
                    {
                        if (iterations == n)
                        {
                            head = head.next;
                            return head;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    if (iterations == n && tempTail.next == null)
                    {
                        if (n == 1)
                        {
                            tail.next = null;
                        }
                        else
                        {
                            tail.next = tail.next.next;
                        }
                        return head;
                    }
                    prev = tempTail;
                    tempTail = tempTail.next;
                    iterations++;
                }
                tail = tail.next;
            }
            return head;
        }
    }
}
