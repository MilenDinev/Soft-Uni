using System;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;

        public Topping(double weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }

        public double Weight
        {
            get 
            { 
                return this.weight; 
            }

            set 
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.type} weight should be in the range[1..50].");
                }
                this.weight = value; 
            }
        }

        public string Type
        {
            get 
            { 
                return this.type; 
            }

            set 
            {
                if (!ToppingValidator.IsValidTopping(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value; 
            }
        }

        public double GetTotalCalories()
        {

            return (this.Weight * 2) * ToppingValidator.GetToppingModifier(this.Type.ToLower());
        }

    }
}
