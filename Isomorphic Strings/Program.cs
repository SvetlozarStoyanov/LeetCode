namespace Isomorphic_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsIsomorphic("egg", "add"));
            Console.WriteLine(IsIsomorphic("badc", "baba"));
        }

        private static bool IsIsomorphic(string s, string t)
        {
            var mappingDictionary = new Dictionary<char, char>();
            var mappedToCharacters = new HashSet<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!mappingDictionary.ContainsKey(s[i]))
                {
                    mappingDictionary.Add(s[i], t[i]);
                    if (!mappedToCharacters.Add(t[i]))
                    {
                        return false;
                    }
                    
                }
                else if (mappingDictionary[s[i]] != t[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
