using WildFarm.Factories.Interfaces;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string[] foodTokens)
        {
            string type = foodTokens[0];
            int quantity = int.Parse(foodTokens[1]);

            switch (type)
            {
                case "Vegetable":
                    return new Vegetable(quantity);

                case "Fruit":
                    return new Fruit(quantity);

                case "Meat":
                    return new Meat(quantity);

                case "Seeds":
                    return new Seeds(quantity);

                default:
                    throw new ArgumentException("Invalid food type!");
            }
        }
    }
}
