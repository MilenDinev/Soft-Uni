using System;
using System.Numerics;
namespace _11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            long snowballs = long.Parse(Console.ReadLine());
            BigInteger highestValue = 0;
            long bestTime = 0;
            long bestSnow = 0;
            long bestQuality = 0;

            for (int i = 0; i < snowballs; i++)
            {
                long snowballSnow = long.Parse(Console.ReadLine());
                long snowballTime = long.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

               
                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

                if (snowballValue >= highestValue)
                {
                    bestTime = snowballTime;
                    bestSnow = snowballSnow;
                    bestQuality = snowballQuality;
                    highestValue = snowballValue;
                }
            }

            Console.WriteLine($"{bestSnow} : {bestTime} = {highestValue} ({bestQuality})");
        }
    }
}
