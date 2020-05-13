using System;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
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
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }


                this.type = value;
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
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{this.Type} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }


        public double CalculateCalories()
        {
            return (this.Weight * 2) * ToppingValidator.GetToppingModifier(this.Type);
        }

    }
}
