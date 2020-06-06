using System;

namespace CarManufacturer
{
    class Program
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumtion = double.Parse(Console.ReadLine());


            Car firstCar = new Car();
            Car secondCar = new Car(make, model, year);
            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumtion);

            Console.WriteLine(thirdCar.FuelConsumption);
        }
    }
}
