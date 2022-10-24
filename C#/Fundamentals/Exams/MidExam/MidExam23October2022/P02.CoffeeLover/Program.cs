using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.CoffeeLover
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> coffees = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = cmdArgs[0];

                if (currCommand == "Include")
                {
                    coffees.Add(cmdArgs[1]);
                }
                else if (currCommand == "Remove")
                {
                    int countRemove = int.Parse(cmdArgs[2]);
                    if (countRemove <= coffees.Count)
                    {
                        if (cmdArgs[1] == "first")
                        {
                            coffees.RemoveRange(0, countRemove);
                        }
                        else if (cmdArgs[1] == "last")
                        {
                            coffees.RemoveRange(coffees.Count - countRemove, countRemove);
                        }
                    }
                    
                }
                else if (currCommand == "Prefer")
                {
                    int coffeIndexOne = int.Parse(cmdArgs[1]);
                    int coffeIndexTwo = int.Parse(cmdArgs[2]);

                    if ((coffeIndexOne >= 0 && coffeIndexOne < coffees.Count)
                        && (coffeIndexTwo >= 0 && coffeIndexTwo < coffees.Count))
                    {
                        coffees = SwapTwoElementsInList(coffees, coffeIndexOne, coffeIndexTwo);
                    }
                }
                else if (currCommand == "Reverse")
                {
                    coffees.Reverse();
                }
            }

            Console.WriteLine("Coffees:");
            Console.WriteLine(string.Join(" ", coffees));
        }

        private static List<string> SwapTwoElementsInList(List<string> list, int indexElementOne, int indexElementTwo)
        {
            List<string> changedList = list;

            string temp = changedList[indexElementOne];
            changedList[indexElementOne] = changedList[indexElementTwo];
            changedList[indexElementTwo] = temp;

            return changedList;
        }
    }
}
