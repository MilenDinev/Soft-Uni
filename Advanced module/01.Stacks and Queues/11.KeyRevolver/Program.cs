using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());

            int[] bulletsArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] locksArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bullets = new Stack<int>(bulletsArgs);
            Queue<int> locks = new Queue<int>(locksArgs);

            int intelligenceValue = int.Parse(Console.ReadLine());

            int spentMoney = 0;

            int bulletCounter = 0;

            while (bullets.Any() && locks.Any())
            {

                int currnetBullet = bullets.Pop();

                spentMoney += bulletPrice;

                    int currentLock = locks.Peek();

                    if (currnetBullet <= currentLock)
                    {
                        Console.WriteLine("Bang!");
                        locks.Dequeue();
                    }

                    else if (currnetBullet > currentLock)
                    {
                        Console.WriteLine("Ping!");
                    }

                bulletCounter++;

                if (bulletCounter % barrelSize == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }


            if (!locks.Any())
            {
                int earnedMoney = intelligenceValue - spentMoney;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${earnedMoney}");
            }

            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }

    }
}




