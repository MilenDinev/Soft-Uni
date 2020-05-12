using System;

namespace _01.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());

            int[] passengers = new int[wagons];
            int sum = 0;
            
            for (int i = 0; i < wagons; i++)
            {
                passengers[i] = int.Parse(Console.ReadLine());
                sum += passengers[i];
            }

            for (int i = 0; i < wagons; i++)
            {
                Console.Write(passengers[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
