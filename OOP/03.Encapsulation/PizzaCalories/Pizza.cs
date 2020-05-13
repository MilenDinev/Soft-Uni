using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private List<Topping> toppings;
        private string name;

        public Dough Dough { get; }
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get 
            {
                return this.name; 
            }
            set 
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value; 
            }
        }


        public int TopingCount()
        {
            return this.toppings.Count;
        }
        public  double GetCallories()
        {

            return toppings.Sum( x => x.CalculateCalories()) + this.Dough.GetTotalCalories(); 
        }


        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

    }
}
