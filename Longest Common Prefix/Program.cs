using System.Text;

namespace Longest_Common_Prefix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstTestArray = new string[] { "flower", "flow", "flight" };
            Console.WriteLine(LongestCommonPrefix(firstTestArray));
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            var lengthOfLongestPrefix = 0;
            for (int i = 0; i < strs[0].Length; i++)
            {

                if (strs.All(s => s.Length > lengthOfLongestPrefix
                && s[lengthOfLongestPrefix] == strs[0][lengthOfLongestPrefix]))
                {
                    lengthOfLongestPrefix++;
                }
                else
                {
                    break;
                }

            }
            return strs[0].Substring(0, lengthOfLongestPrefix);
        }
    }
}
