namespace SearchInsertPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine(SearchInsert(nums, 7));
        }

        public static int SearchInsert(int[] nums, int target)
        {

            int left = 0;
            int right = nums.Length - 1;


            while (left < right)
            {
                if (nums[left] < target)
                {
                    left++;
                }
                if (nums[right] > target)
                {
                    right--;
                }
                if (nums[left] == target)
                {
                    return left;
                }
                if (nums[right] == target)
                {
                    return right;
                }
            }

            if (nums[left] < target)
            {
                left++;
            }

            return left;
        }
    }
}
