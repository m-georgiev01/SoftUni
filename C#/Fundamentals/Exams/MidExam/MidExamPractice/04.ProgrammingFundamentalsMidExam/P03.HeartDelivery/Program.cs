using System;
using System.Linq;

namespace P03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine()
                           .Split("@", StringSplitOptions.RemoveEmptyEntries)
                           .Select(int.Parse)
                           .ToArray();

            int lastLandedIndex = 0;

            string command;
            while ((command = Console.ReadLine()) != "Love!")
            {
                string[] cmdArgs = command.Split();
                int length = int.Parse(cmdArgs[1]);

                if (lastLandedIndex + length >= houses.Length)
                {
                    lastLandedIndex = 0;
                }
                else
                {
                    lastLandedIndex += length;
                }

                if (houses[lastLandedIndex] == 0)
                {
                    Console.WriteLine($"Place {lastLandedIndex} already had Valentine's day.");
                    continue;
                }

                houses[lastLandedIndex] -= 2;

                if (houses[lastLandedIndex] == 0)
                {
                    Console.WriteLine($"Place {lastLandedIndex} has Valentine's day.");
                }
            }

                Console.WriteLine($"Cupid's last position was {lastLandedIndex}.");
                if (houses.All(x => x == 0))
                {
                    Console.WriteLine("Mission was successful.");
                }
                else
                {
                    int houseCount = houses.Where(x => x > 0).Count();
                    Console.WriteLine($"Cupid has failed {houseCount} places.");
                }
        } 
    }
}
