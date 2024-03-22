namespace Power_of_Two
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstTestNumber = 16;
            Console.WriteLine(IsPowerOfTwo(firstTestNumber));
        }

        public static bool IsPowerOfTwo(int n)
        {
            
            if (n <= 0)
            {
                return false;
            }
            while (n > 1)
            {
                if (n % 2 != 0)
                {
                    return false;
                }
                n /= 2;
            }

            return true;
        }
    }
}
