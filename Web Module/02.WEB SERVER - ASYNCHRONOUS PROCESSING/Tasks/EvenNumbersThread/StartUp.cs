namespace EvenNumbersThread
{
    using System;
    using System.Threading;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            Thread evens = new Thread(() =>
                PrintEvenNumbers(start, end));
            evens.Start();

            evens.Join();
            Console.WriteLine("Thread finished work");

        }

        static void PrintEvenNumbers(int a, int b)
        {
            for (int i = a; i <= b; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }

        }
    }
}
