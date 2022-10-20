using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command;
            while ((command = Console.ReadLine()) != "Go Shopping!")
            {
                string[] cmdArgs = command.Split();
                string currCommand = cmdArgs[0];
                string item = cmdArgs[1];

                if (currCommand == "Urgent")
                {
                    if (!groceries.Contains(item))
                    {
                        groceries.Insert(0, item);
                    }
                }
                else if (currCommand == "Unnecessary")
                {
                    if (groceries.Contains(item))
                    {
                        groceries.Remove(item);
                    }
                }
                else if (currCommand == "Correct")
                {
                    if (groceries.Contains(item))
                    {
                        string newItem = cmdArgs[2];
                        int indexOldItem = groceries.IndexOf(item);
                        groceries[indexOldItem] = newItem;
                    }
                }
                else if (currCommand == "Rearrange")
                {
                    if (groceries.Contains(item))
                    {
                        groceries.Add(item);
                        int index = groceries.IndexOf(item);
                        groceries.RemoveAt(index);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}
