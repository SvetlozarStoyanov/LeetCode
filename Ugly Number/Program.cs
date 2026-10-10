namespace Ugly_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(IsUgly(6));
            //Console.WriteLine(IsUgly(-2147483648));
            Console.WriteLine(IsUgly(1024));
        }

        public static bool IsUgly(int n)
        {
            if (n < 1)
            {
                return false;
            }

            var primeFactorsForUglyNumbers = new int[] { 2, 3, 5 };
            var currentNum = n;
            foreach (var factor in primeFactorsForUglyNumbers)
            {
                while (currentNum % factor == 0)
                {
                    currentNum /= factor;
                }
            }

            if (currentNum > 1)
            {
                return false;
            }

            return true;
        }
    }
}
