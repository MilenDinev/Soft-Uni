namespace _03.Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            this.Model = "488-Spider";
            this.Driver = driver;
        }

        public string Model { get; private set; }

        public string Driver { get; private set; }

        public string PushGasPedal()
        {
            return "Gas!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }
    }
}
