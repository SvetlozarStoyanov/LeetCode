namespace Word_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(WordPattern("abba","dog dog dog dog"));
        }
        public static bool WordPattern(string pattern, string s)
        {
            var words = s.Split(' ');
            if (words.Length != pattern.Length)
            {
                return false;
            }
            var dictionary = new Dictionary<char, string>();
            var hashset = new HashSet<string>();
            for (int i = 0; i < pattern.Length; i++)
            {
                var character = pattern[i];
                var word = words[i];
                if (!dictionary.ContainsKey(character))
                {
                    dictionary.Add(character, word);
                    if (!hashset.Add(word))
                    {
                        return false;
                    }
                }
                else
                {
                    if (dictionary[character] != word)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
