namespace Contains_Duplicate_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstTestArray = new int[] { 1, 2, 3, 1 };
            Console.WriteLine(ContainsNearbyAlmostDuplicate(firstTestArray, 3, 0));
            var secondTestArray = new int[] { 1, 5, 9, 1, 5, 9 };
            Console.WriteLine(ContainsNearbyAlmostDuplicate(secondTestArray, 2, 3));
            var thirdTestArray = new int[] { 8, 7, 15, 1, 6, 1, 9, 15 };
            Console.WriteLine(ContainsNearbyAlmostDuplicate(thirdTestArray, 1, 3));
            var fourthTestArray = new int[] { -3, 3, -6 };
            Console.WriteLine(ContainsNearbyAlmostDuplicate(fourthTestArray, 2, 3));
            var fifthTestArray = new int[] { 1, 2, 1, 1 };
            Console.WriteLine(ContainsNearbyAlmostDuplicate(fifthTestArray, 1, 0));
            var sixthTestArray = new int[] { 1, 2, 2, 3, 4, 5 };
            Console.WriteLine(ContainsNearbyAlmostDuplicate(sixthTestArray, 3, 0));
            var seventhTestArray = new int[] { 7, 1, 3 };
            Console.WriteLine(ContainsNearbyAlmostDuplicate(seventhTestArray, 2, 3));
            var eighthTestArray = new int[] { 4, 1, -1, 6, 5 };
            Console.WriteLine(ContainsNearbyAlmostDuplicate(eighthTestArray, 3, 1));
            var ninthTestArray = new int[] { 0, 10, 22, 15, 0, 5, 22, 12, 1, 5 };
            Console.WriteLine(ContainsNearbyAlmostDuplicate(ninthTestArray, 3, 3));
        }

        public static bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
        {
            var queue = new Queue<int>();
            var queueReachedIndex = 0;
            var reachedIndex = 1;
            var currIndexDiff = 0;
            queue.Enqueue(nums[0]);
            while (true)
            {
                if (currIndexDiff >= indexDiff)
                {
                    currIndexDiff = 1;
                    queue.Dequeue();
                    queueReachedIndex++;
                    for (int i = 1; i < indexDiff; i++)
                    {
                        if (Math.Abs(nums[queueReachedIndex + i] - queue.Peek()) <= valueDiff)
                        {
                            return true;
                        }
                    }
                }
                if (reachedIndex >= nums.Length)
                {
                    while (queue.Count > 1)
                    {
                        for (int i = 1; i < indexDiff; i++)
                        {
                            if (queueReachedIndex + i >= nums.Length)
                            {
                                break;
                            }
                            if (Math.Abs(nums[queueReachedIndex + i] - queue.Peek()) <= valueDiff)
                            {
                                return true;
                            }
                        }
                        queue.Dequeue();
                        queueReachedIndex++;
                    }
                    break;
                }
                if (Math.Abs(nums[reachedIndex] - queue.Peek()) <= valueDiff && Math.Abs(queueReachedIndex - reachedIndex) <= indexDiff)
                {
                    return true;
                }
                queue.Enqueue(nums[reachedIndex++]);
                currIndexDiff++;
            }
            return false;
        }
    }
}
