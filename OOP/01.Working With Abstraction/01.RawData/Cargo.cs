namespace _01.RawData
{
    public class Cargo
    {
        public Cargo(int cargoWeight, string cargoType)
        {
            this.Weight = cargoWeight;
            this.Type = cargoType;
        }

        public int Weight { get; private set; }

        public string Type { get; private set; }
    }
}
