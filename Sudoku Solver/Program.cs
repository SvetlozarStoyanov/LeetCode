using System.Text;

namespace Sudoku_Solver
{
    internal class Program
    {
        public class Subbox
        {
            public int MinRow { get; set; }
            public int MaxRow { get; set; }
            public int MinCol { get; set; }
            public int MaxCol { get; set; }
        }

        private static HashSet<char> foundElements;
        private static bool sudokuIsValid;
        private static decimal permutationsCheckedByRecursion;
        static void Main(string[] args)
        {
            //char[][] sudoku = [
            //    ['.', '.', '9', '7', '4', '8', '.', '.', '.'],
            //    ['7', '.', '.', '.', '.', '.', '.', '.', '.'],
            //    ['.', '2', '.', '1', '.', '9', '.', '.', '.'],
            //    ['.', '.', '7', '.', '.', '.', '2', '4', '.'],
            //    ['.', '6', '4', '.', '1', '.', '5', '9', '.'],
            //    ['.', '9', '8', '.', '.', '.', '3', '.', '.'],
            //    ['.', '.', '.', '8', '.', '3', '.', '2', '.'],
            //    ['.', '.', '.', '.', '.', '.', '.', '.', '6'],
            //    ['.', '.', '.', '2', '7', '5', '9', '.', '.']];

            char[][] sudoku = [
                ['.', '.', '.', '.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.', '.', '.', '.'],
                ['.', '.', '.', '.', '.', '.', '.', '.', '.'],
                ['1', '.', '2', '.', '.', '.', '.', '.', '.']];


            SolveSudoku(sudoku);
        }

        public static void SolveSudoku(char[][] board)
        {
            var subboxes = new List<Subbox>()
            {
                new Subbox()
                {
                    MinRow = 0,
                    MaxRow = 2,
                    MinCol = 0,
                    MaxCol = 2,
                },
                new Subbox()
                {
                    MinRow = 0,
                    MaxRow = 2,
                    MinCol = 3,
                    MaxCol = 5,
                },
                new Subbox()
                {
                    MinRow = 0,
                    MaxRow = 2,
                    MinCol = 6,
                    MaxCol = 8,
                },
                new Subbox()
                {
                    MinRow = 3,
                    MaxRow = 5,
                    MinCol = 0,
                    MaxCol = 2,
                },
                new Subbox()
                {
                    MinRow = 3,
                    MaxRow = 5,
                    MinCol = 3,
                    MaxCol = 5,
                },
                new Subbox()
                {
                    MinRow = 3,
                    MaxRow = 5,
                    MinCol = 6,
                    MaxCol = 8,
                },
                new Subbox()
                {
                    MinRow = 6,
                    MaxRow = 8,
                    MinCol = 0,
                    MaxCol = 2,
                },
                new Subbox()
                {
                    MinRow = 6,
                    MaxRow = 8,
                    MinCol = 3,
                    MaxCol = 5,
                },
                new Subbox()
                {
                    MinRow = 6,
                    MaxRow = 8,
                    MinCol = 6,
                    MaxCol = 8,
                },
            };

            foundElements = new HashSet<char>();

            var emptyCells = FindEmptyCells(board);

            #region Honest Solution

            var index = 0;
            var foundElementsInLoop = 0;
            while (true)
            {
                if (index >= emptyCells.Count)
                {
                    index = 0;
                }
                var row = emptyCells[index].Item1;
                var col = emptyCells[index].Item2;
                var emptyCell = board[row][col];

                var subboxIndex = FindSubboxIndex(row, col);

                var possibilities = emptyCells[index].Item3;

                if (possibilities.Count == 1)
                {
                    board[row][col] = possibilities[0];
                    UpdateEmptyCellPossibilities(possibilities[0], subboxes[subboxIndex], emptyCells[index], emptyCells, board);
                    emptyCells.RemoveAt(index);
                    if (emptyCells.Count == 0)
                    {
                        break;
                    }
                    foundElementsInLoop++;
                    continue;
                }

                CheckRow(row, col, possibilities, board);

                if (possibilities.Count == 1)
                {
                    board[row][col] = possibilities[0];
                    UpdateEmptyCellPossibilities(possibilities[0], subboxes[subboxIndex], emptyCells[index], emptyCells, board);
                    emptyCells.RemoveAt(index);
                    if (emptyCells.Count == 0)
                    {
                        break;
                    }
                    foundElementsInLoop++;
                    continue;
                }

                CheckCol(row, col, possibilities, board);

                if (possibilities.Count == 1)
                {
                    board[row][col] = possibilities[0];
                    UpdateEmptyCellPossibilities(possibilities[0], subboxes[subboxIndex], emptyCells[index], emptyCells, board);
                    emptyCells.RemoveAt(index);
                    if (emptyCells.Count == 0)
                    {
                        break;
                    }
                    foundElementsInLoop++;
                    continue;
                }

                CheckSubbox(subboxes[subboxIndex], possibilities, board);

                if (possibilities.Count == 1)
                {
                    board[row][col] = possibilities[0];
                    UpdateEmptyCellPossibilities(possibilities[0], subboxes[subboxIndex], emptyCells[index], emptyCells, board);
                    emptyCells.RemoveAt(index);
                    if (emptyCells.Count == 0)
                    {
                        break;
                    }
                    foundElementsInLoop++;
                    continue;
                }

                index++;
                if (index >= emptyCells.Count)
                {
                    index = 0;


                    PrintSudoku(board);

                    Console.WriteLine("------------------");

                    foreach (var subbox in subboxes)
                    {
                        if (DeduceCell(subbox, emptyCells, board))
                        {
                            foundElementsInLoop++;
                        }
                    }
                    if (foundElementsInLoop == 0)
                    {
                        break;
                    }
                    //PrintSudoku(board);
                    foundElementsInLoop = 0;
                    //Thread.Sleep(3000);
                }
            }
            #endregion

            #region Brute force Recursion
            if (emptyCells.Any())
            {
                Recursion(0, emptyCells, subboxes, board);
            }
            #endregion

            PrintSudoku(board);
        }

