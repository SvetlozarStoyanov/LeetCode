namespace Valid_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsValid("()"));
        }

        public static bool IsValid(string s)
        {
            var openingParentheses = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                {
                    openingParentheses.Push(s[i]);
                }
                else
                {
                    if (openingParentheses.Count == 0)
                    {
                        return false;
                    }
                    var lastParentheses = openingParentheses.Pop();
                    switch (s[i])
                    {
                        case ')':
                            if (lastParentheses != '(')
                            {
                                return false;
                            }
                            break;                        
                        case ']':
                            if (lastParentheses != '[')
                            {
                                return false;
                            }
                            break;                        
                        case '}':
                            if (lastParentheses != '{')
                            {
                                return false;
                            }
                            break;
                    }
                }
            }
            if (openingParentheses.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}
