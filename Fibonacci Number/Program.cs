namespace Fibonacci_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fib(4));
        }

        public static int Fib(int n)
        {
            if (n < 1)
            {
                return 0;
            }
            var first = 0;
            var second = 1;
            var result = first + second;
            for (int i = 1; i < n; i++)
            {
                result = first + second;
                first = second;
                second = result;
            }
            return result;
        }
    }
}
