using System;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _02.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = inputArgs[0];
            int cols = inputArgs[1];
            int counter = 0;
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row, col] == matrix[row,col + 1] &&
                        matrix[row,col] == matrix[row + 1,col] &&
                        matrix[row,col] == matrix[row + 1,col + 1])
                    {
                        counter++;
                    }
                }
            }


                Console.WriteLine($"{counter}");
        }
    }
}
