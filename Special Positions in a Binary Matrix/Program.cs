namespace Special_Positions_in_a_Binary_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumSpecial([[0, 0, 1, 0], [0, 0, 0, 0], [0, 0, 0, 0], [0, 1, 0, 0]]));
            Console.WriteLine(NumSpecial([[0, 0], [0, 0], [1, 0]]));
            Console.WriteLine(NumSpecial([
                [0, 0, 0, 0, 0, 1, 0, 0],
                [0, 0, 0, 0, 1, 0, 0, 1],
                [0, 0, 0, 0, 1, 0, 0, 0],
                [1, 0, 0, 0, 1, 0, 0, 0],
                [0, 0, 1, 1, 0, 0, 0, 0]
                ]));
            Console.WriteLine(NumSpecial([
                [0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 1, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 1, 0],
                [0, 1, 0, 0, 0, 0, 1, 0],
                [0, 1, 0, 0, 0, 0, 0, 0]
                ]));
            Console.WriteLine(NumSpecial([
                [0, 0, 0, 0, 0, 0, 0, 0],
                [0, 1, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0],
                [0, 0, 0, 0, 0, 0, 0, 0],
                [1, 0, 0, 0, 0, 0, 0, 1],
                [0, 0, 0, 0, 0, 0, 1, 0],
                [0, 0, 0, 0, 0, 0, 0, 1]
                ]));
        }

        public static int NumSpecial(int[][] mat)
        {
            var specialNumberCount = 0;
            var rowDictionary = new Dictionary<int, List<int>>();
            var colDictionary = new Dictionary<int, List<int>>();
            var specialPositions = new List<ValueTuple<int, int>>();

            for (int i = 0; i < mat.Length; i++)
            {
                rowDictionary.Add(i, new List<int>());
            }
            for (int i = 0; i < mat[0].Length; i++)
            {
                colDictionary.Add(i, new List<int>());
            }

            for (int row = 0; row < mat.Length; row++)
            {
                for (int col = 0; col < mat[row].Length; col++)
                {
                    if (mat[row][col] == 1)
                    {
                        colDictionary[col].Add(row);
                        rowDictionary[row].Add(col);
                        specialPositions.Add((row, col));
                    }
                }
            }

            for (int i = 0; i < specialPositions.Count; i++)
            {
                var row = specialPositions[i].Item1;
                var col = specialPositions[i].Item2;
                if (rowDictionary[row].Count == 1 && colDictionary[col].Count == 1)
                {
                    specialNumberCount++;
                }
            }

            return specialNumberCount;
        }

    }
}
