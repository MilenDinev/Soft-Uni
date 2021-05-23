using System;
using System.Threading.Tasks;

namespace _01.Chronometer
{
    class Startup
    {
        static void Main(string[] args)
        {
            Chronometer chronometer = new Chronometer();
            string command = Console.ReadLine();
            while (true)
            {
                switch (command)
                {
                    case "start":
                        chronometer.Start();
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                    case "lap":
                        Console.WriteLine($"{chronometer.Lap()}"); 
                        break;
                    case "time":
                        Console.WriteLine($"{chronometer.GetTime}");
                        break;
                    default:
                        break;
                }
                if (command == "laps")
                {
                    var laps = chronometer.Laps;

                    foreach (var lap in laps)
                    {
                        Console.WriteLine(lap);
                    }
                }
                if (command == "exit")
                {
                    break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
