using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.ChangeList
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

            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split();

                if (cmdArgs[0] == "Delete")
                {
                    numbers.RemoveAll(x => x == int.Parse(cmdArgs[1]));
                }
                else if (cmdArgs[0] == "Insert")
                {
                    numbers.Insert(int.Parse(cmdArgs[2]), int.Parse(cmdArgs[1]));
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
