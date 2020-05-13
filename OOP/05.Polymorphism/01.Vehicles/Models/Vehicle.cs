using System;
using System.Runtime.InteropServices;

namespace _01.Vehicles.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;

        }

        public double TankCapacity { get; set; }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
           protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }

                else
                {
                    this.fuelQuantity = value;
                }

            }
        }
        public double FuelConsumption { get; set; }
 



        public string Drive(double distance)
        {
            bool canDrive = this.FuelQuantity >= FuelConsumption * distance;

            if (canDrive)
            {
                this.FuelQuantity -= FuelConsumption * distance;
                return $"{this.GetType().Name} travelled {distance} km";

            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double fuel)
        {
            

            if (fuel <=0)
            {

                throw new ArgumentException("Fuel must be a positive number");
            }

            double wantedFuelAmount = this.FuelQuantity + fuel;

            if (wantedFuelAmount > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            this.FuelQuantity += fuel;
        }


        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
