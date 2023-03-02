using System.Runtime.ConstrainedExecution;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private string type;
        private double weightGrams;
        private const int BaseCaloriesPerGram = 2;

        public Topping(string type, double weightGrams)
        {
            Type = type;
            WeightGrams = weightGrams;
        }

        public string Type
        {
            get => type;
            private set
            {
                string valueLower = value.ToLower();

                if (valueLower != "meat" &&
                    valueLower != "veggies" &&
                    valueLower != "cheese" &&
                    valueLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            }
        }

        public double WeightGrams
        {
            get => weightGrams;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }

                weightGrams = value;
            }
        }

        public double CaloriesPerGram => BaseCaloriesPerGram * FindToppingTypeModifier();
        public double TotalCalories => CaloriesPerGram * WeightGrams;

        private double FindToppingTypeModifier()
        {
            string typeToLower = Type.ToLower();

            if (typeToLower == "meat")
            {
                return Modifiers.Meat;
            }
            else if (typeToLower == "veggies")
            {
                return Modifiers.Veggies;
            }
            else if (typeToLower == "cheese")
            {
                return Modifiers.Cheese;
            }
            else
            {
                return Modifiers.Sauce;
            }
        }

        private struct Modifiers
        {
            public const double Meat = 1.2;
            public const double Veggies = 0.8;
            public const double Cheese = 1.1;
            public const double Sauce = 0.9;
        }
    }
}
