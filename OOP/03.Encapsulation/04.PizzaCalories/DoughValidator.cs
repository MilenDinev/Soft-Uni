namespace _04.PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class DoughValidator
    {
        private static Dictionary<string, double> flourTypes;
        private static Dictionary<string, double> bakingTechniques;

        public static void InitializeFlourTypes()
        {
            flourTypes = new Dictionary<string, double>
            {
                {"white", 1.5},
                {"wholegrain", 1.0}
            };

        }

        public static void InitializeBakingTechniques()
        {
            bakingTechniques = new Dictionary<string, double>
            {
                {"crispy" ,0.9},
                {"chewy",1.1},
                {"homemade",1.0}
            };

        }
        public static bool IsValidFlourType(string flourType)
        {
            if (flourTypes == null)
            {
                InitializeFlourTypes();
            }

            return flourTypes.ContainsKey(flourType.ToLower());
        }

        public static bool IsValidBakingTechnique(string bakingTechnique)
        {
            if (bakingTechniques == null)
            {
                InitializeBakingTechniques();
            }

            return bakingTechniques.ContainsKey(bakingTechnique.ToLower());
        }

        public static double GetFlourModifier(string type)
        {
            return flourTypes[type.ToLower()];
        }

        public static double GetBakingTechniqueModifier(string type)
        {
            return bakingTechniques[type.ToLower()];
        }

    }
}
