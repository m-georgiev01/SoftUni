using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.ManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToList();

            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split();

                if (commandArgs[0] == "Add")
                {
                    nums.Add(int.Parse(commandArgs[1]));
                }
                else if (commandArgs[0] == "Remove")
                {
                    nums.Remove(int.Parse(commandArgs[1]));
                }
                else if (commandArgs[0] == "RemoveAt")
                {
                    nums.RemoveAt(int.Parse(commandArgs[1]));
                }
                else if (commandArgs[0] == "Insert")
                {
                    nums.Insert(int.Parse(commandArgs[2]), int.Parse(commandArgs[1]));
                }
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
