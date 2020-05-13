using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Startup
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = dimestions[0];
            int cols = dimestions[1];

            int[,] matrix = new int[rows, cols];

            int starValue = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = starValue++;
                }
            }

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] firstPlayer = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilPower = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int evilStartRow = evilPower[0];
                int evilStartCol = evilPower[1];

                while (evilStartRow >= 0 && evilStartCol >= 0)
                {
                    if (evilStartRow >= 0 && evilStartRow < matrix.GetLength(0) && evilStartCol >= 0 && evilStartCol < matrix.GetLength(1))
                    {
                        matrix[evilStartRow, evilStartCol] = 0;
                    }
                    evilStartRow--;
                    evilStartCol--;
                }

                int firstPlayerStartsRow = firstPlayer[0];
                int firstPlayerStartsCol = firstPlayer[1];

                while (firstPlayerStartsRow >= 0 && firstPlayerStartsCol < matrix.GetLength(1))
                {
                    if (firstPlayerStartsRow >= 0 && firstPlayerStartsRow < matrix.GetLength(0) && firstPlayerStartsCol >= 0 && firstPlayerStartsCol < matrix.GetLength(1))
                    {
                        sum += matrix[firstPlayerStartsRow, firstPlayerStartsCol];
                    }

                    firstPlayerStartsCol++;
                    firstPlayerStartsRow--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }
    }
}
