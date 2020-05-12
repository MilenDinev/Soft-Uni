using System;
using System.Linq;

namespace _08.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int sum = int.Parse(Console.ReadLine());

            for (int i = 0; i < input.Length; i++)
            {

                for (int j = i+1; j < input.Length; j++)
                {

                    if (input[i] + input[j] == sum)
                    {
                        Console.WriteLine($"{input[i]} {input[j]}");
                    }
                }
            }
        }
    }
}
