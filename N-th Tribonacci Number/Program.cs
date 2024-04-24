namespace N_th_Tribonacci_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Tribonacci(4));
        }

        public static int Tribonacci(int n)
        {
            var first = 0;
            var second = 1;
            var third = 1;
            var curr = 0;
            if (n == 1)
            {
                return first;
            }
            if (n == 2)
            {
                return second;
            }
            for (int i = 2; i < n; i++)
            {
                curr = first + second + third;
                first = second;
                second = third;
                third = curr;
            }
            return curr;
        }
    }
}
