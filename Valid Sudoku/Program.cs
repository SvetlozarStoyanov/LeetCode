namespace Valid_Sudoku
{
    internal class Program
    {
        private static HashSet<char> foundElements;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public static bool IsValidSudoku(char[][] board)
        {
            foundElements = new HashSet<char>();
            foreach (var row in board)
            {
                if (!ValidateRow(row))
                {
                    return false;
                }
            }

            for (int colNum = 0; colNum < board.Length; colNum++)
            {
                if (!ValidateColumn(colNum, board))
                {
                    return false;
                }
            }

            var subboxValidation = ValidateSubbox(0, 2, 0, 2, board) 
                && ValidateSubbox(0, 2, 3, 5, board)
                && ValidateSubbox(0, 2, 6, 8, board)
                && ValidateSubbox(3, 5, 0, 2, board)
                && ValidateSubbox(3, 5, 3, 5, board)
                && ValidateSubbox(3, 5, 6, 8, board)
                && ValidateSubbox(6, 8, 0, 2, board)
                && ValidateSubbox(6, 8, 3, 5, board)
                && ValidateSubbox(6, 8, 6, 8, board);
            
            return subboxValidation;
        }

        private static bool ValidateRow(char[] row)
        {
            foreach (char symbol in row)
            {
                if (symbol != '.')
                {
                    if (foundElements.Contains(symbol))
                    {
                        return false;
                    }
                    foundElements.Add(symbol);
                }
            }

            foundElements.Clear();
            return true;
        }

        private static bool ValidateColumn(int colNum, char[][] board)
        {
            for (int rowNum = 0; rowNum < board.Length; rowNum++)
            {
                var symbol = board[rowNum][colNum];
                if (symbol != '.')
                {
                    if (foundElements.Contains(symbol))
                    {
                        return false;
                    }
                    foundElements.Add(symbol);
                }
            }

            foundElements.Clear();
            return true;
        }

        private static bool ValidateSubbox(int startRow, int endRow, int startCol, int endCol, char[][] board)
        {
            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    var symbol = board[row][col];
                    if (symbol != '.')
                    {
                        if (foundElements.Contains(symbol))
                        {
                            return false;
                        }
                        foundElements.Add(symbol);
                    }
                }
            }

            foundElements.Clear();
            return true;
        }
    }
}
