namespace _03.WildFarm.Animals
{
    using Foods;
    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        protected Animal(string name, double weight, int foodEaten)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = foodEaten;
        }

        public string Name
        {
            get 
            { 
                return this.name; 
            }
            set 
            { 
                this.name = value; 
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                this.weight = value;
            }
        }
        public int FoodEaten
        {
            get 
            { 
                return this.foodEaten; 
            }
            set 
            { 
                this.foodEaten = value; 
            }
        }


        public abstract string ProduceSound();

        public abstract void Eat(Food food);
    }
}
