using _03.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            string typeFood = food.GetType().Name;
            if (typeFood == "Meat")
            {
                this.Weight += food.Quantity * 0.4;
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
            return "Woof!";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
