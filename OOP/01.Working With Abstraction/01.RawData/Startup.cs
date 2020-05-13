using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.RawData
{ 
    public class Startup
    {
       public  static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            Command print= new Command();

            int lines = int.Parse(Console.ReadLine());


            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];
               
                Tire[] tires = new Tire[4];

                foreach (var car in cars)
                {
                    car.GetTires(tires, parameters);
                }

                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Engine engine = new Engine(engineSpeed, enginePower);


                cars.Add(new Car(model, engine, cargo, tires));
            }

            string command = Console.ReadLine();
            print.Info(command, cars);
        }


    }
}
