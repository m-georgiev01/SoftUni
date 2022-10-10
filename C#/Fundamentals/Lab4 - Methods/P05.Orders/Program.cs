using System;

namespace P05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            CalculatePrice(product, quantity);
        }

        static void CalculatePrice(string product, int quantity)
        {
            double price = 0;

            switch (product)
            {
                case "coffee":
                    price = 1.5;
                    break;

                case "water":
                    price = 1;
                    break;

                case "coke":
                    price = 1.4;
                    break;

                case "snacks":
                    price = 2;
                    break;
            }

            Console.WriteLine($"{price *= quantity:F2}");
        }
    }
}
