using System;

namespace _07.WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 255;
            int rotations = int.Parse(Console.ReadLine());
            int totalLitres= 0;

            for (int i = 0; i < rotations; i++)
            {
                int litres = int.Parse(Console.ReadLine());
                totalLitres += litres;
                if (totalLitres > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                    totalLitres -= litres;
                    continue;
                }
            }

            Console.WriteLine(totalLitres);
        }
    }
}
