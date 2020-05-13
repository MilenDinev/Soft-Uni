using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace _01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AdditionConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + AdditionConsumption, tankCapacity)
        {
        }

        public override void Refuel(double fuel)
        {
            if (fuel <= this.TankCapacity)
            {
                fuel *= 0.95;
            }

            base.Refuel(fuel);
        }
    }
}
