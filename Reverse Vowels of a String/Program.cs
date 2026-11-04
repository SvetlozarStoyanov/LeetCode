namespace Reverse_Vowels_of_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(ReverseVowels("IceCreAm"));
            //Console.WriteLine(ReverseVowels("Icszexcxz"));
            Console.WriteLine(ReverseVowels("Yo! Bottoms up, U.S. Motto, boy!"));
        }

        public static string ReverseVowels(string s)
        {
            var vowels = new HashSet<char> { 'a', 'e', 'o', 'u', 'i', 'A', 'E', 'O', 'U', 'I' };
            var charArray = s.ToCharArray();
            var startPointer = 0;
            var endPointer = s.Length - 1;

            while (startPointer < endPointer)
            {
                if (vowels.Contains(charArray[startPointer]))
                {
                    var vowelFound = false;
                    while (endPointer > startPointer && !vowelFound)
                    {
                        if (vowels.Contains(charArray[endPointer]))
                        {
                            var temp = s[endPointer];
                            charArray[endPointer] = charArray[startPointer];
                            charArray[startPointer] = temp;
                            vowelFound = true;
                        }
                        endPointer--;
                    }
                }
                startPointer++;
            }

            return string.Join("", charArray);
        }
    }
}
