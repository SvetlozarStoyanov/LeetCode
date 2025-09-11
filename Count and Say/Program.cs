using System.Text;

namespace Count_and_Say
{
    internal class Program
    {
        private static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            //Console.WriteLine(CountAndSay(2));
            Console.WriteLine(CountAndSay(4));
            //Console.WriteLine(CountAndSay(7));
        }

        private static string CountAndSay(int n)
        {
            if (n == 1)
            {
                return "1";
            }
            Recursion(string.Empty, 1, n);
            return sb.ToString();
        }

        private static void Recursion(string value, int n, int maxN)
        {
            if (n == maxN)
            {
                return;
            }
            if (n == 1)
            {
                sb.Append("11");
            }
            else
            {
                sb.Clear();
                var count = 1;
                var prev = value[0];
                for (int i = 1; i < value.Length; i++)
                {
                    char item = value[i];
                    if (item == prev)
                    {
                        count++;
                    }
                    else
                    {
                        sb.Append($"{count}{prev}");
                        count = 1;
                        prev = item;
                    }
                }
                sb.Append($"{count}{value[value.Length - 1]}");

            }
            Recursion(sb.ToString(), n + 1, maxN);
        }
    }
}
