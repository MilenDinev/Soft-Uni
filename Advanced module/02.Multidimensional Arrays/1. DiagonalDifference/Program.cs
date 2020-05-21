using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    public class DiagonalDifference
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[,] matrix = new long[n,n];

            for (int row = 0; row < n; row++)
            {
                long[] currentRow = Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }


            long primarysum = 0;

            for (int row = 0; row < n; row++)
            {
                primarysum += matrix[row,row];
            }

            long secondarysum = 0;

            for (int row = 0, col = n - 1; row < n; row++, col--)
            {
                secondarysum += matrix[row,col];
            }

            Console.WriteLine(Math.Abs(primarysum - secondarysum));
        }
    }
}