namespace Contains_Duplicate_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstTestArray = new int[] { 1, 2, 3, 1 };
            Console.WriteLine(ContainsNearbyDuplicate(firstTestArray, 3));
            var secondTestArray = new int[] { 1, 2, 3, 1, 2, 3 };
            Console.WriteLine(ContainsNearbyDuplicate(secondTestArray, 2));
        }

        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dictionary.ContainsKey(nums[i]) && Math.Abs(dictionary[nums[i]] - i) <= k)
                {
                    return true;
                }
                dictionary[nums[i]] = i;
            }

            return false;
        }
    }
}
