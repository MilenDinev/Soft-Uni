namespace _03.WildFarm.Animals.Birds
{
    using _03.WildFarm.Foods;

    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingSize) : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            this.Weight += food.Quantity * 0.35;
            this.FoodEaten += food.Quantity;
            return;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
