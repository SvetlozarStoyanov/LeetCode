using System.Text;

namespace Reverse_Integer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Reverse(-123));
        }

        public static int Reverse(int x)
        {
            var sb = new StringBuilder();

            var isNegative = false;
            if (x < 0)
            {
                isNegative = true;
                x *= -1;
            }

            while (x != 0)
            {
                var digit = x % 10;
                x /= 10;
                sb.Append(digit);
            }

            if (int.TryParse(string.Join("", sb), out int resultNum))
            {
                if (isNegative)
                {
                    resultNum *= -1;
                }
                return resultNum;
            }
            return 0;
        }
    }
}
