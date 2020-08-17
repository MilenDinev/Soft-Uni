namespace _03.WildFarm.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        private string livingRegion;

        protected Mammal(string name, double weight, int foodEaten, string livingRegion) : base(name, weight, foodEaten)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get 
            { 
                return this.livingRegion; 
            }
            set 
            { 
                this.livingRegion = value; 
            }
        }

    }
}
