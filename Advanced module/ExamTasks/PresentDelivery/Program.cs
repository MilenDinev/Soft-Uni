namespace PresentDelivery
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int presentsCount = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int cols = (rows * 2) - 1;
            char[,] field = new char[rows, cols];
            int santaRow = 0;
            int santaCol = 0;
            int niceKids = 0;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = input[col];
                    if (field[row, col] == 'S')
                    {
                        santaRow = row;
                        santaCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "Christmas morning" && presentsCount > 0)
            {
                switch (command)
                {
                    case "right":

                        if (santaCol + 2 < cols)
                        {
                            field[santaRow, santaCol] = '-';
                            santaCol += 2;

                            if (field[santaRow, santaCol] == 'V')
                            {
                                niceKids++;
                                presentsCount--;
                            }
                            else if (field[santaRow, santaCol] == 'C')
                            {
                                if (field[santaRow + 1, santaCol] == 'V' || field[santaRow + 1, santaCol] == 'X')
                                {
                                    niceKids++;
                                    presentsCount--;
                                    field[santaRow + 1, santaCol] = '-';
                                }

                                if (field[santaRow - 1, santaCol] == 'V' || field[santaRow - 1, santaCol] == 'X')
                                {
                                    if (presentsCount > 0)
                                    {
                                        niceKids++;
                                        presentsCount--;
                                        field[santaRow - 1, santaCol] = '-';
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }

                                if (field[santaRow, santaCol + 2] == 'V' || field[santaRow, santaCol + 2] == 'X')
                                {
                                    if (presentsCount > 0)
                                    {
                                        niceKids++;
                                        presentsCount--;
                                        field[santaRow, santaCol + 2] = '-';
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }

                                if (field[santaRow, santaCol - 2] == 'V' || field[santaRow, santaCol - 2] == 'X')
                                {
                                    if (presentsCount > 0)
                                    {
                                        niceKids++;
                                        presentsCount--;
                                        field[santaRow, santaCol - 2] = '-';
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }

                            field[santaRow, santaCol] = 'S';
                        }
                        else
                        {
                            continue;
                        }

                        break;

                    case "left":

                        if (santaCol - 2 >= 0)
                        {
                            field[santaRow, santaCol] = '-';
                            santaCol -= 2;

                            if (field[santaRow, santaCol] == 'V')
                            {
                                niceKids++;
                                presentsCount--;
                            }
                            else if (field[santaRow, santaCol] == 'C')
                            {
                                if (field[santaRow + 1, santaCol] == 'V' || field[santaRow + 1, santaCol] == 'X')
                                {
                                    niceKids++;
                                    presentsCount--;
                                    field[santaRow + 1, santaCol] = '-';
                                }

                                if (field[santaRow - 1, santaCol] == 'V' || field[santaRow - 1, santaCol] == 'X')
                                {
                                    if (presentsCount > 0)
                                    {
                                        niceKids++;
                                        presentsCount--;
                                        field[santaRow - 1, santaCol] = '-';
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }

                                if (field[santaRow, santaCol + 2] == 'V' || field[santaRow, santaCol + 2] == 'X')
                                {
                                    if (presentsCount > 0)
                                    {
                                        niceKids++;
                                        presentsCount--;
                                        field[santaRow, santaCol + 2] = '-';
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }

                                if (field[santaRow, santaCol - 2] == 'V' || field[santaRow, santaCol - 2] == 'X')
                                {
                                    if (presentsCount > 0)
                                    {
                                        niceKids++;
                                        presentsCount--;
                                        field[santaRow, santaCol - 2] = '-';
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }

                            field[santaRow, santaCol] = 'S';
                        }
                        else
                        {
                            continue;
                        }

                        break;

                    case "down":

                        if (santaRow + 1 < rows)
                        {
                            field[santaRow, santaCol] = '-';
                            santaRow++;

                            if (field[santaRow, santaCol] == 'V')
                            {
                                niceKids++;
                                presentsCount--;
                            }
                            else if (field[santaRow, santaCol] == 'C')
                            {
                                if (field[santaRow + 1, santaCol] == 'V' || field[santaRow + 1, santaCol] == 'X')
                                {
                                    niceKids++;
                                    presentsCount--;
                                    field[santaRow + 1, santaCol] = '-';
                                }

                                if (field[santaRow - 1, santaCol] == 'V' || field[santaRow - 1, santaCol] == 'X')
                                {
                                    if (presentsCount > 0)
                                    {
                                        niceKids++;
                                        presentsCount--;
                                        field[santaRow - 1, santaCol] = '-';
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }

                                if (field[santaRow, santaCol + 2] == 'V' || field[santaRow, santaCol + 2] == 'X')
                                {
                                    if (presentsCount > 0)
                                    {
                                        niceKids++;
                                        presentsCount--;
                                        field[santaRow, santaCol + 2] = '-';
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }

                                if (field[santaRow, santaCol - 2] == 'V' || field[santaRow, santaCol - 2] == 'X')
                                {
                                    if (presentsCount > 0)
                                    {
                                        niceKids++;
                                        presentsCount--;
                                        field[santaRow, santaCol - 2] = '-';
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }

                            field[santaRow, santaCol] = 'S';
                        }
                        else
                        {
                            continue;
                        }

                        break;

                    case "up":

                        if (santaRow - 1 >= 0)
                        {
                            field[santaRow, santaCol] = '-';
                            santaRow--;

                            if (field[santaRow, santaCol] == 'V')
                            {
                                niceKids++;
                                presentsCount--;
                            }
                            else if (field[santaRow, santaCol] == 'C')
                            {
                                if (field[santaRow + 1, santaCol] == 'V' || field[santaRow + 1, santaCol] == 'X')
                                {
                                    niceKids++;
                                    presentsCount--;
                                    field[santaRow + 1, santaCol] = '-';
                                }

                                if (field[santaRow - 1, santaCol] == 'V' || field[santaRow - 1, santaCol] == 'X')
                                {
                                    if (presentsCount > 0)
                                    {
                                        niceKids++;
                                        presentsCount--;
                                        field[santaRow - 1, santaCol] = '-';
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }

                                if (field[santaRow, santaCol + 2] == 'V' || field[santaRow, santaCol + 2] == 'X')
                                {
                                    if (presentsCount > 0)
                                    {
                                        niceKids++;
                                        presentsCount--;
                                        field[santaRow, santaCol + 2] = '-';
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }

                                if (field[santaRow, santaCol - 2] == 'V' || field[santaRow, santaCol - 2] == 'X')
                                {
                                    if (presentsCount > 0)
                                    {
                                        niceKids++;
                                        presentsCount--;
                                        field[santaRow, santaCol - 2] = '-';
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                            }

                            field[santaRow, santaCol] = 'S';
                        }
                        else
                        {
                            continue;
                        }

                        break;

                    default:
                        break;
                }

                if (presentsCount > 0)
                {
                    command = Console.ReadLine();
                }
            }

            int niceKidsleft = 0;

            if (presentsCount == 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(field[row, col]);
                    if (field[row, col] == 'V')
                    {
                        niceKidsleft++;
                    }
                }

                Console.WriteLine();
            }

            if (niceKidsleft > 0)
            {
                Console.WriteLine($"No presents for {niceKidsleft} nice kid/s.");
            }

            if (niceKidsleft == 0)
            {
                Console.WriteLine($"Good job, Santa! {niceKids} happy nice kid/s.");
            }
        }
    }
}
