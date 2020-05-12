using System;
using System.Linq;
using System.Collections.Generic;

namespace ListManipulationAdvanced
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            int[] firstArray = new int[number];
            int[] secondArray = new int[number];

            for (int index = 0; index < number; index++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (index % 2 == 0)
                {
                    firstArray[index] = input[0];
                    secondArray[index] = input[1];
                }
                else
                {
                    secondArray[index] = input[0];
                    firstArray[index] = input[1];
                }
            }

            Console.WriteLine(string.Join(" ", firstArray));
            Console.WriteLine(string.Join(" ", secondArray));
        }
    }
}