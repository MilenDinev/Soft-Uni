namespace Restaurant
{
    public class Cake : Dessert
    {
        private new const double Grams = 250;
        private new const double Callories = 1000;
        private new const decimal Price = 5m;

        public Cake(string name) : base(name, Price, Grams, Callories)
        {
 
        }
    }
}
