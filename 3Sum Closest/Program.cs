namespace _3Sum_Closest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { -4, 2, 2, 3, 3, 3 };
            var target = 0;
            Console.WriteLine(ThreeSumClosest(nums, target));
        }

        public static int ThreeSumClosest(int[] nums, int target)
        {
            nums = nums.OrderBy(x => x).ToArray();
            var closestSum = nums[0] + nums[1] + nums[nums.Length - 1];

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0)
                {
                    if (nums[i] == nums[i - 1])
                    {
                        continue;
                    }
                }
                var currNum = nums[i];
                var leftIndex = i + 1;
                var rightIndex = nums.Length - 1;

                while (leftIndex < rightIndex)
                {
                    var currSum = currNum + nums[leftIndex] + nums[rightIndex];
                    var currDiff = Math.Abs(target - currSum);
                    if (currDiff < Math.Abs(target - closestSum))
                    {
                        if (currDiff == 0)
                        {
                            return currSum;
                        }
                        closestSum = currSum;
                    }
                    if (currSum < target)
                    {
                        leftIndex++;
                    }
                    else
                    {
                        rightIndex--;
                    }
                }
            }

            return closestSum;
        }
    }
}
