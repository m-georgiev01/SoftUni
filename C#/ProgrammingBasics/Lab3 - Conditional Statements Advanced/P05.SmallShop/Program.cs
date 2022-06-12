using System;

namespace P05.SmallShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            decimal productPrice = 0m;

            if (city.Equals("Sofia"))
            {
                switch (product)
                {
                    case "coffee":
                        productPrice = 0.5m;
                        break;
                    case "water":
                        productPrice = 0.8m;
                        break;
                    case "beer":
                        productPrice = 1.2m;
                        break;
                    case "sweets":
                        productPrice = 1.45m;
                        break;
                    case "peanuts":
                        productPrice = 1.6m;
                        break;
                }
            }
            else if (city.Equals("Plovdiv"))
            {
                switch (product)
                {
                    case "coffee":
                        productPrice = 0.4m;
                        break;
                    case "water":
                        productPrice = 0.7m;
                        break;
                    case "beer":
                        productPrice = 1.15m;
                        break;
                    case "sweets":
                        productPrice = 1.3m;
                        break;
                    case "peanuts":
                        productPrice = 1.5m;
                        break;
                }
            }
            else if (city.Equals("Varna"))
            {
                switch (product)
                {
                    case "coffee":
                        productPrice = 0.45m;
                        break;
                    case "water":
                        productPrice = 0.7m;
                        break;
                    case "beer":
                        productPrice = 1.1m;
                        break;
                    case "sweets":
                        productPrice = 1.35m;
                        break;
                    case "peanuts":
                        productPrice = 1.55m;
                        break;
                }
            }

            Console.WriteLine(productPrice * (decimal)quantity);
        }
    }
}
