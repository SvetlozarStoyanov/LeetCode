namespace Two_Sum_II___Input_Array_Is_Sorted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstTestArray = new int[] { 2, 7, 11, 15 };
            Console.WriteLine(string.Join(",", TwoSum(firstTestArray, 9)));
        }

        public static int[] TwoSum(int[] numbers, int target)
        {
            var result = new int[2];
            var leftPointer = 0;
            var rightPointer = numbers.Length - 1;

            while (leftPointer < rightPointer)
            {
                if (numbers[leftPointer] + numbers[rightPointer] > target)
                {
                    rightPointer--;
                }
                else if (numbers[leftPointer] + numbers[rightPointer] < target)
                {
                    leftPointer++;
                }
                else
                {
                    break;
                }
            }
            result[0] = leftPointer + 1;
            result[1] = rightPointer + 1;
            return result;
        }
    }
}
