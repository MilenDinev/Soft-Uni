using System;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;


        public string Make
        {
            get
            {
                return this.make;
            }

            set
            {
                make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                model = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }

            set
            {
                year = value;
            }
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }

            set
            {
                fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }

            set
            {
                fuelConsumption = value;
            }
        }

        public void  Drive (double distance)
        {
            bool canContinue = this.FuelQuantity - this.FuelConsumption * distance >= 0;
            if (canContinue)
            {
                this.FuelQuantity -=  this.FuelConsumption* distance;
            }

            else
            {
                throw new InvalidOperationException("Not enough fuel to perform this trip!");
            }

        }

        public string GetInformation()
        {

            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}";
        }
    }
}
