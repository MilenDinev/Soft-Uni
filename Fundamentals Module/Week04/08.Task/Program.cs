using System;

namespace _08.Task
{
    class Program
    {
        static decimal Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }     
        }

        static decimal DivideRecursion(int n, int m)
        {
             decimal sum = Factorial(n) / Factorial(m);

            return sum;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
             
            Console.WriteLine($"{DivideRecursion(n,m):f2}");
        }
    }
}
