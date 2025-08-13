namespace Find_First_and_Last_Position_of_Element_in_Sorted_Array
{
    internal class Program
    {
        private static int targetIndex = -1;
        private static bool targetIndexFound = false;
        private static HashSet<int> visited = new HashSet<int>();

        static void Main(string[] args)
        {
            //Console.WriteLine(string.Join(", ", SearchRange([5, 7, 7, 8, 8, 10], 8)));
            //Console.WriteLine(string.Join(", ", SearchRange([], 0)));
            //Console.WriteLine(string.Join(", ", SearchRange([2, 2], 2)));
            //Console.WriteLine(string.Join(", ", SearchRange([2, 2], 2)));
            //Console.WriteLine(string.Join(", ", SearchRange([0, 0, 1, 1, 2, 2, 2, 2, 3, 3, 4, 4, 4, 5, 6, 6, 6, 7, 8, 8], 4)));
            //Console.WriteLine(string.Join(", ", SearchRange([0, 0, 1, 1, 1, 2, 3, 4, 4, 5, 6, 7, 7, 7, 8, 8, 8, 8, 9, 9, 10], 4)));
            //Console.WriteLine(string.Join(", ", SearchRange([1, 2, 3], 3)));
            //Console.WriteLine(string.Join(", ", SearchRange([0, 0, 2, 3, 4, 4, 4, 5], 5)));
            Console.WriteLine(string.Join(", ", SearchRange([5, 7, 7, 8, 8, 10], 6)));
        }

        private static int[] SearchRange(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return [-1, -1];
            }
            var resultArray = new int[2] { -1, -1 };
            var targetIndex = FindIndex(nums, target);
            if (targetIndex == -1)
            {
                return [-1, -1];
            }
            resultArray[0] = targetIndex;
            resultArray[1] = targetIndex;

            var leftIndex = targetIndex - 1;
            var rightIndex = targetIndex + 1;

            var leftLimitReached = false;
            var rightLimitReached = false;

            while (!leftLimitReached || !rightLimitReached)
            {
                if (!leftLimitReached)
                {
                    if (leftIndex < 0 || nums[leftIndex] < nums[targetIndex])
                    {
                        leftLimitReached = true;
                    }
                    else
                    {
                        resultArray[0] = leftIndex;
                    }
                    leftIndex--;
                }
                if (!rightLimitReached)
                {
                    if (rightIndex == nums.Length || nums[rightIndex] > nums[targetIndex])
                    {
                        rightLimitReached = true;
                    }
                    else
                    {
                        resultArray[1] = rightIndex;
                    }
                    rightIndex++;
                }
            }

            return resultArray;
        }

        private static int FindIndex(int[] nums, int target)
        {
            var currIndex = nums.Length / 2;
            BinarySearch(nums, target, nums.Length / 2, 0, nums.Length);
            return targetIndex;
        }

        private static void BinarySearch(int[] nums, int target, int currIndex, int leftBoundary, int rightBoundary)
        {
            if (targetIndexFound || visited.Contains(currIndex))
            {
                return;
            }
            if (nums[currIndex] == target)
            {
                targetIndex = currIndex;
                targetIndexFound = true;
            }
            else if (nums[currIndex] < target)
            {
                visited.Add(currIndex);
                var newIndex = (rightBoundary + currIndex) / 2;
                BinarySearch(nums, target, newIndex, currIndex, rightBoundary);

            }
            else
            {
                visited.Add(currIndex);
                var newIndex = (leftBoundary + currIndex) / 2;
                BinarySearch(nums, target, newIndex, leftBoundary, currIndex);
            }
        }
    }
}
