using System.Collections.Generic;

namespace PizzaCalories
{
    public static class DoughValidator
    {
        private static Dictionary<string, double> flourTypes;
        private static Dictionary<string, double> bakingTechniques;

        public static void InitializeFlourTypes()
        {
            flourTypes = new Dictionary<string, double>();
           

            flourTypes.Add("white", 1.5);
            flourTypes.Add("wholegrain", 1.0);

        }

        public static void InitializeBakingTechniques()
        {

            bakingTechniques = new Dictionary<string, double>();
            bakingTechniques.Add("crispy", 0.9);
            bakingTechniques.Add("chewy", 1.1);
            bakingTechniques.Add("homemade", 1.0);
        }
        public static bool isValidFlourType(string flourType)
        {
            if (flourTypes == null)
            {
                InitializeFlourTypes();
            }

            return flourTypes.ContainsKey(flourType.ToLower());
        }
        public static bool isValidBakingTechnique(string bakingTechnique)
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
