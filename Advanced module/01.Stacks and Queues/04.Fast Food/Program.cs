using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04.Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodVolume = int.Parse(Console.ReadLine());

            int[] ordersArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(ordersArr);

            int biggestOrder = orders.Max();
            int currentOrder = orders.Dequeue();

            while (foodVolume - currentOrder > 0 && orders.Count != 0)
            {
                
                foodVolume -= currentOrder;
                currentOrder = orders.Dequeue();
                if (foodVolume - currentOrder < 0 && orders.Count == 0)
                {
                    orders.Enqueue(currentOrder);
                }
            }

            Console.WriteLine(biggestOrder);
            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }

            else if (orders.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }
    }
}
