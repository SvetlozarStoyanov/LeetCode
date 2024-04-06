using System.Text;

namespace Make_The_String_Great
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MakeGood("leEeetcode"));
            Console.WriteLine(MakeGood("abBAcC"));
            Console.WriteLine(MakeGood("s"));
        }

        public static string MakeGood(string s)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                var currLetter = s[i];
                if (sb.Length > 0)
                {
                    var lastLetter = sb[sb.Length - 1];
                    if (char.IsUpper(lastLetter) && char.IsLower(currLetter) && char.ToLower(lastLetter) == currLetter)
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    else if (char.IsLower(lastLetter) && char.IsUpper(currLetter) && lastLetter == char.ToLower(currLetter))
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    else
                    {
                        sb.Append(currLetter);
                    }
                }
                else
                {
                    sb.Append(currLetter);
                }
            }

            return sb.ToString();
        }
    }
}
