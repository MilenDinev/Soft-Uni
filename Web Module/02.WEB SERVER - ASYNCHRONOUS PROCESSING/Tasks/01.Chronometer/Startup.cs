using System;
using System.Linq;
using System.Threading.Tasks;

namespace _01.Chronometer
{
    class Startup
    {
        static void Main(string[] args)
        {
            Chronometer chronometer = new Chronometer();
            string command = Console.ReadLine();
            int lapsCounter = 0;
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

                    if (!laps.Any())
                    {
                        Console.WriteLine("Laps: no laps");
                    }

                    foreach (var lap in laps)
                    {
                        
                        Console.WriteLine($"{lapsCounter}. {lap}");
                        lapsCounter++;
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
