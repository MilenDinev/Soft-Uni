using _03.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight,wingSize)
        {
        }

        public override void Eat(Food food)
        {
            string typeFood = food.GetType().Name;

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
