using System;
using System.Collections.Generic;
using System.Linq;


namespace Exercises
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
            Queue<int> numbers = new Queue<int>(numbersArr);


            for (int i = 0; i < s; i++)
            {
                if (numbers.Count > 0)
                {
                    numbers.Dequeue();
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
