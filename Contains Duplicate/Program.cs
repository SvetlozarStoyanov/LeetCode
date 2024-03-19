namespace Contains_Duplicate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstTestArray = new int[] { 1, 2, 3, 1 };
            Console.WriteLine(ContainsDuplicate(firstTestArray));
        }

        public static bool ContainsDuplicate(int[] nums)
        {
            //var distinctCount = nums.Distinct().Count();
            //if (distinctCount != nums.Length)
            //{
            //    return true;
            //}
            var hashset = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (hashset.Contains(nums[i]))
                {
                    return true;
                }
                hashset.Add(nums[i]);
            }

            return false;
        }
    }
}
