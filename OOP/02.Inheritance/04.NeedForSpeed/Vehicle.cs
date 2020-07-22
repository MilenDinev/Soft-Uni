namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.FuelConsumption = 1.25d;
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }
        public virtual double FuelConsumption { get; set; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= (this.FuelConsumption * kilometers);
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}: {this.Fuel}";
        }
    }
}
