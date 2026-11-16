using System.Text;

namespace Calculate_Digit_Sum_of_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DigitSum("11111222223", 3));
            Console.WriteLine(DigitSum("00000000", 3));
            Console.WriteLine(DigitSum("01", 3));
            Console.WriteLine(DigitSum("01234567890", 2));
        }

        public static string DigitSum(string s, int k)
        {
            var sb = new StringBuilder(s);

            while (true)
            {
                if (sb.Length > k)
                {
                    var groups = new List<List<char>>();
                    var stringBuilderIndex = 0;
                    var groupsIndex = 0;
                    var endOfCurrGroup = k;
                    while (stringBuilderIndex < sb.Length)
                    {
                        if (endOfCurrGroup == k)
                        {
                            groups.Add(new List<char>());
                        }
                        groups[groupsIndex].Add(sb[stringBuilderIndex]);
                        endOfCurrGroup--;
                        if (endOfCurrGroup == 0)
                        {
                            groupsIndex++;
                            endOfCurrGroup = k;
                        }
                        stringBuilderIndex++;
                    }
                    sb.Clear();
                    foreach (var group in groups)
                    {
                        var sum = 0;
                        foreach (var character in group)
                        {
                            sum += character - 48;
                        }
                        sb.Append(sum);
                    }
                }
                else
                {
                    return sb.ToString();
                }
            }
        }
    }
}
