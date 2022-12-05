using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.WildZoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //animal name, wanted food
            var animals = new Dictionary<string, int>();

            //areaName, animalsNames
            var areas = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "EndDay")
            {
                var cmdArgs = command.Split(new char[] {':', '-', ' '}, StringSplitOptions.RemoveEmptyEntries);
                string currCmd = cmdArgs[0];
                string animalName = cmdArgs[1];

                if (currCmd == "Add")
                {
                    int neededFood = int.Parse(cmdArgs[2]);
                    string area = cmdArgs[3];

                    if (animals.ContainsKey(animalName))
                    {
                        animals[animalName]+= neededFood;
                        continue;
                    }

                    animals.Add(animalName, neededFood);

                    if (!areas.ContainsKey(area))
                    {
                        areas.Add(area, new List<string>());
                    }

                    areas[area].Add(animalName);
                }
                else if (currCmd == "Feed")
                {
                    if (animals.ContainsKey(animalName))
                    {
                        int foodQuantity = int.Parse(cmdArgs[2]);
                        animals[animalName] -= foodQuantity;

                        if (animals[animalName] <= 0)
                        {
                            animals.Remove(animalName);

                            string areaName = areas.FirstOrDefault(x => x.Value.Contains(animalName)).Key;
                            areas[areaName].Remove(animalName);

                            Console.WriteLine($"{animalName} was successfully fed");
                        }
                    }
                }
            }

            Console.WriteLine("Animals:");
            foreach (var (name, food) in animals)
            {
                Console.WriteLine($" {name} -> {food}g");
            }

            Console.WriteLine("Areas with hungry animals:");
            foreach ((string areaName, List<string> animalsInArea) in areas.Where(x => x.Value.Count > 0))
            {
                Console.WriteLine($" {areaName}: {animalsInArea.Count}");
            }
        }
    }
}
