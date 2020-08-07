namespace _03.Ferrari
{
    using System;
   public class StartUp
    {
       public static void Main()
        {
            string driverName = Console.ReadLine();

            ICar car = new Ferrari(driverName);

            Console.WriteLine($"{car.Model}/{car.UseBrakes()}/{car.PushGasPedal()}/{car.Driver}");
        }
    }
}
