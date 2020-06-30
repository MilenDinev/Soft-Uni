namespace _02.CarSalesman
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        static void Main()
        {
            int engineCount = int.Parse(Console.ReadLine());
            EngineConstructor engineConstructor = new EngineConstructor();

            List<Engine> engines = new List<Engine>(engineConstructor.Build(engineCount));

            int carCount = int.Parse(Console.ReadLine());
            CarConstructor carConstructor = new CarConstructor();
            List<Car> cars = new List<Car>(carConstructor.Build(carCount, engines));

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
