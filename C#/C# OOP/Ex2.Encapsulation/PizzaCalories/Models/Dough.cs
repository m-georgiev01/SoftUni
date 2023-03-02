using System.Runtime.ConstrainedExecution;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weighInGrams;
        private const int BaseCaloriesPerGram = 2;

        public Dough(string flourType, string bakingTechnique, double weighInGrams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            WeighInGrams = weighInGrams;
        }

        public string FlourType
        {
            get => flourType;
            private set
            {
                value = value.ToLower();
                if (value != "white" && value != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                value = value.ToLower();
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        public double WeighInGrams
        {
            get => weighInGrams;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                weighInGrams = value;
            }
        }

        public double CaloriesPerGram => BaseCaloriesPerGram * FindFlourTypeModifier() * FindBakingTechniqueModifier();
        public double TotalCalories => CaloriesPerGram * WeighInGrams;

        private double FindFlourTypeModifier()
        {
            if (FlourType == "white")
            {
                return Modifiers.White;
            }

            return Modifiers.Wholegrain;
        }

        private double FindBakingTechniqueModifier()
        {
            if (BakingTechnique == "crispy")
            {
                return Modifiers.Crispy;
            }
            else if (BakingTechnique == "chewy")
            {
                return Modifiers.Chewy;
            }
            else
            {
                return Modifiers.Homemade;
            }
        }

        private struct Modifiers
        {
            public const double White = 1.5;
            public const double Wholegrain = 1;
            public const double Crispy = 0.9;
            public const double Chewy = 1.1;
            public const double Homemade = 1;
        }
    }
}
