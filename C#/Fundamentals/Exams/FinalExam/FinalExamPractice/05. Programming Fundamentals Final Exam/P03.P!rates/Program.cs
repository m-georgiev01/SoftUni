using System;
using System.Collections.Generic;

namespace P03.P_rates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cities = new Dictionary<string, int[]>();

            string firstInput;
            while ((firstInput = Console.ReadLine()) != "Sail")
            {
                var cmdArgs = firstInput.Split("||", StringSplitOptions.RemoveEmptyEntries);
                string cityName = cmdArgs[0];
                int popilation = int.Parse(cmdArgs[1]);
                int gold = int.Parse(cmdArgs[2]);

                if (!cities.ContainsKey(cityName))
                {
                    cities.Add(cityName, new []{popilation, gold});
                    continue;
                }

                cities[cityName][0] += popilation;
                cities[cityName][1] += gold;
            }

            string secondInput;
            while ((secondInput = Console.ReadLine()) != "End")
            {
                var cmdArgs = secondInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string currCmd = cmdArgs[0];
                string cityName = cmdArgs[1];

                if (currCmd == "Plunder")
                {
                    int people = int.Parse(cmdArgs[2]);
                    int gold = int.Parse(cmdArgs[3]);

                    cities[cityName][0] -= people;
                    cities[cityName][1] -= gold;

                    Console.WriteLine($"{cityName} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (cities[cityName][0] <= 0 || cities[cityName][1] <= 0)
                    {
                        cities.Remove(cityName);
                        Console.WriteLine($"{cityName} has been wiped off the map!");
                    }
                }
                else if (currCmd == "Prosper")
                {
                    int gold = int.Parse(cmdArgs[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }

                    cities[cityName][1] += gold;
                    Console.WriteLine($"{gold} gold added to the city treasury. {cityName} now has {cities[cityName][1]} gold.");
                }
            }

            if (cities.Count <= 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
                Environment.Exit(0);
            }

            Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
            foreach ((string cityName, int[] cityResources) in cities)
            {
                Console.WriteLine($"{cityName} -> Population: {cityResources[0]} citizens, Gold: {cityResources[1]} kg");
            }
        }
    }
}
