using System;
using _03.WildFarm.Foods;

namespace _03.WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            string typeFood = food.GetType().Name; 
            if (typeFood == "Fruit" || typeFood == "Vegetable")
            {
                this.Weight += food.Quantity * 0.1;
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
            return "Squeak"; 
        }


        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
