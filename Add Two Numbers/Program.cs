namespace Add_Two_Numbers
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
            //var nodeListOne = new ListNode(2, new ListNode(4, new ListNode(3, null)));
            //var nodeListTwo = new ListNode(5, new ListNode(6, new ListNode(4, null)));
            //PrintNodeList(AddTwoNumbers(nodeListOne, nodeListTwo));            
            var nodeListOne = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, null)))))));
            var nodeListTwo = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, null))));
            PrintNodeList(AddTwoNumbers(nodeListOne, nodeListTwo));
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var resultList = new ListNode(0, null);
            var head = resultList;
            var decimals = 0;
            while (l1 != null && l2 != null)
            {
                var sum = l1.val + l2.val;
                if (decimals > 0)
                {
                    decimals--;
                    sum += 1;
                }
                if (sum >= 10)
                {
                    decimals++;
                    sum -= 10;
                }

                resultList.next = new ListNode(sum, null);
                resultList = resultList.next;
                l1 = l1.next;
                l2 = l2.next;
            }

            while (l1 != null)
            {
                var value = l1.val;
                if (decimals > 0)
                {
                    value += decimals;
                    decimals--;
                }
                if (value >= 10)
                {
                    decimals++;
                    value -= 10;
                }
                resultList.next = new ListNode(value, null);
                resultList = resultList.next;
                l1 = l1.next;
            }

            while (l2 != null)
            {
                var value = l2.val;
                if (decimals > 0)
                {
                    value += decimals;
                    decimals--;
                }
                if (value >= 10)
                {
                    decimals++;
                    value -= 10;
                }
                resultList.next = new ListNode(value, null);
                resultList = resultList.next;
                l2 = l2.next;
            }

            if (decimals > 0)
            {
                resultList.next = new ListNode(decimals, null);
                resultList = resultList.next;
            }

            return head.next;
        }

        private static void PrintNodeList(ListNode nodeList)
        {
            while (nodeList != null)
            {
                Console.Write($"{nodeList.val} ");
                nodeList = nodeList.next;
            }
        }
    }
}
