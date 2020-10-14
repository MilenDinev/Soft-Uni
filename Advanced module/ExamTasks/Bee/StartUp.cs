namespace Bee
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            char[,] field = new char[rows, cols];
            int beeRow = 0;
            int beeCol = 0;
            int pollinatedFlowers = 0;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = input[col];

                    if (field[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                switch (command)
                {
                    case "right":

                        if (beeCol + 1 < cols)
                        {
                            field[beeRow, beeCol] = '.';

                            if (field[beeRow, beeCol + 1] == 'f')
                            {
                                pollinatedFlowers++;
                            }
                            else if (field[beeRow, beeCol + 1] == 'O')
                            {
                                field[beeRow, beeCol + 1] = 'B';
                                beeCol++;

                                if (beeCol + 1 < cols)
                                {
                                    field[beeRow, beeCol] = '.';

                                    if (field[beeRow, beeCol + 1] == 'f')
                                    {
                                        pollinatedFlowers++;
                                    }
                                }
                                else
                                {
                                    field[beeRow, beeCol] = '.';
                                    beeCol++;
                                    Console.WriteLine("The bee got lost!");
                                    break;
                                }
                            }

                            field[beeRow, beeCol + 1] = 'B';
                            beeCol++;
                        }
                        else
                        {
                            field[beeRow, beeCol] = '.';
                            beeCol++;
                            Console.WriteLine("The bee got lost!");
                            break;
                        }

                        break;
                    case "left":

                        if (beeCol - 1 >= 0)
                        {
                            field[beeRow, beeCol] = '.';

                            if (field[beeRow, beeCol - 1] == 'f')
                            {
                                pollinatedFlowers++;
                            }
                            else if (field[beeRow, beeCol - 1] == 'O')
                            {
                                field[beeRow, beeCol - 1] = 'B';
                                beeCol--;

                                if (beeCol - 1 >= 0)
                                {
                                    field[beeRow, beeCol] = '.';

                                    if (field[beeRow, beeCol - 1] == 'f')
                                    {
                                        pollinatedFlowers++;
                                    }
                                }
                                else
                                {
                                    field[beeRow, beeCol] = '.';
                                    beeCol--;
                                    Console.WriteLine("The bee got lost!");
                                    break;
                                }
                            }

                            field[beeRow, beeCol - 1] = 'B';
                            beeCol--;
                        }
                        else
                        {
                            field[beeRow, beeCol] = '.';
                            beeCol--;
                            Console.WriteLine("The bee got lost!");
                            break;
                        }

                        break;
                    case "up":
                        if (beeRow - 1 >= 0)
                        {
                            field[beeRow, beeCol] = '.';

                            if (field[beeRow - 1, beeCol] == 'f')
                            {
                                pollinatedFlowers++;
                            }
                            else if (field[beeRow - 1, beeCol] == 'O')
                            {
                                field[beeRow - 1, beeCol] = 'B';
                                beeRow--;

                                if (beeRow - 1 >= 0)
                                {
                                    field[beeRow, beeCol] = '.';

                                    if (field[beeRow - 1, beeCol] == 'f')
                                    {
                                        pollinatedFlowers++;
                                    }
                                }
                                else
                                {
                                    field[beeRow, beeCol] = '.';
                                    beeRow--;
                                    Console.WriteLine("The bee got lost!");
                                    break;
                                }
                            }

                            field[beeRow - 1, beeCol] = 'B';
                            beeRow--;
                        }
                        else
                        {
                            field[beeRow, beeCol] = '.';
                            beeRow--;
                            Console.WriteLine("The bee got lost!");
                            break;
                        }

                        break;
                    case "down":
                        if (beeRow + 1 < rows)
                        {
                            field[beeRow, beeCol] = '.';

                            if (field[beeRow + 1, beeCol] == 'f')
                            {
                                pollinatedFlowers++;
                            }
                            else if (field[beeRow + 1, beeCol] == 'O')
                            {
                                field[beeRow + 1, beeCol] = 'B';
                                beeRow++;

                                if (beeRow + 1 < rows)
                                {
                                    field[beeRow, beeCol] = '.';

                                    if (field[beeRow + 1, beeCol] == 'f')
                                    {
                                        pollinatedFlowers++;
                                    }
                                }
                                else
                                {
                                    field[beeRow, beeCol] = '.';
                                    beeRow++;
                                    Console.WriteLine("The bee got lost!");
                                    break;
                                }
                            }

                            field[beeRow + 1, beeCol] = 'B';
                            beeRow++;
                        }
                        else
                        {
                            field[beeRow, beeCol] = '.';
                            beeRow++;
                            Console.WriteLine("The bee got lost!");
                            break;
                        }

                        break;
                    default:
                        break;
                }

                if (beeCol < cols && beeCol >= 0 && beeRow < rows && beeRow >= 0)
                {
                    command = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }

            if (pollinatedFlowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
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
