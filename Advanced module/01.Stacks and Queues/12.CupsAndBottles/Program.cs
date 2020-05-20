using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] bottlesArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> cups = new Queue<int>(cupsArgs);
            Stack<int> bottles = new Stack<int>(bottlesArgs);

            int wastedWater = 0;

            while (cups.Any() && bottles.Any())
            {
                int currentCup = cups.Peek();
                int currentBottle = bottles.Pop();

                if (currentBottle >= currentCup)
                {
                    currentBottle -= currentCup;
                    wastedWater += currentBottle;
                    cups.Dequeue();
                }

                else if (currentCup > currentBottle)
                {

                    while (currentCup > currentBottle && bottles.Any())
                    {
                        currentCup -= currentBottle;
                        currentBottle = bottles.Pop();
                    }

                    currentBottle -= currentCup;

                    cups.Dequeue();
                    wastedWater += currentBottle;

                }
            }

            if (bottles.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
