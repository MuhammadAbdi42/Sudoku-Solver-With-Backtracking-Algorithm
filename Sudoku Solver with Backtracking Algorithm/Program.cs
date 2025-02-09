Suduko suduko = new();
suduko.Start();

public class Suduko
{
    public void Start()
    {
        Console.Clear();
        Console.WriteLine("Please select the size of the sudoku you want to solve:");
        Console.WriteLine("1. 9x9");
        Console.WriteLine("2. 16x16");
        char c = Console.ReadKey().KeyChar;
        Console.Clear();
        if (c == '1') SudukoEditor(9);
        else if (c == '2') SudukoEditor(16);
        else
        {
            Console.WriteLine("--- Invalid Input ---");
            Console.WriteLine();
            Start();
        }
    }
    private void SudukoEditor(int sizeOption)
    {
        int[,] board = new int[sizeOption, sizeOption];
        for (int i = 0; i < sizeOption; i++)
        {
            for (int j = 0; j < sizeOption; j++) board[i, j] = 0;
        }
        bool isOver = false;
        for (int i = 0; i < sizeOption; i++)
        {
            for (int j = 0; j < sizeOption; j++)
            {
                if (!isOver)
                {
                    board[i, j] = -1;
                    PrintBoard(board, sizeOption);
                    Console.WriteLine();
                    Console.WriteLine("Please type the number you want to add to the board (space for empty)");
                    if (ValidOptions(board, [i, j], sizeOption) != "") Console.WriteLine("Valid options: " + ValidOptions(board, [i, j], sizeOption));
                    else Console.WriteLine("--- No valid options ---");
                    char c = Console.ReadKey().KeyChar;
                    Dictionary<char, int> size16 = new() { { '0', 1 }, { '1', 2 }, { '2', 3 }, { '3', 4 }, { '4', 5 }, { '5', 6 }, { '6', 7 }, { '7', 8 }, { '8', 9 }, { '9', 10 }, { 'A', 11 }, { 'B', 12 }, { 'C', 13 }, { 'D', 14 }, { 'E', 15 }, { 'F', 16 }, { 'a', 11 }, { 'b', 12 }, { 'c', 13 }, { 'd', 14 }, { 'e', 15 }, { 'f', 16 } };
                    Dictionary<char, int> size9 = new() { { '1', 1 }, { '2', 2 }, { '3', 3 }, { '4', 4 }, { '5', 5 }, { '6', 6 }, { '7', 7 }, { '8', 8 }, { '9', 9 } };
                    if (c == ' ') board[i, j] = 0;
                    else if (sizeOption == 16 && size16.ContainsKey(c))
                    {
                        if (IsValidOption(board, [i, j], size16[c], 16))
                        {
                            board[i, j] = size16[c];
                        }
                        else j--;
                    }
                    else if (sizeOption == 9 && size9.ContainsKey(c))
                    {
                        if (IsValidOption(board, [i, j], size9[c], 9))
                        {
                            board[i, j] = size9[c];
                        }
                        else j--;
                    }
                    else if (c == '\b')
                    {
                        board[i, j] = 0;
                        if (j == 0 && i == 0)
                        {
                            j = -1;
                        }
                        else if (j == 0)
                        {
                            i -= 1;
                            j = sizeOption - 2;
                        }
                        else
                        {
                            j -= 2;
                        }
                    }
                    else if (c == '\r')
                    {
                        board[i, j] = 0;
                        isOver = true;
                    }
                    else j--;
                }
                else
                {
                    board[i, j] = 0;
                }
            }
        }
        Solving(board, sizeOption);
    }
    private void PrintBoard(int[,] board, int sizeOption)
    {
        int divisor;
        if (sizeOption == 9) divisor = 3;
        else divisor = 4;
        Dictionary<int, string> size9 = new() { { -1, "_" }, { 0, " " }, { 1, "1" }, { 2, "2" }, { 3, "3" }, { 4, "4" }, { 5, "5" }, { 6, "6" }, { 7, "7" }, { 8, "8" }, { 9, "9" } };
        Dictionary<int, string> size16 = new() { { -1, "_" }, { 0, " " }, { 1, "0" }, { 2, "1" }, { 3, "2" }, { 4, "3" }, { 5, "4" }, { 6, "5" }, { 7, "6" }, { 8, "7" }, { 9, "8" }, { 10, "9" }, { 11, "A" }, { 12, "B" }, { 13, "C" }, { 14, "D" }, { 15, "E" }, { 16, "F" } };
        Console.Clear();
        string temp = "";
        for (int i = 0; i < sizeOption; i++)
        {
            temp = "";
            if (i != 0 && i % divisor == 0)
            {
                if (sizeOption == 9) Console.WriteLine("-----------");
                else if (sizeOption == 16) Console.WriteLine("-------------------");
            }
            for (int j = 0; j < sizeOption; j++)
            {
                if (j != 0 && j % divisor == 0) temp += "|";
                if (sizeOption == 9) temp += size9[board[i, j]];
                else if (sizeOption == 16) temp += size16[board[i, j]];
            }
            Console.WriteLine(temp);
        }
    }
    private bool IsValidOption(int[,] board, int[] position, int value, int sizeOption)
    {
        int divisor = new();
        if (sizeOption == 9) divisor = 3;
        else divisor = 4;
        for (int i = 0; i < sizeOption; i++)
        {
            if (board[position[0], i] == value || board[i, position[1]] == value) return false;
        }
        for (int i = (position[0] / divisor) * divisor; i < ((position[0] / divisor) + 1) * divisor; i++)
        {
            for (int j = (position[1] / divisor) * divisor; j < ((position[1] / divisor) + 1) * divisor; j++)
            {
                if (board[i, j] == value) return false;
            }
        }
        return true;
    }
    private void Solving(int[,] board, int sizeOption)
    {
        Console.Clear();
        Console.WriteLine("Do you want visualization? (y/n)");
        char c = Console.ReadKey().KeyChar;
        bool visualization = false;
        if (c == 'y' || c == 'Y') visualization = true;

        if (!AssigningNumbers(board, visualization, sizeOption))
        {
            Console.Clear();
            PrintBoard(board, sizeOption);
            Console.WriteLine();
            Console.WriteLine("No Solution Found");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Process Finished");
        }

        Console.WriteLine("Another one? (y/n)");
        c = Console.ReadKey().KeyChar;
        if (c == 'y' || c == 'Y') Start();

        Console.ReadLine();
    }
    public bool AssigningNumbers(int[,] board, bool visualization, int sizeOption)
    {
        int[] position = FinidingFirstEmptyPlace(board, sizeOption);
        if (visualization) PrintBoard(board, sizeOption);
        if (position[0] == -1 && position[1] == -1)
        {
            PrintBoard(board, sizeOption);
            return true;
        }
        for (int i = 1; i <= sizeOption; i++)
        {
            if (IsValidOption(board, position, i, sizeOption))
            {
                board[position[0], position[1]] = i;
                if (AssigningNumbers(board, visualization, sizeOption)) return true;
                board[position[0], position[1]] = 0;
            }
        }
        return false;
    }
    private int[] FinidingFirstEmptyPlace(int[,] board, int sizeOption)
    {
        for (int i = 0; i < sizeOption; i++)
        {
            for (int j = 0; j < sizeOption; j++)
            {
                if (board[i, j] == 0) return new int[] { i, j };
            }
        }
        return new int[] { -1, -1 };
    }
    private string ValidOptions(int[,] board, int[] position, int sizeOption)
    {
        string answer = "";
        Dictionary<int, string> size9 = new() { { -1, "_" }, { 0, " " }, { 1, "1" }, { 2, "2" }, { 3, "3" }, { 4, "4" }, { 5, "5" }, { 6, "6" }, { 7, "7" }, { 8, "8" }, { 9, "9" } };
        Dictionary<int, string> size16 = new() { { -1, "_" }, { 0, " " }, { 1, "0" }, { 2, "1" }, { 3, "2" }, { 4, "3" }, { 5, "4" }, { 6, "5" }, { 7, "6" }, { 8, "7" }, { 9, "8" }, { 10, "9" }, { 11, "A" }, { 12, "B" }, { 13, "C" }, { 14, "D" }, { 15, "E" }, { 16, "F" } };
        for (int i = 1; i <= sizeOption; i++)
        {
            if (IsValidOption(board, position, i, sizeOption))
            {
                if (sizeOption == 9) answer += size9[i] + " ";
                else if (sizeOption == 16) answer += size16[i] + " ";
            }
        }
        return answer;
    }
}