namespace _3Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstTestArray = new[] { -1, 0, 1, 2, -1, -4 };
            PrintLists(ThreeSum(firstTestArray));
            //var secondTestArray = new[] { 0, 0, 0 };
            //PrintLists(ThreeSum(secondTestArray));            
            //var thirdTestArray = new[] { -4, -1, -1, 0, 1, 2 };
            //PrintLists(ThreeSum(thirdTestArray));
            //var fourthTestArray = new[] { 0, 0, 0, 0 };
            //PrintLists(ThreeSum(fourthTestArray));
        }

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            var target = 0;
            var result = new List<IList<int>>();
            nums = nums.OrderBy(n => n).ToArray();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                {
                    continue;
                }
                var currTarget = -nums[i];
                var leftPointer = i + 1;
                var rightPointer = nums.Length - 1;
                while (leftPointer < rightPointer)
                {
                    if (nums[leftPointer] + nums[rightPointer] < currTarget)
                    {
                        leftPointer++;
                    }
                    else if (nums[leftPointer] + nums[rightPointer] > currTarget)
                    {
                        rightPointer--;
                    }
                    else
                    {
                        result.Add(new List<int>()
                            {
                                nums[i],
                                nums[leftPointer],
                                nums[rightPointer]
                            });

                        leftPointer++;
                        while (nums[leftPointer] == nums[leftPointer - 1] && leftPointer < rightPointer)
                        {
                            leftPointer++;
                        }
                    }
                }
            }
            return result;
        }

        private static void PrintLists(IList<IList<int>> result)
        {
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write("[");
                Console.Write($"[{string.Join(",", result[i])}]");
                Console.Write("]");
                if (i < result.Count - 1)
                {
                    Console.Write(",");
                }
            }
            Console.WriteLine();
        }
    }
}
