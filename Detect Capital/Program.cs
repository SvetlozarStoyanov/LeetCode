namespace Detect_Capital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DetectCapitalUse("mL"));
        }

        public static bool DetectCapitalUse(string word)
        {
            if (word.Length == 1)
            {
                return true;
            }

            var firstLetterIsCapital = word[0] >= 65 && word[0] <= 90;
            var secondLetterIsCapital = word[1] >= 65 && word[1] <= 90;

            if (!firstLetterIsCapital && secondLetterIsCapital)
            {
                return false;
            }

            var allLettersShouldBeCapital = !firstLetterIsCapital ? false : secondLetterIsCapital;

            for (int i = 2; i < word.Length; i++)
            {
                if (allLettersShouldBeCapital)
                {
                    if (word[i] >= 97 && word[i] <= 122)
                    {
                        return false;
                    }
                }
                else
                {
                    if (word[i] >= 65 && word[i] <= 90)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
