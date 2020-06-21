using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.CarSalesman
{
 
   
    public class CarSalesman
    {
        static void Main(string[] args)
        {
            int engineCount = int.Parse(Console.ReadLine());
            EngineConstructor engineConstructor = new EngineConstructor();

            List<Engine> engines = new List<Engine>(engineConstructor.Build(engineCount));

            int carCount = int.Parse(Console.ReadLine());
            CarConstructor carConstructor = new CarConstructor();
            List<Car> cars = new List<Car>(carConstructor.Build(engineCount, engines));


            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