        private static void Recursion(int index, List<(int, int, List<char>)> emptyCells, List<Subbox> subboxes, char[][] board)
        {
            if (index >= emptyCells.Count)
            {
                sudokuIsValid = IsValidSudoku(board);
                //PrintSudoku(board);
                Thread.Sleep(10);
                return;
            }
            if (sudokuIsValid)
            {
                Console.WriteLine("Sudoku is valid\n");
                PrintSudoku(board);
                return;
            }
            //if (emptyCellLeft)
            //{
            //    emptyCellLeft = false;
            //    return;
            //}
            var emptyCell = emptyCells[index];
            var row = emptyCell.Item1;
            var col = emptyCell.Item2;
            var subbox = subboxes[FindSubboxIndex(row, col)];
            foreach (var possibility in emptyCell.Item3)
            {
                if (CheckRowForNumber(row, col, possibility, board)
                    && CheckColForNumber(row, col, possibility, board)
                    && CheckSubboxForNumber(subbox, possibility, board))
                {
                    board[row][col] = possibility;
                    Recursion(index + 1, emptyCells, subboxes, board);
                    if (!sudokuIsValid)
                    {
                        board[row][col] = '.';
                    }
                }

            }
            //emptyCellLeft = board[row][col] == '.';
        }

        private static List<ValueTuple<int, int, List<char>>> FindEmptyCells(char[][] board)
        {
            var emptyCells = new List<ValueTuple<int, int, List<char>>>();
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board.Length; col++)
                {
                    if (board[row][col] == '.')
                    {
                        emptyCells.Add((row, col, new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9' }));
                    }
                }
            }

            return emptyCells;
        }

