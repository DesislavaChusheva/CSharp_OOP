using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private double whiteMod = 1.5;
        private double wholegrainMod = 1.0;
        private double crispyMod = 0.9;
        private double chewyMod = 1.1;
        private double homemadeMod = 1.0;

        private string flourType;
        private string bakingTechnique;
        private int weight;

        private double flourTypeMod;
        private double bakingTechiqueMod;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }
        public string FlourType
        {
            get => flourType;
            private set
            {
                string valueToLower = value.ToLower();
                if (valueToLower != "white" && valueToLower != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
                switch (valueToLower)
                {
                    case "white":
                        flourTypeMod = whiteMod;
                        break;
                    case "wholegrain":
                        flourTypeMod = wholegrainMod;
                        break;
                    default:
                        break;
                }
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                string valueToLower = value.ToLower();
                if (valueToLower != "crispy" && valueToLower != "chewy" && valueToLower != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
                switch (valueToLower)
                {
                    case "crispy":
                        bakingTechiqueMod = crispyMod;
                        break;
                    case "chewy":
                        bakingTechiqueMod = chewyMod;
                        break;
                    case "homemade":
                        bakingTechiqueMod = homemadeMod;
                        break;
                    default:
                        break;
                }
            }
        }
        public int Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || weight > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public double DoughCalories()
        {
            return 2 * Weight * flourTypeMod * bakingTechiqueMod;
        }
    }
}

