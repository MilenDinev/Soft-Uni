﻿
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
        private Engine engine;
        private Tire[] tires;




        public Car(string make, string model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;

        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumtion) : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumtion;
        }


        public string Make
        {
            get
            {
                return this.make;
            }

           private set
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

           private set
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

          private  set
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

           private set
            {
                fuelConsumption = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return this.engine;
            }

            set
            {
                this.engine = value;
            }
        }

        public Tire[] Tires
        {
            get
            {
                return this.tires;
            }

            set
            {
                this.tires = value;
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