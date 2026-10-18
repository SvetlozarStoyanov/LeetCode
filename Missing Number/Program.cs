namespace Missing_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(MissingNumber([9, 6, 4, 2, 3, 5, 7, 0, 1]));
            Console.WriteLine(MissingNumber([0, 1]));
        }

        public static int MissingNumber(int[] nums)
        {
            var numsLength = nums.Length;
            var listOfIndexes = new List<int>();

            for (int i = 0; i < numsLength; i++)
            {
                listOfIndexes.Add(i);
            }

            foreach (var number in nums)
            {
                listOfIndexes.Remove(number);
            }

            if (listOfIndexes.Count == 0)
            {
                return nums.Length;
            }

            var missingNumber = listOfIndexes[0];

            return missingNumber;
        }
    }
}
