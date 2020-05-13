namespace Restaurant
{
    public class Food : Product
    {
        public Food(string name, decimal price, double grams) : base (name, price)
        {
            this.Grams = grams;
        }

        public double Grams { get; set; }


        public override string ToString()
        {
            return $"Type: {this.GetType().Name}, Price :{this.Price}, Grams: {this.Grams}";
        }
    }
}
