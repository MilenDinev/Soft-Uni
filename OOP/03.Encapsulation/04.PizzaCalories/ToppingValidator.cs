namespace _04.PizzaCalories
{
    using System.Collections.Generic;

    public class ToppingValidator
    {
        private static Dictionary<string, double> toppings;

        public static void InitializeToppings()
        {
            toppings = new Dictionary<string, double>
            { 
                {"meat", 1.2 }, 
                {"veggies", 0.8 }, 
                {"cheese", 1.1 }, 
                {"sauce", 0.9 }
            };
        }


        public static bool IsValidTopping(string type)
        {
            if (toppings == null)
            {
                InitializeToppings();
            }

            return toppings.ContainsKey(type.ToLower());
        }

        public static double GetToppingModifier(string type)
        {
            return toppings[type.ToLower()];
        }

    }
}
