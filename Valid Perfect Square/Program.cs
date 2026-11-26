namespace Valid_Perfect_Square
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Math.Sqrt(1024));
            //Console.WriteLine(IsPerfectSquare(14));
            Console.WriteLine(IsPerfectSquare(1024));
        }

        public static bool IsPerfectSquare(int num)
        {
            var lastDigit = num % 10;
            var isPerfectSquare = false;
            for (int i = 0; i < int.MaxValue; i++)
            {
                var square = i * i;

                if (square > num)
                {
                    isPerfectSquare = false;
                    break;
                }

                if (square == num)
                {
                    isPerfectSquare = true;
                    break;
                }
            }
            return isPerfectSquare;
        }
    }
}