        public static bool IsValidSudoku(char[][] board)
        {
            permutationsCheckedByRecursion++;
            foundElements.Clear();
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

        private static void UpdateEmptyCellPossibilities(char number,
            Subbox subbox,
            (int, int, List<char>) emptyCell,
            List<(int, int, List<char>)> emptyCells, char[][] board)
        {
            var row = emptyCell.Item1;
            var col = emptyCell.Item2;
            var emptyCellsWithSameRow = emptyCells.Where(x => x.Item1 == row);

            foreach (var emptyCellWithSameRow in emptyCellsWithSameRow)
            {
                emptyCellWithSameRow.Item3.Remove(number);
            }

            var emptyCellsWithSameCol = emptyCells.Where(x => x.Item2 == col);

            foreach (var emptyCellWithSameCol in emptyCellsWithSameCol)
            {
                emptyCellWithSameCol.Item3.Remove(number);
            }

            var emptyCellsFromSameSubbox = emptyCells.Where(x => x.Item1 >= subbox.MinRow
                && x.Item1 <= subbox.MaxRow && x.Item2 >= subbox.MinCol && x.Item2 <= subbox.MaxCol);

            foreach (var emptyCellFromSameSubbox in emptyCellsFromSameSubbox)
            {
                emptyCellFromSameSubbox.Item3.Remove(number);
            }
        }

        private static void CheckRow(int row, int col, List<char> possiblities, char[][] board)
        {
            for (int i = col + 1; i < board.Length; i++)
            {
                if (!IsValidCell(row, i))
                {
                    break;
                }
                if (board[row][i] != '.')
                {
                    possiblities.Remove(board[row][i]);
                }
            }

            for (int i = col - 1; i >= 0; i--)
            {
                if (!IsValidCell(row, i))
                {
                    break;
                }
                if (board[row][i] != '.')
                {
                    possiblities.Remove(board[row][i]);
                }
            }

        }

        private static void CheckCol(int row, int col, List<char> possiblities, char[][] board)
        {
            for (int i = row + 1; i < board.Length; i++)
            {
                if (!IsValidCell(i, col))
                {
                    break;
                }
                if (board[i][col] != '.')
                {
                    possiblities.Remove(board[i][col]);
                }
            }

            for (int i = row - 1; i >= 0; i--)
            {
                if (!IsValidCell(row, i))
                {
                    break;
                }
                if (board[i][col] != '.')
                {
                    possiblities.Remove(board[i][col]);
                }
            }

        }

        private static void CheckSubbox(Subbox subbox, List<char> possiblities, char[][] board)
        {
            for (int row = subbox.MinRow; row <= subbox.MaxRow; row++)
            {
                for (int col = subbox.MinCol; col <= subbox.MaxCol; col++)
                {
                    if (board[row][col] != '.')
                    {
                        possiblities.Remove(board[row][col]);
                    }
                }
            }
        }

        private static bool DeduceCell(Subbox subbox, List<ValueTuple<int, int, List<char>>> emptyCells, char[][] board)
        {
            var subboxEmptyCells = new List<ValueTuple<int, int, List<char>>>();

            var dictionary = new Dictionary<char, int>();

            for (int row = subbox.MinRow; row <= subbox.MaxRow; row++)
            {
                for (int col = subbox.MinCol; col <= subbox.MaxCol; col++)
                {
                    if (board[row][col] == '.')
                    {
                        var emptyCell = emptyCells.First(x => x.Item1 == row && x.Item2 == col);
                        foreach (var possibility in emptyCell.Item3)
                        {
                            if (!dictionary.ContainsKey(possibility))
                            {
                                dictionary[possibility] = 0;
                            }
                            dictionary[possibility]++;
                        }
                        subboxEmptyCells.Add(emptyCell);
                    }
                }
            }

            var singlePossibility = dictionary.FirstOrDefault(x => x.Value == 1).Key;
            if (singlePossibility != default)
            {
                var cell = subboxEmptyCells.First(x => x.Item3.Contains(singlePossibility));
                board[cell.Item1][cell.Item2] = singlePossibility;
                UpdateEmptyCellPossibilities(singlePossibility, subbox, cell, emptyCells, board);
                emptyCells.Remove(cell);
                return true;
            }
            return false;
        }


        private static bool CheckRowForNumber(int row, int col, char number, char[][] board)
        {
            for (int i = col + 1; i < board.Length; i++)
            {
                if (!IsValidCell(row, i))
                {
                    break;
                }
                if (board[row][i] == number)
                {
                    return false;
                }
            }

            for (int i = col - 1; i >= 0; i--)
            {
                if (!IsValidCell(row, i))
                {
                    break;
                }
                if (board[row][i] == number)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool CheckColForNumber(int row, int col, char number, char[][] board)
        {
            for (int i = row + 1; i < board.Length; i++)
            {
                if (!IsValidCell(i, col))
                {
                    break;
                }
                if (board[i][col] == number)
                {
                    return false;
                }
            }

            for (int i = row - 1; i >= 0; i--)
            {
                if (!IsValidCell(row, i))
                {
                    break;
                }
                if (board[i][col] == number)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckSubboxForNumber(Subbox subbox, char number, char[][] board)
        {
            for (int row = subbox.MinRow; row <= subbox.MaxRow; row++)
            {
                for (int col = subbox.MinCol; col <= subbox.MaxCol; col++)
                {
                    if (board[row][col] == number)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool IsValidCell(int row, int col)
        {
            return row >= 0 && row < 9 && col >= 0 && col < 9;
        }

        private static int FindSubboxIndex(int row, int col)
        {
            if (row >= 0 && row < 3)
            {
                if (col >= 0 && col < 3)
                {
                    return 0;
                }
                else if (col >= 3 && col < 6)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else if (row >= 3 && row < 6)
            {
                if (col >= 0 && col < 3)
                {
                    return 3;
                }
                else if (col >= 3 && col < 6)
                {
                    return 4;
                }
                else
                {
                    return 5;
                }
            }
            else
            {
                if (col >= 0 && col < 3)
                {
                    return 6;
                }
                else if (col >= 3 && col < 6)
                {
                    return 7;
                }
                else
                {
                    return 8;
                }
            }
        }

        private static void PrintSudoku(char[][] board)
        {
            var stringBuilder = new StringBuilder();
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board.Length; col++)
                {
                    stringBuilder.Append($"{board[row][col]} ");
                }
                stringBuilder.AppendLine();
            }

            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
