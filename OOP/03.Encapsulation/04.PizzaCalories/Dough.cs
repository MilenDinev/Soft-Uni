namespace _04.PizzaCalories
{
    using System;

    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get 
            { 
                return this.flourType; 
            }

            set 
            {
                if (!DoughValidator.IsValidFlourType(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.flourType = value; 
            }
        }

        public string BakingTechnique
        {

            get 
            { 
                return this.bakingTechnique; 
            }

            set 
            {
                if (!DoughValidator.IsValidBakingTechnique(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.bakingTechnique = value; 
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
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range[1..200].");
                }
                this.weight = value;
            }
        }

        public double GetTotalCalories()
        {

            return (this.Weight * 2) * DoughValidator.GetFlourModifier(this.FlourType.ToLower()) * DoughValidator.GetBakingTechniqueModifier(this.BakingTechnique.ToLower());
        }

    }
}
