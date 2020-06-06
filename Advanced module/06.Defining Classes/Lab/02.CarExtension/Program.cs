using System;

namespace CarManufacturer
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "Opel";
            car.Model = "Astra";
            car.Year = 1994;
            car.FuelConsumption = 6.5;
            car.FuelQuantity = 42.50;

            Console.WriteLine(car.GetInformation()); 
        }
    }
}
