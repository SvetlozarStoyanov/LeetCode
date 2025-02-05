namespace Check_if_One_String_Swap_Can_Make_Strings_Equal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AreAlmostEqual("bank", "kanb"));
        }

        public static bool AreAlmostEqual(string s1, string s2)
        {
            if (s1 == s2)
            {
                return true;
            }
            if (s1.Length != s2.Length)
            {
                return false;
            }

            var diffCount = 0;
            var diffIndexes = new int[2];
            var diffIndex = 0;
            var length = s1.Length;
            var index = 0;

            while (index < length)
            {
                if (s1[index] != s2[index])
                {
                    diffCount++;
                    if (diffCount > 2)
                    {
                        return false;
                    }
                    diffIndexes[diffIndex++] = index;
                }
                index++;
            }

            if (diffCount < 2)
            {
                return false;
            }

            if (s1[diffIndexes[0]] == s2[diffIndexes[1]] && s1[diffIndexes[1]] == s2[diffIndexes[0]])
            {
                return true;
            }


            return false;
        }
    }
}
