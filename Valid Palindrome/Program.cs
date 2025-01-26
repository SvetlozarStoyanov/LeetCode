namespace Valid_Palindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPalindrome("A man, a plan, a canal: Panama"));
        }

        public static bool IsPalindrome(string s)
        {
            var left = 0;
            var right = s.Length - 1;

            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }

                while (right > left && !char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }

                var leftSymbol = s[left];
                var rightSymbol = s[right];

                if (leftSymbol == rightSymbol || (Math.Abs(leftSymbol - rightSymbol) == 32
                    && (char.IsLetter(leftSymbol) && char.IsLetter(rightSymbol)
                    || char.IsDigit(leftSymbol) && char.IsDigit(rightSymbol))))
                {
                    left++;
                    right--;
                }
                else
                {
                    return false;
                }

            }

            return true;
        }
    }
}
