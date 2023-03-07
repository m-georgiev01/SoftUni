using FoodShortage.Models;
using FoodShortage.Models.Interfaces;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyers = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IBuyer buyer;
                if (tokens.Length == 4)
                {
                    buyer = new Citizen(tokens[2], tokens[0], int.Parse(tokens[1]), tokens[3]);
                }
                else
                {
                    buyer = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                }

                buyers.Add(tokens[0], buyer);
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                buyers.FirstOrDefault(buyer => buyer.Value.Name == input).Value?.BuyFood();
            }

            Console.WriteLine(buyers.Sum(b => b.Value.Food));
        }
    }
}
