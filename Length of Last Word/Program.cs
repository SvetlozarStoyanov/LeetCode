namespace Length_of_Last_Word
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LengthOfLastWord("   fly me   to   the moon  "));
        }

        public static int LengthOfLastWord(string s)
        {
            var arraySplit = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return arraySplit[arraySplit.Length - 1].Length;
        }
    }
}
