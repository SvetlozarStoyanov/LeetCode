namespace Add_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AddDigits(38));
            Console.WriteLine(AddDigits(0));
            Console.WriteLine(AddDigits(111));
            Console.WriteLine(AddDigits(9));
        }

        public static int AddDigits(int num)
        {
            while (num > 0)
            {
                var sum = 0;
                while (num > 0)
                {
                    sum += num % 10;
                    num = num / 10;
                }
                if (sum < 10)
                {
                    return sum;
                }
                num = sum;
            }

            return 0;
        }
    }
}
