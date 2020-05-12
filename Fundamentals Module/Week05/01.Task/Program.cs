using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> trainWagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int limit = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input!="end")
            {
                string[] operation = input.Split();

                if (operation[0] == "Add")
                {
                    trainWagons.Add(int.Parse(operation[1]));
                }

                else
                {
                    for (int i = 0; i < trainWagons.Count; i++)
                    {
                        if (int.Parse(operation[0]) + trainWagons[i] <= limit)
                        {
                            trainWagons[i] += int.Parse(operation[0]);
                            break;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join(" ", trainWagons));
        }
    }
}
