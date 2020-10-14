namespace Snake
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            char[,] field = new char[rows, cols];
            int snakeRow = 0;
            int snakeCol = 0;
            int snakeFood = 0;

            for (int row = 0; row < rows; row++)
            {
                string currnetRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = currnetRow[col];

                    if (field[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (snakeFood < 10 && (snakeCol < cols && snakeCol >= 0 && snakeRow < rows && snakeRow >= 0))
            {
                switch (command)
                {
                    case "right":
                        if (snakeCol + 1 < cols)
                        {
                            field[snakeRow, snakeCol] = '.';
                            snakeCol++;
                            if (field[snakeRow, snakeCol] == '*')
                            {
                                snakeFood++;
                            }
                            else if (field[snakeRow, snakeCol] == 'B')
                            {
                                field[snakeRow, snakeCol] = '.';

                                for (int row = 0; row < rows; row++)
                                {
                                    for (int col = 0; col < cols; col++)
                                    {
                                        if (field[row, col] == 'B')
                                        {
                                            snakeRow = row;
                                            snakeCol = col;
                                        }
                                    }
                                }
                            }
                        }
                        else if (snakeCol + 1 >= cols)
                        {
                            field[snakeRow, snakeCol] = '.';
                            snakeCol++;
                            break;
                        }

                        field[snakeRow, snakeCol] = 'S';

                        break;
                    case "left":

                        if (snakeCol - 1 >= 0)
                        {
                            field[snakeRow, snakeCol] = '.';
                            snakeCol--;
                            if (field[snakeRow, snakeCol] == '*')
                            {
                                snakeFood++;
                            }
                            else if (field[snakeRow, snakeCol] == 'B')
                            {
                                field[snakeRow, snakeCol] = '.';

                                for (int row = 0; row < rows; row++)
                                {
                                    for (int col = 0; col < cols; col++)
                                    {
                                        if (field[row, col] == 'B')
                                        {
                                            snakeRow = row;
                                            snakeCol = col;
                                        }
                                    }
                                }
                            }
                        }
                        else if (snakeCol - 1 < 0)
                        {
                            field[snakeRow, snakeCol] = '.';
                            snakeCol--;
                            break;
                        }

                        field[snakeRow, snakeCol] = 'S';
                        break;
                    case "down":
                        if (snakeRow + 1 < rows)
                        {
                            field[snakeRow, snakeCol] = '.';
                            snakeRow++;
                            if (field[snakeRow, snakeCol] == '*')
                            {
                                snakeFood++;
                            }
                            else if (field[snakeRow, snakeCol] == 'B')
                            {
                                field[snakeRow, snakeCol] = '.';

                                for (int row = 0; row < rows; row++)
                                {
                                    for (int col = 0; col < cols; col++)
                                    {
                                        if (field[row, col] == 'B')
                                        {
                                            snakeRow = row;
                                            snakeCol = col;
                                        }
                                    }
                                }
                            }
                        }
                        else if (snakeRow + 1 >= rows)
                        {
                            field[snakeRow, snakeCol] = '.';
                            snakeRow++;
                            break;
                        }

                        field[snakeRow, snakeCol] = 'S';

                        break;
                    case "up":
                        if (snakeRow - 1 >= 0)
                        {
                            field[snakeRow, snakeCol] = '.';
                            snakeRow--;

                            if (field[snakeRow, snakeCol] == '*')
                            {
                                snakeFood++;
                            }
                            else if (field[snakeRow, snakeCol] == 'B')
                            {
                                field[snakeRow, snakeCol] = '.';

                                for (int row = 0; row < rows; row++)
                                {
                                    for (int col = 0; col < cols; col++)
                                    {
                                        if (field[row, col] == 'B')
                                        {
                                            snakeRow = row;
                                            snakeCol = col;
                                        }
                                    }
                                }
                            }
                        }
                        else if (snakeRow - 1 < 0)
                        {
                            field[snakeRow, snakeCol] = '.';
                            snakeRow--;
                            break;
                        }

                        field[snakeRow, snakeCol] = 'S';

                        break;
                    default:
                        Console.WriteLine("Wrong command!");
                        break;
                }

                if (snakeFood < 10)
                {
                    command = Console.ReadLine();
                }
            }

            if (snakeFood == 10)
            {
                Console.WriteLine("You won! You fed the snake.");
                Console.WriteLine($"Food eaten: {snakeFood}");
            }
            else
            {
                Console.WriteLine("Game over!");
                Console.WriteLine($"Food eaten: {snakeFood}");
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
