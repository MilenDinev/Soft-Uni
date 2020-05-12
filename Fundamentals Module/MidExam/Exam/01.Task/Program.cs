using System;

namespace _01.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = int.Parse(Console.ReadLine());
            double stepLength = double.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            double fifthStep = stepLength * 0.7;

            double traveledDistance = 0;

            for (int i = 1; i <= steps; i++)
            {
                if (i % 5 == 0)
                {
                    traveledDistance += fifthStep;
                }
                else
                {
                    traveledDistance += stepLength;
                }

                
            }

            double percentage = traveledDistance / distance;

            Console.WriteLine($"You travelled {percentage:f2}% of the distance!");

        }
    }
}
