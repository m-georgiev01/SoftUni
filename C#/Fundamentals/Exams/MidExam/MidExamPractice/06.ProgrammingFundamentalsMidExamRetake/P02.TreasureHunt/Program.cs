using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> treasureChest = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command;
            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currCommand = cmdArgs[0];

                if (currCommand == "Loot")
                {
                    for (int i = 1; i < cmdArgs.Length; i++)
                    {
                        if (!treasureChest.Contains(cmdArgs[i]))
                        {
                            treasureChest.Insert(0, cmdArgs[i]);
                        }
                    }
                }
                else if (currCommand == "Drop")
                {
                    int index = int.Parse(cmdArgs[1]);
                    if (index >= 0 && index < treasureChest.Count)
                    {
                        treasureChest.Add(treasureChest[index]);
                        treasureChest.Remove(treasureChest[index]);
                    }
                }
                else if (currCommand == "Steal")
                {

                    if (treasureChest.Count == 0)
                    {
                        continue;
                    }

                    int count = int.Parse(cmdArgs[1]);
                    int startIndex = treasureChest.Count - count;

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    if (count > treasureChest.Count)
                    {
                        count = treasureChest.Count;
                    }

                    Console.WriteLine(string.Join(", ", treasureChest.Skip(treasureChest.Count - count).ToList()));
                    treasureChest.RemoveRange(startIndex, count);
                }
            }

            if (treasureChest.Any())
            {
                double averageGain = 0;
                treasureChest.ForEach(x => averageGain += x.Length);
                averageGain /= treasureChest.Count;
                Console.WriteLine($"Average treasure gain: {averageGain:F2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
