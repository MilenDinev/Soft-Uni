using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.RawData
{
    public class Command
    {
        public void Info(string command, List<Car> cars)
        {
            if (command == "fragile")
            {
                cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(p => p.Pressure < 1.0)).ToList().ForEach(x => Console.WriteLine(x.Model));
            }
            else
            {
                cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250).ToList().ForEach(x => Console.WriteLine(x.Model));
            }
        }
    }
}
