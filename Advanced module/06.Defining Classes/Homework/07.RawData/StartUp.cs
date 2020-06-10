using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string[] inputArgs = Console.ReadLine().Split().ToArray();

                string carModel = inputArgs[0];


                int engineSpeed = int.Parse(inputArgs[1]);
                int enginePower = int.Parse(inputArgs[2]);



                int cargoWeight = int.Parse(inputArgs[3]);
                string type = inputArgs[4];

                Tire[] tires = new Tire[4];
                int tiresCounter = 0;

                for (int tireIndex = 5; tireIndex < inputArgs.Length; tireIndex += 2)
                {
                    double currentTirePressure = double.Parse(inputArgs[tireIndex]);
                    int currentTireAge = int.Parse(inputArgs[tireIndex + 1]);

                    Tire tire = new Tire(currentTirePressure, currentTireAge);
                    tires[tiresCounter] = tire;

                    tiresCounter++;
                }

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(type, cargoWeight);
                Car car = new Car(carModel, engine, cargo, tires);

                cars.Add(car);
            }

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
