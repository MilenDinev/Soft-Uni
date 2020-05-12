using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

  


            while (input !="end")
            {
                string[] operation = input.Split();

                if (operation[0] == "Delete")
                {
                    while (numbers.Contains(int.Parse(operation[1])))
                    {
                        numbers.Remove(int.Parse(operation[1]));
                    }
                }

                if (operation[0] == "Insert")
                {
                    numbers.Insert(int.Parse(operation[2]), int.Parse(operation[1]));
                }

                input = Console.ReadLine();

            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
