﻿using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double DogWeightMultiplier = 0.4;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier 
            => DogWeightMultiplier;

        public override IReadOnlyCollection<Type> PreferredFoods 
            => new HashSet<Type>() { typeof(Meat) };

        public override string ProduceSound()
            => "Woof!";

        public override string ToString()
            => $"{base.ToString()} {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
