namespace _03.WildFarm.Animals.Birds
{
    public abstract class Bird : Animal
    {
        private double wingSize;

        protected Bird(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten)
        {
            this.WingSize = wingSize;
        }

        public double WingSize
        {
            get 
            { 
                return this.wingSize; 
            }
            set 
            { 
                this.wingSize = value; 
            }
        }

        public override string  ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
