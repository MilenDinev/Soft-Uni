using System;
using System.Linq;

namespace _06.SpeedRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int carsToTrack = int.Parse(Console.ReadLine());

            Car[] cars = new Car[carsToTrack];


            for (int i = 0; i < carsToTrack; i++)
            {
                string[] carsArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carsArgs[0];
                double fuelAmount = double.Parse(carsArgs[1]);
                double fuelConsumptionPerKm = double.Parse(carsArgs[2]);


                cars[i] = new Car(model, fuelAmount, fuelConsumptionPerKm);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];
                string currentModel = inputArgs[1];
                double amountOfKm = double.Parse(inputArgs[2]);



                cars.Where(c => c.Model == currentModel).ToList().ForEach(c => c.Travel(amountOfKm));
                input = Console.ReadLine();
            }



            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }

        }
    }
}
