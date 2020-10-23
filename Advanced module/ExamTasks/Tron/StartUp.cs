namespace TronRacers
{
    using System;
    using System.Linq;

   public class StartUp
    {
       public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            char[,] field = new char[rows, cols];

            int firstPlayerRow = 0;
            int firstPlayerCol = 0;

            int secondPlayerRow = 0;
            int secondPlayerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = input[col];

                    if (field[row, col] == 'f')
                    {
                        firstPlayerRow = row;
                        firstPlayerCol = col;
                    }
                    else if (field[row, col] == 's')
                    {
                        secondPlayerRow = row;
                        secondPlayerCol = col;
                    }
                }
            }

            string[] command = Console.ReadLine().Split().ToArray();
            string commandFirstPlayer = command[0];
            string commandSecondPlayer = command[1];
            bool firstPlayerWin = false;
            bool secondPlayerWin = false;

            while (!firstPlayerWin && !secondPlayerWin)
            {
                switch (commandFirstPlayer)
                {
                    case "right":
                        if (firstPlayerCol + 1 < cols)
                        {
                            field[firstPlayerRow, firstPlayerCol] = 'f';
                            firstPlayerCol++;
                            if (field[firstPlayerRow, firstPlayerCol] == 's')
                            {
                                field[firstPlayerRow, firstPlayerCol] = 'x';
                                firstPlayerWin = true;
                                continue;
                            }
                            else
                            {
                                field[firstPlayerRow, firstPlayerCol] = 'f';
                            }
                        }
                        else
                        {
                            firstPlayerCol = 0;
                            field[firstPlayerCol, firstPlayerRow] = 'f';
                        }

                        break;
                    case "down":

                        if (firstPlayerRow + 1 < rows)
                        {
                            field[firstPlayerRow, firstPlayerCol] = 'f';
                            firstPlayerRow++;
                            if (field[firstPlayerRow, firstPlayerCol] == 's')
                            {
                                field[firstPlayerRow, firstPlayerCol] = 'x';
                                firstPlayerWin = true;
                                continue;
                            }
                            else
                            {
                                field[firstPlayerRow, firstPlayerCol] = 'f';
                            }
                        }
                        else
                        {
                            firstPlayerRow = 0;
                            field[firstPlayerCol, firstPlayerRow] = 'f';
                        }

                        break;
                    case "left":
                        if (firstPlayerCol - 1 >= 0)
                        {
                            field[firstPlayerRow, firstPlayerCol] = 'f';
                            firstPlayerCol--;
                            if (field[firstPlayerRow, firstPlayerCol] == 's')
                            {
                                field[firstPlayerRow, firstPlayerCol] = 'x';
                                firstPlayerWin = true;
                                continue;
                            }
                            else
                            {
                                field[firstPlayerRow, firstPlayerCol] = 'f';
                            }
                        }
                        else
                        {
                            firstPlayerCol = cols - 1;
                            field[firstPlayerCol, firstPlayerRow] = 'f';
                        }

                        break;
                    case "up":
                        if (firstPlayerRow - 1 >= 0)
                        {
                            field[firstPlayerRow, firstPlayerCol] = 'f';
                            firstPlayerRow--;
                            if (field[firstPlayerRow, firstPlayerCol] == 's')
                            {
                                field[firstPlayerRow, firstPlayerCol] = 'x';
                                firstPlayerWin = true;
                                continue;
                            }
                            else
                            {
                                field[firstPlayerRow, firstPlayerCol] = 'f';
                            }
                        }
                        else
                        {
                            firstPlayerRow = rows - 1;
                            field[firstPlayerCol, firstPlayerRow] = 'f';
                        }

                        break;
                    default:
                        Console.WriteLine("Wrong Command!");
                        break;
                }

                if (!firstPlayerWin)
                {
                    switch (commandSecondPlayer)
                    {
                        case "right":
                            if (secondPlayerCol + 1 < cols)
                            {
                                field[secondPlayerRow, secondPlayerCol] = 's';
                                secondPlayerCol++;
                                if (field[secondPlayerRow, secondPlayerCol] == 'f')
                                {
                                    field[secondPlayerRow, secondPlayerCol] = 'x';
                                    secondPlayerWin = true;
                                    continue;
                                }
                                else
                                {
                                    field[secondPlayerRow, secondPlayerCol] = 's';
                                }
                            }
                            else
                            {
                                secondPlayerCol = 0;
                                field[secondPlayerRow, secondPlayerCol] = 's'; 
                            }

                            break;
                        case "down":
                            if (secondPlayerRow + 1 < rows)
                            {
                                field[secondPlayerRow, secondPlayerCol] = 's';
                                secondPlayerRow++;
                                if (field[secondPlayerRow, secondPlayerCol] == 'f')
                                {
                                    field[secondPlayerRow, secondPlayerCol] = 'x';
                                    secondPlayerWin = true;
                                    continue;
                                }
                                else
                                {
                                    field[secondPlayerRow, secondPlayerCol] = 's';
                                }
                            }
                            else
                            {
                                secondPlayerRow = 0;
                                field[secondPlayerRow, secondPlayerCol] = 's';
                            }

                            break;
                        case "left":
                            if (secondPlayerCol - 1 >= 0)                          
                            {
                                field[secondPlayerRow, secondPlayerCol] = 's';
                                secondPlayerCol--;
                                if (field[secondPlayerRow, secondPlayerCol] == 'f')
                                {
                                    field[secondPlayerRow, secondPlayerCol] = 'x';
                                    secondPlayerWin = true;
                                    continue;
                                }
                                else
                                {
                                    field[secondPlayerRow, secondPlayerCol] = 's';
                                }
                            }
                            else
                            {
                                secondPlayerCol = cols - 1;
                                field[secondPlayerRow, secondPlayerCol] = 's';
                            }

                            break;
                        case "up":
                            if (secondPlayerRow - 1 >= 0)
                            {
                                field[secondPlayerRow, secondPlayerCol] = 's';
                                secondPlayerRow--;
                                if (field[secondPlayerRow, secondPlayerCol] == 'f')
                                {
                                    field[secondPlayerRow, secondPlayerCol] = 'x';
                                    secondPlayerWin = true;
                                    continue;
                                }
                                else
                                {
                                    field[secondPlayerRow, secondPlayerCol] = 's';
                                }
                            }
                            else
                            {
                                secondPlayerRow = rows - 1;
                                field[secondPlayerRow, secondPlayerCol] = 's';
                            }

                            break;
                        default:
                            break;
                    }
                }

                command = Console.ReadLine().Split().ToArray();
                commandFirstPlayer = command[0];
                commandSecondPlayer = command[1];
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
