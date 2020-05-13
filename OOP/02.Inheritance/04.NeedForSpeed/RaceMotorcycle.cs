namespace NeedForSpeed
{
   public  class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel) : base (horsePower, fuel)
        {
            this.FuelConsumption = 8.0;
        }
    }
}
