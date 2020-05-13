using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Rotations
{
    class Program
    {
        static void Main(string[] args)
        {
            int rotations = int.Parse(Console.ReadLine());

            HashSet<string> uniqueElements = new HashSet<string>();

            for (int i = 0; i < rotations; i++)
            {
                string[] elements = Console.ReadLine().Split();

                for (int j = 0; j < elements.Length; j++)
                {
                    uniqueElements.Add(elements[j]);
                }
            }
            
            Console.WriteLine(string.Join(" ", uniqueElements.OrderBy(x => x)));
        }
    }
}
