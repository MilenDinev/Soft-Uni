using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = numbersArgs[0];
            int s = numbersArgs[1];
            int x = numbersArgs[2];

            int[] numbersArr = new int[n];

            numbersArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>(numbersArr);


            for (int i = 0; i < s; i++)
            {
                if (numbers.Count > 0)
                {
                    numbers.Pop();
                }

            }

            if (numbers.Contains(x))
            {
                Console.WriteLine("true");
            }

            else if (numbers.Count > 0)
            {
                Console.WriteLine(numbers.Min());
            }

            else if (numbers.Count == 0)
            {
                Console.WriteLine("0");
            }
        }
    }
}
