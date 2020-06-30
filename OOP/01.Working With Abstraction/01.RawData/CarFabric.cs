namespace _01.RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarFabric
    {
        public List<Car> Build(int counter)
        {
            List<Car> cars = new List<Car>();
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
                Cargo cargo = new Cargo(cargoWeight, type);
                Car car = new Car(carModel, engine, cargo, tires);

                cars.Add(car);
            }

            return cars;
        }
    }
}
