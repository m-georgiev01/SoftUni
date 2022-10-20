using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> passengersPerWagon = Console.ReadLine()
                                           .Split()
                                           .Select(int.Parse)
                                           .ToList();

            int maxCapacityPerWagon = int.Parse(Console.ReadLine());

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                if (command.Contains("Add"))
                {
                    string[] cmdArgs = command.Split();
                    passengersPerWagon.Add(int.Parse(cmdArgs[1]));
                }
                else
                {
                    for (int i = 0; i < passengersPerWagon.Count; i++)
                    {
                        if (passengersPerWagon[i] + int.Parse(command) <= maxCapacityPerWagon)
                        {
                            passengersPerWagon[i] += int.Parse(command);
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", passengersPerWagon));
        }
    }
}
