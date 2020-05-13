

using System;

namespace _06.Sneaking
{
    public class Player
    {
        public int[] GetPosition(char[][] room)
        {
            int[] playerPosition = new int[2];


            for (int row = 0; row < room.Length; row++)
            {
                int cols = room[row].Length;

                for (int col = 0; col < cols; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                    }
                }
            }

            return playerPosition;
        }

        public void Moves(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }


        public bool GotKilled(char[][] room, int[] playePosition, int[] enemyPosition)
        {
            bool playerGotKilled = false;

            if ((playePosition[1] < enemyPosition[1] && room[enemyPosition[0]][enemyPosition[1]] == 'd' && enemyPosition[0] == playePosition[0]) || enemyPosition[1] < playePosition[1] && room[enemyPosition[0]][enemyPosition[1]] == 'b' && enemyPosition[0] == playePosition[0])
            {
                room[playePosition[0]][playePosition[1]] = 'X';

                Console.WriteLine($"Sam died at {playePosition[0]}, {playePosition[1]}");
                for (int row = 0; row < room.Length; row++)
                {
                    for (int col = 0; col < room[row].Length; col++)
                    {
                        Console.Write(room[row][col]);
                    }
                    Console.WriteLine();
                }
                playerGotKilled = true;
            }

            return playerGotKilled;
        }

    }
}
