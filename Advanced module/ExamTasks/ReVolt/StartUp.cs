namespace ReVolt
{
    using System;

   public class StartUp
    {
      public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            int rotations = int.Parse(Console.ReadLine());

            char[,] field = new char[rows, cols];

            int playerRow = 0;
            int playerCol = 0;
            int counter = 0;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = input[col];

                    if (field[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < rotations; i++)
            {
                string command = Console.ReadLine();

                if (command == "right")
                {
                    if (playerCol + 1 < cols)
                    {
                        if (field[playerRow, playerCol + 1] == 'F')
                        {
                            field[playerRow, playerCol] = '-';
                            playerCol++;
                            field[playerRow, playerCol] = 'f';
                            Console.WriteLine("Player won!");
                            break;
                        }
                        else if (field[playerRow, playerCol + 1] == 'B')
                        {
                            playerCol++;

                            if (playerCol + 1 < cols)
                            {
                                field[playerRow, playerCol - 1] = '-';

                                if (field[playerRow, playerCol + 1] == 'F')
                                {
                                    playerCol++;
                                    field[playerRow, playerCol] = 'f';
                                    Console.WriteLine("Player won!");
                                    break;
                                }
                                else
                                {
                                    playerCol++;
                                    field[playerRow, playerCol] = 'f';
                                }
                            }
                            else if (playerCol + 1 >= cols)
                            {
                                field[playerRow, playerCol] = '-';
                                playerCol = 0;

                                if (field[playerRow, playerCol] == 'F')
                                {
                                    field[playerRow, playerCol] = 'f';
                                    Console.WriteLine("Player won!");
                                    break;
                                }

                                field[playerRow, playerCol] = 'f';
                            }
                        }
                        else if (field[playerRow, playerCol + 1] == 'T')
                        {
                            counter++;
                            continue;
                        }
                        else
                        {
                            field[playerRow, playerCol] = '-';
                            field[playerRow, playerCol + 1] = 'f';
                            playerCol++;
                        }
                    }
                    else if (playerCol + 1 >= cols)
                    {
                        field[playerRow, playerCol] = '-';
                        playerCol = 0;

                        if (field[playerRow, playerCol] == 'F')
                        {
                            field[playerRow, playerCol] = 'f';
                            Console.WriteLine("Player won!");
                            break;
                        }

                        field[playerRow, playerCol] = 'f';
                    }
                }         
                else if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {                       
                        if (field[playerRow, playerCol - 1] == 'F')
                        {
                            playerCol--;
                            field[playerRow, playerCol] = 'f';
                            Console.WriteLine("Player won!");
                            break;
                        }
                        else if (field[playerRow, playerCol - 1] == 'B')
                        {
                            playerCol--;

                            if (playerCol - 1 >= 0)
                            {
                                field[playerRow, playerCol + 1] = '-';

                                if (field[playerRow, playerCol - 1] == 'F')
                                {
                                    playerCol--;
                                    field[playerRow, playerCol] = 'f';
                                    Console.WriteLine("Player won!");
                                    break;
                                }
                                else
                                {
                                    playerCol--;
                                    field[playerRow, playerCol] = 'f';
                                }
                            }
                            else if (playerCol - 1 < 0)
                            {
                                field[playerRow, playerCol] = '-';
                                playerCol = cols - 1;

                                if (field[playerRow, playerCol] == 'F')
                                {
                                    field[playerRow, playerCol] = 'f';
                                    Console.WriteLine("Player won!");
                                    break;
                                }

                                field[playerRow, playerCol] = 'f';
                            }
                        }
                        else if (field[playerRow, playerCol - 1] == 'T')
                        {
                            counter++;
                            continue;
                        }
                        else
                        {
                            field[playerRow, playerCol] = '-';
                            field[playerRow, playerCol - 1] = 'f';
                            playerCol--;
                        }
                    }
                    else if (playerCol - 1 < 0)
                    {
                        field[playerRow, playerCol] = '-';
                        playerCol = cols - 1;

                        if (field[playerRow, playerCol] == 'F')
                        {
                            field[playerRow, playerCol] = 'f';
                            Console.WriteLine("Player won!");
                            break;
                        }
                        
                        field[playerRow, playerCol] = 'f';
                    }
                }
                else if (command == "up")
                {
                    if (playerRow - 1 >= 0)
                    {
                        if (field[playerRow - 1, playerCol] == 'F')
                        {
                            playerRow--;
                            field[playerRow, playerCol] = 'f';
                            Console.WriteLine("Player won!");
                            break;
                        }
                        else if (field[playerRow - 1, playerCol] == 'B')
                        {
                            playerRow--;

                            if (playerRow - 1 >= 0)
                            {
                                field[playerRow + 1, playerCol] = '-';

                                if (field[playerRow - 1, playerCol] == 'F')
                                {
                                    playerRow--;
                                    field[playerRow, playerCol] = 'f';
                                    Console.WriteLine("Player won!");
                                    break;
                                }
                                else
                                {
                                    playerRow--;
                                    field[playerRow, playerCol] = 'f';
                                }
                            }
                            else if (playerRow - 1 < 0)
                            {
                                field[playerRow, playerCol] = '-';
                                playerRow = rows - 1;

                                if (field[playerRow, playerCol] == 'F')
                                {
                                    field[playerRow, playerCol] = 'f';
                                    Console.WriteLine("Player won!");
                                    break;
                                }

                                field[playerRow, playerCol] = 'f';
                            }
                        }
                        else if (field[playerRow - 1, playerCol] == 'T')
                        {
                            counter++;
                            continue;
                        }
                        else
                        {
                            field[playerRow, playerCol] = '-';
                            field[playerRow - 1, playerCol] = 'f';
                            playerRow--;
                        }
                    }
                    else if (playerRow - 1 < 0)
                    {
                        field[playerRow, playerCol] = '-';
                        playerRow = rows - 1;

                        if (field[playerRow, playerCol] == 'F')
                        {
                            field[playerRow, playerCol] = 'f';
                            Console.WriteLine("Player won!");
                            break;
                        }

                        field[playerRow, playerCol] = 'f';
                    }
                }
                else if (command == "down")
                {
                    if (playerRow + 1 < rows)
                    {
                        if (field[playerRow + 1, playerCol] == 'F')
                        {
                            field[playerRow, playerCol] = '-';
                            playerRow++;
                            field[playerRow, playerCol] = 'f';
                            Console.WriteLine("Player won!");
                            break;
                        }
                        else if (field[playerRow + 1, playerCol] == 'B')
                        {
                            playerRow++;

                            if (playerRow + 1 < rows)
                            {
                                field[playerRow - 1, playerCol] = '-';

                                if (field[playerRow + 1, playerCol] == 'F')
                                {
                                    playerRow++;
                                    field[playerRow, playerCol] = 'f';
                                    Console.WriteLine("Player won!");
                                    break;
                                }
                                else
                                {
                                    playerRow++;
                                    field[playerRow, playerCol] = 'f';
                                }
                            }
                            else if (playerRow + 1 >= rows)
                            {
                                field[playerRow, playerCol] = '-';
                                playerCol = 0;

                                if (field[playerRow, playerCol] == 'F')
                                {
                                    field[playerRow, playerCol] = 'f';
                                    Console.WriteLine("Player won!");
                                    break;
                                }

                                field[playerRow, playerCol] = 'f';
                            }
                        }
                        else if (field[playerRow + 1, playerCol] == 'T')
                        {
                            counter++;
                            continue;
                        }
                        else
                        {
                            field[playerRow, playerCol] = '-';
                            field[playerRow + 1, playerCol] = 'f';
                            playerRow++;
                        }
                    }
                    else if (playerRow + 1 >= rows)
                    {
                        field[playerRow, playerCol] = '-';
                        playerRow = 0;

                        if (field[playerRow, playerCol] == 'F')
                        {
                            field[playerRow, playerCol] = 'f';
                            Console.WriteLine("Player won!");
                            break;
                        }

                        field[playerRow, playerCol] = 'f';
                    }
                }

                counter++;
            }

            if (counter == rotations)
            {
                Console.WriteLine("Player lost!");
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
