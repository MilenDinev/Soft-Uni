using System;

namespace _05.Task
{
    class Program
    {
        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Substract(int a, int b, int c)
        {
            return Sum(a, b) - c;
        }

        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            Console.WriteLine(Substract(a,b,c));

        }
    }
}
