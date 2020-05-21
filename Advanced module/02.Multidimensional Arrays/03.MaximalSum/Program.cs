using System;
using System.Linq;


namespace _03.MaximalSum
{

    public class MaximalSum
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row <rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int maxSum = 0;
            int rowStartIndex = 0;
            int colStartIndex = 0;


            for (int row = 0; row < rows - 2 ; row++)
            {

                for (int col = 0; col < cols - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        rowStartIndex = row;
                        colStartIndex = col;
                    }
                }


            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = rowStartIndex; row <= rowStartIndex + 2; row++)
            {
                for (int col = colStartIndex; col <= colStartIndex + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}