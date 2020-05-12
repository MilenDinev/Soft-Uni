using System;
using System.Linq;

namespace _05.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
           

            for (int i = 0; i < input.Length - 1; i++)
            {
                bool topInt = true;

                for (int j = i + 1; j < input.Length ; j++)
                {
                  
                    if (input[i] <= input[j])
                    {
                        topInt = false;
                        break;
                    }

                }
                if (topInt)
                {
                    Console.Write(input[i] + " ");
                }


            }
            Console.WriteLine(input[input.Length - 1]);
        }
    }
}
