namespace Restaurant
{
    public class Beverage : Product
    {

        public Beverage(string name, decimal price, double milliters) : base(name, price)
        {
            this.Milliters = milliters;
        }

        public double Milliters { get; set; }
    }
}
