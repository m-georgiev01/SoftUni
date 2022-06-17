using System;

namespace P02.GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int extras = int.Parse(Console.ReadLine());
            double pricePerCloth = double.Parse(Console.ReadLine());

            double decor = budget * 0.1;

            if (extras > 150)
            {
                pricePerCloth *= 0.9;
            }

            double costs = (extras * pricePerCloth) + decor;

            if (costs > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(costs - budget):F2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {(budget - costs):F2} leva left.");
            }
        }
    }
}
