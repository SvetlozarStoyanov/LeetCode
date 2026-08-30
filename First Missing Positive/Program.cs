namespace First_Missing_Positive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FirstMissingPositive([1, 2, 0]));
        }

        public static int FirstMissingPositive(int[] nums)
        {
            var foundPositives = new HashSet<int>(1);
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    foundPositives.Add(nums[i]);
                }
            }

            if (foundPositives.Count == 0 )
            {
                return 1;
            }

            foundPositives = foundPositives.OrderBy(x => x).ToHashSet();

            if (foundPositives.First() == 1)
            {
                return 1;
            }

            foreach (var item in foundPositives)
            {
                if (!foundPositives.Contains(item + 1))
                {
                    return item + 1;
                }
            }

            return 1;
        }
    }
}
