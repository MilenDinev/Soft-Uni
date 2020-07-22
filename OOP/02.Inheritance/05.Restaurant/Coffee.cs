namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private new const double Milliters = 50;
        private new const decimal Price = 3.50m;
        public Coffee(string name, double caffeine) : base(name, Price, Milliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
