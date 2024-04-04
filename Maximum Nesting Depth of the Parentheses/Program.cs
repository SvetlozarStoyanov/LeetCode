namespace Maximum_Nesting_Depth_of_the_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstTestString = "(1+(2*3)+((8)/4))+1";
            Console.WriteLine(MaxDepth(firstTestString));
            var secondTestString = "";
            Console.WriteLine(MaxDepth(secondTestString));

        }

        public static int MaxDepth(string s)
        {
            var openBrackets = 0;
            var maxCount = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    openBrackets++;
                }
                else if (s[i] == ')')
                {
                    if (openBrackets > maxCount)
                    {
                        maxCount = openBrackets;
                    }
                    openBrackets--;
                }
            }
            return maxCount;
        }
    }
}
