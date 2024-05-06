namespace First_Letter_to_Appear_Twice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static char RepeatedCharacter(string s)
        {
            var letterList = new List<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (letterList.Contains(s[i]))
                {
                    return s[i];
                }
                letterList.Add(s[i]);
            }

            return s[0];
        }
    }
}
