namespace _01.RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    class RawData
    {
        static void Main(string[] args)
        {

            int counter = int.Parse(Console.ReadLine());
            CarFabric fabric = new CarFabric();
            List<Car> cars = new List<Car>(fabric.Build(counter));

            string cargoType = Console.ReadLine();

            if (cargoType == "fragile")
            {
                cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(p => p.Pressure < 1.0)).ToList().ForEach(x => Console.WriteLine(x.Model));
            }


            else if (cargoType == "flamable")
            {
                cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250).ToList().ForEach(x => Console.WriteLine(x.Model));
            }
        }
    }
}
