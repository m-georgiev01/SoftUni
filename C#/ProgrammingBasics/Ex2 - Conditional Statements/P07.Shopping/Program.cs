using System;

namespace P07.Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int graphicCards = int.Parse(Console.ReadLine());
            int processors = int.Parse(Console.ReadLine());
            int rams = int.Parse(Console.ReadLine());

            double graphicCardsPrice = graphicCards * 250;
            double processorsPrice = (graphicCardsPrice * 0.35) * processors;
            double ramsPrice = (graphicCardsPrice * 0.1) * rams;

            double totalPrice = graphicCardsPrice + processorsPrice + ramsPrice;

            if (graphicCards > processors)
            {
                totalPrice *= 0.85;
            }

            if (budget >= totalPrice)
            {
                Console.WriteLine($"You have {(budget - totalPrice):F2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(totalPrice - budget):F2} leva more!");
            }
        }
    }
}
