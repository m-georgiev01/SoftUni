using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        public abstract double WeightMultiplier { get; }
        public abstract IReadOnlyCollection<Type> PreferredFoods { get; }


        public abstract string ProduceSound();

        public void Eat(IFood food)
        {
            Type f = PreferredFoods.FirstOrDefault(f => f.Name == food.GetType().Name);

            if (f == null)
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * WeightMultiplier;

            FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name},";
        }
    }
}
