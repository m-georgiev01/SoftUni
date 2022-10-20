using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                           .Split()
                                           .Select(int.Parse)
                                           .ToList();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (cmdArgs[0] == "Add")
                {
                    numbers.Add(int.Parse(cmdArgs[1]));
                }
                else if (cmdArgs[0] == "Insert")
                {
                    int index = int.Parse(cmdArgs[2]);
                    if (index < 0 || index >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.Insert(index, int.Parse(cmdArgs[1]));
                }
                else if (cmdArgs[0] == "Remove")
                {
                    int index = int.Parse(cmdArgs[1]);
                    if (index < 0 || index >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers.RemoveAt(index);
                }
                else if (cmdArgs[0] == "Shift")
                {                    
                    int timesToShift = int.Parse(cmdArgs[2]);

                    numbers = ShiftListNTymes(numbers, timesToShift, cmdArgs[1]);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static List<int> ShiftListNTymes(List<int> numbers, int timesToShift, string direction)
        {
            List<int> tempList = new List<int>();

            if (direction == "left")
            {
                for (int i = 0; i < timesToShift; i++)
                {
                    tempList.Clear();

                    for (int k = 1; k < numbers.Count; k++)
                    {
                        tempList.Add(numbers[k]);
                    }
                    tempList.Add(numbers[0]);

                    numbers.Clear();
                    numbers.AddRange(tempList);
                }
            }
            else if (direction == "right")
            {
                for (int i = 0; i < timesToShift; i++)
                {
                    tempList.Clear();
                    tempList.Add(numbers[numbers.Count - 1]);

                    for (int k = 0; k < numbers.Count - 1; k++)
                    {
                        tempList.Add(numbers[k]);
                    }

                    numbers.Clear();
                    numbers.AddRange(tempList);
                }
            }

            return tempList;      
        }
    }
}
