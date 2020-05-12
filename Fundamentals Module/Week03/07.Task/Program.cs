using System;
using System.Linq;

namespace _07.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int number = 0;
            int currentCounter = 0;
            int finalCounter = 0;

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    currentCounter++;
                }
                else
                {
                    currentCounter = 0;
                }

                if (currentCounter > finalCounter)
                {
                    finalCounter = currentCounter;
                    number = input[i];

                }
         
            }

            for (int i = 0; i <= finalCounter; i++)
            {
                Console.Write(number + " ");
            }
        }
    }
}
