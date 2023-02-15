using System;
using System.Collections.Generic;
using System.Linq;

namespace BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffeeQuantity = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> milkQuantity = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            //name -> sum, countMade
            Dictionary<string, int[]> coffeeDrinks = new Dictionary<string, int[]>()
            {
                {"Cortado", new []{50, 0}},
                {"Espresso", new []{75, 0}},
                {"Capuccino", new []{100, 0}},
                {"Americano", new []{150, 0}},
                {"Latte", new []{200, 0}}
            };

            while (coffeeQuantity.Any() && milkQuantity.Any())
            {
                int currSum = coffeeQuantity.Dequeue() + milkQuantity.Peek();
                var coffeeWithCurrSum = coffeeDrinks.FirstOrDefault(c => c.Value[0] == currSum);

                if (coffeeWithCurrSum.Key != null)
                {
                    milkQuantity.Pop();
                    coffeeDrinks[coffeeWithCurrSum.Key][1]++;
                    continue;
                }

                milkQuantity.Push(milkQuantity.Pop() - 5);
            }

            if (!coffeeQuantity.Any() && !milkQuantity.Any())
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            string coffee = coffeeQuantity.Any() ? string.Join(", ", coffeeQuantity) : "none";
            Console.WriteLine($"Coffee left: {coffee}");

            string milk = milkQuantity.Any() ? string.Join(", ", milkQuantity) : "none";
            Console.WriteLine($"Milk left: {milk}");

            var filtered = coffeeDrinks
                .Where(c => c.Value[1] > 0)
                .OrderBy(c => c.Value[1])
                .ThenByDescending(c => c.Key);

            foreach (var (name, coffeeValue) in filtered)
            {
                Console.WriteLine($"{name}: {coffeeValue[1]}");
            }
        }
    }
}
