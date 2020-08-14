namespace _01.Vehicles
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }


        string Drive(double distance);
        void Refuel(double fuel);
    }
}
