namespace Palindrome_Linked_List
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
            var firstTestList = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1, null))));
            Console.WriteLine(IsPalindrome(firstTestList));
        }

        public static bool IsPalindrome(ListNode head)
        {
            var queue = new Queue<int>();
            var stack = new Stack<int>();
            var tail = head;
            while (tail != null)
            {
                queue.Enqueue(tail.val);
                stack.Push(tail.val);
                tail = tail.next;
            }

            while (queue.Count > 0 && stack.Count > 0)
            {
                if (stack.Pop() != queue.Dequeue())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
