namespace _03.WildFarm.Animals.Mammals.Feline
{
    using _03.WildFarm.Foods;
    using System;

    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten, string breed) : base(name, weight, foodEaten, breed)
        {
        }

        public override void Eat(Food food)
        {
            string typeFood = food.GetType().Name;
            if (typeFood == "Meat" || typeFood == "Vegetable")
            {
                this.Weight += food.Quantity * 0.30;
                this.FoodEaten += food.Quantity;
                return;
            }
            else
            {
                throw new Exception($"{this.GetType().Name} does not eat {typeFood}!");

            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
