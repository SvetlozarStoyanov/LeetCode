namespace Remove_Duplicates_from_Sorted_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstTestArray = new int[] { 1, 1, 2 };
            Console.WriteLine(RemoveDuplicates(firstTestArray));
            //var secondTestArray = new int[] { 1, 1, 2, 3, 4 };
            //Console.WriteLine(RemoveDuplicates(secondTestArray));            
            //var thirdTestArray = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            //Console.WriteLine(RemoveDuplicates(thirdTestArray));
            //var fourthTestArray = new int[] { 1, 1 };
            //Console.WriteLine(RemoveDuplicates(fourthTestArray));
            //var fifthTestArray = new int[] { 1, 2 };
            //Console.WriteLine(RemoveDuplicates(fifthTestArray));
        }

        public static int RemoveDuplicates(int[] nums)
        {
            var reachedIndex = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[reachedIndex])
                {
                    reachedIndex++;
                    nums[reachedIndex] = nums[i];
                }
            }

            return reachedIndex + 1;
        }

    }
}
