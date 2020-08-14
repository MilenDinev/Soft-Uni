namespace _01.Vehicles
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] carArgs = Console.ReadLine().Split().ToArray();
            double carFuelQuantity = double.Parse(carArgs[1]);
            double carFuelConsumption = double.Parse(carArgs[2]);
            Vehicle car = new Car(carFuelQuantity, carFuelConsumption);
            string[] truckArgs = Console.ReadLine().Split().ToArray();
            double truckFuelQuantity = double.Parse(truckArgs[1]);
            double truckFuelConsumption = double.Parse(truckArgs[2]);
            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption);


            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                string[] commandArgs = Console.ReadLine().Split().ToArray();

                if (commandArgs[1] == "Car")
                {
                    if (commandArgs[0] == "Drive")
                    {
                        double distance = double.Parse(commandArgs[2]);
                        Console.WriteLine(car.Drive(distance)); 
                    }

                    else if (commandArgs[0] == "Refuel")
                    {
                        double fuelQuantity = double.Parse(commandArgs[2]);
                        car.Refuel(fuelQuantity);
                    }
                }

                else if (commandArgs[1] == "Truck")
                {
                    if (commandArgs[0] == "Drive")
                    {
                        double distance = double.Parse(commandArgs[2]);
                        Console.WriteLine(truck.Drive(distance)) ;
                    }

                    else if (commandArgs[0] == "Refuel")
                    {
                        double fuelQuantity = double.Parse(commandArgs[2]);
                        truck.Refuel(fuelQuantity);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
