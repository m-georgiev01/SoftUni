using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> gameSequence = Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .ToList();

            int movesCounter = 0;

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] testIndexes = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int indexOne = int.Parse(testIndexes[0]);
                int indexTwo = int.Parse(testIndexes[1]);

                if (!ValidateIndexes(indexOne, indexTwo, gameSequence.Count))
                {
                    movesCounter++;
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    AddElementsToTheMiddleOfCollection(gameSequence, movesCounter);
                    continue;
                }

                //player hit 2 matching elements
                if (gameSequence[indexOne] == gameSequence[indexTwo])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {gameSequence[indexOne]}!");
                    string target = gameSequence[indexOne];
                    gameSequence.RemoveAll(x => x == target);
                    movesCounter++;
                }
                else if (gameSequence[indexOne] != gameSequence[indexTwo])
                {
                    Console.WriteLine("Try again!");
                }

                if (!gameSequence.Any())
                {
                    Console.WriteLine($"You have won in {movesCounter} turns!");
                    break;
                }
            }

            if (command == "end")
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", gameSequence));
            }
        }

        private static void AddElementsToTheMiddleOfCollection(List<string> collection, int movesCounter)
        {
            string[] cheatPunishers = new string[2] { $"-{movesCounter}a", $"-{ movesCounter }a" };

            if (collection.Count % 2 == 0)
            {
                collection.InsertRange(collection.Count / 2, cheatPunishers);
            }
            else
            {
                collection.InsertRange((collection.Count / 2) + 1, cheatPunishers);
            }
        }

        private static bool ValidateIndexes(int indexOne, int indexTwo, int collectionLength)
        {
            bool isValid = true;

            if (indexOne == indexTwo)
            {
                isValid = false;
            }
            else if (indexOne < 0 || indexOne >= collectionLength)
            {
                isValid = false;
            }
            else if (indexTwo < 0 || indexTwo >= collectionLength)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
