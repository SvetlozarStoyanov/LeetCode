namespace Climbing_Stairs
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(ClimbStairs(2));
        }

        public static int ClimbStairs(int n)
        {
            var left = 1;
            var right = 2;
            if (n == 1)
            {
                return left;
            }
            else if (n == 2)
            {
                return right;
            }

            var curr = left + right;
            var index = 2;

            while (index < n)
            {
                curr = left + right;
                left = right;
                right = curr;
                index++;
            }

            return curr;
        }
    }
}
