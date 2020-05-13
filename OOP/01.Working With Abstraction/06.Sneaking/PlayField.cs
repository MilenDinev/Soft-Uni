using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Sneaking
{
    public class PlayField
    {
        public PlayField(int rows)
        {
            this.Rows = rows;
        }

        public int Rows { get; set; }


        public void Draw(char[][] room)
        {
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }

                Console.WriteLine();

            }
        }
    }
}
