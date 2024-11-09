namespace _3Sum_Closest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { -1, 2, 1, -4 };
            var target = 1;
            Console.WriteLine(ThreeSumClosest(nums, target));
        }

        public static int ThreeSumClosest(int[] nums, int target)
        {
            var closestSum = nums[0] + nums[1] + nums[2];

            var currSum = 0;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                currSum += nums[i];
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    currSum += nums[j];
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        currSum += nums[k];

                        var diff = Math.Abs(target - currSum);
                        if (diff < Math.Abs(target - closestSum))
                        {
                            closestSum = currSum;
                        }

                        currSum -= nums[k];
                    }
                    currSum -= nums[j];
                }
                currSum -= nums[i];
            }

            return closestSum;
        }
    }
}
