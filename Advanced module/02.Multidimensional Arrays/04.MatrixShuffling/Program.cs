using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] currentRow = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            string command = Console.ReadLine();


            while (command != "END")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();


                if (commandArgs[0] == "swap" && commandArgs.Length == 5)
                {

                    int firstRow = int.Parse(commandArgs[1]);
                    int firstCol = int.Parse(commandArgs[2]);
                    int secondRow = int.Parse(commandArgs[3]);
                    int secondCol = int.Parse(commandArgs[4]);

                    if (firstRow >= 0 && firstRow <= rows - 1 && firstCol >= 0 && firstCol <= cols - 1
                        && secondRow >= 0 && secondRow <= rows - 1 && secondCol >= 0 && secondCol <= cols - 1)
                    {

                        var temp = matrix[firstRow, firstCol];
                        matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                        matrix[secondRow, secondCol] = temp;

                        for (int row = 0; row <rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }
                            Console.WriteLine();

                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input!");
                    }
                }

                else
                {
                    Console.WriteLine($"Invalid input!");
                }

                command = Console.ReadLine();
            }
        }
    }
}
