using System;
using System.Text;

public class SampleExam02Sudoku
{
    private static int[,] sudoku = new int[9, 9];
    private static bool solved = false;

    private static void Main()
    {
            StringBuilder buildSudoku = new StringBuilder();
            for (int i = 0; i < 9; i++)
            {
                buildSudoku.Append(Console.ReadLine());
            }

            string stringSudoku = buildSudoku.ToString().Replace('-', '0').Trim();
            int index = 0;
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    sudoku[y, x] = int.Parse(stringSudoku[index].ToString());
                    index++;
                }
            }

            SolveSudoku(0, 0);
        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                Console.Write(sudoku[y, x]);
            }

            Console.WriteLine();
        }
    }

    private static void SolveSudoku(int y, int x)
    {
        if (y > 8 || solved)
        {
            solved = true;
            return;
        }
        else
        {
            while (sudoku[y, x] != 0)
            {
                if (++x > 8)
                {
                    x = 0;
                    y++;
                    if (y > 8)
                    {
                        solved = true;
                        return;
                    }
                }
            }

            for (int number = 1; number < 10; number++)
            {
                if (CheckY(x, number) && CheckX(y, number) && CheckBox(y, x, number))
                {
                    sudoku[y, x] = number;

                    if (x < 8)
                    {
                        SolveSudoku(y, x + 1);
                    }
                    else
                    {
                        SolveSudoku(y + 1, 0);
                    }
                }
            }

            if (solved)
            {
                return; 
            }

            sudoku[y, x] = 0;
        }
    }

    private static bool CheckX(int y, int number)
    {
        for (int x = 0; x < 9; x++)
        {
            if (sudoku[y, x] == number)
            {
                return false;
            }
        }

        return true;
    }

    private static bool CheckY(int x, int number)
    {
        for (int y = 0; y < 9; y++)
        {
            if (sudoku[y, x] == number)
            {
                return false;
            }
        }

        return true;
    }

    private static bool CheckBox(int y, int x, int number)
    {
        x = (x / 3) * 3;
        y = (y / 3) * 3;
        for (int modY = 0; modY < 3; modY++)
        {
            for (int modX = 0; modX < 3; modX++)
            {
                if (sudoku[y + modY, x + modX] == number)
                {
                    return false;
                }
            }
        }
        
        return true;
    }
}