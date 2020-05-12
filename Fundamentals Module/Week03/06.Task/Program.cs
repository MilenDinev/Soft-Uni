using System;
using System.Linq;

namespace _06.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int leftsum = 0;
            int rightsum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                rightsum += input[i];
            }

            for (int k = 0; k < input.Length; k++)
            {

                rightsum -= input[k];

                if (leftsum == rightsum)
                {
                    Console.WriteLine(k);
                    return;
                }

                else
                {
                    leftsum += input[k];
                }
            }
            Console.WriteLine("no");
        }
    }
}
