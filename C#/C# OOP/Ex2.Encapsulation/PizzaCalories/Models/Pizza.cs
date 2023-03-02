namespace PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private readonly List<Topping> toppings;

        private const int MinValueOfToppings = 0;
        private const int MaxValueOfToppings = 10;

        public Pizza(string name)
        {
            Name = name;
            toppings = new();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public IReadOnlyList<Topping> Toppings
        {
            get => toppings.AsReadOnly();
        }

        public Dough Dough { get; set; }

        public int NumberOfToppings => toppings.Count;

        public double TotalCalories => toppings.Sum(t => t.TotalCalories) + Dough.TotalCalories;

        public void AddTopping(Topping topping)
        {
            toppings.Add(topping);

            if (NumberOfToppings > MaxValueOfToppings)
            {
                throw new ArgumentException(
                    $"Number of toppings should be in range [{MinValueOfToppings}..{MaxValueOfToppings}].");
            }
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:f2} Calories.";
        }
    }
}
