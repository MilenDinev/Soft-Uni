using System;
using System.Linq;

namespace _03.JediGalaxy
{
    public class Startup
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split((' '), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = dimestions[0];
            int y = dimestions[1];

            Universe universe = new Universe(x, y);
            universe.Create(x, y);


            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoArgs = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilArgs = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int evilCoordinatesX = evilArgs[0];
                int evilCoordinatesY = evilArgs[1];

                while (evilCoordinatesX >= 0 && evilCoordinatesY >= 0)
                {
                    if (evilCoordinatesX >= 0 && evilCoordinatesX < x && evilCoordinatesY >= 0 && evilCoordinatesY < y)
                    {
                        universe.Field[evilCoordinatesX, evilCoordinatesY] = 0;
                    }
                    evilCoordinatesX--;
                    evilCoordinatesY--;
                }

                int ivoCoordinatesX = ivoArgs[0];
                int ivoCoordinatesY = ivoArgs[1];

                while (ivoCoordinatesX >= 0 && ivoCoordinatesY < y)
                {
                    if (ivoCoordinatesX >= 0 && ivoCoordinatesX < x && ivoCoordinatesY >= 0 && ivoCoordinatesY < y)
                    {
                        sum += universe.Field[ivoCoordinatesX, ivoCoordinatesY];
                    }

                    ivoCoordinatesY++;
                    ivoCoordinatesX--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }
    }
}
