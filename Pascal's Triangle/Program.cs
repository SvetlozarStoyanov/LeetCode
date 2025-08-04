namespace Pascal_s_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfRows = 5;
            var triangle = Generate(numberOfRows);

            PrintPascalTriangle(triangle);
        }

        public static IList<IList<int>> Generate(int numRows)
        {
            var pascalTriangle = new List<IList<int>>();

            pascalTriangle.Add(new List<int>() { 1 });

            var prevRow = pascalTriangle[0];
            var prevRowIdxOne = 0;
            var prevRowIdxTwo = prevRow.Count - 1;
            for (int i = 1; i < numRows; i++)
            {
                var row = new List<int>();
                prevRowIdxOne = 0;
                if (i == 1)
                {
                    prevRowIdxTwo = prevRow.Count - 1;
                }
                else
                {
                    prevRowIdxTwo = 1;
                }
                row.Add(1);
                while (prevRowIdxOne < prevRowIdxTwo && prevRowIdxTwo < prevRow.Count)
                {
                    row.Add(prevRow[prevRowIdxOne++] + prevRow[prevRowIdxTwo++]);
                }
                row.Add(1);

                pascalTriangle.Add(row);
                prevRow = row;
            }
            return pascalTriangle;
        }

        private static void PrintPascalTriangle(IList<IList<int>> pascalTriangle)
        {
            foreach (var row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
