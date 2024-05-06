namespace Rotting_Oranges
{
    internal class Program
    {
        private static HashSet<ValueTuple<int, int>> visitedIndices;
        private static int maxMinutes;
        static void Main(string[] args)
        {
            var firstTestGrid = new int[3][] { new int[] { 2, 1, 1 }, new int[] { 1, 1, 0 }, new int[] { 0, 1, 1 } };
            Console.WriteLine(OrangesRotting(firstTestGrid));
            var secondTestGrid = new int[1][] { new int[] { 0, 2 } };
            Console.WriteLine(OrangesRotting(secondTestGrid));
        }

        public static int OrangesRotting(int[][] grid)
        {
            //visitedIndices = new HashSet<(int, int)>();
            var indicesToRot = new HashSet<(int, int)>();
            var minutes = 0;
            while (true)
            {
                var normalOrangesFound = 0;
                for (int row = 0; row < grid.Length; row++)
                {
                    for (int col = 0; col < grid[row].Length; col++)
                    {
                        if (grid[row][col] == 1)
                        {
                            normalOrangesFound++;
                            if (HasAdjacentRottenOranges(row, col, grid))
                            {
                                indicesToRot.Add((row, col));
                            }
                        }
                    }
                }
                if (indicesToRot.Count == 0 && normalOrangesFound > 0)
                {
                    return -1;
                }
                if (indicesToRot.Count == 0 && normalOrangesFound == 0)
                {
                    break;
                }
                foreach(var index in indicesToRot)
                {
                    grid[index.Item1][index.Item2] = 2;
                }
                indicesToRot.Clear();
                minutes++;
            }
            return minutes;
        }

        private static bool HasAdjacentRottenOranges(int row, int col, int[][] grid)
        {
            Func<int, int, bool> hasAdjacentRotten = (rowIncrement, colIncrement) => (IsInBounds(row + rowIncrement, col + colIncrement, grid)
            && grid[row + rowIncrement][col + colIncrement] == 2);
            if (hasAdjacentRotten(1, 0) || hasAdjacentRotten(-1, 0) || hasAdjacentRotten(0, 1) || hasAdjacentRotten(0, -1))
            {
                return true;
            }
            return false;
        }

        private static bool IsInBounds(int row, int col, int[][] grid)
        {
            return row >= 0 && row < grid.Length && col >= 0 && col < grid[row].Length;
        }
    }
}
