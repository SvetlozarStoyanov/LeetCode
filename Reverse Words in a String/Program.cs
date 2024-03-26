namespace Reverse_Words_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReverseWords("the sky is blue"));
            Console.WriteLine(ReverseWords("  hello world  "));
        }

        public static string ReverseWords(string s)
        {
            // Two liner
            //var stringSplit = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //return string.Join(" ", stringSplit.Reverse().ToArray());

            var wordStack = new Stack<string>();
            var currWordLen = 0;
            var currWordStartIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    if (currWordLen > 0)
                    {
                        wordStack.Push(s.Substring(currWordStartIndex, currWordLen));
                        currWordLen = 0;
                    }
                }
                else
                {
                    if (currWordLen == 0)
                    {
                        currWordStartIndex = i;
                    }
                    currWordLen++;
                }
            }
            if (currWordLen > 0)
            {
                wordStack.Push(s.Substring(currWordStartIndex, currWordLen));
            }
            return string.Join(" ", wordStack);
        }
    }
}
