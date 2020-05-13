using System;
using System.Data.Common;
using System.Linq;

namespace _06.Sneaking
{
    public class Startup
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            PlayField playField = new PlayField(rows);

            char[][] room = new char[rows][];

            int playerRow = 0;
            int playerCol = 0;


            for (int row = 0; row < rows; row++)
            {

                string input = Console.ReadLine();
                room[row] = input.ToCharArray();

                if (room[row].Contains('S'))
                {
                    playerRow = row;
                    playerCol = input.IndexOf('S');
                }
            }

            Console.WriteLine();

            playField.Draw(room);

            Console.WriteLine(playerRow);
            Console.WriteLine(playerCol);
        }    
    }
}

