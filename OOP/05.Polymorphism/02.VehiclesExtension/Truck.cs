namespace _02.VehiclesExtension
{

    public class Truck : Vehicle
    {
        private const double AdditionConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + AdditionConsumption, tankCapacity)
        {
        }

        public override void Refuel(double fuel)
        {

            fuel *= 0.95;

            base.Refuel(fuel);
        }

    }
}
