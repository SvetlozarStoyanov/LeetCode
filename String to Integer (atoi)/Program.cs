using System.Text;

namespace String_to_Integer__atoi_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(MyAtoi(" -042"));
            Console.WriteLine(MyAtoi("0-1"));
        }

        public static int MyAtoi(string s)
        {
            var digitEncountered = false;
            var signEncountered = false;
            var sign = '+';
            var reachedIndex = -1;

            // searching for sign and first digit
            for (int i = 0; i < s.Length; i++)
            {
                var currSymbol = s[i];
                if (char.IsDigit(currSymbol))
                {
                    digitEncountered = true;
                    if (currSymbol > 48)
                    {
                        reachedIndex = i;
                        break;
                    }
                }
                else if (char.IsWhiteSpace(currSymbol))
                {
                    if (digitEncountered || signEncountered)
                    {
                        break;
                    }
                }
                else if (currSymbol == 43 || currSymbol == 45)
                {
                    if (digitEncountered || signEncountered)
                    {
                        break;
                    }
                    signEncountered = true;
                    sign = currSymbol;
                }
                else
                {
                    break;
                }
            }
            if (reachedIndex == -1)
            {
                return 0;
            }

            var stringBuilder = new StringBuilder();
            while (reachedIndex < s.Length && char.IsDigit(s[reachedIndex]) && stringBuilder.Length < 11)
            {
                stringBuilder.Append(s[reachedIndex++]);
            }

            var number = long.Parse(stringBuilder.ToString());
            if (sign == '-')
            {
                number *= -1;
            }
            if (number > int.MaxValue)
            {
                number = int.MaxValue;
            }
            else if (number < int.MinValue)
            {
                number = int.MinValue;
            }
            

            return (int)number;
        }
    }
}
