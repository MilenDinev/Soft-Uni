using System.Text;

namespace _03.Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
            this.Model = "488-Spider";
        }

        public string Driver { get; private set;}

        public string Model { get; private set; }

        public string UseBrakes()
        {
            return "Brakes!";
        }

        public string PushGasPedal()
        {
            return "Gas!";
        }

        public override string ToString()
        {

            return $"{this.Model}/{UseBrakes()}/{PushGasPedal()}/{this.Driver}";
        }

    }
}
