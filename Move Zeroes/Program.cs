namespace Move_Zeroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MoveZeroes([0, 1, 0, 3, 12]);
            MoveZeroes([0]);
            MoveZeroes([0, 1, 2, 0, 3, 0, 0, 0, 0, 4, 0, 0, 5]);
        }

        public static void MoveZeroes(int[] nums)
        {
            var nonZeroIndexes = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nonZeroIndexes.Add(i);
                }
            }
            var numIndex = 0;
            foreach (int index in nonZeroIndexes)
            {
                nums[numIndex] = nums[index];
                numIndex++;
            }

            for (int i = numIndex; i < nums.Length; i++)
            {
                nums[i] = 0;
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
