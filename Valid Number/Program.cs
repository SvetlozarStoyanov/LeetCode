namespace Valid_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsNumber("-.7e+0435"));
        }

        public static bool IsNumber(string s)
        {
            var digitEncountered = false;
            var digitsAfterExponentEncountered = false;
            var signEncountered = false;
            var exponentEncountered = false;
            var dotEncountered = false;

            for (int i = 0; i < s.Length; i++)
            {
                var currSymbol = s[i];
                if (currSymbol == 'e' || currSymbol == 'E')
                {
                    if (exponentEncountered || !digitEncountered)
                    {
                        return false;
                    }
                    signEncountered = false;
                    exponentEncountered = true;
                }
                else if (char.IsLetter(currSymbol))
                {
                    return false;
                }
                else if (currSymbol == 43 || currSymbol == 45)
                {
                    if (digitsAfterExponentEncountered)
                    {
                        return false;
                    }
                    else if (dotEncountered && !digitEncountered)
                    {
                        return false;
                    }
                    else if (signEncountered || (!exponentEncountered && digitEncountered) || dotEncountered)
                    {
                        return false;
                    }
                    signEncountered = true;
                    digitEncountered = false;
                }
                else if (currSymbol == '.')
                {
                    if (dotEncountered || exponentEncountered)
                    {
                        return false;
                    }
                    dotEncountered = true;
                }
                else
                {
                    digitEncountered = true;
                    if (exponentEncountered)
                    {
                        digitsAfterExponentEncountered = true;
                    }
                }
            }

            if (!digitEncountered)
            {
                return false;
            }
            else if (exponentEncountered)
            {
                if (!digitsAfterExponentEncountered)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
