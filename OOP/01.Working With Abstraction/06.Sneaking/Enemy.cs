

using System;

namespace _06.Sneaking
{
    public class Enemy
    {

        public int[] GetPosition(char[][] room, int[] playerPosition)
        {
            int[] getEnemyPosition = new int[2];


            for (int j = 0; j < room[playerPosition[0]].Length; j++)
            {
                if (room[playerPosition[0]][j] != '.' && room[playerPosition[0]][j] != 'S')
                {
                    getEnemyPosition[0] = playerPosition[0];
                    getEnemyPosition[1] = j;
                }

            }

            return getEnemyPosition;
        }








        public void GotKilled(char[][] room, int[] enemyPosition)
        {
            room[enemyPosition[0]][enemyPosition[1]] = 'X';

            Console.WriteLine("Nikoladze killed!");
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            return;
        }

    }
}
