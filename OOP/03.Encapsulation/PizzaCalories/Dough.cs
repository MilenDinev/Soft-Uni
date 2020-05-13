using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private double weight;
        private string flourType;
        private string bakingTechnique;
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
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

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            set
            {
                if (!DoughValidator.isValidBakingTechnique(value))
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            set
            {
                if (!DoughValidator.isValidFlourType(value))
                {
                    throw new Exception("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public double GetTotalCalories()
        {

            return (this.Weight * 2) * DoughValidator.GetFlourModifier(this.FlourType) * DoughValidator.GetBakingTechniqueModifier(this.BakingTechnique);
        }
    }
}
