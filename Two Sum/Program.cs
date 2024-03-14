namespace Two_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstTestArray = new int[] { 2, 7, 11, 15 };
            Console.WriteLine(string.Join(", ", TwoSum(firstTestArray, 9)));
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var dictionary = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];
                if (dictionary.ContainsKey(nums[i]))
                {
                    return new int[] { dictionary[nums[i]] , i};
                }
                dictionary[diff] = i;
            }
            return new int[0];
        }
    }
}
