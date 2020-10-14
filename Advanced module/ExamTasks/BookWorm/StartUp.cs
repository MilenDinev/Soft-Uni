namespace BookWorm
{
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            StringBuilder word = new StringBuilder(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            char[,] field = new char[rows, cols];
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = input[col];

                    if (field[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "right":
                        if (playerCol + 1 < cols)
                        {
                            field[playerRow, playerCol] = '-';
                            playerCol++;
                            if (char.IsLetter(field[playerRow, playerCol]))
                            {
                                word.Append(field[playerRow, playerCol]);
                                field[playerRow, playerCol] = 'P';
                            }
                            else
                            {
                                field[playerRow, playerCol] = 'P';
                            }
                        }
                        else
                        {
                            if (word != null)
                            {
                                word.Remove(word.Length - 1, 1);
                            }
                        }

                        break;

                    case "down":
                        if (playerRow + 1 < rows)
                        {
                            field[playerRow, playerCol] = '-';
                            playerRow++;
                            if (char.IsLetter(field[playerRow, playerCol]))
                            {
                                word.Append(field[playerRow, playerCol]);
                                field[playerRow, playerCol] = 'P';
                            }
                            else
                            {
                                field[playerRow, playerCol] = 'P';
                            }
                        }
                        else
                        {
                            if (word != null)
                            {
                                word.Remove(word.Length - 1, 1);
                            }
                        }

                        break;

                    case "left":
                        if (playerCol - 1 >= 0)
                        {
                            field[playerRow, playerCol] = '-';
                            playerCol--;
                            if (char.IsLetter(field[playerRow, playerCol]))
                            {
                                word.Append(field[playerRow, playerCol]);
                                field[playerRow, playerCol] = 'P';
                            }
                            else
                            {
                                field[playerRow, playerCol] = 'P';
                            }
                        }
                        else
                        {
                            if (word != null)
                            {
                                word.Remove(word.Length - 1, 1);
                            }
                        }

                        break;

                    case "up":
                        if (playerRow - 1 >= 0)
                        {
                            field[playerRow, playerCol] = '-';
                            playerRow--;
                            if (char.IsLetter(field[playerRow, playerCol]))
                            {
                                word.Append(field[playerRow, playerCol]);
                                field[playerRow, playerCol] = 'P';
                            }
                            else
                            {
                                field[playerRow, playerCol] = 'P';
                            }
                        }
                        else
                        {
                            if (word != null)
                            {
                                word.Remove(word.Length - 1, 1);
                            }
                        }

                        break;

                    default:
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(word.ToString());

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
