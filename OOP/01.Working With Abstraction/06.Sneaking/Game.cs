using System;

namespace _06.Sneaking
{
    public class Game
    {

        public Player Player { get; set; }
        public Enemy Enemy { get; set; }

        public void Play(char[][] room)
        {
            int[] playePosition = this.Player.GetPosition(room);

            int playerRow = playePosition[0];
            int playerCol = playePosition[1];

            char[] moves = Console.ReadLine().ToCharArray();


            for (int i = 0; i < moves.Length; i++)
            {
               this.Player.Moves(room);



                int[] enemyPosition = this.Enemy.GetPosition(room, playePosition);

                if (this.Player.GotKilled(room, playePosition, enemyPosition))
                {
                    return;
                }


                room[playerRow][playerCol] = '.';

                switch (moves[i])
                {
                    case 'U':
                        playePosition[0]--;
                        break;
                    case 'D':
                        playePosition[0]++;
                        break;
                    case 'L':
                        playePosition[1]--;
                        break;
                    case 'R':
                        playePosition[1]++;
                        break;
                    default:
                        break;
                }


                room[playerRow][playerCol] = 'S';

                for (int j = 0; j < room[playerRow].Length; j++)
                {
                    if (room[playerRow][j] != '.' && room[playerRow][j] != 'S')
                    {
                        enemyPosition[0] = playerRow;
                        enemyPosition[1] = j;
                    }
                }

                if (room[enemyPosition[0]][enemyPosition[1]] == 'N' && playerRow == enemyPosition[0])
                {
                    this.Enemy.GotKilled(room, enemyPosition);

                    return;
                }
            }
        }
    }
}
