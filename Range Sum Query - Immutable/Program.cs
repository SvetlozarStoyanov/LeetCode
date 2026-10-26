namespace Range_Sum_Query___Immutable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class NumArray
    {
        private int[] nums;

        public NumArray(int[] nums)
        {
            this.nums = nums;
        }

        public int SumRange(int left, int right)
        {
            var sum = 0;
            for (int i = left; i <= right; i++)
            {
                sum += this.nums[i];
            }
            return sum;
        }
    }
}
