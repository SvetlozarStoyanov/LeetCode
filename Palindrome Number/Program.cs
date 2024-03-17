namespace Palindrome_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(IsPalindrome(121));
            Console.WriteLine(IsPalindrome(0));
            //Console.WriteLine(IsPalindrome(4004));
            //Console.WriteLine(IsPalindrome(5555));
            //Console.WriteLine(IsPalindrome(5556));
            //Console.WriteLine(IsPalindrome(10));
        }

        public static bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }

            var depth = 0;
            var length = Math.Floor(Math.Log10(x) + 1);
            if (length < 1)
            {
                length = 1;
            }
            var condition = true;
            while (condition)
            {
                var firstNum = Math.Floor(x / Math.Pow(10, length - depth - 1) % 10);
                var lastNum = Math.Floor(x / Math.Pow(10, depth++) % 10);
                if (firstNum != lastNum)
                {
                    return false;
                }
                condition = length > depth + 1 * 2;
            }
            return true;
        }
    }
}

