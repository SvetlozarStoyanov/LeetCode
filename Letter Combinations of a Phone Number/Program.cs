using System.Text;

namespace Letter_Combinations_of_a_Phone_Number
{
    internal class Program
    {
        private static IList<string> combinations;
        private static StringBuilder sb;
        private static Dictionary<char, char[]> numbersAndLetters;

        static void Main(string[] args)
        {
            //Console.WriteLine(string.Join(", ", LetterCombinations("234")));
            Console.WriteLine(string.Join(", ", LetterCombinations("22")));
            Console.WriteLine(string.Join(", ", LetterCombinations("338")));
        }

        public static IList<string> LetterCombinations(string digits)
        {
            combinations = new List<string>();
            if (digits.Length == 0)
            {
                return combinations.ToList();
            }
            sb = new StringBuilder();
            numbersAndLetters = new Dictionary<char, char[]>()
            {
                { '2', new char[]{ 'a','b','c'} },
                { '3', new char[]{ 'd','e','f'} },
                { '4', new char[]{ 'g','h','i'} },
                { '5', new char[]{ 'j','k','l'} },
                { '6', new char[]{ 'm','n','o'} },
                { '7', new char[]{ 'p','q','r','s'} },
                { '8', new char[]{ 't','u','v'} },
                { '9', new char[]{ 'w','x','y','z'} },
            };
            RecursiveCall(0, digits);
            return combinations;
        }

        private static void RecursiveCall(int index, string input)
        {
            if (index == input.Length)
            {
                combinations.Add(sb.ToString());
                return;
            }
            foreach (var letter in numbersAndLetters[input[index]])
            {
                sb.Append(letter);
                RecursiveCall(index + 1, input);
                sb.Remove(sb.Length - 1, 1);
            }
        }

    }
}
