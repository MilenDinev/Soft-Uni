using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace PizzaCalories
{
    public static class ToppingValidator
    {
        private static  Dictionary<string, double> types;


        public static void Initialize()
        {
            types = new Dictionary<string, double>();
            types.Add("meat", 1.2);
            types.Add("veggies", 0.8);
            types.Add("cheese", 1.1);
            types.Add("sauce", 0.9);
        }
        public static bool IsValidTopping(string type)
        {
            if (types == null)
            {
                Initialize();
            }

            return types.ContainsKey(type);
        }

        public static double GetToppingModifier(string type)
        {

            return types[type.ToLower()];
        }
    }
}
