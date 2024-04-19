namespace Squares_of_a_Sorted_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var firstTestArray = new[] { -4, -1, 0, 3, 10 };
            //Console.WriteLine(string.Join(", ", SortedSquares(firstTestArray)));            
            var secondTestArray = new[] { -7, -3, 2, 3, 11 };
            Console.WriteLine(string.Join(", ", SortedSquares(secondTestArray)));
        }

        public static int[] SortedSquares(int[] nums)
        {
            var left = 0;
            var right = nums.Length - 1;
            var result = new int[nums.Length];
            var reachedIndex = nums.Length - 1;
            while (left <= right)
            {
                if (nums[left] * nums[left] > nums[right] * nums[right])
                {
                    result[reachedIndex] = nums[left] * nums[left];
                    left++;
                }
                else
                {
                    result[reachedIndex] = nums[right] * nums[right];
                    right--;
                }
                reachedIndex--;
            }

            return result;
        }
    }
}
