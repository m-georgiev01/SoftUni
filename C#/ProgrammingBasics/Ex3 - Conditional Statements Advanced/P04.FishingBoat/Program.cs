using System;

namespace P04.FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());

            double rentalPrice = 0;

            switch (season)
            {
                case "Spring":
                    rentalPrice = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    rentalPrice = 4200;
                    break;
                case "Winter":
                    rentalPrice = 2600;
                    break;
            }

            if (fishermen <= 6)
            {
                rentalPrice *= 0.9;
            }
            else if (fishermen >= 7 && fishermen <= 11)
            {
                rentalPrice *= 0.85;
            }
            else if (fishermen > 11)
            {
                rentalPrice *= 0.75;
            }

            if (fishermen % 2 == 0 && season != "Autumn")
            {
                rentalPrice *= 0.95;
            }

            if(budget >= rentalPrice)
            {
                Console.WriteLine($"Yes! You have {(budget - rentalPrice):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(rentalPrice - budget):F2} leva.");
            }
        }
    }
}
