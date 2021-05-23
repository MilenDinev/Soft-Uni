using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {


            PrintNumbersInRange(0, 100);

            var task = Task.Run(() =>
                PrintNumbersInRange(100, 200));

            Console.WriteLine("Done.");
            task.Wait();

            Thread primes = new Thread(() => PrintNumbersInRange(1, 50));
            primes.Start();
            Console.WriteLine("Waiting for thread to finish work...");
            primes.Join();

        }

        static void PrintNumbersInRange(int a, int b)
        {
            for (int i = a; i <= b; i++)
            {
                Console.WriteLine(i);
            }
        }

    }
}
