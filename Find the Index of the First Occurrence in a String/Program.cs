namespace Find_the_Index_of_the_First_Occurrence_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var firstTestHaystack = "sadbutsad";
            //var firstTestNeedle = "sad";
            //Console.WriteLine(StrStr(firstTestHaystack, firstTestNeedle));            
            //var secondTestHaystack = "leetcode";
            //var secondTestNeedle = "leeto";
            //Console.WriteLine(StrStr(secondTestHaystack, secondTestNeedle));            
            //var thirdTestHaystack = "mississippi";
            //var thirdTestNeedle = "issip";
            //Console.WriteLine(StrStr(thirdTestHaystack, thirdTestNeedle));            
            var fourthTestHaystack = "aabaaabaaac";
            var fourthTestNeedle = "aabaaac";
            Console.WriteLine(StrStr(fourthTestHaystack, fourthTestNeedle));
        }

        public static int StrStr(string haystack, string needle)
        {
            if (needle.Length > haystack.Length)
            {
                return -1;
            }
            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack.Length - i < needle.Length)
                {
                    return -1;
                }
                if (haystack[i] == needle[0])
                {
                    var currIndex = i + 1;
                    for (int j = 1; j < needle.Length; j++)
                    {
                        if (currIndex >= haystack.Length || haystack[currIndex] != needle[j])
                        {
                            break;
                        }
                        currIndex++;
                    }
                    if (currIndex - i == needle.Length)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}
