using System;

namespace CarManufacturer
{
    class Program
    {
        static void Main(string[] args)
        {
            Tire[] tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3),
            };

            Engine engine = new Engine(560, 6300);

            Car car = new Car("Lexus", "IS250", 2006, 60, 11);

        }
    }
}
