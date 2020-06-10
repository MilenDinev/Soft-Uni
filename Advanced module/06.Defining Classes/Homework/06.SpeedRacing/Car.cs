using System;

namespace _06.SpeedRacing
{
    public class Car
    {
		private string model;
		private double fuelAmount;
		private double fuelConsumptionPerKilometer;
		private double travelledDistance;

		public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
		{
			this.Model = model;
			this.FuelAmount = fuelAmount;
			this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
			this.TravelledDistance = 0;

		}

		public string Model
		{
			get 
			{ 
				return this.model; 
			}
			set 
			{ 
				this.model = value; 
			}
		}

		public double FuelAmount
		{
			get
			{
				return this.fuelAmount;
			}
			set
			{
				this.fuelAmount = value;
			}
		}

		public double FuelConsumptionPerKilometer
		{
			get
			{
				return this.fuelConsumptionPerKilometer;
			}
			set
			{
				this.fuelConsumptionPerKilometer = value;
			}
		}

		public double TravelledDistance
		{
			get
			{
				return this.travelledDistance;
			}
			set
			{
				this.travelledDistance = value;
			}
		}

		public void Travel(double distance)
		{
			if (this.fuelAmount < distance * this.fuelConsumptionPerKilometer)
			{
				Console.WriteLine("Insufficient fuel for the drive");
			}
			else
			{
				this.fuelAmount -= distance * this.fuelConsumptionPerKilometer;
				this.travelledDistance += distance;
			}
		}
	}
}
