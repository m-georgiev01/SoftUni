using System;
using System.Collections.Generic;

namespace P03.GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            double gamePrice;
            double totalSpent = 0;

            while (input != "Game Time")
            {
                gamePrice = 0;

                switch (input)
                {
                    case "OutFall 4":
                    case "RoverWatch Origins Edition":
                        gamePrice = 39.99;
                        break;

                    case "CS: OG":
                        gamePrice = 15.99;
                        break;

                    case "Zplinter Zell":
                        gamePrice = 19.99;
                        break;

                    case "Honored 2":
                        gamePrice = 59.99;
                        break;

                    case "RoverWatch":
                        gamePrice = 29.99;
                        break;

                    default:
                        Console.WriteLine("Not Found");
                        break;
                }

                if (balance >= gamePrice)
                {
                    Console.WriteLine($"Bought {input}");
                    balance -= gamePrice;
                    totalSpent += gamePrice;

                    if (balance <= 0)
                    {
                        Console.WriteLine("Out of money!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Too Expensive");
                }

                input = Console.ReadLine();
            }

            if (balance > 0)
            {
                Console.WriteLine($"Total spent: ${totalSpent:F2}. Remaining: ${balance:F2}");
            }
            
        }
    }
}
