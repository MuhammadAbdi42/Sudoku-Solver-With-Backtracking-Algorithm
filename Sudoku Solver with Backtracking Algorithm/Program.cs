SudokoEditior sudokoEditior = new();
sudokoEditior.SelectSize();
public class SudokoEditior
{
    public void SelectSize()
    {
        Console.WriteLine("Please select the size of the sudoku you want to solve:");
        Console.WriteLine("1. 9x9");
        Console.WriteLine("2. 16x16");
        char c = Console.ReadKey().KeyChar;
        Console.Clear();
        if (c == '1')
        {
            TypeSudoku(9);
        }
        else if (c == '2')
        {
            TypeSudoku(16);
        }
        else
        {
            Console.WriteLine("Invalid Input");
            SelectSize();
        }
    }
    private void TypeSudoku(int sizeOption)
    {
        int[,] board = new int[sizeOption, sizeOption];
        bool isOver = false;
        for (int i = 0; i < sizeOption; i++)
        {
            for (int j = 0; j < sizeOption; j++)
            {
                if (!isOver)
                {
                    board[i, j] = -1;
                    PrintBoard(sizeOption, board);
                    Console.WriteLine();
                    Console.WriteLine("Please type the number you want to add to the board (space for empty):");
                    char c = Console.ReadKey().KeyChar;
                    if (sizeOption == 16)
                    {
                        switch (c)
                        {
                            case ' ':
                                board[i, j] = 0;
                                break;
                            case '0':
                                if (CheckingValidity(board, [i, j], 1, 16))
                                {
                                    board[i, j] = 1;
                                }
                                else j--;
                                break;
                            case '1':
                                if (CheckingValidity(board, [i, j], 2, 16))
                                {
                                    board[i, j] = 2;
                                }
                                else j--;
                                break;
                            case '2':
                                if (CheckingValidity(board, [i, j], 3, 16))
                                {
                                    board[i, j] = 3;
                                }
                                else j--;
                                break;
                            case '3':
                                if (CheckingValidity(board, [i, j], 4, 16))
                                {
                                    board[i, j] = 4;
                                }
                                else j--;
                                break;
                            case '4':
                                if (CheckingValidity(board, [i, j], 5, 16))
                                {
                                    board[i, j] = 5;
                                }
                                else j--;
                                break;
                            case '5':
                                if (CheckingValidity(board, [i, j], 6, 16))
                                {
                                    board[i, j] = 6;
                                }
                                else j--;
                                break;
                            case '6':
                                if (CheckingValidity(board, [i, j], 7, 16))
                                {
                                    board[i, j] = 7;
                                }
                                else j--;
                                break;
                            case '7':
                                if (CheckingValidity(board, [i, j], 8, 16))
                                {
                                    board[i, j] = 8;
                                }
                                else j--;
                                break;
                            case '8':
                                if (CheckingValidity(board, [i, j], 9, 16))
                                {
                                    board[i, j] = 9;
                                }
                                else j--;
                                break;
                            case '9':
                                if (CheckingValidity(board, [i, j], 10, 16))
                                {
                                    board[i, j] = 10;
                                }
                                else j--;
                                break;
                            case 'A':
                            case 'a':
                                if (CheckingValidity(board, [i, j], 11, 16))
                                {
                                    board[i, j] = 11;
                                }
                                else j--;
                                break;
                            case 'B':
                            case 'b':
                                if (CheckingValidity(board, [i, j], 12, 16))
                                {
                                    board[i, j] = 12;
                                }
                                else j--;
                                break;
                            case 'C':
                            case 'c':
                                if (CheckingValidity(board, [i, j], 13, 16))
                                {
                                    board[i, j] = 13;
                                }
                                else j--;
                                break;
                            case 'D':
                            case 'd':
                                if (CheckingValidity(board, [i, j], 14, 16))
                                {
                                    board[i, j] = 14;
                                }
                                else j--;
                                break;
                            case 'E':
                            case 'e':
                                if (CheckingValidity(board, [i, j], 15, 16))
                                {
                                    board[i, j] = 15;
                                }
                                else j--;
                                break;
                            case 'F':
                            case 'f':
                                if (CheckingValidity(board, [i, j], 16, 16))
                                {
                                    board[i, j] = 16;
                                }
                                else j--;
                                break;
                            case '\b':
                                board[i, j] = 0;
                                if (j == 0 && i == 0)
                                {
                                    j = -1;
                                }
                                else if (j == 0)
                                {
                                    i -= 1;
                                    j = 14;
                                }
                                else
                                {
                                    j -= 2;
                                }
                                break;
                            case '\r':
                                board[i, j] = 0;
                                isOver = true;
                                break;
                            default:
                                j--;
                                break;
                        }
                    }
                    else if (sizeOption == 9)
                    {
                        switch (c)
                        {
                            case ' ':
                                board[i, j] = 0;
                                break;
                            case '1':
                                if (CheckingValidity(board, [i, j], 1, 9))
                                {
                                    board[i, j] = 1;
                                }
                                else j--;
                                break;
                            case '2':
                                if (CheckingValidity(board, [i, j], 2, 9))
                                {
                                    board[i, j] = 2;
                                }
                                else j--;
                                break;
                            case '3':
                                if (CheckingValidity(board, [i, j], 3, 9))
                                {
                                    board[i, j] = 3;
                                }
                                else j--;
                                break;
                            case '4':
                                if (CheckingValidity(board, [i, j], 4, 9))
                                {
                                    board[i, j] = 4;
                                }
                                else j--;
                                break;
                            case '5':
                                if (CheckingValidity(board, [i, j], 5, 9))
                                {
                                    board[i, j] = 5;
                                }
                                else j--;
                                break;
                            case '6':
                                if (CheckingValidity(board, [i, j], 6, 9))
                                {
                                    board[i, j] = 6;
                                }
                                else j--;
                                break;
                            case '7':
                                if (CheckingValidity(board, [i, j], 7, 9))
                                {
                                    board[i, j] = 7;
                                }
                                else j--;
                                break;
                            case '8':
                                if (CheckingValidity(board, [i, j], 8, 9))
                                {
                                    board[i, j] = 8;
                                }
                                else j--;
                                break;
                            case '9':
                                if (CheckingValidity(board, [i, j], 9, 9))
                                {
                                    board[i, j] = 9;
                                }
                                else j--;
                                break;
                            case '\b':
                                board[i, j] = 0;
                                if (j == 0 && i == 0)
                                {
                                    j = -1;
                                }
                                else if (j == 0)
                                {
                                    i -= 1;
                                    j = 7;
                                }
                                else
                                {
                                    j -= 2;
                                }
                                break;
                            case '\r':
                                board[i, j] = 0;
                                isOver = true;
                                break;
                            default:
                                j--;
                                break;
                        }
                    }
                }
                else
                {
                    board[i, j] = 0;
                }
            }
        }
        Solving(board, sizeOption);
    }
    private void PrintBoard(int sizeOption, int[,] board)
    {
        if (sizeOption == 9)
        {
            SudokuSolver9x9 sudokuSolver9X9 = new();
            sudokuSolver9X9.PrintBoard(board);
        }
        if (sizeOption == 16)
        {
            SudokuSolver16x16 sudokuSolver16x16 = new();
            sudokuSolver16x16.PrintBoard(board);
        }
    }
    private void Solving(int[,] board, int sizeOption)
    {
        Console.Clear();
        Console.WriteLine("Do you want visualization? (y/n)");
        char c = Console.ReadKey().KeyChar;
        bool visualization = false;
        if (c == 'y' || c == 'Y') visualization = true;
        if (sizeOption == 9)
        {
            SudokuSolver9x9 sudokuSolver9X9 = new();
            if (!sudokuSolver9X9.AssigningNumbers(board, visualization))
            {
                Console.Clear();
                sudokuSolver9X9.PrintBoard(board);
                Console.WriteLine("No Solution Found");
            }
            else
            {
                Console.WriteLine("Process Finished");
            }
            Console.ReadLine();
        }
        if (sizeOption == 16)
        {
            SudokuSolver16x16 sudokuSolver16x16 = new();
            if (!sudokuSolver16x16.AssigningNumbers(board, visualization))
            {
                Console.Clear();
                sudokuSolver16x16.PrintBoard(board);
                Console.WriteLine("No Solution Found");
            }
            else
            {
                Console.WriteLine("Process Finished");
            }
            Console.ReadLine();
        }
    }
    private bool CheckingValidity(int[,] board, int[] position, int value, int sizeOption)
    {
        if (sizeOption == 9)
        {
            SudokuSolver9x9 sudokuSolver9X9 = new();
            return sudokuSolver9X9.IsValidOption(board, position, value);
        }
        if (sizeOption == 16)
        {
            SudokuSolver16x16 sudokuSolver16x16 = new();
            return sudokuSolver16x16.IsValidOption(board, position, value);
        }
        return false;
    }
}
public class SudokuSolver16x16
{
    public bool AssigningNumbers(int[,] board, bool visualization)
    {
        int[] position = FinidingFirstEmptyPlace(board);
        if (visualization) PrintBoard(board);
        if (position[0] == -1 && position[1] == -1)
        {
            PrintBoard(board);
            return true;
        }
        for (int i = 1; i <= 16; i++)
        {
            if (IsValidOption(board, position, i))
            {
                board[position[0], position[1]] = i;
                if (AssigningNumbers(board, visualization)) return true;
                board[position[0], position[1]] = 0;
            }
        }
        return false;
    }
    private int[] FinidingFirstEmptyPlace(int[,] board)
    {
        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                if (board[i, j] == 0) return new int[] { i, j };
            }
        }
        return new int[] { -1, -1 };
    }
    public bool IsValidOption(int[,] board, int[] position, int value)
    {
        for (int i = 0; i < 16; i++)
        {
            if (board[position[0], i] == value || board[i, position[1]] == value) return false;
        }
        for (int i = (position[0] / 4) * 4; i < ((position[0] / 4) + 1) * 4; i++)
        {
            for (int j = (position[1] / 4) * 4; j < ((position[1] / 4) + 1) * 4; j++)
            {
                if (board[i, j] == value) return false;
            }
        }
        return true;
    }
    public void PrintBoard(int[,] board)
    {
        Console.Clear();
        string temp = "";
        for (int i = 0; i < 16; i++)
        {
            temp = "";
            if (i != 0 && i % 4 == 0)
            {
                Console.WriteLine("-------------------");
            }
            for (int j = 0; j < 16; j++)
            {
                if (j != 0 && j % 4 == 0) temp += "|";
                switch (board[i, j])
                {
                    case -1:
                        temp += "_";
                        break;
                    case 0:
                        temp += " ";
                        break;
                    case 1:
                        temp += "0";
                        break;
                    case 2:
                        temp += "1";
                        break;
                    case 3:
                        temp += "2";
                        break;
                    case 4:
                        temp += "3";
                        break;
                    case 5:
                        temp += "4";
                        break;
                    case 6:
                        temp += "5";
                        break;
                    case 7:
                        temp += "6";
                        break;
                    case 8:
                        temp += "7";
                        break;
                    case 9:
                        temp += "8";
                        break;
                    case 10:
                        temp += "9";
                        break;
                    case 11:
                        temp += "A";
                        break;
                    case 12:
                        temp += "B";
                        break;
                    case 13:
                        temp += "C";
                        break;
                    case 14:
                        temp += "D";
                        break;
                    case 15:
                        temp += "E";
                        break;
                    case 16:
                        temp += "F";
                        break;
                }
            }
            Console.WriteLine(temp);
        }
    }
}
public class SudokuSolver9x9
{
    public bool AssigningNumbers(int[,] board, bool visualization)
    {
        int[] position = FinidingFirstEmptyPlace(board);
        if (visualization) PrintBoard(board);
        if (position[0] == -1 && position[1] == -1)
        {
            PrintBoard(board);
            return true;
        }
        for (int i = 1; i <= 9; i++)
        {
            if (IsValidOption(board, position, i))
            {
                board[position[0], position[1]] = i;
                if (AssigningNumbers(board, visualization)) return true;
                board[position[0], position[1]] = 0;
            }
        }
        return false;
    }
    private int[] FinidingFirstEmptyPlace(int[,] board)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[i, j] == 0) return new int[] { i, j };
            }
        }
        return new int[] { -1, -1 };
    }
    public bool IsValidOption(int[,] board, int[] position, int value)
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[position[0], i] == value || board[i, position[1]] == value) return false;
        }
        for (int i = (position[0] / 3) * 3; i < ((position[0] / 3) + 1) * 3; i++)
        {
            for (int j = (position[1] / 3) * 3; j < ((position[1] / 3) + 1) * 3; j++)
            {
                if (board[i, j] == value) return false;
            }
        }
        return true;
    }
    public void PrintBoard(int[,] board)
    {
        Console.Clear();
        string temp = "";
        for (int i = 0; i < 9; i++)
        {
            temp = "";
            if (i != 0 && i % 3 == 0)
            {
                Console.WriteLine("-----------");
            }
            for (int j = 0; j < 9; j++)
            {
                if (j != 0 && j % 3 == 0) temp += "|";
                switch (board[i, j])
                {
                    case -1:
                        temp += "_";
                        break;
                    case 0:
                        temp += " ";
                        break;
                    case 1:
                        temp += "1";
                        break;
                    case 2:
                        temp += "2";
                        break;
                    case 3:
                        temp += "3";
                        break;
                    case 4:
                        temp += "4";
                        break;
                    case 5:
                        temp += "5";
                        break;
                    case 6:
                        temp += "6";
                        break;
                    case 7:
                        temp += "7";
                        break;
                    case 8:
                        temp += "8";
                        break;
                    case 9:
                        temp += "9";
                        break;
                }
            }
            Console.WriteLine(temp);
        }
    }
}