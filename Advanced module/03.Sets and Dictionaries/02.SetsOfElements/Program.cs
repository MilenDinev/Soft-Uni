using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nmArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < nmArgs[0]; i++)
            {
                int currentDigit = int.Parse(Console.ReadLine());
                firstSet.Add(currentDigit);
            }


            for (int i = 0; i < nmArgs[1]; i++)
            {
                int currentDigit = int.Parse(Console.ReadLine());
                secondSet.Add(currentDigit);
            }


            foreach (var digit in firstSet)
            {
                if (secondSet.Contains(digit))
                {
                    Console.Write (digit + " ");
                }
            }
        }
    }
}
