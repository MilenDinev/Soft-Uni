using System;

namespace _04.Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = x; i <= y; i++)
            {
                sum += i;
                Console.Write(i +" ");
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
