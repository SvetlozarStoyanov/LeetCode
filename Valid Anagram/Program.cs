namespace Valid_Anagram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsAnagram("anagram", "nagaram"));
            //Console.WriteLine(IsAnagram("ab", "a"));
        }

        public static bool IsAnagram(string s, string t)
        {
            var dictionary = new Dictionary<char, int>();

            foreach (var item in s)
            {
                if (!dictionary.ContainsKey(item))
                {
                    dictionary[item] = 0;
                }
                dictionary[item]++;
            }

            foreach (var item in t)
            {
                if (!dictionary.ContainsKey(item))
                {
                    return false;
                }

                dictionary[item]--;
                if (dictionary[item] == 0)
                {
                    dictionary.Remove(item);
                }
            }
            
            return !dictionary.Any();
        }
    }
}
