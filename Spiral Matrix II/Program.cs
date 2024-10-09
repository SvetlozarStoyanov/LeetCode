using System.Text;

namespace Spiral_Matrix_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = GenerateMatrix(5);
            Console.WriteLine(PrintMatrix(matrix));
        }

        public static int[][] GenerateMatrix(int n)
        {
            var matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
            }

            var currElement = 1;
            var maxElement = n * n;
            var currRow = 0;
            var currCol = 0;

            var maxRow = n - 1;
            var minRow = 0;

            var maxCol = n - 1;
            var minCol = 0;
            while (currElement <= maxElement)
            {
                while (currCol <= maxCol)
                {
                    matrix[currRow][currCol++] = currElement++;
                }
                if (currElement > maxElement)
                {
                    break;
                }
                currCol = maxCol;
                currRow++;
                minRow++;

                while (currRow <= maxRow)
                {
                    matrix[currRow++][currCol] = currElement++;
                }
                if (currElement > maxElement)
                {
                    break;
                }
                currRow = maxRow;
                currCol--;
                maxCol--;

                while (currCol >= minCol)
                {
                    matrix[currRow][currCol--] = currElement++;
                }
                if (currElement > maxElement)
                {
                    break;
                }
                currCol = minCol;
                currRow--;
                maxRow--;

                while (currRow >= minRow)
                {
                    matrix[currRow--][currCol] = currElement++;
                }
                if (currElement > maxElement)
                {
                    break;
                }
                currRow = minRow;
                currCol++;
                minCol++;
            }

            return matrix;
        }

        public static string PrintMatrix(int[][] matrix)
        {
            var sb = new StringBuilder();
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix.Length; col++)
                {
                    sb.Append($"{matrix[row][col]} ");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
