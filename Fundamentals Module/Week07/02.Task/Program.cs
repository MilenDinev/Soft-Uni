//02.	A Miner Task 

using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            

            var resources = new Dictionary<string, int>();


            while (input != "stop")
            {
                int resourcesCount = int.Parse(Console.ReadLine());
                if (!resources.ContainsKey(input))
                {
                    resources.Add(input, resourcesCount);
                }

                else
                {
                    resources[input] += resourcesCount;     
                }

                input = Console.ReadLine();
            }


            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }

        }
    }
}
