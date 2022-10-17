using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.ListManipulationAdvanced
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
            bool isChanged = false;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArgs = command.Split();

                if (commandArgs[0] == "Add")
                {
                    nums.Add(int.Parse(commandArgs[1]));
                    isChanged = true;
                }
                else if (commandArgs[0] == "Remove")
                {
                    nums.Remove(int.Parse(commandArgs[1]));
                    isChanged = true;
                }
                else if (commandArgs[0] == "RemoveAt")
                {
                    nums.RemoveAt(int.Parse(commandArgs[1]));
                    isChanged = true;
                }
                else if (commandArgs[0] == "Insert")
                {
                    nums.Insert(int.Parse(commandArgs[2]), int.Parse(commandArgs[1]));
                    isChanged = true;
                }
                else if (commandArgs[0] == "Contains")
                {
                    if(nums.Contains(int.Parse(commandArgs[1])))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (commandArgs[0] == "PrintEven" || commandArgs[0] == "PrintOdd")
                {
                    PrintEvenOrOddFromList(nums, commandArgs[0]);
                    
                }
                else if (commandArgs[0] == "GetSum")
                {
                    PrintSumOfElementsInList(nums);
                }
                else if (commandArgs[0] == "Filter")
                {
                    FilterList(nums, commandArgs[1], int.Parse(commandArgs[2]));
                }
            }

            if (isChanged)
            {
                Console.WriteLine(string.Join(" ", nums));
            }
        }

        private static void PrintEvenOrOddFromList(List<int> nums, string type)
        {
            string evenOrOdd = type.Substring(5);
            List<int> result = new List<int>();

            if (evenOrOdd == "Even")
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] % 2 == 0)
                    {
                        result.Add(nums[i]);
                    }
                }
            }
            else if (evenOrOdd == "Odd")
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] % 2 != 0)
                    {
                        result.Add(nums[i]);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static void PrintSumOfElementsInList(List<int> numbers)
        {
            int sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine(sum);
        }

        private static void FilterList(List<int> numbers, string condition, int number)
        {
            List<int> result = new List<int>();

            switch (condition)
            {
                case "<":
                    result = numbers.FindAll(x => x < number);
                    break;

                case ">":
                    result = numbers.FindAll(x => x > number);
                    break;

                case ">=":
                    result = numbers.FindAll(x => x >= number);
                    break;

                case "<=":
                    result = numbers.FindAll(x => x <= number);
                    break;
            }

            Console.WriteLine(string.Join(" ", result));
        }

    }
}
