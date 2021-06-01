
namespace ThreadExample
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;

    public  class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            string command = Console.ReadLine();
            Thread t = new Thread(() =>
              SumOddNumbers(command, stopwatch));
            t.Start();

            Console.WriteLine("What should I do?");
            while (true)
            {
                if (command == "start")
                {
                    stopwatch.Restart();
                    stopwatch.Start();
                    Console.WriteLine(stopwatch.ElapsedMilliseconds);
                }
                if (command == "stop")
                {
                    stopwatch.Stop();
                    Console.WriteLine(stopwatch.ElapsedMilliseconds);
                }
                if (command == "exit") break;
                command = Console.ReadLine();
            }


;
            int totalMiliseconds = 60000;
            int miliSeconds = totalMiliseconds % 1000;
            int totalSeconds = totalMiliseconds / 1000;
            int totalMinutes = totalSeconds / 60;

            int seconds = totalSeconds % 60;
            int minutes = totalMinutes % 60;
            int hours = totalMinutes / 60;
            Console.WriteLine(hours);
            Console.WriteLine(minutes);
            Console.WriteLine(seconds);
            Console.WriteLine(miliSeconds);
            t.Join();

        }

        static void SumOddNumbers(string command, Stopwatch stopwatch)
        {
            switch (command)
            {
                case "start":
                    stopwatch.Start();
                        break;
                case "stop":
                    stopwatch.Stop();
                    break;
                default:
                    break;
            }
        }
    }
}
