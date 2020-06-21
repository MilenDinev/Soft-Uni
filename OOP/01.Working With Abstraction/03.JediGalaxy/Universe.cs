using System.Security.Cryptography.X509Certificates;

namespace _03.JediGalaxy
{
    public class Universe
    {
        public Universe(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Field = new int[X,Y];
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public int[,] Field { get; private set;}

        public int[,] Create(int x, int y)
        {
            
            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    this.Field[i, j] = value++;
                }
            }
            return this.Field;
        }
    }
}
