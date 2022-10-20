using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                string currCommand = cmdArgs[0];
                int index = int.Parse(cmdArgs[1]);
                int value = int.Parse(cmdArgs[2]);

                if (currCommand == "Shoot")
                {
                    if (ValidateIndex(index, targets))
                    {
                        targets[index] -= value;

                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                else if (currCommand == "Add")
                {
                    if (ValidateIndex(index, targets))
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (currCommand == "Strike")
                {
                    int startIndex = index - value;
                    int endIndex = index + value;

                    if (!ValidateIndex(startIndex, targets) || !ValidateIndex(endIndex, targets))
                    {
                        Console.WriteLine("Strike missed!");
                        continue;
                    }

                    targets.RemoveRange(startIndex, endIndex - startIndex + 1);
                }
            }

            Console.WriteLine(string.Join('|', targets));
        }

        private static bool ValidateIndex(int index, List<int> numbers)
        {
            bool isValid = true;
            if (index < 0 || index >= numbers.Count)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
