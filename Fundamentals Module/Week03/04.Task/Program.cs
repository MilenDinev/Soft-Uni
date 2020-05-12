using System;
using System.Linq;

namespace _04.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());
            int[] tempArray = new int[input.Length];




            for (int i = 0; i < rotations; i++)
            {
                int temp = input[0];

                for (int j = 0; j < tempArray.Length; j++)
                {
                    tempArray[j] = input[j];
                }

                for (int k = 0; k < tempArray.Length - 1; k++)
                {
                    input[k] = tempArray[k + 1];
                }

                input[input.Length - 1] = temp;

            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(input[i] + " ");
            }
        }
    }
}
