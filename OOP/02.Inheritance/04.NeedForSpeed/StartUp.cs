namespace NeedForSpeed
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(200, 50);
            Car car = new Car(200, 50);
            SportCar sportCar  = new SportCar(200, 50);
            Motorcycle motorCycle  = new Motorcycle(200, 50);

            System.Console.WriteLine(vehicle);
            System.Console.WriteLine(motorCycle);
            System.Console.WriteLine(car);
            System.Console.WriteLine(sportCar);

            vehicle.Drive(20);
            car.Drive(20);
            sportCar.Drive(20);
            motorCycle.Drive(20);

            System.Console.WriteLine(vehicle);
            System.Console.WriteLine(motorCycle);
            System.Console.WriteLine(car);
            System.Console.WriteLine(sportCar);
        }
    }
}
