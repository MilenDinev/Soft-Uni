using System;

namespace _03.Ferrari
{
    public class Startup
    {
        static void Main(string[] args)
        {
            string driver = Console.ReadLine();

            ICar ferrari = new Ferrari(driver);

            Console.WriteLine(ferrari);
        }
    }
}
