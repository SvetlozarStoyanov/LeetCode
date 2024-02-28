namespace Generate_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var number = 3;
            Console.WriteLine(string.Join(" ", GenerateParenthesis(number)));
        }

        public static IList<string> GenerateParenthesis(int n)
        {
            var combinations = new List<string>();
            var stack = new Stack<string>();
            Backtrack(0, 0, n, stack, combinations);
            return combinations;
        }

        public static void Backtrack(int openCount,
            int closedCount,
            int pairCountAllowed,
            Stack<string> stack,
            List<string> combinations)
        {
            if (openCount == pairCountAllowed && openCount == closedCount)
            {
                combinations.Add(string.Join("", stack.Reverse()));
            }

            if (openCount < pairCountAllowed)
            {
                stack.Push("(");
                Backtrack(openCount + 1, closedCount, pairCountAllowed, stack, combinations);

                stack.Pop();
            }
            if (closedCount < openCount)
            {
                stack.Push(")");
                Backtrack(openCount, closedCount + 1, pairCountAllowed, stack, combinations);
                stack.Pop();
            }
        }
    }
}
