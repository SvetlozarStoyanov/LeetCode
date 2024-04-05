
namespace Sort_List
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
            var firstTestList = CreateLinkedListFromIntArray(new int[] { 4, 2, 1, 3 });
            PrintLinkedList(SortList(firstTestList));
            //var secondTestList = CreateLinkedListFromIntArray(new int[] { -1, 5, 3, 4, 0 });
            //PrintLinkedList(SortList(secondTestList));
            //var thirdTestList = CreateLinkedListFromIntArray(CreateLargeArray());
            //PrintLinkedList(SortList(thirdTestList));
        }

        public static ListNode SortList(ListNode head)
        {
            #region My Solution
            //var dummyNode = new ListNode(0, head);
            //while (true)
            //{
            //    var prev = dummyNode;
            //    var tail = dummyNode.next;
            //    var swaps = 0;
            //    while (tail != null && tail.next != null)
            //    {
            //        if (tail.val > tail.next.val)
            //        {
            //            var temp = tail.next.next;
            //            tail.next.next = tail;
            //            prev.next = tail.next;
            //            tail.next = temp;
            //            swaps++;
            //        }
            //        else
            //        {
            //            tail = tail.next;
            //        }
            //        //tail = tail.next;
            //        if (prev.next == null)
            //        {
            //            break;
            //        }
            //        prev = prev.next;
            //    }
            //    if (swaps == 0)
            //    {
            //        break;
            //    }
            //}
            //return dummyNode.next;
            #endregion

            #region NeetCode's Solution
            if (head == null || head.next == null)
            {
                return head;
            }

            var left = head;
            var right = SplitIntoTwo(head);
            var temp = right.next;
            right.next = null;
            right = temp;
            left = SortList(left);
            right = SortList(right);

            return Merge(left, right);
            #endregion
        }

        private static ListNode SplitIntoTwo(ListNode listNode)
        {
            var slow = listNode;
            var fast = listNode.next;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        private static ListNode Merge(ListNode list1, ListNode list2)
        {
            var dummy = new ListNode();

            var tail = dummy;

            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    tail.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    tail.next = list2;
                    list2 = list2.next;
                }
                tail = tail.next;
            }

            while (list1 != null)
            {
                tail.next = list1;
                list1 = list1.next;
                tail = tail.next;
            }
            while (list2 != null)
            {
                tail.next = list2;
                list2 = list2.next;
                tail = tail.next;
            }

            return dummy.next;
        }

        private static int[] CreateLargeArray()
        {
            var array = new int[1000000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
            return array;
        }

        private static ListNode CreateLinkedListFromIntArray(int[] inputArray)
        {
            var head = new ListNode();
            var tail = head;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (i == 0)
                {
                    tail.val = inputArray[i];
                }
                else
                {
                    tail.next = new ListNode(inputArray[i], null);
                    tail = tail.next;
                }
            }
            return head;
        }

        private static void PrintLinkedList(ListNode head)
        {
            var tail = head;
            while (tail != null)
            {
                Console.Write($"{tail.val} ");
                tail = tail.next;
            }
        }
    }
}
