using System.Text;

namespace Zigzag_Conversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = "PAYPALISHIRING";
            Console.WriteLine(Convert(input, 4));
        }

        public static string Convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }
            var currRow = 0;

            var diagonalLength = numRows - 2;

            var result = new StringBuilder();
            var diagonalStep = 2;
            while (currRow < numRows)
            {
                var increment = 0;
                if (currRow == 0 || currRow == numRows - 1)
                {
                    increment = numRows + diagonalLength;
                    for (int i = currRow; i < s.Length; i += increment)
                    {
                        result.Append(s[i]);
                    }
                }
                else
                {
                    var firstSkip = (numRows - currRow - 1) * diagonalStep;
                    var secondSkip = currRow * diagonalStep;
                    for (int i = currRow; i < s.Length; i += increment)
                    {
                        result.Append(s[i]);
                        if (increment == firstSkip)
                        {
                            increment = secondSkip;
                        }
                        else
                        {
                            increment = firstSkip;
                        }
                    }

                }
                currRow++;
            }
            return result.ToString();
        }
    }
}
