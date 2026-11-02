namespace Reverse_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ReverseString(['H', 'a', 'n', 'n', 'a', 'h']);
            //ReverseString(['a', 'b', 'c', 'd', 'e', 'f']);
            //ReverseString(['a', 'b', 'c', 'd', 'e']);
            ReverseString(['a', 'b']);
        }

        public static void ReverseString(char[] s)
        {
            var length = s.Length;
            var midIndex = s.Length / 2;
            for (int i = 0; i < midIndex; i++)
            {
                var temp = s[i];
                s[i] = s[s.Length - i - 1];
                s[s.Length - i - 1] = temp;
            }
            Console.WriteLine(string.Join(' ', s));
        }
    }
}
