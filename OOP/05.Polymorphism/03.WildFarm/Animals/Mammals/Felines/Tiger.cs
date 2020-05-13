using _03.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            string typeFood = food.GetType().Name;
            if (typeFood == "Meat")
            {
                this.Weight += food.Quantity * 1.0;
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
            return "ROAR!!!";
        }
    }
}
