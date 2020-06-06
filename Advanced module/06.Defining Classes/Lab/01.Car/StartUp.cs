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

            Console.WriteLine($"Make: {car.Make} \nModel: {car.Model} \nYear: {car.Year}");
        }
    }
}
