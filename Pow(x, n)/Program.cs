namespace Pow_x__n_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MyPow(-10, 0));
        }

        public static double MyPow(double x, int n)
        {
            var result = 1d;
            if (Math.Abs(x) == 1)
            {
                return x;
            }
            if (n > 0)
            {

                for (int i = 0; i < n; i++)
                {
                    result *= x;
                }
            }
            else if (n < 0)
            {
                var power = Math.Abs((long)n);
                for (int i = 0; i < power; i++)
                {
                    result /= x;
                    if (result == 0)
                    {
                        break;
                    }
                }
            }
            else
            {
                result = Math.Sign(x) * x / x;
            }
            return result;
        }
    }
}
