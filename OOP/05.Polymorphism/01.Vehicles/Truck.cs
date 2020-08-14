namespace _01.Vehicles
{
    using System;
    public class Truck : Vehicle
    {
        private const double AdditionConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption + AdditionConsumption)
        {
        }

        public override void Refuel(double fuel)
        {

            fuel *= 0.95;

            base.Refuel(fuel);
        }
    }
}
