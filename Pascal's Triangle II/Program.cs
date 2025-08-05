namespace Pascal_s_Triangle_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public IList<int> GetRow(int rowIndex)
        {
            var pascalTriangle = new List<IList<int>>();

            pascalTriangle.Add(new List<int>() { 1 });

            var prevRow = pascalTriangle[0];
            var prevRowIdxOne = 0;
            var prevRowIdxTwo = prevRow.Count - 1;
            for (int i = 1; i < rowIndex + 1; i++)
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
            return pascalTriangle[rowIndex];
        }
    }
}
