using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Task
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            List<string> names = new List<string>(n);

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] operation = input.Split();

                if (operation.Length <= 3 )
                {
                    if (names.Contains(operation[0]))
                    {
                        Console.WriteLine($"{operation[0]} is already in the list!");
                    }
                    else
                    {
                        names.Add(operation[0]);
                    }
                }
                else if (operation.Length > 3)
                {
                    if (names.Contains(operation[0]))
                    {
                        names.Remove(operation[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{operation[0]} is not in the list!");
                    }
                     
                }
            }


            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }

        }
    }
}
