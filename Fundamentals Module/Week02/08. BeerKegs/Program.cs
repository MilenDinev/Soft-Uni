using System;

namespace _08._BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfKegs = int.Parse(Console.ReadLine());
            float biggestVolume = 0.0f;
            string biggestModel = string.Empty;
            for (int i = 0; i < numberOfKegs; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                float volume = (3.14f * (radius * radius)) * height;

                if (volume > biggestVolume)
                {
                    biggestModel = model;
                    biggestVolume = volume;
                }
            }

            Console.WriteLine(biggestModel);
        }
    }
}
