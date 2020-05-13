namespace _01.Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AdditionConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + AdditionConsumption, tankCapacity)
        {
        }
    }
}
