namespace Longest_Palindromic_Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = "aacabdkacaa";
            Console.WriteLine(LongestPalindrome(input));
        }

        public static string LongestPalindrome(string inputString)
        {
            var startIndex = -1;
            var maxLength = 1;

            for (int i = 0; i < inputString.Length; i++)
            {
                var startingLetter = inputString[i];

                for (int j = i + 1; j < inputString.Length; j++)
                {
                    if (inputString[j] == startingLetter)
                    {
                        var currLength = j - i + 1;
                        if (currLength > maxLength && CheckIfWordIsPalindrome(i, j, inputString))
                        {
                            maxLength = currLength;
                            startIndex = i;
                        }
                    }
                }
            }
            if (startIndex == -1)
            {
                return inputString[0].ToString();
            }
            return inputString.Substring(startIndex, maxLength);
        }

        public static bool CheckIfWordIsPalindrome(int start, int end, string input)
        {
            var increment = 1;
            var maxIncrement = (end - start + 1) / 2;
            while (increment <= maxIncrement)
            {
                if (input[start + increment] != input[end - increment++])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
