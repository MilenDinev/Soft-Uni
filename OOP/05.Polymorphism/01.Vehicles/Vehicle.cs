namespace _01.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public  double FuelQuantity { get; set; }

        public  double FuelConsumption { get; set; }

        public double TankCapacity { get; set; }

        public string Drive(double distance)
        {
            bool canDrive = this.FuelQuantity >= this.FuelConsumption * distance;
            if (canDrive)
            {
                
                this.FuelQuantity -= this.FuelConsumption * distance;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }

        public override string ToString()
        {

            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

    }
}
